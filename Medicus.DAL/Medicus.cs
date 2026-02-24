using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Medicus.Entidades;

namespace Medicus.DAL
{
    public class TurnoDAL
    {
        public List<Turno> ListarTurnos()
        {
            List<Turno> lista = new List<Turno>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Usamos JOIN para traer el nombre del paciente y del médico
                string query = @"SELECT t.IdTurno, t.IdPaciente, t.IdMedico, t.FechaTurno, t.HoraTurno, t.Motivo, t.Estado,
                                        p.Nombre + ' ' + p.Apellido AS PacienteNombre, p.Dni AS PacienteDni,
                                        m.Nombre + ' ' + m.Apellido AS MedicoNombre, m.Especialidad
                                 FROM Turno t
                                 INNER JOIN Paciente p ON t.IdPaciente = p.IdPaciente
                                 INNER JOIN Medico m ON t.IdMedico = m.IdMedico
                                 ORDER BY t.FechaTurno DESC, t.HoraTurno DESC";

                SqlCommand cmd = new SqlCommand(query, cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Turno
                        {
                            IdTurno = Convert.ToInt32(dr["IdTurno"]),
                            IdPaciente = Convert.ToInt32(dr["IdPaciente"]),
                            IdMedico = Convert.ToInt32(dr["IdMedico"]),
                            FechaTurno = Convert.ToDateTime(dr["FechaTurno"]),
                            HoraTurno = (TimeSpan)dr["HoraTurno"],
                            Motivo = dr["Motivo"].ToString(),
                            Estado = dr["Estado"].ToString(),
                            PacienteNombre = dr["PacienteNombre"].ToString(),
                            PacienteDni = dr["PacienteDni"].ToString(),
                            MedicoNombre = dr["MedicoNombre"].ToString(),
                            Especialidad = dr["Especialidad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        // VALIDACIÓN DE SOBRETURNO
        public bool ExisteTurno(int idMedico, DateTime fecha, TimeSpan hora, int idTurnoExcluir = 0)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Busca si el médico ya tiene un turno en esa fecha y hora exacta, que no esté Cancelado
                string query = "SELECT COUNT(1) FROM Turno WHERE IdMedico = @idMed AND FechaTurno = @fec AND HoraTurno = @hora AND Estado != 'Cancelado' AND IdTurno != @idExcluir";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idMed", idMedico);
                cmd.Parameters.AddWithValue("@fec", fecha);
                cmd.Parameters.AddWithValue("@hora", hora);
                cmd.Parameters.AddWithValue("@idExcluir", idTurnoExcluir); // Sirve por si estamos editando el mismo turno

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool AgregarTurno(Turno obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "INSERT INTO Turno (IdPaciente, IdMedico, FechaTurno, HoraTurno, Motivo, Estado) VALUES (@idP, @idM, @fec, @hora, @mot, 'Pendiente')";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idP", obj.IdPaciente);
                cmd.Parameters.AddWithValue("@idM", obj.IdMedico);
                cmd.Parameters.AddWithValue("@fec", obj.FechaTurno);
                cmd.Parameters.AddWithValue("@hora", obj.HoraTurno);
                cmd.Parameters.AddWithValue("@mot", obj.Motivo);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool ModificarTurno(Turno obj)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Turno SET IdPaciente = @idP, IdMedico = @idM, FechaTurno = @fec, HoraTurno = @hora, Motivo = @mot WHERE IdTurno = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idP", obj.IdPaciente);
                cmd.Parameters.AddWithValue("@idM", obj.IdMedico);
                cmd.Parameters.AddWithValue("@fec", obj.FechaTurno);
                cmd.Parameters.AddWithValue("@hora", obj.HoraTurno);
                cmd.Parameters.AddWithValue("@mot", obj.Motivo);
                cmd.Parameters.AddWithValue("@id", obj.IdTurno);
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CambiarEstado(int idTurno, string nuevoEstado)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = "UPDATE Turno SET Estado = @est WHERE IdTurno = @id";
                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@est", nuevoEstado);
                cmd.Parameters.AddWithValue("@id", idTurno);
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}