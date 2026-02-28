using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;

namespace Medicus.UX
{
    public partial class frmMedicos : Form
    {
        private MedicoBLL bllMedico = new MedicoBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();
        private int idMedicoSeleccionado = 0;

        public frmMedicos()
        {
            InitializeComponent();
        }

        private void frmMedicos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            // ¡MAGIA APLICADA! Ahora lee los permisos específicos de btnGuardarMedico, btnEditarMedico, etc.
            bllSeguridad.AplicarSeguridadGranular(this, "frmMedicos");
        }

        private void CargarGrilla()
        {
            dgvMedicos.DataSource = null;
            dgvMedicos.DataSource = bllMedico.ListarMedicos();
            // Ocultamos la columna ID para que quede más limpio
            if (dgvMedicos.Columns["IdMedico"] != null) dgvMedicos.Columns["IdMedico"].Visible = false;
        }

        // --- LÓGICA DE DÍAS DE LA SEMANA ---
        private string ObtenerDiasSeleccionados()
        {
            List<string> dias = new List<string>();
            if (chkLunes.Checked) dias.Add("Lunes");
            if (chkMartes.Checked) dias.Add("Martes");
            if (chkMiercoles.Checked) dias.Add("Miércoles");
            if (chkJueves.Checked) dias.Add("Jueves");
            if (chkViernes.Checked) dias.Add("Viernes");
            if (chkSabado.Checked) dias.Add("Sábado");
            if (chkDomingo.Checked) dias.Add("Domingo");

            return string.Join(", ", dias);
        }

        private void CargarDiasSeleccionados(string diasGuardados)
        {
            if (string.IsNullOrEmpty(diasGuardados)) diasGuardados = "";
            chkLunes.Checked = diasGuardados.Contains("Lunes");
            chkMartes.Checked = diasGuardados.Contains("Martes");
            chkMiercoles.Checked = diasGuardados.Contains("Miércoles");
            chkJueves.Checked = diasGuardados.Contains("Jueves");
            chkViernes.Checked = diasGuardados.Contains("Viernes");
            chkSabado.Checked = diasGuardados.Contains("Sábado");
            chkDomingo.Checked = diasGuardados.Contains("Domingo");
        }
        // -----------------------------------

        private void LimpiarCampos()
        {
            idMedicoSeleccionado = 0;
            txtNombre.Clear();
            txtApellido.Clear();
            txtEspecialidad.Clear();
            txtMatricula.Clear();
            txtTelefono.Clear();
            txtMatricula.ReadOnly = false;

            // Limpiar agenda
            CargarDiasSeleccionados(""); // Destilda todo
            dtpHoraInicio.Value = DateTime.Today.AddHours(8); // Por defecto 08:00
            dtpHoraFin.Value = DateTime.Today.AddHours(16); // Por defecto 16:00
            nudDuracion.Value = 30; // Por defecto 30 minutos
        }

        // ==========================================
        // BOTONES CON NOMBRES ACTUALIZADOS
        // ==========================================

        private void btnGuardarMedico_Click(object sender, EventArgs e)
        {
            Medico obj = new Medico
            {
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                Matricula = txtMatricula.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                DiasAtencion = ObtenerDiasSeleccionados(),
                HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                HoraFin = dtpHoraFin.Value.TimeOfDay,
                DuracionTurno = Convert.ToInt32(nudDuracion.Value)
            };

            string msj = bllMedico.AgregarMedico(obj);
            if (msj == "OK")
            {
                MessageBox.Show("Médico registrado correctamente.", "Éxito");
                CargarGrilla();
                LimpiarCampos();
            }
            else MessageBox.Show(msj, "Error");
        }

        private void btnEditarMedico_Click(object sender, EventArgs e)
        {
            if (idMedicoSeleccionado == 0) return;

            Medico obj = new Medico
            {
                IdMedico = idMedicoSeleccionado,
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                Especialidad = txtEspecialidad.Text.Trim(),
                Matricula = txtMatricula.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                DiasAtencion = ObtenerDiasSeleccionados(),
                HoraInicio = dtpHoraInicio.Value.TimeOfDay,
                HoraFin = dtpHoraFin.Value.TimeOfDay,
                DuracionTurno = Convert.ToInt32(nudDuracion.Value)
            };

            string msj = bllMedico.ModificarMedico(obj);
            if (msj == "OK")
            {
                MessageBox.Show("Médico actualizado correctamente.", "Éxito");
                CargarGrilla();
                LimpiarCampos();
            }
            else MessageBox.Show(msj, "Error");
        }

        private void btnEliminarMedico_Click(object sender, EventArgs e)
        {
            if (idMedicoSeleccionado == 0) return;

            bool estadoActual = Convert.ToBoolean(dgvMedicos.CurrentRow.Cells["Estado"].Value);
            string msj = bllMedico.CambiarEstado(idMedicoSeleccionado, !estadoActual);

            if (msj == "OK") CargarGrilla();
            else MessageBox.Show(msj, "Error");
        }

        private void btnLimpiar_Click(object sender, EventArgs e) => LimpiarCampos();

        private void dgvMedicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idMedicoSeleccionado = Convert.ToInt32(dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value);
                txtNombre.Text = dgvMedicos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvMedicos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                txtEspecialidad.Text = dgvMedicos.Rows[e.RowIndex].Cells["Especialidad"].Value.ToString();
                txtMatricula.Text = dgvMedicos.Rows[e.RowIndex].Cells["Matricula"].Value.ToString();
                txtTelefono.Text = dgvMedicos.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtMatricula.ReadOnly = true;

                // Cargar Agenda
                string dias = dgvMedicos.Rows[e.RowIndex].Cells["DiasAtencion"].Value?.ToString();
                CargarDiasSeleccionados(dias);

                if (dgvMedicos.Rows[e.RowIndex].Cells["HoraInicio"].Value != null)
                {
                    TimeSpan inicio = (TimeSpan)dgvMedicos.Rows[e.RowIndex].Cells["HoraInicio"].Value;
                    dtpHoraInicio.Value = DateTime.Today.Add(inicio);
                }

                if (dgvMedicos.Rows[e.RowIndex].Cells["HoraFin"].Value != null)
                {
                    TimeSpan fin = (TimeSpan)dgvMedicos.Rows[e.RowIndex].Cells["HoraFin"].Value;
                    dtpHoraFin.Value = DateTime.Today.Add(fin);
                }

                if (dgvMedicos.Rows[e.RowIndex].Cells["DuracionTurno"].Value != null)
                {
                    nudDuracion.Value = Convert.ToInt32(dgvMedicos.Rows[e.RowIndex].Cells["DuracionTurno"].Value);
                }
            }
        }
    }
}