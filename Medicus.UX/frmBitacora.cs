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

namespace Medicus.UX
{
    public partial class frmBitacora : Form
    {
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        public frmBitacora()
        {
            InitializeComponent();
        }

        private void frmBitacora_Load(object sender, EventArgs e)
        {
            bllSeguridad.AplicarSeguridadGranular(this, "frmBitacora");

            chkVerTodo.Checked = false;
            dtpFecha.Value = DateTime.Today;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            dgvBitacora.DataSource = null;

            // Si el CheckBox está tildado, le pasamos NULL (trae todo). Si no, pasamos la fecha elegida.
            if (chkVerTodo.Checked)
                dgvBitacora.DataSource = BitacoraBLL.ListarBitacora(null);
            else
                dgvBitacora.DataSource = BitacoraBLL.ListarBitacora(dtpFecha.Value);

            // Ocultamos las columnas de IDs
            if (dgvBitacora.Columns["IdBitacora"] != null) dgvBitacora.Columns["IdBitacora"].Visible = false;
            if (dgvBitacora.Columns["IdUsuario"] != null) dgvBitacora.Columns["IdUsuario"].Visible = false;
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            if (!chkVerTodo.Checked) CargarGrilla();
        }

        private void chkVerTodo_CheckedChanged(object sender, EventArgs e)
        {
            dtpFecha.Enabled = !chkVerTodo.Checked; // Desactiva el calendario si "Ver todo" está tildado
            CargarGrilla();
        }
    }
}