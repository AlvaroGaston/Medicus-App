using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;

namespace Medicus.BLL
{
    public class DashboardBLL
    {
        private DashboardDAL dalDashboard = new DashboardDAL();

        public int ObtenerTotalPacientes() => dalDashboard.ObtenerTotalPacientes();
        public int ObtenerTotalMedicos() => dalDashboard.ObtenerTotalMedicos();
        public Dictionary<string, int> ObtenerTurnosPorEspecialidad() => dalDashboard.ObtenerTurnosPorEspecialidad();
        public Dictionary<string, int> ObtenerTurnosPorEstado() => dalDashboard.ObtenerTurnosPorEstado();
    }
}