using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.Entidades;



namespace Medicus.BLL
{
    public static class Sesion
    {
        public static Usuario UsuarioActual { get; set; }
        public static List<Permiso> PermisosActuales { get; set; }

        public static void CerrarSesion()
        {
            UsuarioActual = null;
            PermisosActuales = null;
        }

        public static bool HaySesionActiva()
        {
            return UsuarioActual != null;
        }
    }
}