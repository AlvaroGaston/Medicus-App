using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Medicus.Entidades;



namespace Medicus.DAL
{
    public class MedicoDAL
    {
        public List<Medico> ListarMedicos()
        {
            List<Medico> lista = new List<Medico>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdMedico, Nombre, Apellido, Especialidad, Matricula, Telefono, Estado, DiasAtencion, HoraInicio, HoraFin, DuracionTurno FROM Medico";
                SqlCommand cmd = new SqlCommand(query, cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Medico
                        {
                            IdMedico = Convert.ToInt32(dr["IdMedico"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            Especialidad = dr["Especialidad"].ToString(),
                            Matricula = dr["Matricula"].ToString(),
                            Telefono = dr["Telefono"] != DBNull.Value ? dr["Telefono"].ToString() : "",
                            Estado = Convert.ToBoolean(dr["Estado"]),
                            DiasAtencion = dr["DiasAtencion"] != DBNull.Value ? dr["DiasAtencion"].ToString() : "",
                            HoraInicio = dr["HoraInicio"] != DBNull.Value ? (TimeSpan?)dr["HoraInicio"] : null,
                            HoraFin = dr["HoraFin"] != DBNull.Value ? (TimeSpan?)dr["HoraFin"] : null,
                            DuracionTurno = dr["DuracionTurno"] != DBNull.Value ? Convert.ToInt32(dr["DuracionTurno"]) : (int?)null
                        });
                    }
                }
            }
            return lista;
        }

        public bool AgregarMedico(Medico obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = @"INSERT INTO Medico (Nombre, Apellido, Especialidad, Matricula, Telefono, Estado, DiasAtencion, HoraInicio, HoraFin, DuracionTurno) 
                                 VALUES (@nom, @ape, @esp, @mat, @tel, 1, @dias, @hIni, @hFin, @dur)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", obj.Nombre);
                cmd.Parameters.AddWithValue("@ape", obj.Apellido);
                cmd.Parameters.AddWithValue("@esp", obj.Especialidad);
                cmd.Parameters.AddWithValue("@mat", obj.Matricula);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@dias", obj.DiasAtencion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hIni", obj.HoraInicio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hFin", obj.HoraFin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dur", obj.DuracionTurno ?? (object)DBNull.Value);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarMedico(Medico obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = @"UPDATE Medico SET Nombre = @nom, Apellido = @ape, Especialidad = @esp, Matricula = @mat, Telefono = @tel,
                                 DiasAtencion = @dias, HoraInicio = @hIni, HoraFin = @hFin, DuracionTurno = @dur WHERE IdMedico = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", obj.Nombre);
                cmd.Parameters.AddWithValue("@ape", obj.Apellido);
                cmd.Parameters.AddWithValue("@esp", obj.Especialidad);
                cmd.Parameters.AddWithValue("@mat", obj.Matricula);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@dias", obj.DiasAtencion ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hIni", obj.HoraInicio ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@hFin", obj.HoraFin ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@dur", obj.DuracionTurno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@id", obj.IdMedico);

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CambiarEstado(int idMedico, bool nuevoEstado)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Medico SET Estado = @est WHERE IdMedico = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@est", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idMedico);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}