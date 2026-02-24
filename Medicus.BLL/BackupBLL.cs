using Medicus.DAL;
using System;

namespace Medicus.BLL
{
    public class BackupBLL
    {
        private BackupDAL dalBackup = new BackupDAL();

        // Método principal para crear el respaldo
        public void GenerarCopiaSeguridad(string ruta)
        {
            dalBackup.RealizarBackup(ruta);
            // Registro en bitácora para seguridad de la clínica
            BitacoraBLL.RegistrarMovimiento("Generó un respaldo completo de la base de datos", "Sistema");
        }

        // Método para recuperar los datos
        public void RestaurarSistema(string archivo)
        {
            dalBackup.RestaurarBackup(archivo);
            BitacoraBLL.RegistrarMovimiento("Restauración total del sistema realizada con éxito", "Sistema");
        }
    }
}