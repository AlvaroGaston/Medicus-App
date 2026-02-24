using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;
using Medicus.Entidades;

namespace Medicus.BLL
{
    public class TurnoBLL
    {
        private TurnoDAL dalTurno = new TurnoDAL();

        public List<Turno> ListarTurnos() => dalTurno.ListarTurnos();

        public string AgregarTurno(Turno obj)
        {
            if (obj.IdPaciente == 0 || obj.IdMedico == 0)
                return "Debe seleccionar un paciente y un médico para asignar el turno.";

            // Acá está la validación fuerte
            if (dalTurno.ExisteTurno(obj.IdMedico, obj.FechaTurno, obj.HoraTurno))
                return "El médico seleccionado ya tiene un turno asignado en esa fecha y horario.";

            return dalTurno.AgregarTurno(obj) ? "OK" : "Error al registrar el turno.";
        }

        public string ModificarTurno(Turno obj)
        {
            if (obj.IdPaciente == 0 || obj.IdMedico == 0)
                return "Debe seleccionar un paciente y un médico.";

            // Le pasamos el IdTurno para que no dé error si se está guardando a sí mismo en el mismo horario
            if (dalTurno.ExisteTurno(obj.IdMedico, obj.FechaTurno, obj.HoraTurno, obj.IdTurno))
                return "El médico seleccionado ya tiene OTRO turno asignado en esa fecha y horario.";

            return dalTurno.ModificarTurno(obj) ? "OK" : "Error al actualizar el turno.";
        }

        public string CambiarEstado(int idTurno, string estado)
        {
            return dalTurno.CambiarEstado(idTurno, estado) ? "OK" : "Error al cambiar el estado del turno.";
        }
    }
}