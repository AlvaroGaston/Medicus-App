using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Medicus.Entidades;

namespace Medicus.DAL
{
    public class BitacoraDAL
    {
        public void Registrar(Bitacora obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Bitacora (IdUsuario, UsuarioNombre, Accion, Modulo) VALUES (@idUsu, @nom, @acc, @mod)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idUsu", obj.IdUsuario);
                cmd.Parameters.AddWithValue("@nom", obj.UsuarioNombre);
                cmd.Parameters.AddWithValue("@acc", obj.Accion);
                cmd.Parameters.AddWithValue("@mod", obj.Modulo);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Bitacora> Listar(DateTime? fechaFiltro = null)
        {
            List<Bitacora> lista = new List<Bitacora>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdBitacora, IdUsuario, UsuarioNombre, Accion, Modulo, Fecha FROM Bitacora";

                if (fechaFiltro.HasValue)
                {
                    query += " WHERE CAST(Fecha AS DATE) = @fec";
                }

                query += " ORDER BY Fecha DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                if (fechaFiltro.HasValue) cmd.Parameters.AddWithValue("@fec", fechaFiltro.Value.Date);

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Bitacora
                        {
                            IdBitacora = Convert.ToInt32(dr["IdBitacora"]),
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            UsuarioNombre = dr["UsuarioNombre"].ToString(),
                            Accion = dr["Accion"].ToString(),
                            Modulo = dr["Modulo"].ToString(),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }
            return lista;
        }
    }
}