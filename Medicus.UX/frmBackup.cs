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
    public partial class frmBackup : Form
    {
        private BackupBLL bllBackup = new BackupBLL();

        public frmBackup()
        {
            InitializeComponent();
        }

        private void btnSeleccionarCarpeta_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    txtRuta.Text = fbd.SelectedPath;
                }
            }
        }

        private void btnGenerarBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRuta.Text))
            {
                MessageBox.Show("Por favor, seleccione una carpeta de destino.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                bllBackup.GenerarCopiaSeguridad(txtRuta.Text);
                Cursor = Cursors.Default;

                MessageBox.Show("Copia de seguridad realizada con éxito.", "Backup Finalizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("Error al realizar el backup: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}