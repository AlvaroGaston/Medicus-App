using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;
using Medicus.Entidades;

namespace Medicus.BLL
{
    public static class BitacoraBLL
    {
        private static BitacoraDAL dalBitacora = new BitacoraDAL();

        // Método estático para usarlo en cualquier lado fácilmente
        public static void RegistrarMovimiento(string accion, string modulo)
        {
            // Validamos que haya una sesión activa
            if (!Sesion.HaySesionActiva()) return;

            Bitacora obj = new Bitacora
            {
                IdUsuario = Sesion.UsuarioActual.IdUsuario,
                UsuarioNombre = Sesion.UsuarioActual.NombreCompleto,
                Accion = accion,
                Modulo = modulo
            };

            dalBitacora.Registrar(obj);
        }

        public static List<Bitacora> ListarBitacora(DateTime? fecha = null)
        {
            return dalBitacora.Listar(fecha);
        }
    }
}