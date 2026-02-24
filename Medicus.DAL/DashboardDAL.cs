using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Medicus.DAL
{
    public class DashboardDAL
    {
        public int ObtenerTotalPacientes()
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Paciente", cn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        public int ObtenerTotalMedicos()
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Medico WHERE Estado = 1", cn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Gráfico 1: Turnos por Especialidad
        public Dictionary<string, int> ObtenerTurnosPorEspecialidad()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                string query = @"SELECT m.Especialidad, COUNT(t.IdTurno) AS Cantidad
                                 FROM Turno t INNER JOIN Medico m ON t.IdMedico = m.IdMedico
                                 GROUP BY m.Especialidad";
                SqlCommand cmd = new SqlCommand(query, cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) dict.Add(dr["Especialidad"].ToString(), Convert.ToInt32(dr["Cantidad"]));
                }
            }
            return dict;
        }

        // Gráfico 2: Turnos por Estado
        public Dictionary<string, int> ObtenerTurnosPorEstado()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT Estado, COUNT(IdTurno) AS Cantidad FROM Turno GROUP BY Estado", cn);
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read()) dict.Add(dr["Estado"].ToString(), Convert.ToInt32(dr["Cantidad"]));
                }
            }
            return dict;
        }
    }
}