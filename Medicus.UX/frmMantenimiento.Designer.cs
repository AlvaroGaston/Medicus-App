namespace Medicus.UX
{
    partial class frmMantenimiento
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabMantenimiento = new System.Windows.Forms.TabControl();
            this.tabBackup = new System.Windows.Forms.TabPage();
            this.btnEjecutarBackup = new System.Windows.Forms.Button();
            this.btnExplorarBackup = new System.Windows.Forms.Button();
            this.txtRutaBackup = new System.Windows.Forms.TextBox();
            this.lblInstruccionesBackup = new System.Windows.Forms.Label();
            this.tabRestore = new System.Windows.Forms.TabPage();
            this.btnEjecutarRestore = new System.Windows.Forms.Button();
            this.btnExplorarRestore = new System.Windows.Forms.Button();
            this.txtRutaRestore = new System.Windows.Forms.TextBox();
            this.lblInstruccionesRestore = new System.Windows.Forms.Label();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.tabMantenimiento.SuspendLayout();
            this.tabBackup.SuspendLayout();
            this.tabRestore.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(374, 32);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mantenimiento de Datos";
            // 
            // tabMantenimiento
            // 
            this.tabMantenimiento.Controls.Add(this.tabBackup);
            this.tabMantenimiento.Controls.Add(this.tabRestore);
            this.tabMantenimiento.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabMantenimiento.Location = new System.Drawing.Point(25, 75);
            this.tabMantenimiento.Name = "tabMantenimiento";
            this.tabMantenimiento.SelectedIndex = 0;
            this.tabMantenimiento.Size = new System.Drawing.Size(530, 280);
            this.tabMantenimiento.TabIndex = 1;
            // 
            // tabBackup
            // 
            this.tabBackup.Controls.Add(this.btnEjecutarBackup);
            this.tabBackup.Controls.Add(this.btnExplorarBackup);
            this.tabBackup.Controls.Add(this.txtRutaBackup);
            this.tabBackup.Controls.Add(this.lblInstruccionesBackup);
            this.tabBackup.Location = new System.Drawing.Point(4, 26);
            this.tabBackup.Name = "tabBackup";
            this.tabBackup.Padding = new System.Windows.Forms.Padding(10);
            this.tabBackup.Size = new System.Drawing.Size(522, 250);
            this.tabBackup.TabIndex = 0;
            this.tabBackup.Text = "Copia de Seguridad";
            this.tabBackup.UseVisualStyleBackColor = true;
            // 
            // btnEjecutarBackup
            // 
            this.btnEjecutarBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnEjecutarBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutarBackup.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEjecutarBackup.ForeColor = System.Drawing.Color.White;
            this.btnEjecutarBackup.Location = new System.Drawing.Point(20, 160);
            this.btnEjecutarBackup.Name = "btnEjecutarBackup";
            this.btnEjecutarBackup.Size = new System.Drawing.Size(480, 50);
            this.btnEjecutarBackup.TabIndex = 3;
            this.btnEjecutarBackup.Text = "🚀 Generar Respaldo Comprimido";
            this.btnEjecutarBackup.UseVisualStyleBackColor = false;
            this.btnEjecutarBackup.Click += new System.EventHandler(this.btnEjecutarBackup_Click);
            // 
            // btnExplorarBackup
            // 
            this.btnExplorarBackup.Location = new System.Drawing.Point(450, 100);
            this.btnExplorarBackup.Name = "btnExplorarBackup";
            this.btnExplorarBackup.Size = new System.Drawing.Size(50, 28);
            this.btnExplorarBackup.TabIndex = 2;
            this.btnExplorarBackup.Text = "...";
            this.btnExplorarBackup.UseVisualStyleBackColor = true;
            this.btnExplorarBackup.Click += new System.EventHandler(this.btnExplorarBackup_Click);
            // 
            // txtRutaBackup
            // 
            this.txtRutaBackup.Location = new System.Drawing.Point(20, 101);
            this.txtRutaBackup.Name = "txtRutaBackup";
            this.txtRutaBackup.ReadOnly = true;
            this.txtRutaBackup.Size = new System.Drawing.Size(420, 25);
            this.txtRutaBackup.TabIndex = 1;
            // 
            // lblInstruccionesBackup
            // 
            this.lblInstruccionesBackup.Location = new System.Drawing.Point(20, 20);
            this.lblInstruccionesBackup.Name = "lblInstruccionesBackup";
            this.lblInstruccionesBackup.Size = new System.Drawing.Size(480, 60);
            this.lblInstruccionesBackup.TabIndex = 0;
            this.lblInstruccionesBackup.Text = "Esta función creará una copia completa de la base de datos Medicus. Se recomienda" +
    " guardar el archivo en una unidad externa o en la nube.";
            // 
            // tabRestore
            // 
            this.tabRestore.Controls.Add(this.btnEjecutarRestore);
            this.tabRestore.Controls.Add(this.btnExplorarRestore);
            this.tabRestore.Controls.Add(this.txtRutaRestore);
            this.tabRestore.Controls.Add(this.lblInstruccionesRestore);
            this.tabRestore.Location = new System.Drawing.Point(4, 26);
            this.tabRestore.Name = "tabRestore";
            this.tabRestore.Padding = new System.Windows.Forms.Padding(10);
            this.tabRestore.Size = new System.Drawing.Size(522, 250);
            this.tabRestore.TabIndex = 1;
            this.tabRestore.Text = "Restauración de Sistema";
            this.tabRestore.UseVisualStyleBackColor = true;
            // 
            // btnEjecutarRestore
            // 
            this.btnEjecutarRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnEjecutarRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEjecutarRestore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnEjecutarRestore.ForeColor = System.Drawing.Color.White;
            this.btnEjecutarRestore.Location = new System.Drawing.Point(20, 160);
            this.btnEjecutarRestore.Name = "btnEjecutarRestore";
            this.btnEjecutarRestore.Size = new System.Drawing.Size(480, 50);
            this.btnEjecutarRestore.TabIndex = 3;
            this.btnEjecutarRestore.Text = "⚠️ Iniciar Restauración Crítica";
            this.btnEjecutarRestore.UseVisualStyleBackColor = false;
            this.btnEjecutarRestore.Click += new System.EventHandler(this.btnEjecutarRestore_Click);
            // 
            // btnExplorarRestore
            // 
            this.btnExplorarRestore.Location = new System.Drawing.Point(450, 100);
            this.btnExplorarRestore.Name = "btnExplorarRestore";
            this.btnExplorarRestore.Size = new System.Drawing.Size(50, 28);
            this.btnExplorarRestore.TabIndex = 2;
            this.btnExplorarRestore.Text = "...";
            this.btnExplorarRestore.UseVisualStyleBackColor = true;
            this.btnExplorarRestore.Click += new System.EventHandler(this.btnExplorarRestore_Click);
            // 
            // txtRutaRestore
            // 
            this.txtRutaRestore.Location = new System.Drawing.Point(20, 101);
            this.txtRutaRestore.Name = "txtRutaRestore";
            this.txtRutaRestore.ReadOnly = true;
            this.txtRutaRestore.Size = new System.Drawing.Size(420, 25);
            this.txtRutaRestore.TabIndex = 1;
            // 
            // lblInstruccionesRestore
            // 
            this.lblInstruccionesRestore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblInstruccionesRestore.ForeColor = System.Drawing.Color.DarkRed;
            this.lblInstruccionesRestore.Location = new System.Drawing.Point(20, 20);
            this.lblInstruccionesRestore.Name = "lblInstruccionesRestore";
            this.lblInstruccionesRestore.Size = new System.Drawing.Size(480, 60);
            this.lblInstruccionesRestore.TabIndex = 0;
            this.lblInstruccionesRestore.Text = "ATENCIÓN: Al restaurar, se borrarán todos los datos actuales y se reemplazarán p" +
    "or los de la copia seleccionada. Este proceso no se puede deshacer.";
            // 
            // frmMantenimiento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(580, 380);
            this.Controls.Add(this.tabMantenimiento);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMantenimiento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicus - Mantenimiento de Base de Datos";
            this.tabMantenimiento.ResumeLayout(false);
            this.tabBackup.ResumeLayout(false);
            this.tabBackup.PerformLayout();
            this.tabRestore.ResumeLayout(false);
            this.tabRestore.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabMantenimiento;
        private System.Windows.Forms.TabPage tabBackup;
        private System.Windows.Forms.TabPage tabRestore;
        private System.Windows.Forms.Label lblInstruccionesBackup;
        private System.Windows.Forms.Button btnEjecutarBackup;
        private System.Windows.Forms.Button btnExplorarBackup;
        private System.Windows.Forms.TextBox txtRutaBackup;
        private System.Windows.Forms.Label lblInstruccionesRestore;
        private System.Windows.Forms.Button btnEjecutarRestore;
        private System.Windows.Forms.Button btnExplorarRestore;
        private System.Windows.Forms.TextBox txtRutaRestore;
    }
}