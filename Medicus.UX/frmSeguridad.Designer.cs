namespace Medicus.UX
{
    partial class frmSeguridad
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
            this.groupBoxRoles = new System.Windows.Forms.GroupBox();
            this.btnEliminarRol = new System.Windows.Forms.Button();
            this.btnEditarRol = new System.Windows.Forms.Button();
            this.btnNuevoRol = new System.Windows.Forms.Button();
            this.lstGrupos = new System.Windows.Forms.ListBox();
            this.groupBoxPermisos = new System.Windows.Forms.GroupBox();
            this.btnGuardarPermisos = new System.Windows.Forms.Button();
            this.dgvPermisos = new System.Windows.Forms.DataGridView();
            this.groupBoxRoles.SuspendLayout();
            this.groupBoxPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(298, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configuración de Seguridad";
            // 
            // groupBoxRoles
            // 
            this.groupBoxRoles.Controls.Add(this.btnEliminarRol);
            this.groupBoxRoles.Controls.Add(this.btnEditarRol);
            this.groupBoxRoles.Controls.Add(this.btnNuevoRol);
            this.groupBoxRoles.Controls.Add(this.lstGrupos);
            this.groupBoxRoles.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxRoles.Location = new System.Drawing.Point(25, 70);
            this.groupBoxRoles.Name = "groupBoxRoles";
            this.groupBoxRoles.Size = new System.Drawing.Size(280, 450);
            this.groupBoxRoles.TabIndex = 1;
            this.groupBoxRoles.TabStop = false;
            this.groupBoxRoles.Text = "Roles del Sistema";
            // 
            // btnEliminarRol
            // 
            this.btnEliminarRol.BackColor = System.Drawing.Color.LightCoral;
            this.btnEliminarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEliminarRol.Location = new System.Drawing.Point(185, 395);
            this.btnEliminarRol.Name = "btnEliminarRol";
            this.btnEliminarRol.Size = new System.Drawing.Size(80, 35);
            this.btnEliminarRol.TabIndex = 3;
            this.btnEliminarRol.Text = "Eliminar";
            this.btnEliminarRol.UseVisualStyleBackColor = false;
            this.btnEliminarRol.Click += new System.EventHandler(this.btnEliminarRol_Click);
            // 
            // btnEditarRol
            // 
            this.btnEditarRol.BackColor = System.Drawing.Color.LightGray;
            this.btnEditarRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEditarRol.Location = new System.Drawing.Point(100, 395);
            this.btnEditarRol.Name = "btnEditarRol";
            this.btnEditarRol.Size = new System.Drawing.Size(80, 35);
            this.btnEditarRol.TabIndex = 2;
            this.btnEditarRol.Text = "Renombrar";
            this.btnEditarRol.UseVisualStyleBackColor = false;
            this.btnEditarRol.Click += new System.EventHandler(this.btnEditarRol_Click);
            // 
            // btnNuevoRol
            // 
            this.btnNuevoRol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(183)))), ((int)(((byte)(42)))));
            this.btnNuevoRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoRol.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnNuevoRol.ForeColor = System.Drawing.Color.White;
            this.btnNuevoRol.Location = new System.Drawing.Point(15, 395);
            this.btnNuevoRol.Name = "btnNuevoRol";
            this.btnNuevoRol.Size = new System.Drawing.Size(80, 35);
            this.btnNuevoRol.TabIndex = 1;
            this.btnNuevoRol.Text = "Nuevo";
            this.btnNuevoRol.UseVisualStyleBackColor = false;
            this.btnNuevoRol.Click += new System.EventHandler(this.btnNuevoRol_Click);
            // 
            // lstGrupos
            // 
            this.lstGrupos.FormattingEnabled = true;
            this.lstGrupos.ItemHeight = 17;
            this.lstGrupos.Location = new System.Drawing.Point(15, 30);
            this.lstGrupos.Name = "lstGrupos";
            this.lstGrupos.Size = new System.Drawing.Size(250, 344);
            this.lstGrupos.TabIndex = 0;
            this.lstGrupos.SelectedIndexChanged += new System.EventHandler(this.lstGrupos_SelectedIndexChanged);
            // 
            // groupBoxPermisos
            // 
            this.groupBoxPermisos.Controls.Add(this.btnGuardarPermisos);
            this.groupBoxPermisos.Controls.Add(this.dgvPermisos);
            this.groupBoxPermisos.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.groupBoxPermisos.Location = new System.Drawing.Point(320, 70);
            this.groupBoxPermisos.Name = "groupBoxPermisos";
            this.groupBoxPermisos.Size = new System.Drawing.Size(650, 450);
            this.groupBoxPermisos.TabIndex = 2;
            this.groupBoxPermisos.TabStop = false;
            this.groupBoxPermisos.Text = "Matriz de Permisos";
            // 
            // btnGuardarPermisos
            // 
            this.btnGuardarPermisos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(119)))), ((int)(((byte)(242)))));
            this.btnGuardarPermisos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarPermisos.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardarPermisos.ForeColor = System.Drawing.Color.White;
            this.btnGuardarPermisos.Location = new System.Drawing.Point(435, 395);
            this.btnGuardarPermisos.Name = "btnGuardarPermisos";
            this.btnGuardarPermisos.Size = new System.Drawing.Size(200, 35);
            this.btnGuardarPermisos.TabIndex = 1;
            this.btnGuardarPermisos.Text = "Guardar Cambios Matriz";
            this.btnGuardarPermisos.UseVisualStyleBackColor = false;
            this.btnGuardarPermisos.Click += new System.EventHandler(this.btnGuardarPermisos_Click);
            // 
            // dgvPermisos
            // 
            this.dgvPermisos.AllowUserToAddRows = false;
            this.dgvPermisos.AllowUserToDeleteRows = false;
            this.dgvPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPermisos.Location = new System.Drawing.Point(15, 30);
            this.dgvPermisos.Name = "dgvPermisos";
            this.dgvPermisos.Size = new System.Drawing.Size(620, 344);
            this.dgvPermisos.TabIndex = 0;
            // 
            // frmSeguridad
            // 
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.groupBoxPermisos);
            this.Controls.Add(this.groupBoxRoles);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seguridad - Medicus";
            this.Load += new System.EventHandler(this.frmSeguridad_Load);
            this.groupBoxRoles.ResumeLayout(false);
            this.groupBoxPermisos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox groupBoxRoles;
        private System.Windows.Forms.ListBox lstGrupos;
        private System.Windows.Forms.Button btnNuevoRol;
        private System.Windows.Forms.Button btnEditarRol;
        private System.Windows.Forms.Button btnEliminarRol;
        private System.Windows.Forms.GroupBox groupBoxPermisos;
        private System.Windows.Forms.DataGridView dgvPermisos;
        private System.Windows.Forms.Button btnGuardarPermisos;
    }
}