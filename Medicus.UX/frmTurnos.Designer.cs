namespace Medicus.UX
{
    partial class frmTurnos
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
            this.lblTituloPrincipal = new System.Windows.Forms.Label();
            this.gbPaso1 = new System.Windows.Forms.GroupBox();
            this.cmbEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.lblPaciente = new System.Windows.Forms.Label();
            this.gbPaso2 = new System.Windows.Forms.GroupBox();
            this.lblMedicoSeleccionado = new System.Windows.Forms.Label();
            this.dgvMedicos = new System.Windows.Forms.DataGridView();
            this.gbPaso3 = new System.Windows.Forms.GroupBox();
            this.lblDiaSeleccionado = new System.Windows.Forms.Label();
            this.dgvDias = new System.Windows.Forms.DataGridView();
            this.gbPaso4 = new System.Windows.Forms.GroupBox();
            this.lblHoraSeleccionada = new System.Windows.Forms.Label();
            this.dgvHorarios = new System.Windows.Forms.DataGridView();
            this.groupBoxConfirmacion = new System.Windows.Forms.GroupBox();
            this.btnImprimirRecibo = new System.Windows.Forms.Button();
            this.btnConfirmarTurno = new System.Windows.Forms.Button();
            this.btnTurnos = new System.Windows.Forms.Button();
            this.gbPaso1.SuspendLayout();
            this.gbPaso2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).BeginInit();
            this.gbPaso3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).BeginInit();
            this.gbPaso4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).BeginInit();
            this.groupBoxConfirmacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTituloPrincipal
            // 
            this.lblTituloPrincipal.AutoSize = true;
            this.lblTituloPrincipal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTituloPrincipal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblTituloPrincipal.Location = new System.Drawing.Point(20, 15);
            this.lblTituloPrincipal.Name = "lblTituloPrincipal";
            this.lblTituloPrincipal.Size = new System.Drawing.Size(299, 30);
            this.lblTituloPrincipal.TabIndex = 0;
            this.lblTituloPrincipal.Text = "Asistente de Nuevos Turnos";
            // 
            // gbPaso1
            // 
            this.gbPaso1.Controls.Add(this.cmbEspecialidad);
            this.gbPaso1.Controls.Add(this.lblEspecialidad);
            this.gbPaso1.Controls.Add(this.btnBuscarPaciente);
            this.gbPaso1.Controls.Add(this.txtPaciente);
            this.gbPaso1.Controls.Add(this.lblPaciente);
            this.gbPaso1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaso1.Location = new System.Drawing.Point(20, 60);
            this.gbPaso1.Name = "gbPaso1";
            this.gbPaso1.Size = new System.Drawing.Size(940, 90);
            this.gbPaso1.TabIndex = 1;
            this.gbPaso1.TabStop = false;
            this.gbPaso1.Text = "Paso 1: Paciente y Especialidad";
            // 
            // cmbEspecialidad
            // 
            this.cmbEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbEspecialidad.FormattingEnabled = true;
            this.cmbEspecialidad.Location = new System.Drawing.Point(500, 45);
            this.cmbEspecialidad.Name = "cmbEspecialidad";
            this.cmbEspecialidad.Size = new System.Drawing.Size(320, 25);
            this.cmbEspecialidad.TabIndex = 4;
            this.cmbEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbEspecialidad_SelectedIndexChanged);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEspecialidad.Location = new System.Drawing.Point(500, 25);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(134, 15);
            this.lblEspecialidad.TabIndex = 3;
            this.lblEspecialidad.Text = "Seleccione Especialidad:";
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(350, 44);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(100, 27);
            this.btnBuscarPaciente.TabIndex = 2;
            this.btnBuscarPaciente.Text = "🔍 Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = false;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // txtPaciente
            // 
            this.txtPaciente.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPaciente.Location = new System.Drawing.Point(20, 45);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.ReadOnly = true;
            this.txtPaciente.Size = new System.Drawing.Size(320, 25);
            this.txtPaciente.TabIndex = 1;
            // 
            // lblPaciente
            // 
            this.lblPaciente.AutoSize = true;
            this.lblPaciente.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaciente.Location = new System.Drawing.Point(20, 25);
            this.lblPaciente.Name = "lblPaciente";
            this.lblPaciente.Size = new System.Drawing.Size(107, 15);
            this.lblPaciente.TabIndex = 0;
            this.lblPaciente.Text = "Paciente a atender:";
            // 
            // gbPaso2
            // 
            this.gbPaso2.Controls.Add(this.lblMedicoSeleccionado);
            this.gbPaso2.Controls.Add(this.dgvMedicos);
            this.gbPaso2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaso2.Location = new System.Drawing.Point(20, 160);
            this.gbPaso2.Name = "gbPaso2";
            this.gbPaso2.Size = new System.Drawing.Size(300, 340);
            this.gbPaso2.TabIndex = 2;
            this.gbPaso2.TabStop = false;
            this.gbPaso2.Text = "Paso 2: Profesionales";
            // 
            // lblMedicoSeleccionado
            // 
            this.lblMedicoSeleccionado.AutoSize = true;
            this.lblMedicoSeleccionado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblMedicoSeleccionado.ForeColor = System.Drawing.Color.DimGray;
            this.lblMedicoSeleccionado.Location = new System.Drawing.Point(20, 310);
            this.lblMedicoSeleccionado.Name = "lblMedicoSeleccionado";
            this.lblMedicoSeleccionado.Size = new System.Drawing.Size(66, 19);
            this.lblMedicoSeleccionado.TabIndex = 1;
            this.lblMedicoSeleccionado.Text = "Médico: -";
            // 
            // dgvMedicos
            // 
            this.dgvMedicos.AllowUserToAddRows = false;
            this.dgvMedicos.AllowUserToDeleteRows = false;
            this.dgvMedicos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMedicos.BackgroundColor = System.Drawing.Color.White;
            this.dgvMedicos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvMedicos.Location = new System.Drawing.Point(20, 35);
            this.dgvMedicos.Name = "dgvMedicos";
            this.dgvMedicos.ReadOnly = true;
            this.dgvMedicos.RowHeadersVisible = false;
            this.dgvMedicos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicos.Size = new System.Drawing.Size(260, 260);
            this.dgvMedicos.TabIndex = 0;
            this.dgvMedicos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMedicos_CellClick);
            // 
            // gbPaso3
            // 
            this.gbPaso3.Controls.Add(this.lblDiaSeleccionado);
            this.gbPaso3.Controls.Add(this.dgvDias);
            this.gbPaso3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaso3.Location = new System.Drawing.Point(340, 160);
            this.gbPaso3.Name = "gbPaso3";
            this.gbPaso3.Size = new System.Drawing.Size(300, 340);
            this.gbPaso3.TabIndex = 3;
            this.gbPaso3.TabStop = false;
            this.gbPaso3.Text = "Paso 3: Días Disponibles";
            // 
            // lblDiaSeleccionado
            // 
            this.lblDiaSeleccionado.AutoSize = true;
            this.lblDiaSeleccionado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblDiaSeleccionado.ForeColor = System.Drawing.Color.DimGray;
            this.lblDiaSeleccionado.Location = new System.Drawing.Point(20, 310);
            this.lblDiaSeleccionado.Name = "lblDiaSeleccionado";
            this.lblDiaSeleccionado.Size = new System.Drawing.Size(44, 19);
            this.lblDiaSeleccionado.TabIndex = 2;
            this.lblDiaSeleccionado.Text = "Día: -";
            // 
            // dgvDias
            // 
            this.dgvDias.AllowUserToAddRows = false;
            this.dgvDias.AllowUserToDeleteRows = false;
            this.dgvDias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDias.BackgroundColor = System.Drawing.Color.White;
            this.dgvDias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDias.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvDias.Location = new System.Drawing.Point(20, 35);
            this.dgvDias.Name = "dgvDias";
            this.dgvDias.ReadOnly = true;
            this.dgvDias.RowHeadersVisible = false;
            this.dgvDias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDias.Size = new System.Drawing.Size(260, 260);
            this.dgvDias.TabIndex = 1;
            this.dgvDias.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDias_CellClick);
            // 
            // gbPaso4
            // 
            this.gbPaso4.Controls.Add(this.lblHoraSeleccionada);
            this.gbPaso4.Controls.Add(this.dgvHorarios);
            this.gbPaso4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.gbPaso4.Location = new System.Drawing.Point(660, 160);
            this.gbPaso4.Name = "gbPaso4";
            this.gbPaso4.Size = new System.Drawing.Size(300, 340);
            this.gbPaso4.TabIndex = 4;
            this.gbPaso4.TabStop = false;
            this.gbPaso4.Text = "Paso 4: Horarios";
            // 
            // lblHoraSeleccionada
            // 
            this.lblHoraSeleccionada.AutoSize = true;
            this.lblHoraSeleccionada.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblHoraSeleccionada.ForeColor = System.Drawing.Color.DimGray;
            this.lblHoraSeleccionada.Location = new System.Drawing.Point(20, 310);
            this.lblHoraSeleccionada.Name = "lblHoraSeleccionada";
            this.lblHoraSeleccionada.Size = new System.Drawing.Size(53, 19);
            this.lblHoraSeleccionada.TabIndex = 2;
            this.lblHoraSeleccionada.Text = "Hora: -";
            // 
            // dgvHorarios
            // 
            this.dgvHorarios.AllowUserToAddRows = false;
            this.dgvHorarios.AllowUserToDeleteRows = false;
            this.dgvHorarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHorarios.BackgroundColor = System.Drawing.Color.White;
            this.dgvHorarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHorarios.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvHorarios.Location = new System.Drawing.Point(20, 35);
            this.dgvHorarios.Name = "dgvHorarios";
            this.dgvHorarios.ReadOnly = true;
            this.dgvHorarios.RowHeadersVisible = false;
            this.dgvHorarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHorarios.Size = new System.Drawing.Size(260, 260);
            this.dgvHorarios.TabIndex = 1;
            this.dgvHorarios.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvHorarios_CellClick);
            // 
            // groupBoxConfirmacion
            // 
            this.groupBoxConfirmacion.Controls.Add(this.btnImprimirRecibo);
            this.groupBoxConfirmacion.Controls.Add(this.btnConfirmarTurno);
            this.groupBoxConfirmacion.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.groupBoxConfirmacion.Location = new System.Drawing.Point(20, 510);
            this.groupBoxConfirmacion.Name = "groupBoxConfirmacion";
            this.groupBoxConfirmacion.Size = new System.Drawing.Size(940, 90);
            this.groupBoxConfirmacion.TabIndex = 5;
            this.groupBoxConfirmacion.TabStop = false;
            this.groupBoxConfirmacion.Text = "Paso 5: Confirmación";
            // 
            // btnImprimirRecibo
            // 
            this.btnImprimirRecibo.BackColor = System.Drawing.Color.DimGray;
            this.btnImprimirRecibo.Enabled = false;
            this.btnImprimirRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimirRecibo.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnImprimirRecibo.ForeColor = System.Drawing.Color.White;
            this.btnImprimirRecibo.Location = new System.Drawing.Point(222, 24);
            this.btnImprimirRecibo.Name = "btnImprimirRecibo";
            this.btnImprimirRecibo.Size = new System.Drawing.Size(190, 50);
            this.btnImprimirRecibo.TabIndex = 5;
            this.btnImprimirRecibo.Text = "🖨️ Imprimir Recibo";
            this.btnImprimirRecibo.UseVisualStyleBackColor = false;
            this.btnImprimirRecibo.Click += new System.EventHandler(this.btnImprimirRecibo_Click);
            // 
            // btnConfirmarTurno
            // 
            this.btnConfirmarTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnConfirmarTurno.Enabled = false;
            this.btnConfirmarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmarTurno.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnConfirmarTurno.ForeColor = System.Drawing.Color.White;
            this.btnConfirmarTurno.Location = new System.Drawing.Point(6, 24);
            this.btnConfirmarTurno.Name = "btnConfirmarTurno";
            this.btnConfirmarTurno.Size = new System.Drawing.Size(210, 50);
            this.btnConfirmarTurno.TabIndex = 4;
            this.btnConfirmarTurno.Text = "✅ Confirmar Turno";
            this.btnConfirmarTurno.UseVisualStyleBackColor = false;
            this.btnConfirmarTurno.Click += new System.EventHandler(this.btnConfirmarTurno_Click);
            // 
            // btnTurnos
            // 
            this.btnTurnos.BackColor = System.Drawing.Color.OrangeRed;
            this.btnTurnos.Enabled = false;
            this.btnTurnos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTurnos.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTurnos.ForeColor = System.Drawing.Color.White;
            this.btnTurnos.Location = new System.Drawing.Point(852, 12);
            this.btnTurnos.Name = "btnTurnos";
            this.btnTurnos.Size = new System.Drawing.Size(108, 50);
            this.btnTurnos.TabIndex = 6;
            this.btnTurnos.Text = "✅ ABM";
            this.btnTurnos.UseVisualStyleBackColor = false;
            this.btnTurnos.Click += new System.EventHandler(this.btnTurnos_Click);
            // 
            // frmTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 621);
            this.Controls.Add(this.btnTurnos);
            this.Controls.Add(this.groupBoxConfirmacion);
            this.Controls.Add(this.gbPaso4);
            this.Controls.Add(this.gbPaso3);
            this.Controls.Add(this.gbPaso2);
            this.Controls.Add(this.gbPaso1);
            this.Controls.Add(this.lblTituloPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicus - Gestión de Turnos";
            this.Load += new System.EventHandler(this.frmTurnos_Load);
            this.gbPaso1.ResumeLayout(false);
            this.gbPaso1.PerformLayout();
            this.gbPaso2.ResumeLayout(false);
            this.gbPaso2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicos)).EndInit();
            this.gbPaso3.ResumeLayout(false);
            this.gbPaso3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDias)).EndInit();
            this.gbPaso4.ResumeLayout(false);
            this.gbPaso4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHorarios)).EndInit();
            this.groupBoxConfirmacion.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTituloPrincipal;
        private System.Windows.Forms.GroupBox gbPaso1;
        private System.Windows.Forms.ComboBox cmbEspecialidad;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label lblPaciente;
        private System.Windows.Forms.GroupBox gbPaso2;
        private System.Windows.Forms.DataGridView dgvMedicos;
        private System.Windows.Forms.Label lblMedicoSeleccionado;
        private System.Windows.Forms.GroupBox gbPaso3;
        private System.Windows.Forms.DataGridView dgvDias;
        private System.Windows.Forms.Label lblDiaSeleccionado;
        private System.Windows.Forms.GroupBox gbPaso4;
        private System.Windows.Forms.Label lblHoraSeleccionada;
        private System.Windows.Forms.DataGridView dgvHorarios;
        private System.Windows.Forms.GroupBox groupBoxConfirmacion;
        private System.Windows.Forms.Button btnImprimirRecibo;
        private System.Windows.Forms.Button btnConfirmarTurno;
        private System.Windows.Forms.Button btnTurnos;
    }
}