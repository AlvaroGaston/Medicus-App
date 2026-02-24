using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;



namespace Medicus.DAL
{
    public class ConexionDB
    {
        // Apuntamos directo a tu nueva base MedicusDB2_0
        private static readonly string cadena = "Server=localhost; Database=MedicusDB2_0; Integrated Security=True;";

        public static SqlConnection ObtenerConexion()
        {
            SqlConnection cn = new SqlConnection(cadena);
            cn.Open();
            return cn;
        }
    }
}