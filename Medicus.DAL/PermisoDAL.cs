using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Medicus.Entidades;

namespace Medicus.DAL
{
    public class PermisoDAL
    {
        // 1. LISTAR TODOS LOS GRUPOS (ROLES)
        public List<Grupo> ListarGrupos()
        {
            List<Grupo> lista = new List<Grupo>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT IdGrupo, Nombre FROM Grupo", cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Grupo
                        {
                            IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                            Nombre = dr["Nombre"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        // 2. LISTAR PERMISOS DE UN GRUPO ESPECÍFICO
        public List<Permiso> ListarPermisos(int idGrupo)
        {
            List<Permiso> lista = new List<Permiso>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Permiso WHERE IdGrupo = @id", cn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Permiso
                        {
                            IdPermiso = Convert.ToInt32(dr["IdPermiso"]),
                            IdGrupo = Convert.ToInt32(dr["IdGrupo"]),
                            NombreMenu = dr["NombreMenu"].ToString(),
                            PuedeVer = Convert.ToBoolean(dr["PuedeVer"]),
                            PuedeCrear = Convert.ToBoolean(dr["PuedeCrear"]),
                            PuedeEditar = Convert.ToBoolean(dr["PuedeEditar"]),
                            PuedeEliminar = Convert.ToBoolean(dr["PuedeEliminar"])
                        });
                    }
                }
            }
            return lista;
        }

        // 3. GUARDAR CAMBIOS EN LA MATRIZ DE PERMISOS
        public bool GuardarPermiso(Permiso obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = @"UPDATE Permiso SET PuedeVer = @v, PuedeCrear = @c, PuedeEditar = @e, PuedeEliminar = @d 
                                 WHERE IdPermiso = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@v", obj.PuedeVer);
                cmd.Parameters.AddWithValue("@c", obj.PuedeCrear);
                cmd.Parameters.AddWithValue("@e", obj.PuedeEditar);
                cmd.Parameters.AddWithValue("@d", obj.PuedeEliminar);
                cmd.Parameters.AddWithValue("@id", obj.IdPermiso);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 4. CREAR NUEVO ROL Y SUS PERMISOS BASE
        public bool CrearGrupoYPermisos(string nombreGrupo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Iniciamos la transacción para asegurar que se cree el grupo Y los permisos
                SqlTransaction trx = cn.BeginTransaction();
                try
                {
                    // 1. Insertar el Grupo y obtener el ID generado
                    SqlCommand cmdGrupo = new SqlCommand("INSERT INTO Grupo (Nombre) VALUES (@nom); SELECT SCOPE_IDENTITY();", cn, trx);
                    cmdGrupo.Parameters.AddWithValue("@nom", nombreGrupo);

                    // Convert.ToInt32 falla si SCOPE_IDENTITY devuelve null, usamos decimal primero por seguridad de SQL
                    int idNuevoGrupo = Convert.ToInt32(cmdGrupo.ExecuteScalar());

                    // 2. Lista de formularios que DEBEN tener una entrada en la matriz de permisos
                    // Asegurate de que estos nombres coincidan con los que usas en el resto del sistema
                    string[] formularios = { "frmPacientes", "frmMedicos", "frmTurnos", "frmSeguridad", "frmBitacora", "frmReportes"};

                    foreach (string form in formularios)
                    {
                        SqlCommand cmdPermiso = new SqlCommand(
                            "INSERT INTO Permiso (IdGrupo, NombreMenu, PuedeVer, PuedeCrear, PuedeEditar, PuedeEliminar) " +
                            "VALUES (@idG, @nomM, 0, 0, 0, 0)", cn, trx);

                        cmdPermiso.Parameters.AddWithValue("@idG", idNuevoGrupo);
                        cmdPermiso.Parameters.AddWithValue("@nomM", form);

                        cmdPermiso.ExecuteNonQuery();
                    }

                    trx.Commit(); // Si llegó acá, todo salió bien
                    return true;
                }
                catch (Exception)
                {
                    trx.Rollback(); // Si hubo cualquier error, deshacemos todo
                    return false;
                }
            }
        }

        // 5. MODIFICAR NOMBRE DE UN ROL
        public bool ModificarNombreGrupo(int id, string nombre)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("UPDATE Grupo SET Nombre = @nom WHERE IdGrupo = @id", cn);
                cmd.Parameters.AddWithValue("@nom", nombre);
                cmd.Parameters.AddWithValue("@id", id);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        // 6. VALIDAR SI UN ROL TIENE USUARIOS ASIGNADOS (PARA BORRADO SEGURO)
        public bool GrupoTieneUsuarios(int idGrupo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Usuario WHERE IdGrupo = @id", cn);
                cmd.Parameters.AddWithValue("@id", idGrupo);
                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        // 7. ELIMINAR ROL Y SUS PERMISOS (TRANSACCIONAL)
        public bool EliminarGrupoYPermisos(int idGrupo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlTransaction trx = cn.BeginTransaction();
                try
                {
                    // Primero borramos la matriz de permisos
                    SqlCommand cmd1 = new SqlCommand("DELETE FROM Permiso WHERE IdGrupo = @id", cn, trx);
                    cmd1.Parameters.AddWithValue("@id", idGrupo);
                    cmd1.ExecuteNonQuery();

                    // Luego borramos el grupo
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM Grupo WHERE IdGrupo = @id", cn, trx);
                    cmd2.Parameters.AddWithValue("@id", idGrupo);
                    cmd2.ExecuteNonQuery();

                    trx.Commit();
                    return true;
                }
                catch
                {
                    trx.Rollback();
                    return false;
                }
            }
        }
    }
}