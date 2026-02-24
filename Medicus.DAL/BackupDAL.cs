using System;
using System.Data.SqlClient;

namespace Medicus.DAL
{
    public class BackupDAL
    {
        public void RealizarBackup(string rutaDestino)
        {
            string nombreArchivo = $"Medicus_Full_{DateTime.Now:yyyyMMdd_HHmm}.bak";
            string rutaCompleta = System.IO.Path.Combine(rutaDestino, nombreArchivo);

            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // Usamos COMPRESSION para ahorrar espacio y CHECKSUM para validar integridad
                string query = $@"BACKUP DATABASE [MedicusDB2_0] 
                                 TO DISK = '{rutaCompleta}' 
                                 WITH FORMAT, COMPRESSION, CHECKSUM, NAME = 'Medicus Full Backup';";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
        }

        public void RestaurarBackup(string rutaArchivo)
        {
            using (SqlConnection cn = ConexionDB.ObtenerConexion())
            {
                // 1. Forzamos la desconexión de otros usuarios para poder restaurar
                // 2. Restauramos la base de datos
                // 3. Devolvemos la base a modo multiusuario
                string query = $@"
                    USE master;
                    ALTER DATABASE [MedicusDB2_0] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
                    RESTORE DATABASE [MedicusDB2_0] FROM DISK = '{rutaArchivo}' WITH REPLACE;
                    ALTER DATABASE [MedicusDB2_0] SET MULTI_USER;";

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.ExecuteNonQuery();
            }
        }
    }
}