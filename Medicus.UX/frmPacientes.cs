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
    public partial class frmPacientes : Form
    {
        private PacienteBLL bllPaciente = new PacienteBLL();
        private SeguridadBLL bllSeguridad = new SeguridadBLL();
        private int idPacienteSeleccionado = 0;

        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            // ¡ACÁ OCURRE LA MAGIA! Aplicamos los permisos para habilitar/deshabilitar botones
            bllSeguridad.AplicarPermisosPantalla(this, "frmPacientes", Sesion.PermisosActuales);
        }

        private void CargarGrilla()
        {
            dgvPacientes.DataSource = null;
            dgvPacientes.DataSource = bllPaciente.ListarPacientes();
        }

        private void LimpiarCampos()
        {
            idPacienteSeleccionado = 0;
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            txtTelefono.Clear();
            txtObraSocial.Clear();
            txtDni.ReadOnly = false; // Permitimos volver a escribir el DNI para un paciente nuevo
        }

        private void btnGuardarNuevo_Click(object sender, EventArgs e)
        {
            Paciente obj = new Paciente
            {
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value,
                Telefono = txtTelefono.Text.Trim(),
                ObraSocial = txtObraSocial.Text.Trim()
            };

            string msj = bllPaciente.AgregarPaciente(obj);
            if (msj == "OK")
            {
                MessageBox.Show("Paciente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un paciente de la grilla para editar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Paciente obj = new Paciente
            {
                IdPaciente = idPacienteSeleccionado,
                Dni = txtDni.Text.Trim(),
                Nombre = txtNombre.Text.Trim(),
                Apellido = txtApellido.Text.Trim(),
                FechaNacimiento = dtpFechaNacimiento.Value,
                Telefono = txtTelefono.Text.Trim(),
                ObraSocial = txtObraSocial.Text.Trim()
            };

            string msj = bllPaciente.ModificarPaciente(obj);
            if (msj == "OK")
            {
                MessageBox.Show("Paciente actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                LimpiarCampos();
            }
            else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (idPacienteSeleccionado == 0)
            {
                MessageBox.Show("Seleccione un paciente para eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de eliminar este paciente?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string msj = bllPaciente.EliminarPaciente(idPacienteSeleccionado);
                if (msj == "OK")
                {
                    MessageBox.Show("Paciente eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                    LimpiarCampos();
                }
                else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void dgvPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idPacienteSeleccionado = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["IdPaciente"].Value);
                txtDni.Text = dgvPacientes.Rows[e.RowIndex].Cells["Dni"].Value.ToString();
                txtNombre.Text = dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvPacientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvPacientes.Rows[e.RowIndex].Cells["FechaNacimiento"].Value);
                txtTelefono.Text = dgvPacientes.Rows[e.RowIndex].Cells["Telefono"].Value.ToString();
                txtObraSocial.Text = dgvPacientes.Rows[e.RowIndex].Cells["ObraSocial"].Value.ToString();

                txtDni.ReadOnly = true; // El DNI no se debería cambiar una vez creado para no romper el historial
            }
        }
    }
}