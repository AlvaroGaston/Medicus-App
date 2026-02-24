using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Medicus.Entidades
{
    public class Medico
    {
        public int IdMedico { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Especialidad { get; set; }
        public string Matricula { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        // --- NUEVOS CAMPOS DE AGENDA ---
        public string DiasAtencion { get; set; }
        public TimeSpan? HoraInicio { get; set; }
        public TimeSpan? HoraFin { get; set; }
        public int? DuracionTurno { get; set; }
    }
}