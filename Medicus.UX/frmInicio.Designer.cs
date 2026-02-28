namespace Medicus.UX
{
    partial class frmInicio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) { components.Dispose(); }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.btnMantenimiento = new System.Windows.Forms.Button();
            this.btnReportes = new System.Windows.Forms.Button();
            this.btnBitacora = new System.Windows.Forms.Button();
            this.btnSeguridad = new System.Windows.Forms.Button();
            this.btnMedicos = new System.Windows.Forms.Button();
            this.btnPacientes = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.panelCentral = new System.Windows.Forms.Panel();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.panelTarjetaMedicos = new System.Windows.Forms.Panel();
            this.lblNumMedicos = new System.Windows.Forms.Label();
            this.lblTituloMedicos = new System.Windows.Forms.Label();
            this.panelTarjetaPacientes = new System.Windows.Forms.Panel();
            this.lblNumPacientes = new System.Windows.Forms.Label();
            this.lblTituloPacientes = new System.Windows.Forms.Label();
            this.lblTotalDia = new System.Windows.Forms.Label();
            this.dgvTurnosDia = new System.Windows.Forms.DataGridView();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.panelGrafico2 = new System.Windows.Forms.Panel();
            this.panelGrafico1 = new System.Windows.Forms.Panel();
            this.lblRol = new System.Windows.Forms.Label();
            this.lblBienvenida = new System.Windows.Forms.Label();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelCentral.SuspendLayout();
            this.panelTarjetaMedicos.SuspendLayout();
            this.panelTarjetaPacientes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDia)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.panelMenu.Controls.Add(this.btnCerrarSesion);
            this.panelMenu.Controls.Add(this.btnMantenimiento);
            this.panelMenu.Controls.Add(this.btnReportes);
            this.panelMenu.Controls.Add(this.btnBitacora);
            this.panelMenu.Controls.Add(this.btnSeguridad);
            this.panelMenu.Controls.Add(this.btnMedicos);
            this.panelMenu.Controls.Add(this.btnPacientes);
            this.panelMenu.Controls.Add(this.btnTurnos);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(250, 720);
            this.panelMenu.TabIndex = 0;
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnCerrarSesion.FlatAppearance.BorderSize = 0;
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.Tomato;
            this.btnCerrarSesion.Location = new System.Drawing.Point(0, 660);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(250, 60);
            this.btnCerrarSesion.TabIndex = 8;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = true;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // btnMantenimiento
            // 
            this.btnMantenimiento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMantenimiento.FlatAppearance.BorderSize = 0;
            this.btnMantenimiento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMantenimiento.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMantenimiento.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMantenimiento.Location = new System.Drawing.Point(0, 400);
            this.btnMantenimiento.Name = "btnMantenimiento";
            this.btnMantenimiento.Size = new System.Drawing.Size(250, 50);
            this.btnMantenimiento.TabIndex = 7;
            this.btnMantenimiento.Text = "Mantenimiento / Backup";
            this.btnMantenimiento.UseVisualStyleBackColor = true;
            this.btnMantenimiento.Click += new System.EventHandler(this.btnMantenimiento_Click);
            // 
            // btnReportes
            // 
            this.btnReportes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReportes.FlatAppearance.BorderSize = 0;
            this.btnReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReportes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnReportes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnReportes.Location = new System.Drawing.Point(0, 350);
            this.btnReportes.Name = "btnReportes";
            this.btnReportes.Size = new System.Drawing.Size(250, 50);
            this.btnReportes.TabIndex = 6;
            this.btnReportes.Text = "Reportes";
            this.btnReportes.UseVisualStyleBackColor = true;
            this.btnReportes.Click += new System.EventHandler(this.btnReportes_Click);
            // 
            // btnBitacora
            // 
            this.btnBitacora.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBitacora.FlatAppearance.BorderSize = 0;
            this.btnBitacora.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBitacora.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnBitacora.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnBitacora.Location = new System.Drawing.Point(0, 300);
            this.btnBitacora.Name = "btnBitacora";
            this.btnBitacora.Size = new System.Drawing.Size(250, 50);
            this.btnBitacora.TabIndex = 5;
            this.btnBitacora.Text = "Auditoría (Bitácora)";
            this.btnBitacora.UseVisualStyleBackColor = true;
            this.btnBitacora.Click += new System.EventHandler(this.btnBitacora_Click);
            // 
            // btnSeguridad
            // 
            this.btnSeguridad.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSeguridad.FlatAppearance.BorderSize = 0;
            this.btnSeguridad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeguridad.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnSeguridad.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnSeguridad.Location = new System.Drawing.Point(0, 250);
            this.btnSeguridad.Name = "btnSeguridad";
            this.btnSeguridad.Size = new System.Drawing.Size(250, 50);
            this.btnSeguridad.TabIndex = 4;
            this.btnSeguridad.Text = "Seguridad y Roles";
            this.btnSeguridad.UseVisualStyleBackColor = true;
            this.btnSeguridad.Click += new System.EventHandler(this.btnSeguridad_Click);
            // 
            // btnMedicos
            // 
            this.btnMedicos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMedicos.FlatAppearance.BorderSize = 0;
            this.btnMedicos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMedicos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMedicos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnMedicos.Location = new System.Drawing.Point(0, 200);
            this.btnMedicos.Name = "btnMedicos";
            this.btnMedicos.Size = new System.Drawing.Size(250, 50);
            this.btnMedicos.TabIndex = 3;
            this.btnMedicos.Text = "Médicos";
            this.btnMedicos.UseVisualStyleBackColor = true;
            this.btnMedicos.Click += new System.EventHandler(this.btnMedicos_Click);
            // 
            // btnPacientes
            // 
            this.btnPacientes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnPacientes.FlatAppearance.BorderSize = 0;
            this.btnPacientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPacientes.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnPacientes.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnPacientes.Location = new System.Drawing.Point(0, 150);
            this.btnPacientes.Name = "btnPacientes";
            this.btnPacientes.Size = new System.Drawing.Size(250, 50);
            this.btnPacientes.TabIndex = 2;
            this.btnPacientes.Text = "Pacientes";
            this.btnPacientes.UseVisualStyleBackColor = true;
            this.btnPacientes.Click += new System.EventHandler(this.btnPacientes_Click);
            // 
            // btnTurnos
            // 
            this.btnTurnos.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTurnos.FlatAppearance.BorderSize = 0;
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnos.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnTurnos.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnTurnos.Location = new System.Drawing.Point(0, 100);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(250, 50);
            this.btnTurnos.TabIndex = 1;
            this.btnTurnos.Text = "Gestión de Turnos";
            this.btnTurnos.UseVisualStyleBackColor = true;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.panelLogo.Controls.Add(this.lblLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(250, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // lblLogo
            // 
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(40, 25);
            this.lblLogo.Name = "lblLogo";
            this.lblLogo.Size = new System.Drawing.Size(163, 45);
            this.lblLogo.TabIndex = 0;
            this.lblLogo.Text = "MEDICUS";
            // 
            // panelCentral
            // 
            this.panelCentral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.panelCentral.Controls.Add(this.btnActualizar);
            this.panelCentral.Controls.Add(this.panelTarjetaMedicos);
            this.panelCentral.Controls.Add(this.panelTarjetaPacientes);
            this.panelCentral.Controls.Add(this.lblTotalDia);
            this.panelCentral.Controls.Add(this.dgvTurnosDia);
            this.panelCentral.Controls.Add(this.dtpFechaFiltro);
            this.panelCentral.Controls.Add(this.lblFiltroFecha);
            this.panelCentral.Controls.Add(this.panelGrafico2);
            this.panelCentral.Controls.Add(this.panelGrafico1);
            this.panelCentral.Controls.Add(this.lblRol);
            this.panelCentral.Controls.Add(this.lblBienvenida);
            this.panelCentral.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCentral.Location = new System.Drawing.Point(250, 0);
            this.panelCentral.Name = "panelCentral";
            this.panelCentral.Size = new System.Drawing.Size(950, 720);
            this.panelCentral.TabIndex = 1;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnActualizar.ForeColor = System.Drawing.Color.White;
            this.btnActualizar.Location = new System.Drawing.Point(780, 40);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(130, 45);
            this.btnActualizar.TabIndex = 10;
            this.btnActualizar.Text = "🔄 Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // panelTarjetaMedicos
            // 
            this.panelTarjetaMedicos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTarjetaMedicos.BackColor = System.Drawing.Color.White;
            this.panelTarjetaMedicos.Controls.Add(this.lblNumMedicos);
            this.panelTarjetaMedicos.Controls.Add(this.lblTituloMedicos);
            this.panelTarjetaMedicos.Location = new System.Drawing.Point(639, 40);
            this.panelTarjetaMedicos.Name = "panelTarjetaMedicos";
            this.panelTarjetaMedicos.Size = new System.Drawing.Size(135, 90);
            this.panelTarjetaMedicos.TabIndex = 9;
            // 
            // lblNumMedicos
            // 
            this.lblNumMedicos.AutoSize = true;
            this.lblNumMedicos.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumMedicos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblNumMedicos.Location = new System.Drawing.Point(15, 40);
            this.lblNumMedicos.Name = "lblNumMedicos";
            this.lblNumMedicos.Size = new System.Drawing.Size(33, 37);
            this.lblNumMedicos.TabIndex = 1;
            this.lblNumMedicos.Text = "0";
            // 
            // lblTituloMedicos
            // 
            this.lblTituloMedicos.AutoSize = true;
            this.lblTituloMedicos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloMedicos.ForeColor = System.Drawing.Color.Gray;
            this.lblTituloMedicos.Location = new System.Drawing.Point(15, 10);
            this.lblTituloMedicos.Name = "lblTituloMedicos";
            this.lblTituloMedicos.Size = new System.Drawing.Size(108, 19);
            this.lblTituloMedicos.TabIndex = 0;
            this.lblTituloMedicos.Text = "Médicos Activos";
            // 
            // panelTarjetaPacientes
            // 
            this.panelTarjetaPacientes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTarjetaPacientes.BackColor = System.Drawing.Color.White;
            this.panelTarjetaPacientes.Controls.Add(this.lblNumPacientes);
            this.panelTarjetaPacientes.Controls.Add(this.lblTituloPacientes);
            this.panelTarjetaPacientes.Location = new System.Drawing.Point(498, 40);
            this.panelTarjetaPacientes.Name = "panelTarjetaPacientes";
            this.panelTarjetaPacientes.Size = new System.Drawing.Size(135, 90);
            this.panelTarjetaPacientes.TabIndex = 8;
            // 
            // lblNumPacientes
            // 
            this.lblNumPacientes.AutoSize = true;
            this.lblNumPacientes.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNumPacientes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.lblNumPacientes.Location = new System.Drawing.Point(15, 40);
            this.lblNumPacientes.Name = "lblNumPacientes";
            this.lblNumPacientes.Size = new System.Drawing.Size(33, 37);
            this.lblNumPacientes.TabIndex = 1;
            this.lblNumPacientes.Text = "0";
            // 
            // lblTituloPacientes
            // 
            this.lblTituloPacientes.AutoSize = true;
            this.lblTituloPacientes.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTituloPacientes.ForeColor = System.Drawing.Color.Gray;
            this.lblTituloPacientes.Location = new System.Drawing.Point(15, 10);
            this.lblTituloPacientes.Name = "lblTituloPacientes";
            this.lblTituloPacientes.Size = new System.Drawing.Size(113, 19);
            this.lblTituloPacientes.TabIndex = 0;
            this.lblTituloPacientes.Text = "Total Registrados";
            // 
            // lblTotalDia
            // 
            this.lblTotalDia.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTotalDia.AutoSize = true;
            this.lblTotalDia.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalDia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblTotalDia.Location = new System.Drawing.Point(30, 670);
            this.lblTotalDia.Name = "lblTotalDia";
            this.lblTotalDia.Size = new System.Drawing.Size(216, 19);
            this.lblTotalDia.TabIndex = 7;
            this.lblTotalDia.Text = "Total de turnos para este día: 0";
            // 
            // dgvTurnosDia
            // 
            this.dgvTurnosDia.AllowUserToAddRows = false;
            this.dgvTurnosDia.AllowUserToDeleteRows = false;
            this.dgvTurnosDia.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTurnosDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnosDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnosDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosDia.Location = new System.Drawing.Point(30, 480);
            this.dgvTurnosDia.Name = "dgvTurnosDia";
            this.dgvTurnosDia.ReadOnly = true;
            this.dgvTurnosDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnosDia.Size = new System.Drawing.Size(880, 180);
            this.dgvTurnosDia.TabIndex = 6;
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(30, 440);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(150, 25);
            this.dtpFechaFiltro.TabIndex = 5;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.Location = new System.Drawing.Point(30, 410);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(197, 21);
            this.lblFiltroFecha.TabIndex = 4;
            this.lblFiltroFecha.Text = "Agenda Diaria de Turnos";
            // 
            // panelGrafico2
            // 
            this.panelGrafico2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGrafico2.BackColor = System.Drawing.Color.White;
            this.panelGrafico2.Location = new System.Drawing.Point(470, 150);
            this.panelGrafico2.Name = "panelGrafico2";
            this.panelGrafico2.Size = new System.Drawing.Size(440, 240);
            this.panelGrafico2.TabIndex = 3;
            // 
            // panelGrafico1
            // 
            this.panelGrafico1.BackColor = System.Drawing.Color.White;
            this.panelGrafico1.Location = new System.Drawing.Point(30, 150);
            this.panelGrafico1.Name = "panelGrafico1";
            this.panelGrafico1.Size = new System.Drawing.Size(420, 240);
            this.panelGrafico1.TabIndex = 2;
            // 
            // lblRol
            // 
            this.lblRol.AutoSize = true;
            this.lblRol.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblRol.ForeColor = System.Drawing.Color.DimGray;
            this.lblRol.Location = new System.Drawing.Point(30, 75);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(148, 21);
            this.lblRol.TabIndex = 1;
            this.lblRol.Text = "Usuario del Sistema";
            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblBienvenida.Location = new System.Drawing.Point(25, 25);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new System.Drawing.Size(209, 45);
            this.lblBienvenida.TabIndex = 0;
            this.lblBienvenida.Text = "Hola, Admin";
            // 
            // frmInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 720);
            this.Controls.Add(this.panelCentral);
            this.Controls.Add(this.panelMenu);
            this.Name = "frmInicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicus - Tablero Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmInicio_FormClosed);
            this.Load += new System.EventHandler(this.frmInicio_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelCentral.ResumeLayout(false);
            this.panelCentral.PerformLayout();
            this.panelTarjetaMedicos.ResumeLayout(false);
            this.panelTarjetaMedicos.PerformLayout();
            this.panelTarjetaPacientes.ResumeLayout(false);
            this.panelTarjetaPacientes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDia)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnTurnos;
        private System.Windows.Forms.Button btnPacientes;
        private System.Windows.Forms.Button btnMedicos;
        private System.Windows.Forms.Button btnSeguridad;
        private System.Windows.Forms.Button btnBitacora;
        private System.Windows.Forms.Button btnReportes;
        private System.Windows.Forms.Button btnMantenimiento;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Panel panelCentral;
        private System.Windows.Forms.Label lblBienvenida;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.Panel panelGrafico1;
        private System.Windows.Forms.Panel panelGrafico2;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.DataGridView dgvTurnosDia;
        private System.Windows.Forms.Label lblTotalDia;
        private System.Windows.Forms.Panel panelTarjetaPacientes;
        private System.Windows.Forms.Label lblTituloPacientes;
        private System.Windows.Forms.Label lblNumPacientes;
        private System.Windows.Forms.Panel panelTarjetaMedicos;
        private System.Windows.Forms.Label lblTituloMedicos;
        private System.Windows.Forms.Label lblNumMedicos;
        private System.Windows.Forms.Button btnActualizar;
    }
}