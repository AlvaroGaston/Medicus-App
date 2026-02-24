using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;

namespace Medicus.UX
{
    public partial class frmTurnos : Form
    {
        private TurnoBLL bllTurno = new TurnoBLL();
        private MedicoBLL bllMedico = new MedicoBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        private int idTurnoSeleccionado = 0;
        private int idPacienteSeleccionado = 0;
        private int idMedicoSeleccionado = 0;

        public frmTurnos()
        {
            InitializeComponent();
        }

        private void frmTurnos_Load(object sender, EventArgs e)
        {
            // 1. Bloqueamos fechas pasadas en el calendario
            dtpFecha.MinDate = DateTime.Today;

            // 2. Cargamos configuraciones iniciales
            cmbEstado.Items.AddRange(new string[] { "Pendiente", "Atendido", "Cancelado" });
            CargarGrilla();
            LimpiarCampos();

            // 3. Aplicamos permisos según el rol logueado
            bllSeguridad.AplicarPermisosPantalla(this, "frmTurnos", Sesion.PermisosActuales);
        }

        private void CargarGrilla()
        {
            dgvTurnos.DataSource = null;
            dgvTurnos.DataSource = bllTurno.ListarTurnos();

            // Ocultamos columnas técnicas para que el usuario no las vea
            if (dgvTurnos.Columns["IdTurno"] != null) dgvTurnos.Columns["IdTurno"].Visible = false;
            if (dgvTurnos.Columns["IdPaciente"] != null) dgvTurnos.Columns["IdPaciente"].Visible = false;
            if (dgvTurnos.Columns["IdMedico"] != null) dgvTurnos.Columns["IdMedico"].Visible = false;
        }

        // ========================================================
        // MOTOR DE HORARIOS DINÁMICOS
        // ========================================================
        private void CargarHorariosDisponibles()
        {
            if (idMedicoSeleccionado == 0) return;

            cmbHorarios.Items.Clear();

            // Buscamos al médico para obtener su configuración de horario y duración
            var medico = bllMedico.ListarMedicos().FirstOrDefault(m => m.IdMedico == idMedicoSeleccionado);
            if (medico == null) return;

            // CORRECCIÓN DE TIPADO: Usamos casting explícito y valores por defecto (??)
            TimeSpan horaActual = medico.HoraInicio ?? new TimeSpan(8, 0, 0);
            TimeSpan horaFin = medico.HoraFin ?? new TimeSpan(17, 0, 0);
            int intervalo = medico.DuracionTurno ?? 30;

            // Buscamos turnos ya ocupados que no estén cancelados
            var turnosOcupados = bllTurno.ListarTurnos()
                .Where(t => t.IdMedico == idMedicoSeleccionado &&
                            t.FechaTurno.Date == dtpFecha.Value.Date &&
                            t.Estado != "Cancelado")
                .Select(t => t.HoraTurno)
                .ToList();

            TimeSpan ahora = DateTime.Now.TimeOfDay;

            while (horaActual < horaFin)
            {
                // Validación: Si la fecha es hoy, no mostramos horarios que ya pasaron
                bool esHoyYYaPaso = dtpFecha.Value.Date == DateTime.Today && horaActual <= ahora;

                if (!turnosOcupados.Contains(horaActual) && !esHoyYYaPaso)
                {
                    cmbHorarios.Items.Add(horaActual.ToString(@"hh\:mm"));
                }
                horaActual = horaActual.Add(TimeSpan.FromMinutes(intervalo));
            }

            if (cmbHorarios.Items.Count > 0) cmbHorarios.SelectedIndex = 0;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e) => CargarHorariosDisponibles();

        // ========================================================
        // BUSCADORES INTELIGENTES
        // ========================================================
        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {
            using (frmBuscarPaciente frmP = new frmBuscarPaciente())
            {
                if (frmP.ShowDialog() == DialogResult.OK)
                {
                    idPacienteSeleccionado = frmP.IdSeleccionado;
                    txtPaciente.Text = frmP.NombreSeleccionado;
                }
            }
        }

