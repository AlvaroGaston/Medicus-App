using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Medicus.Entidades;



namespace Medicus.DAL
{
    public class UsuarioDAL
    {
        public Usuario Login(string documento, string claveEncriptada)
        {
            Usuario user = null;
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Solo dejamos entrar a usuarios con Estado = 1 (Activos)
                string query = "SELECT IdUsuario, Documento, NombreCompleto, Correo, Clave, Estado, IdGrupo FROM Usuario WHERE Documento = @doc AND Clave = @clave AND Estado = 1";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@clave", claveEncriptada);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        user = new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : "",
                            Clave = dr["Clave"].ToString(),
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            IdGrupo = dr["IdGrupo"] != DBNull.Value ? Convert.ToInt32(dr["IdGrupo"]) : (int?)null
                        };
                    }
                }
            }
            return user;
        }
        // Método para verificar si ya existe alguien con ese DNI o Correo
        public bool ExisteUsuario(string documento, string correo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT COUNT(1) FROM Usuario WHERE Documento = @doc OR Correo = @correo";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@correo", correo);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Método para insertar el usuario nuevo
        public bool CrearUsuario(Usuario user)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Insertamos el usuario. Por seguridad, nace con Estado = 1 (Activo) pero sin Rol asignado (NULL)
                string query = @"INSERT INTO Usuario (Documento, NombreCompleto, Correo, Clave, Estado) 
                                 VALUES (@doc, @nom, @correo, @clave, 1)";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@doc", user.Documento);
                cmd.Parameters.AddWithValue("@nom", user.NombreCompleto);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@clave", user.Clave); // Acá llega ya encriptada

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Verifica que el Documento y el Correo coincidan con un usuario real
        public bool VerificarUsuarioParaRecupero(string documento, string correo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT COUNT(1) FROM Usuario WHERE Documento = @doc AND Correo = @correo AND Estado = 1";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@doc", documento);
                cmd.Parameters.AddWithValue("@correo", correo);

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // Actualiza la contraseña en la base de datos
        public bool ActualizarClave(string documento, string nuevaClaveEncriptada)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Usuario SET Clave = @clave WHERE Documento = @doc";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@clave", nuevaClaveEncriptada);
                cmd.Parameters.AddWithValue("@doc", documento);

                return cmd.ExecuteNonQuery() > 0;
            }
        }
        // Trae todos los usuarios para la grilla
        public List<Usuario> ListarUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdUsuario, Documento, NombreCompleto, Correo, Estado, IdGrupo FROM Usuario";
                SqlCommand cmd = new SqlCommand(query, cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            Documento = dr["Documento"].ToString(),
                            NombreCompleto = dr["NombreCompleto"].ToString(),
                            Correo = dr["Correo"] != DBNull.Value ? dr["Correo"].ToString() : "",
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            IdGrupo = dr["IdGrupo"] != DBNull.Value ? Convert.ToInt32(dr["IdGrupo"]) : (int?)null
                        });
                    }
                }
            }
            return lista;
        }

        // Edita un usuario (No toca la clave)
        public bool ModificarUsuario(Usuario user)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Usuario SET NombreCompleto = @nom, Correo = @correo, IdGrupo = @idGrp WHERE IdUsuario = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", user.NombreCompleto);
                cmd.Parameters.AddWithValue("@correo", user.Correo);
                cmd.Parameters.AddWithValue("@idGrp", (object)user.IdGrupo ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@id", user.IdUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // Cambia el estado (Activo/Inactivo)
        public bool CambiarEstado(int idUsuario, bool nuevoEstado)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Usuario SET Estado = @est WHERE IdUsuario = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@est", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}