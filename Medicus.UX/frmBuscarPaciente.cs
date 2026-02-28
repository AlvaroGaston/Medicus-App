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
    public partial class frmBuscarPaciente : Form
    {
        private PacienteBLL bllPaciente = new PacienteBLL();
        private List<Paciente> listaOriginal; // Guardamos la lista completa en memoria para no saturar SQL

        // Propiedades públicas para que el formulario que lo llame pueda leer a quién seleccionó
        public int IdSeleccionado { get; private set; } = 0;
        public string NombreSeleccionado { get; private set; } = "";

        public frmBuscarPaciente()
        {
            InitializeComponent();
        }

        private void frmBuscarPaciente_Load(object sender, EventArgs e)
        {
            // 1. Aplicamos la Seguridad Granular para este formulario
            // (Esto se encarga de habilitar o deshabilitar el btnGuardarPaciente según el rol)
            SeguridadBLL bllSeguridad = new SeguridadBLL();
            bllSeguridad.AplicarSeguridadGranular(this, "frmBuscarPaciente");

            // 2. Cargamos todos los pacientes al abrir
            listaOriginal = bllPaciente.ListarPacientes();
            dgvPacientes.DataSource = listaOriginal;

            // 3. Ocultamos las columnas técnicas y configuramos la vista
            if (dgvPacientes.Columns["IdPaciente"] != null)
            {
                dgvPacientes.Columns["IdPaciente"].Visible = false;
            }

            // Opcional: quitamos la selección por defecto de la primera fila para que se vea más limpio
            dgvPacientes.ClearSelection();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            // Filtro en tiempo real por DNI, Nombre o Apellido
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                dgvPacientes.DataSource = listaOriginal;
            }
            else
            {
                dgvPacientes.DataSource = listaOriginal.Where(p =>
                    p.Dni.ToLower().Contains(filtro) ||
                    p.Nombre.ToLower().Contains(filtro) ||
                    p.Apellido.ToLower().Contains(filtro)).ToList();
            }
        }

        private void dgvPacientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Capturamos los datos y cerramos avisando que todo salió OK
                IdSeleccionado = Convert.ToInt32(dgvPacientes.Rows[e.RowIndex].Cells["IdPaciente"].Value);
                string nombre = dgvPacientes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string apellido = dgvPacientes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                NombreSeleccionado = $"{nombre} {apellido}";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnGuardarPaciente_Click(object sender, EventArgs e)
        {
            frmPacientes frm = new frmPacientes();
            frm.ShowDialog();
        }
    }
}