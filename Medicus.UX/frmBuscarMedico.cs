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
    public partial class frmBuscarMedico : Form
    {
        private MedicoBLL bllMedico = new MedicoBLL();
        private List<Medico> listaOriginal;

        public int IdSeleccionado { get; private set; } = 0;
        public string NombreSeleccionado { get; private set; } = "";

        public frmBuscarMedico()
        {
            InitializeComponent();
        }

        private void frmBuscarMedico_Load(object sender, EventArgs e)
        {
            // Solo traemos los médicos activos
            listaOriginal = bllMedico.ListarMedicos().Where(m => m.Estado == true).ToList();
            dgvMedicos.DataSource = listaOriginal;
            if (dgvMedicos.Columns["IdMedico"] != null) dgvMedicos.Columns["IdMedico"].Visible = false;
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(filtro))
            {
                dgvMedicos.DataSource = listaOriginal;
            }
            else
            {
                dgvMedicos.DataSource = listaOriginal.Where(m =>
                    m.Nombre.ToLower().Contains(filtro) ||
                    m.Apellido.ToLower().Contains(filtro) ||
                    m.Especialidad.ToLower().Contains(filtro)).ToList();
            }
        }

        private void dgvMedicos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdSeleccionado = Convert.ToInt32(dgvMedicos.Rows[e.RowIndex].Cells["IdMedico"].Value);
                string nombre = dgvMedicos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                string apellido = dgvMedicos.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                string especialidad = dgvMedicos.Rows[e.RowIndex].Cells["Especialidad"].Value.ToString();
                NombreSeleccionado = $"Dr. {nombre} {apellido} - {especialidad}";

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}