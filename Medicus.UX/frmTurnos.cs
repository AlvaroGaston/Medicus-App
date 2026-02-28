using Medicus.BLL;
using Medicus.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Medicus.UX
{
    public partial class frmTurnos : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private MedicoBLL bllMedico = new MedicoBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        private int idPacienteSeleccionado = 0;
        private int idMedicoSeleccionado = 0;
        private DateTime fechaSeleccionada = DateTime.MinValue;
        private string horaSeleccionada = "";

        public frmTurnos()
        {
            InitializeComponent();
        }

        private void btnTurnos_Click(object sender, EventArgs e)
        {
            frmTableroTurnos frm = new frmTableroTurnos();
            frm.ShowDialog();
        }

        private void frmTurnos_Load(object sender, EventArgs e)
        {
            // 1. Aplica seguridad
            bllSeguridad.AplicarSeguridadGranular(this, "frmTurnos");

            // 2. Carga combos
            CargarEspecialidades();

            // 3. Limpia y bloquea pasos (Acá es donde se bloquean los GroupBoxes)
            ReiniciarFormulario();

            // 4. LA ORDEN FINAL: Forzamos el botón a estar vivo sí o sí
            if (btnTurnos != null)
            {
                btnTurnos.Enabled = true;
            }
        }

        // ========================================================
        // PASO 1: PACIENTE Y ESPECIALIDAD
        // ========================================================
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            using (frmBuscarPaciente frmP = new frmBuscarPaciente())
            {
                if (frmP.ShowDialog() == DialogResult.OK)
                {
                    idPacienteSeleccionado = frmP.IdSeleccionado;
                    txtPaciente.Text = frmP.NombreSeleccionado;

                    // Si ya eligió especialidad, disparamos la búsqueda de médicos
                    if (cmbEspecialidad.SelectedIndex != -1) FiltrarMedicos();
                }
            }
        }

        private void CargarEspecialidades()
        {
            var especialidades = bllMedico.ListarMedicos()
                .Where(m => !string.IsNullOrWhiteSpace(m.Especialidad))
                .Select(m => m.Especialidad.Trim().ToUpper())
                .Distinct()
                .ToList();

            cmbEspecialidad.DataSource = especialidades;
            cmbEspecialidad.SelectedIndex = -1;
        }

        private void cmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0 && cmbEspecialidad.SelectedIndex != -1)
            {
                MessageBox.Show("Por favor, seleccione primero el paciente.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbEspecialidad.SelectedIndex = -1;
                return;
            }

            FiltrarMedicos();
        }

        // ========================================================
        // PASO 2: MÉDICOS DISPONIBLES
        // ========================================================
        private void FiltrarMedicos()
        {
            if (cmbEspecialidad.SelectedItem == null || idPacienteSeleccionado == 0) return;

            LimpiarPasos(desdePaso: 3);

            string especialidad = cmbEspecialidad.SelectedItem.ToString();
            var medicos = bllMedico.ListarMedicos().Where(m => m.Especialidad.ToUpper() == especialidad).ToList();

            DataTable dt = new DataTable();
            dt.Columns.Add("IdMedico", typeof(int));
            dt.Columns.Add("Doctor", typeof(string));

            foreach (var med in medicos)
            {
                dt.Rows.Add(med.IdMedico, $"Dr. {med.Nombre} {med.Apellido}");
            }

            dgvMedicos.DataSource = dt;
            if (dgvMedicos.Columns["IdMedico"] != null) dgvMedicos.Columns["IdMedico"].Visible = false;
        }

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            idMedicoSeleccionado = Convert.ToInt32(dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value);
            lblMedicoSeleccionado.Text = "Médico: " + dgvMedicos.Rows[e.RowIndex].Cells["Doctor"].Value.ToString();

            GenerarDiasDisponibles();
        }

        // ========================================================
        // PASO 3: DÍAS DISPONIBLES (Próximos 30 días)
        // ========================================================
        private void GenerarDiasDisponibles()
        {
            if (idMedicoSeleccionado == 0) return;

            LimpiarPasos(desdePaso: 4);

            var medico = bllMedico.ListarMedicos().FirstOrDefault(m => m.IdMedico == idMedicoSeleccionado);
            if (medico == null || string.IsNullOrEmpty(medico.DiasAtencion)) return;

            DataTable dt = new DataTable();
            dt.Columns.Add("FechaOculta", typeof(DateTime));
            dt.Columns.Add("Fecha", typeof(string));
            dt.Columns.Add("Día", typeof(string));

            DateTime fechaBase = DateTime.Today;

            // Evaluamos los próximos 30 días para ver cuáles coinciden con su agenda
            for (int i = 0; i < 30; i++)
            {
                DateTime fechaEvaluar = fechaBase.AddDays(i);
                string nombreDia = ObtenerNombreDia(fechaEvaluar);

                if (medico.DiasAtencion.Contains(nombreDia))
                {
                    dt.Rows.Add(fechaEvaluar, fechaEvaluar.ToString("dd/MM/yyyy"), nombreDia);
                }
            }

            dgvDias.DataSource = dt;
            if (dgvDias.Columns["FechaOculta"] != null) dgvDias.Columns["FechaOculta"].Visible = false;
        }

        private string ObtenerNombreDia(DateTime fecha)
        {
            switch (fecha.DayOfWeek)
            {
                case DayOfWeek.Monday: return "Lunes";
                case DayOfWeek.Tuesday: return "Martes";
                case DayOfWeek.Wednesday: return "Miércoles";
                case DayOfWeek.Thursday: return "Jueves";
                case DayOfWeek.Friday: return "Viernes";
                case DayOfWeek.Saturday: return "Sábado";
                case DayOfWeek.Sunday: return "Domingo";
                default: return "";
            }
        }

        private void dgvDias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            fechaSeleccionada = Convert.ToDateTime(dgvDias.Rows[e.RowIndex].Cells["FechaOculta"].Value);
            lblDiaSeleccionado.Text = $"Día: {fechaSeleccionada.ToString("dd/MM/yyyy")}";

            CargarGrillaHorarios();
        }

        // ========================================================
        // PASO 4: HORARIOS DISPONIBLES
        // ========================================================
        private void CargarGrillaHorarios()
        {
            if (idMedicoSeleccionado == 0 || fechaSeleccionada == DateTime.MinValue) return;

            LimpiarPasos(desdePaso: 5);

            DataTable dt = new DataTable();
            dt.Columns.Add("Horario", typeof(string));
            dt.Columns.Add("Estado", typeof(string));

            var medico = bllMedico.ListarMedicos().FirstOrDefault(m => m.IdMedico == idMedicoSeleccionado);
            if (medico == null) return;

            TimeSpan horaActual = medico.HoraInicio ?? new TimeSpan(8, 0, 0);
            TimeSpan horaFin = medico.HoraFin ?? new TimeSpan(17, 0, 0);
            int intervalo = medico.DuracionTurno ?? 30;

            var turnosOcupados = bllTurno.ListarTurnos()
                .Where(t => t.IdMedico == idMedicoSeleccionado && t.FechaTurno.Date == fechaSeleccionada.Date && t.Estado != "Cancelado")
                .Select(t => t.HoraTurno).ToList();

            while (horaActual < horaFin)
            {
                bool ocupado = turnosOcupados.Contains(horaActual);
                // Si la fecha seleccionada es hoy, y la hora ya pasó, también la bloqueamos
                bool pasoHoy = fechaSeleccionada.Date == DateTime.Today && horaActual <= DateTime.Now.TimeOfDay;

                string estadoTexto = (ocupado || pasoHoy) ? "🚫 OCUPADO" : "✅ LIBRE";
                dt.Rows.Add(horaActual.ToString(@"hh\:mm"), estadoTexto);
                horaActual = horaActual.Add(TimeSpan.FromMinutes(intervalo));
            }

            dgvHorarios.DataSource = dt;

            foreach (DataGridViewRow row in dgvHorarios.Rows)
            {
                if (row.Cells["Estado"].Value.ToString().Contains("OCUPADO"))
                {
                    row.DefaultCellStyle.BackColor = Color.MistyRose;
                    row.DefaultCellStyle.ForeColor = Color.DimGray;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Honeydew;
                }
            }
        }

        private void dgvHorarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvHorarios.Rows[e.RowIndex].Cells["Estado"].Value.ToString().Contains("OCUPADO"))
            {
                MessageBox.Show("Este horario no está disponible.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            horaSeleccionada = dgvHorarios.Rows[e.RowIndex].Cells["Horario"].Value.ToString();
            lblHoraSeleccionada.Text = $"Hora: {horaSeleccionada}";

            // Habilitamos los botones finales
            btnConfirmarTurno.Enabled = true;
            btnImprimirRecibo.Enabled = true;
        }

        // ========================================================
        // PASO 5: CONFIRMACIÓN Y RECIBO
        // ========================================================
        private void btnConfirmarTurno_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0 || idMedicoSeleccionado == 0 || fechaSeleccionada == DateTime.MinValue || string.IsNullOrEmpty(horaSeleccionada))
            {
                MessageBox.Show("Faltan completar pasos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Turno obj = new Turno
            {
                IdPaciente = idPacienteSeleccionado,
                IdMedico = idMedicoSeleccionado,
                FechaTurno = fechaSeleccionada.Date,
                HoraTurno = TimeSpan.Parse(horaSeleccionada),
                Motivo = "Consulta " + cmbEspecialidad.Text
            };

            if (bllTurno.AgregarTurno(obj) == "OK")
            {
                BitacoraBLL.RegistrarMovimiento("Agendó un nuevo turno", "Turnos");
                MessageBox.Show("Turno agendado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ReiniciarFormulario();
            }
        }

        private void btnImprimirRecibo_Click(object sender, EventArgs e)
        {
            frmReportes frm = new frmReportes();
            frm.ShowDialog();
        }


        // ========================================================
        // CONTROLADORES DE INTERFAZ
        // ========================================================
        private void LimpiarPasos(int desdePaso)
        {
            if (desdePaso <= 3)
            {
                dgvDias.DataSource = null;
                fechaSeleccionada = DateTime.MinValue;
                lblDiaSeleccionado.Text = "Día: -";
            }
            if (desdePaso <= 4)
            {
                dgvHorarios.DataSource = null;
                horaSeleccionada = "";
                lblHoraSeleccionada.Text = "Hora: -";
            }
            if (desdePaso <= 5)
            {
                btnConfirmarTurno.Enabled = false;
                btnImprimirRecibo.Enabled = false;
            }
        }

        private void ReiniciarFormulario()
        {
            txtPaciente.Clear();
            idPacienteSeleccionado = 0;
            cmbEspecialidad.SelectedIndex = -1;
            dgvMedicos.DataSource = null;
            idMedicoSeleccionado = 0;
            lblMedicoSeleccionado.Text = "Médico: -";

            LimpiarPasos(desdePaso: 3);
        }
    }

}