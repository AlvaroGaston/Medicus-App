using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;
using Medicus.Entidades;


namespace Medicus.BLL
{
    public class UsuarioBLL
    {
        private UsuarioDAL dalUsuario = new UsuarioDAL();

        public Usuario Login(string documento, string clave)
        {
            string claveEncriptada = Encriptador.GetSHA256(clave);
            return dalUsuario.Login(documento, claveEncriptada);
        }

        public string RegistrarUsuario(Usuario user)
        {
            if (dalUsuario.ExisteUsuario(user.Documento, user.Correo))
                return "El documento o el correo ya se encuentran registrados.";

            user.Clave = Encriptador.GetSHA256(user.Clave);
            bool exito = dalUsuario.CrearUsuario(user);

            if (exito)
            {
                // Como el registro puede ocurrir antes de loguearse (desde el frmRegistro vacío), 
                // validamos para que no tire error si Sesion es nulo.
                if (Sesion.HaySesionActiva())
                    BitacoraBLL.RegistrarMovimiento($"Registró al usuario DNI: {user.Documento}", "Usuarios");

                return "OK";
            }
            return "Ocurrió un error al intentar guardar el usuario.";
        }

        public string RecuperarClave(string documento, string correo, string nuevaClave)
        {
            if (!dalUsuario.VerificarUsuarioParaRecupero(documento, correo))
                return "Los datos ingresados no coinciden con ningún usuario activo.";

            string claveEncriptada = Encriptador.GetSHA256(nuevaClave);
            bool exito = dalUsuario.ActualizarClave(documento, claveEncriptada);

            if (exito)
            {
                if (Sesion.HaySesionActiva())
                    BitacoraBLL.RegistrarMovimiento($"Restableció la clave del usuario DNI: {documento}", "Usuarios");
                return "OK";
            }
            return "Ocurrió un error al intentar actualizar la contraseña.";
        }

        public List<Usuario> ListarUsuarios() => dalUsuario.ListarUsuarios();

        public string ModificarUsuario(Usuario user)
        {
            bool exito = dalUsuario.ModificarUsuario(user);
            if (exito)
            {
                BitacoraBLL.RegistrarMovimiento($"Editó los datos del usuario ID: {user.IdUsuario}", "Usuarios");
                return "OK";
            }
            return "Error al actualizar el usuario.";
        }

        public string CambiarEstado(int idUsuario, bool estado)
        {
            if (idUsuario == 1 && estado == false) return "No puedes desactivar al Administrador principal.";

            bool exito = dalUsuario.CambiarEstado(idUsuario, estado);
            if (exito)
            {
                string txtEstado = estado ? "Activo" : "Inactivo";
                BitacoraBLL.RegistrarMovimiento($"Cambió el estado del usuario ID: {idUsuario} a {txtEstado}", "Usuarios");
                return "OK";
            }
            return "Error al cambiar el estado.";
        }
    }
}