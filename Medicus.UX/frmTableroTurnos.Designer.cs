namespace Medicus.UX
{
    partial class frmTableroTurnos
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

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dtpFechaFiltro = new System.Windows.Forms.DateTimePicker();
            this.lblFiltroFecha = new System.Windows.Forms.Label();
            this.dgvTurnosDelDia = new System.Windows.Forms.DataGridView();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            this.btnCancelarTurno = new System.Windows.Forms.Button();
            this.btnAsistio = new System.Windows.Forms.Button();
            this.txtBuscarTurno = new System.Windows.Forms.TextBox();
            this.cmbFiltroEstado = new System.Windows.Forms.ComboBox();
            this.cmbFiltroEspecialidad = new System.Windows.Forms.ComboBox();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblEspecialidad = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDelDia)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(264, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Tablero de Recepción";
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBuscar.Location = new System.Drawing.Point(20, 55);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(205, 19);
            this.lblBuscar.TabIndex = 7;
            this.lblBuscar.Text = "Buscar por motivo o nombre:";
            // 
            // txtBuscarTurno
            // 
            this.txtBuscarTurno.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarTurno.Location = new System.Drawing.Point(20, 75);
            this.txtBuscarTurno.Name = "txtBuscarTurno";
            this.txtBuscarTurno.Size = new System.Drawing.Size(230, 25);
            this.txtBuscarTurno.TabIndex = 8;
            this.txtBuscarTurno.TextChanged += new System.EventHandler(this.txtBuscarTurno_TextChanged);
            // 
            // lblEspecialidad
            // 
            this.lblEspecialidad.AutoSize = true;
            this.lblEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEspecialidad.Location = new System.Drawing.Point(270, 55);
            this.lblEspecialidad.Name = "lblEspecialidad";
            this.lblEspecialidad.Size = new System.Drawing.Size(161, 19);
            this.lblEspecialidad.TabIndex = 11;
            this.lblEspecialidad.Text = "Filtrar por Especialidad:";
            // 
            // cmbFiltroEspecialidad
            // 
            this.cmbFiltroEspecialidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEspecialidad.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroEspecialidad.FormattingEnabled = true;
            this.cmbFiltroEspecialidad.Location = new System.Drawing.Point(270, 75);
            this.cmbFiltroEspecialidad.Name = "cmbFiltroEspecialidad";
            this.cmbFiltroEspecialidad.Size = new System.Drawing.Size(220, 25);
            this.cmbFiltroEspecialidad.TabIndex = 12;
            this.cmbFiltroEspecialidad.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEspecialidad_SelectedIndexChanged);
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblEstado.Location = new System.Drawing.Point(510, 55);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(129, 19);
            this.lblEstado.TabIndex = 9;
            this.lblEstado.Text = "Filtrar por Estado:";
            // 
            // cmbFiltroEstado
            // 
            this.cmbFiltroEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFiltroEstado.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbFiltroEstado.FormattingEnabled = true;
            this.cmbFiltroEstado.Location = new System.Drawing.Point(510, 75);
            this.cmbFiltroEstado.Name = "cmbFiltroEstado";
            this.cmbFiltroEstado.Size = new System.Drawing.Size(160, 25);
            this.cmbFiltroEstado.TabIndex = 10;
            this.cmbFiltroEstado.SelectedIndexChanged += new System.EventHandler(this.cmbFiltroEstado_SelectedIndexChanged);
            // 
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.Location = new System.Drawing.Point(690, 55);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(117, 19);
            this.lblFiltroFecha.TabIndex = 1;
            this.lblFiltroFecha.Text = "Agenda del Día:";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(690, 75);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(140, 25);
            this.dtpFechaFiltro.TabIndex = 2;
            this.dtpFechaFiltro.ValueChanged += new System.EventHandler(this.dtpFechaFiltro_ValueChanged);
            // 
            // dgvTurnosDelDia
            // 
            this.dgvTurnosDelDia.AllowUserToAddRows = false;
            this.dgvTurnosDelDia.AllowUserToDeleteRows = false;
            this.dgvTurnosDelDia.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnosDelDia.BackgroundColor = System.Drawing.Color.White;
            this.dgvTurnosDelDia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnosDelDia.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dgvTurnosDelDia.Location = new System.Drawing.Point(20, 115);
            this.dgvTurnosDelDia.Name = "dgvTurnosDelDia";
            this.dgvTurnosDelDia.ReadOnly = true;
            this.dgvTurnosDelDia.RowHeadersVisible = false;
            this.dgvTurnosDelDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnosDelDia.Size = new System.Drawing.Size(940, 420);
            this.dgvTurnosDelDia.TabIndex = 3;
            this.dgvTurnosDelDia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTurnosDelDia_CellClick);
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnNuevoTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNuevoTurno.ForeColor = System.Drawing.Color.White;
            this.btnNuevoTurno.Location = new System.Drawing.Point(20, 550);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(180, 45);
            this.btnNuevoTurno.TabIndex = 4;
            this.btnNuevoTurno.Text = "➕ Nuevo Turno";
            this.btnNuevoTurno.UseVisualStyleBackColor = false;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // btnAsistio
            // 
            this.btnAsistio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnAsistio.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsistio.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAsistio.ForeColor = System.Drawing.Color.White;
            this.btnAsistio.Location = new System.Drawing.Point(590, 550);
            this.btnAsistio.Name = "btnAsistio";
            this.btnAsistio.Size = new System.Drawing.Size(180, 45);
            this.btnAsistio.TabIndex = 5;
            this.btnAsistio.Text = "✅ Marcar Presente";
            this.btnAsistio.UseVisualStyleBackColor = false;
            this.btnAsistio.Click += new System.EventHandler(this.btnAsistio_Click);
            // 
            // btnCancelarTurno
            // 
            this.btnCancelarTurno.BackColor = System.Drawing.Color.Tomato;
            this.btnCancelarTurno.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelarTurno.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancelarTurno.ForeColor = System.Drawing.Color.White;
            this.btnCancelarTurno.Location = new System.Drawing.Point(780, 550);
            this.btnCancelarTurno.Name = "btnCancelarTurno";
            this.btnCancelarTurno.Size = new System.Drawing.Size(180, 45);
            this.btnCancelarTurno.TabIndex = 6;
            this.btnCancelarTurno.Text = "❌ Cancelar Turno";
            this.btnCancelarTurno.UseVisualStyleBackColor = false;
            this.btnCancelarTurno.Click += new System.EventHandler(this.btnCancelarTurno_Click);
            // 
            // frmTableroTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(984, 611);
            this.Controls.Add(this.cmbFiltroEspecialidad);
            this.Controls.Add(this.lblEspecialidad);
            this.Controls.Add(this.cmbFiltroEstado);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.txtBuscarTurno);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnCancelarTurno);
            this.Controls.Add(this.btnAsistio);
            this.Controls.Add(this.btnNuevoTurno);
            this.Controls.Add(this.dgvTurnosDelDia);
            this.Controls.Add(this.dtpFechaFiltro);
            this.Controls.Add(this.lblFiltroFecha);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmTableroTurnos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Medicus - Recepción";
            this.Load += new System.EventHandler(this.frmTableroTurnos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnosDelDia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DateTimePicker dtpFechaFiltro;
        private System.Windows.Forms.Label lblFiltroFecha;
        private System.Windows.Forms.DataGridView dgvTurnosDelDia;
        private System.Windows.Forms.Button btnNuevoTurno;
        private System.Windows.Forms.Button btnAsistio;
        private System.Windows.Forms.Button btnCancelarTurno;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.TextBox txtBuscarTurno;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.ComboBox cmbFiltroEstado;
        private System.Windows.Forms.Label lblEspecialidad;
        private System.Windows.Forms.ComboBox cmbFiltroEspecialidad;
    }
}