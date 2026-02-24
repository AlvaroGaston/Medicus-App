using System;
using System.Windows.Forms;
using Medicus.BLL;

namespace Medicus.UX
{
    public partial class frmMantenimiento : Form
    {
        private BackupBLL bllBackup = new BackupBLL();

        public frmMantenimiento()
        {
            InitializeComponent();
        }

        // --- SECCIÓN DE BACKUP ---
        private void btnExplorarBackup_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() == DialogResult.OK) txtRutaBackup.Text = fbd.SelectedPath;
            }
        }

        private void btnEjecutarBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRutaBackup.Text))
            {
                MessageBox.Show("Por favor, seleccioná una carpeta de destino para el respaldo.", "Atención");
                return;
            }

            try
            {
                Cursor = Cursors.WaitCursor;
                // Llamada sincronizada con el nombre corregido en BLL
                bllBackup.GenerarCopiaSeguridad(txtRutaBackup.Text);
                Cursor = Cursors.Default;

                MessageBox.Show("Copia de seguridad generada y comprimida con éxito.", "Mantenimiento Medicus");
            }
            catch (Exception ex)
            {
                Cursor = Cursors.Default;
                MessageBox.Show("No se pudo realizar el backup: " + ex.Message, "Error en Base de Datos");
            }
        }

        // --- SECCIÓN DE RESTAURACIÓN ---
        private void btnExplorarRestore_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog { Filter = "Archivos de Backup (*.bak)|*.bak" })
            {
                if (ofd.ShowDialog() == DialogResult.OK) txtRutaRestore.Text = ofd.FileName;
            }
        }

        private void btnEjecutarRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRutaRestore.Text)) return;

            var confirm = MessageBox.Show("¡ADVERTENCIA CRÍTICA!\n\nSe reemplazarán todos los datos actuales de la clínica por los de la copia de seguridad. Esta acción no se puede deshacer.\n\n¿Desea continuar?",
                                        "Confirmar Restauración", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;
                    bllBackup.RestaurarSistema(txtRutaRestore.Text);
                    Cursor = Cursors.Default;

                    MessageBox.Show("Restauración completada. La aplicación se reiniciará para aplicar los cambios.", "Éxito");
                    Application.Restart();
                }
                catch (Exception ex)
                {
                    Cursor = Cursors.Default;
                    MessageBox.Show("Error crítico durante la restauración: " + ex.Message, "Falla de Sistema");
                }
            }
        }
    }
}