using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Medicus.Entidades;

namespace Medicus.DAL
{
    public class PacienteDAL
    {
        public List<Paciente> ListarPacientes()
        {
            List<Paciente> lista = new List<Paciente>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "SELECT IdPaciente, Dni, Nombre, Apellido, FechaNacimiento, Telefono, ObraSocial FROM Paciente";
                SqlCommand cmd = new SqlCommand(query, cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Paciente
                        {
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"]),
                            Dni = dr["Dni"].ToString(),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString(),
                            FechaNacimiento = Convert.ToDateTime(dr["FechaNacimiento"]),
                            Telefono = dr["Telefono"] != DBNull.Value ? dr["Telefono"].ToString() : "",
                            ObraSocial = dr["ObraSocial"] != DBNull.Value ? dr["ObraSocial"].ToString() : ""
                        });
                    }
                }
            }
            return lista;
        }

        public bool AgregarPaciente(Paciente obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Paciente (Dni, Nombre, Apellido, FechaNacimiento, Telefono, ObraSocial) VALUES (@dni, @nom, @ape, @fec, @tel, @obra)";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@dni", obj.Dni);
                cmd.Parameters.AddWithValue("@nom", obj.Nombre);
                cmd.Parameters.AddWithValue("@ape", obj.Apellido);
                cmd.Parameters.AddWithValue("@fec", obj.FechaNacimiento);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@obra", obj.ObraSocial);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarPaciente(Paciente obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Paciente SET Nombre = @nom, Apellido = @ape, FechaNacimiento = @fec, Telefono = @tel, ObraSocial = @obra WHERE IdPaciente = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@nom", obj.Nombre);
                cmd.Parameters.AddWithValue("@ape", obj.Apellido);
                cmd.Parameters.AddWithValue("@fec", obj.FechaNacimiento);
                cmd.Parameters.AddWithValue("@tel", obj.Telefono);
                cmd.Parameters.AddWithValue("@obra", obj.ObraSocial);
                cmd.Parameters.AddWithValue("@id", obj.IdPaciente);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool EliminarPaciente(int idPaciente)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "DELETE FROM Paciente WHERE IdPaciente = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@id", idPaciente);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}