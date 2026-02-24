using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Medicus.BLL;
using Medicus.Entidades;

namespace Medicus.UX
{
    public partial class frmSeguridad : Form
    {
        private SeguridadBLL bllSeguridad = new SeguridadBLL();

        public frmSeguridad()
        {
            InitializeComponent();
        }

        private void frmSeguridad_Load(object sender, EventArgs e)
        {
            // Aplicar seguridad a la propia pantalla
            bllSeguridad.AplicarPermisosPantalla(this, "frmSeguridad", Sesion.PermisosActuales);
            CargarListaGrupos();
        }

        private void CargarListaGrupos()
        {
            lstGrupos.DataSource = null;
            lstGrupos.DataSource = bllSeguridad.ListarGrupos();
            lstGrupos.DisplayMember = "Nombre";
            lstGrupos.ValueMember = "IdGrupo";
        }

        private void lstGrupos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem != null)
            {
                Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;
                dgvPermisos.DataSource = bllSeguridad.ListarPermisos(seleccionado.IdGrupo);

                // Formatear grilla de permisos
                if (dgvPermisos.Columns["IdPermiso"] != null) dgvPermisos.Columns["IdPermiso"].Visible = false;
                if (dgvPermisos.Columns["IdGrupo"] != null) dgvPermisos.Columns["IdGrupo"].Visible = false;
            }
        }

        private void btnNuevoRol_Click(object sender, EventArgs e)
        {
            // Usamos un InputBox sencillo para el nombre (requiere referencia a Microsoft.VisualBasic)
            string nombreRol = Microsoft.VisualBasic.Interaction.InputBox("Ingrese el nombre del nuevo rol:", "Nuevo Rol", "");

            if (!string.IsNullOrWhiteSpace(nombreRol))
            {
                string msj = bllSeguridad.CrearRol(nombreRol);
                if (msj == "OK")
                {
                    MessageBox.Show("Rol creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarRol_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;

            if (seleccionado.Nombre.ToLower() == "admin")
            {
                MessageBox.Show("No se puede renombrar el rol de Administrador por seguridad.", "Protección del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            string nuevoNombre = Microsoft.VisualBasic.Interaction.InputBox("Modificar nombre del rol:", "Editar Rol", seleccionado.Nombre);

            if (!string.IsNullOrWhiteSpace(nuevoNombre) && nuevoNombre != seleccionado.Nombre)
            {
                string msj = bllSeguridad.ModificarRol(seleccionado.IdGrupo, nuevoNombre);
                if (msj == "OK")
                {
                    MessageBox.Show("Nombre del rol actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminarRol_Click(object sender, EventArgs e)
        {
            if (lstGrupos.SelectedItem == null) return;
            Grupo seleccionado = (Grupo)lstGrupos.SelectedItem;

            if (seleccionado.Nombre.ToLower() == "admin")
            {
                MessageBox.Show("El rol de Administrador es vital y no puede ser eliminado.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            var confirm = MessageBox.Show($"¿Está seguro que desea eliminar el rol '{seleccionado.Nombre}'?\nEsta acción borrará también toda su matriz de permisos asociada.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                string msj = bllSeguridad.EliminarRol(seleccionado.IdGrupo);
                if (msj == "OK")
                {
                    MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarListaGrupos();
                }
                else MessageBox.Show(msj, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnGuardarPermisos_Click(object sender, EventArgs e)
        {
            if (dgvPermisos.Rows.Count > 0)
            {
                List<Permiso> lista = (List<Permiso>)dgvPermisos.DataSource;
                bllSeguridad.GuardarPermisos(lista);
                MessageBox.Show("Matriz de permisos actualizada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}