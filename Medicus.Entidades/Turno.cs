using System;

namespace Medicus.Entidades
{
    public class Turno
    {
        public int IdTurno { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public DateTime FechaTurno { get; set; }
        public TimeSpan HoraTurno { get; set; }
        public string Motivo { get; set; }
        public string Estado { get; set; } // Pendiente, Atendido, Cancelado

        // Propiedades de navegación para las grillas
        public string PacienteNombre { get; set; }
        public string PacienteDni { get; set; }
        public string MedicoNombre { get; set; }
        public string Especialidad { get; set; }

        // Formato amigable para visualización
        public string HoraFormateada => DateTime.Today.Add(HoraTurno).ToString(@"HH\:mm");
    }
}