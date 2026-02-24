namespace Medicus.UX
{
    partial class frmBackup
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblInstrucciones = new System.Windows.Forms.Label();
            this.txtRuta = new System.Windows.Forms.TextBox();
            this.btnSeleccionarCarpeta = new System.Windows.Forms.Button();
            this.btnGenerarBackup = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Text = "Copia de Seguridad (Backup)";
            // 
            // lblInstrucciones
            // 
            this.lblInstrucciones.Location = new System.Drawing.Point(25, 70);
            this.lblInstrucciones.Size = new System.Drawing.Size(400, 40);
            this.lblInstrucciones.Text = "Seleccione la carpeta donde desea guardar el archivo de respaldo de la base de datos.";
            // 
            // txtRuta
            // 
            this.txtRuta.Location = new System.Drawing.Point(25, 120);
            this.txtRuta.ReadOnly = true;
            this.txtRuta.Size = new System.Drawing.Size(320, 25);
            // 
            // btnSeleccionarCarpeta
            // 
            this.btnSeleccionarCarpeta.Location = new System.Drawing.Point(355, 120);
            this.btnSeleccionarCarpeta.Size = new System.Drawing.Size(40, 25);
            this.btnSeleccionarCarpeta.Text = "...";
            this.btnSeleccionarCarpeta.Click += new System.EventHandler(this.btnSeleccionarCarpeta_Click);
            // 
            // btnGenerarBackup
            // 
            this.btnGenerarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnGenerarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarBackup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGenerarBackup.ForeColor = System.Drawing.Color.White;
            this.btnGenerarBackup.Location = new System.Drawing.Point(25, 180);
            this.btnGenerarBackup.Size = new System.Drawing.Size(370, 45);
            this.btnGenerarBackup.Text = "🚀 Iniciar Copia de Seguridad";
            this.btnGenerarBackup.Click += new System.EventHandler(this.btnGenerarBackup_Click);
            // 
            // frmBackup
            // 
            this.ClientSize = new System.Drawing.Size(430, 260);
            this.Controls.Add(this.btnGenerarBackup);
            this.Controls.Add(this.btnSeleccionarCarpeta);
            this.Controls.Add(this.txtRuta);
            this.Controls.Add(this.lblInstrucciones);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Backup - Medicus";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblInstrucciones;
        private System.Windows.Forms.TextBox txtRuta;
        private System.Windows.Forms.Button btnSeleccionarCarpeta;
        private System.Windows.Forms.Button btnGenerarBackup;
    }
}