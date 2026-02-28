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
            // lblFiltroFecha
            // 
            this.lblFiltroFecha.AutoSize = true;
            this.lblFiltroFecha.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFiltroFecha.Location = new System.Drawing.Point(680, 25);
            this.lblFiltroFecha.Name = "lblFiltroFecha";
            this.lblFiltroFecha.Size = new System.Drawing.Size(117, 19);
            this.lblFiltroFecha.TabIndex = 1;
            this.lblFiltroFecha.Text = "Agenda del Día:";
            // 
            // dtpFechaFiltro
            // 
            this.dtpFechaFiltro.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpFechaFiltro.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFiltro.Location = new System.Drawing.Point(800, 22);
            this.dtpFechaFiltro.Name = "dtpFechaFiltro";
            this.dtpFechaFiltro.Size = new System.Drawing.Size(160, 25);
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
            this.dgvTurnosDelDia.Location = new System.Drawing.Point(20, 70);
            this.dgvTurnosDelDia.Name = "dgvTurnosDelDia";
            this.dgvTurnosDelDia.ReadOnly = true;
            this.dgvTurnosDelDia.RowHeadersVisible = false;
            this.dgvTurnosDelDia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnosDelDia.Size = new System.Drawing.Size(940, 460);
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
    }
}