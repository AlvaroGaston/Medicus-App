using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Medicus.DAL;
using Medicus.Entidades;



namespace Medicus.BLL
{
    public class SeguridadBLL
    {
        private PermisoDAL dalPermiso = new PermisoDAL();

        public List<Grupo> ListarGrupos() => dalPermiso.ListarGrupos();
        public List<Permiso> ListarPermisos(int idGrupo) => dalPermiso.ListarPermisos(idGrupo);

        public void GuardarPermisos(List<Permiso> lista)
        {
            foreach (var p in lista) dalPermiso.GuardarPermiso(p);

            // Si la lista tiene elementos, tomamos el ID del grupo del primer elemento para el log
            if (lista.Count > 0)
            {
                BitacoraBLL.RegistrarMovimiento($"Actualizó la matriz de permisos del Grupo ID: {lista[0].IdGrupo}", "Seguridad");
            }
        }

        // Agregá estos métodos a tu SeguridadBLL.cs
        public string ModificarRol(int idGrupo, string nuevoNombre)
        {
            if (string.IsNullOrWhiteSpace(nuevoNombre)) return "El nombre no puede estar vacío.";

            bool exito = dalPermiso.ModificarNombreGrupo(idGrupo, nuevoNombre);
            if (exito)
            {
                BitacoraBLL.RegistrarMovimiento($"Cambió el nombre del Rol ID: {idGrupo} a {nuevoNombre}", "Seguridad");
                return "OK";
            }
            return "Error al intentar modificar el nombre.";
        }

        public string EliminarRol(int idGrupo)
        {
            // 1. Validación Crítica: ¿Hay usuarios usando este rol?
            if (dalPermiso.GrupoTieneUsuarios(idGrupo))
            {
                return "No se puede eliminar el rol porque existen usuarios asignados a él. Reasigne a los usuarios antes de borrar.";
            }

            // 2. Si está limpio, procedemos a borrar permisos y luego el grupo
            bool exito = dalPermiso.EliminarGrupoYPermisos(idGrupo);
            if (exito)
            {
                BitacoraBLL.RegistrarMovimiento($"Eliminó el Rol ID: {idGrupo}", "Seguridad");
                return "OK";
            }
            return "Error al intentar eliminar el rol.";
        }

        public string CrearRol(string nombreRol)
        {
            if (string.IsNullOrWhiteSpace(nombreRol)) return "El nombre del rol no puede estar vacío.";

            try
            {
                bool exito = dalPermiso.CrearGrupoYPermisos(nombreRol);
                if (exito)
                {
                    BitacoraBLL.RegistrarMovimiento($"Creó un nuevo rol llamado: {nombreRol}", "Seguridad");
                    return "OK";
                }
                return "Error al crear el rol.";
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("UNIQUE")) return "Ya existe un rol con ese nombre.";
                return ex.Message;
            }
        }

        public void AplicarPermisosPantalla(Form formulario, string nombreMenu, List<Permiso> permisosActuales)
        {
            if (Sesion.UsuarioActual?.Documento?.Trim().ToLower() == "admin") return;

            var permiso = permisosActuales?.FirstOrDefault(p => p.NombreMenu == nombreMenu);

            if (permiso == null || !permiso.PuedeVer)
            {
                MessageBox.Show("No tiene los privilegios necesarios para acceder a este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                formulario.BeginInvoke(new MethodInvoker(formulario.Close));
                return;
            }

            foreach (Control ctrl in formulario.Controls) EvaluarControles(ctrl, permiso);
        }

        private void EvaluarControles(Control ctrl, Permiso permiso)
        {
            if (ctrl is Button btn)
            {
                if (btn.Name.Contains("Guardar") || btn.Name.Contains("Nuevo") || btn.Name.Contains("Crear"))
                    btn.Enabled = permiso.PuedeCrear;
                else if (btn.Name.Contains("Editar") || btn.Name.Contains("Actualizar") || btn.Name.Contains("Modificar"))
                    btn.Enabled = permiso.PuedeEditar;
                else if (btn.Name.Contains("Eliminar") || btn.Name.Contains("Borrar") || btn.Name.Contains("Baja"))
                    btn.Enabled = permiso.PuedeEliminar;
            }

            if (ctrl.HasChildren)
            {
                foreach (Control hijo in ctrl.Controls) EvaluarControles(hijo, permiso);
            }
        }
    }
}