        private void btnBuscarMedico_Click(object sender, EventArgs e)
        {
            using (frmBuscarMedico frmM = new frmBuscarMedico())
            {
                if (frmM.ShowDialog() == DialogResult.OK)
                {
                    idMedicoSeleccionado = frmM.IdSeleccionado;
                    txtMedico.Text = frmM.NombreSeleccionado;
                    CargarHorariosDisponibles(); // Recalculamos horarios inmediatamente
                }
            }
        }

        // ========================================================
        // ACCIONES (GUARDAR, EDITAR, SELECCIONAR)
        // ========================================================
        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0 || idMedicoSeleccionado == 0 || cmbHorarios.SelectedItem == null)
            {
                MessageBox.Show("Debe completar Paciente, Médico y Horario disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Turno obj = new Turno
            {
                IdPaciente = idPacienteSeleccionado,
                IdMedico = idMedicoSeleccionado,
                FechaTurno = dtpFecha.Value.Date,
                HoraTurno = TimeSpan.Parse(cmbHorarios.SelectedItem.ToString()),
                Motivo = txtMotivo.Text.Trim()
            };

            if (bllTurno.AgregarTurno(obj) == "OK")
            {
                BitacoraBLL.RegistrarMovimiento("Agendó un nuevo turno", "Turnos");
                MessageBox.Show("Turno agendado con éxito.", "Éxito");
                CargarGrilla();
                LimpiarCampos();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idTurnoSeleccionado == 0) return;

            Turno obj = new Turno
            {
                IdTurno = idTurnoSeleccionado,
                IdPaciente = idPacienteSeleccionado,
                IdMedico = idMedicoSeleccionado,
                FechaTurno = dtpFecha.Value.Date,
                HoraTurno = TimeSpan.Parse(cmbHorarios.Text),
                Motivo = txtMotivo.Text.Trim()
            };

            if (bllTurno.ModificarTurno(obj) == "OK")
            {
                bllTurno.CambiarEstado(idTurnoSeleccionado, cmbEstado.Text);
                BitacoraBLL.RegistrarMovimiento($"Modificó el turno ID: {idTurnoSeleccionado}", "Turnos");
                MessageBox.Show("Turno actualizado correctamente.");
                CargarGrilla();
                LimpiarCampos();
            }
        }

        private void dgvTurnos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idTurnoSeleccionado = (int)dgvTurnos.Rows[e.RowIndex].Cells["IdTurno"].Value;
                idPacienteSeleccionado = (int)dgvTurnos.Rows[e.RowIndex].Cells["IdPaciente"].Value;
                idMedicoSeleccionado = (int)dgvTurnos.Rows[e.RowIndex].Cells["IdMedico"].Value;

                txtPaciente.Text = dgvTurnos.Rows[e.RowIndex].Cells["PacienteNombre"].Value.ToString();
                txtMedico.Text = dgvTurnos.Rows[e.RowIndex].Cells["MedicoNombre"].Value.ToString();
                dtpFecha.Value = (DateTime)dgvTurnos.Rows[e.RowIndex].Cells["FechaTurno"].Value;

                // Cargamos el horario actual del turno en el combo aunque ya esté "ocupado"
                string h = ((TimeSpan)dgvTurnos.Rows[e.RowIndex].Cells["HoraTurno"].Value).ToString(@"hh\:mm");
                CargarHorariosDisponibles();
                if (!cmbHorarios.Items.Contains(h)) cmbHorarios.Items.Add(h);
                cmbHorarios.Text = h;

                txtMotivo.Text = dgvTurnos.Rows[e.RowIndex].Cells["Motivo"].Value.ToString();
                cmbEstado.Text = dgvTurnos.Rows[e.RowIndex].Cells["Estado"].Value.ToString();
                cmbEstado.Enabled = true;
            }
        }

        private void LimpiarCampos()
        {
            idTurnoSeleccionado = 0;
            idPacienteSeleccionado = 0;
            idMedicoSeleccionado = 0;
            txtPaciente.Clear();
            txtMedico.Clear();
            txtMotivo.Clear();
            cmbHorarios.Items.Clear();
            dtpFecha.Value = DateTime.Today;
            cmbEstado.Text = "Pendiente";
            cmbEstado.Enabled = false;
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();
    }
}