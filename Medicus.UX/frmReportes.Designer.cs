namespace Medicus.UX
{
    partial class frmReportes
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
            this.tabControlReportes = new System.Windows.Forms.TabControl();
            this.tabComprobante = new System.Windows.Forms.TabPage();
            this.chkTodosLosTurnos = new System.Windows.Forms.CheckBox();
            this.dtpFechaTurnos = new System.Windows.Forms.DateTimePicker();
            this.lblFechaTurnos = new System.Windows.Forms.Label();
            this.txtBuscarTurnos = new System.Windows.Forms.TextBox();
            this.lblBuscarTurnos = new System.Windows.Forms.Label();
            this.btnImprimirComprobante = new System.Windows.Forms.Button();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.tabAgenda = new System.Windows.Forms.TabPage();
            this.btnBuscarMedico = new System.Windows.Forms.Button();
            this.txtMedicoAgenda = new System.Windows.Forms.TextBox();
            this.btnImprimirAgenda = new System.Windows.Forms.Button();
            this.dtpFechaAgenda = new System.Windows.Forms.DateTimePicker();
            this.lblFechaAgenda = new System.Windows.Forms.Label();
            this.lblMedicoAgenda = new System.Windows.Forms.Label();
            this.tabControlReportes.SuspendLayout();
            this.tabComprobante.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.tabAgenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(258, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Reportes e Impresiones";
            // 
            // tabControlReportes
            // 
            this.tabControlReportes.Controls.Add(this.tabComprobante);
            this.tabControlReportes.Controls.Add(this.tabAgenda);
            this.tabControlReportes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlReportes.Location = new System.Drawing.Point(20, 70);
            this.tabControlReportes.Name = "tabControlReportes";
            this.tabControlReportes.SelectedIndex = 0;
            this.tabControlReportes.Size = new System.Drawing.Size(840, 460);
            this.tabControlReportes.TabIndex = 1;
            // 
            // tabComprobante
            // 
            this.tabComprobante.Controls.Add(this.chkTodosLosTurnos);
            this.tabComprobante.Controls.Add(this.dtpFechaTurnos);
            this.tabComprobante.Controls.Add(this.lblFechaTurnos);
            this.tabComprobante.Controls.Add(this.txtBuscarTurnos);
            this.tabComprobante.Controls.Add(this.lblBuscarTurnos);
            this.tabComprobante.Controls.Add(this.btnImprimirComprobante);
            this.tabComprobante.Controls.Add(this.dgvTurnos);
            this.tabComprobante.Location = new System.Drawing.Point(4, 26);
            this.tabComprobante.Name = "tabComprobante";
            this.tabComprobante.Padding = new System.Windows.Forms.Padding(3);
            this.tabComprobante.Size = new System.Drawing.Size(832, 430);
            this.tabComprobante.TabIndex = 0;
            this.tabComprobante.Text = "Comprobante de Turno";
            this.tabComprobante.UseVisualStyleBackColor = true;
            // 
            // chkTodosLosTurnos
            // 
            this.chkTodosLosTurnos.AutoSize = true;
            this.chkTodosLosTurnos.Location = new System.Drawing.Point(480, 40);
            this.chkTodosLosTurnos.Name = "chkTodosLosTurnos";
            this.chkTodosLosTurnos.Size = new System.Drawing.Size(126, 23);
            this.chkTodosLosTurnos.TabIndex = 8;
            this.chkTodosLosTurnos.Text = "Ver todas las fechas";
            this.chkTodosLosTurnos.UseVisualStyleBackColor = true;
            this.chkTodosLosTurnos.CheckedChanged += new System.EventHandler(this.chkTodosLosTurnos_CheckedChanged);
            // 
            // dtpFechaTurnos
            // 
            this.dtpFechaTurnos.Enabled = false;
            this.dtpFechaTurnos.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaTurnos.Location = new System.Drawing.Point(340, 40);
            this.dtpFechaTurnos.Name = "dtpFechaTurnos";
            this.dtpFechaTurnos.Size = new System.Drawing.Size(120, 25);
            this.dtpFechaTurnos.TabIndex = 7;
            this.dtpFechaTurnos.ValueChanged += new System.EventHandler(this.dtpFechaTurnos_ValueChanged);
            // 
            // lblFechaTurnos
            // 
            this.lblFechaTurnos.AutoSize = true;
            this.lblFechaTurnos.Location = new System.Drawing.Point(340, 15);
            this.lblFechaTurnos.Name = "lblFechaTurnos";
            this.lblFechaTurnos.Size = new System.Drawing.Size(108, 19);
            this.lblFechaTurnos.TabIndex = 6;
            this.lblFechaTurnos.Text = "Filtrar por Fecha:";
            // 
            // txtBuscarTurnos
            // 
            this.txtBuscarTurnos.Location = new System.Drawing.Point(20, 40);
            this.txtBuscarTurnos.Name = "txtBuscarTurnos";
            this.txtBuscarTurnos.Size = new System.Drawing.Size(290, 25);
            this.txtBuscarTurnos.TabIndex = 5;
            this.txtBuscarTurnos.TextChanged += new System.EventHandler(this.txtBuscarTurnos_TextChanged);
            // 
            // lblBuscarTurnos
            // 
            this.lblBuscarTurnos.AutoSize = true;
            this.lblBuscarTurnos.Location = new System.Drawing.Point(20, 15);
            this.lblBuscarTurnos.Name = "lblBuscarTurnos";
            this.lblBuscarTurnos.Size = new System.Drawing.Size(232, 19);
            this.lblBuscarTurnos.TabIndex = 4;
            this.lblBuscarTurnos.Text = "Buscar por Paciente, DNI o Médico:";
            // 
            // btnImprimirComprobante
            // 
            this.btnImprimirComprobante.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnImprimirComprobante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirComprobante.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimirComprobante.ForeColor = System.Drawing.Color.White;
            this.btnImprimirComprobante.Location = new System.Drawing.Point(580, 380);
            this.btnImprimirComprobante.Name = "btnImprimirComprobante";
            this.btnImprimirComprobante.Size = new System.Drawing.Size(230, 40);
            this.btnImprimirComprobante.TabIndex = 2;
            this.btnImprimirComprobante.Text = "🖨️ Imprimir Recibo";
            this.btnImprimirComprobante.UseVisualStyleBackColor = false;
            this.btnImprimirComprobante.Click += new System.EventHandler(this.btnImprimirComprobante_Click);
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Location = new System.Drawing.Point(20, 80);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.ReadOnly = true;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(790, 290);
            this.dgvTurnos.TabIndex = 1;
            // 
            // tabAgenda
            // 
            this.tabAgenda.Controls.Add(this.btnBuscarMedico);
            this.tabAgenda.Controls.Add(this.txtMedicoAgenda);
            this.tabAgenda.Controls.Add(this.btnImprimirAgenda);
            this.tabAgenda.Controls.Add(this.dtpFechaAgenda);
            this.tabAgenda.Controls.Add(this.lblFechaAgenda);
            this.tabAgenda.Controls.Add(this.lblMedicoAgenda);
            this.tabAgenda.Location = new System.Drawing.Point(4, 26);
            this.tabAgenda.Name = "tabAgenda";
            this.tabAgenda.Padding = new System.Windows.Forms.Padding(3);
            this.tabAgenda.Size = new System.Drawing.Size(832, 430);
            this.tabAgenda.TabIndex = 1;
            this.tabAgenda.Text = "Agenda Diaria del Médico";
            this.tabAgenda.UseVisualStyleBackColor = true;
            // 
            // btnBuscarMedico
            // 
            this.btnBuscarMedico.BackColor = System.Drawing.Color.LightGray;
            this.btnBuscarMedico.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarMedico.Location = new System.Drawing.Point(340, 70);
            this.btnBuscarMedico.Name = "btnBuscarMedico";
            this.btnBuscarMedico.Size = new System.Drawing.Size(50, 27);
            this.btnBuscarMedico.TabIndex = 14;
            this.btnBuscarMedico.Text = "🔍";
            this.btnBuscarMedico.UseVisualStyleBackColor = false;
            this.btnBuscarMedico.Click += new System.EventHandler(this.btnBuscarMedico_Click);
            // 
            // txtMedicoAgenda
            // 
            this.txtMedicoAgenda.Location = new System.Drawing.Point(40, 70);
            this.txtMedicoAgenda.Name = "txtMedicoAgenda";
            this.txtMedicoAgenda.ReadOnly = true;
            this.txtMedicoAgenda.Size = new System.Drawing.Size(290, 25);
            this.txtMedicoAgenda.TabIndex = 5;
            // 
            // btnImprimirAgenda
            // 
            this.btnImprimirAgenda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnImprimirAgenda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirAgenda.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnImprimirAgenda.ForeColor = System.Drawing.Color.White;
            this.btnImprimirAgenda.Location = new System.Drawing.Point(40, 220);
            this.btnImprimirAgenda.Name = "btnImprimirAgenda";
            this.btnImprimirAgenda.Size = new System.Drawing.Size(350, 45);
            this.btnImprimirAgenda.TabIndex = 4;
            this.btnImprimirAgenda.Text = "🖨️ Generar e Imprimir Agenda";
            this.btnImprimirAgenda.UseVisualStyleBackColor = false;
            this.btnImprimirAgenda.Click += new System.EventHandler(this.btnImprimirAgenda_Click);
            // 
            // dtpFechaAgenda
            // 
            this.dtpFechaAgenda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaAgenda.Location = new System.Drawing.Point(40, 150);
            this.dtpFechaAgenda.Name = "dtpFechaAgenda";
            this.dtpFechaAgenda.Size = new System.Drawing.Size(350, 25);
            this.dtpFechaAgenda.TabIndex = 3;
            // 
            // lblFechaAgenda
            // 
            this.lblFechaAgenda.AutoSize = true;
            this.lblFechaAgenda.Location = new System.Drawing.Point(40, 125);
            this.lblFechaAgenda.Name = "lblFechaAgenda";
            this.lblFechaAgenda.Size = new System.Drawing.Size(130, 19);
            this.lblFechaAgenda.TabIndex = 2;
            this.lblFechaAgenda.Text = "Seleccione la Fecha:";
            // 
            // lblMedicoAgenda
            // 
            this.lblMedicoAgenda.AutoSize = true;
            this.lblMedicoAgenda.Location = new System.Drawing.Point(40, 45);
            this.lblMedicoAgenda.Name = "lblMedicoAgenda";
            this.lblMedicoAgenda.Size = new System.Drawing.Size(127, 19);
            this.lblMedicoAgenda.TabIndex = 0;
            this.lblMedicoAgenda.Text = "Buscar Profesional:";
            // 
            // frmReportes
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(880, 560);
            this.Controls.Add(this.tabControlReportes);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes - Medicus";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.tabControlReportes.ResumeLayout(false);
            this.tabComprobante.ResumeLayout(false);
            this.tabComprobante.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.tabAgenda.ResumeLayout(false);
            this.tabAgenda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TabControl tabControlReportes;
        private System.Windows.Forms.TabPage tabComprobante;
        private System.Windows.Forms.TabPage tabAgenda;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.Button btnImprimirComprobante;
        private System.Windows.Forms.Label lblMedicoAgenda;
        private System.Windows.Forms.DateTimePicker dtpFechaAgenda;
        private System.Windows.Forms.Label lblFechaAgenda;
        private System.Windows.Forms.Button btnImprimirAgenda;
        private System.Windows.Forms.TextBox txtBuscarTurnos;
        private System.Windows.Forms.Label lblBuscarTurnos;
        private System.Windows.Forms.DateTimePicker dtpFechaTurnos;
        private System.Windows.Forms.Label lblFechaTurnos;
        private System.Windows.Forms.CheckBox chkTodosLosTurnos;
        private System.Windows.Forms.Button btnBuscarMedico;
        private System.Windows.Forms.TextBox txtMedicoAgenda;
    }
}