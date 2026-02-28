using System;
using System.Collections.Generic;
using System.Linq;
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

        // ========================================================
        // GESTIÓN DE ROLES (ABM)
        // ========================================================
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

        // ========================================================
        // MOTOR DE SEGURIDAD GRANULAR (PANTALLAS Y BOTONES)
        // ========================================================
        public void AplicarSeguridadGranular(Form formulario, string nombreModulo)
        {
            // 1. El Administrador Supremo tiene acceso irrestricto
            if (Sesion.UsuarioActual?.Documento?.Trim().ToLower() == "admin") return;

            // 2. Verificamos si el usuario tiene permiso para abrir la pantalla completa
            var permisoPantalla = Sesion.PermisosActuales?.FirstOrDefault(p => p.NombreMenu == nombreModulo);

            if (permisoPantalla == null || !permisoPantalla.PuedeVer)
            {
                MessageBox.Show("No tiene los privilegios necesarios para acceder a este módulo.", "Acceso Denegado", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                // Forzamos el cierre del formulario antes de que termine de cargar
                formulario.BeginInvoke(new MethodInvoker(formulario.Close));
                return;
            }

            // 3. Si puede entrar a la pantalla, evaluamos botón por botón
            EvaluarControlesGranulares(formulario.Controls);
        }

        private void EvaluarControlesGranulares(Control.ControlCollection controles)
        {
            foreach (Control c in controles)
            {
                // Entramos recursivamente en paneles, groupboxes, etc.
                if (c.HasChildren) EvaluarControlesGranulares(c.Controls);

                // Buscamos si el control (ej: "btnGuardarNuevo") existe en la lista de permisos de la Base de Datos
                var permisoControl = Sesion.PermisosActuales?.FirstOrDefault(p => p.NombreMenu == c.Name);

                if (permisoControl != null)
                {
                    // Si el control está registrado en la matriz, aplicamos la visibilidad según lo que se tildó
                    c.Visible = permisoControl.PuedeVer;
                    c.Enabled = permisoControl.PuedeVer;
                }
            }
        }
    }
}