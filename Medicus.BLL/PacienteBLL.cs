using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;
using Medicus.Entidades;



namespace Medicus.BLL
{
    public class PacienteBLL
    {
        private PacienteDAL dalPaciente = new PacienteDAL();

        public List<Paciente> ListarPacientes() => dalPaciente.ListarPacientes();

        public string AgregarPaciente(Paciente obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Dni) || string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Apellido))
                return "El DNI, Nombre y Apellido son obligatorios.";

            try
            {
                bool exito = dalPaciente.AgregarPaciente(obj);
                if (exito)
                {
                    BitacoraBLL.RegistrarMovimiento($"Registró al paciente DNI: {obj.Dni}", "Pacientes");
                    return "OK";
                }
                return "Error al registrar el paciente.";
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("UNIQUE")) return "Ya existe un paciente registrado con ese DNI.";
                return ex.Message;
            }
        }

        public string ModificarPaciente(Paciente obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Apellido))
                return "El Nombre y Apellido son obligatorios.";

            bool exito = dalPaciente.ModificarPaciente(obj);
            if (exito)
            {
                BitacoraBLL.RegistrarMovimiento($"Modificó los datos del paciente DNI: {obj.Dni}", "Pacientes");
                return "OK";
            }
            return "Error al actualizar el paciente.";
        }

        public string EliminarPaciente(int idPaciente)
        {
            try
            {
                bool exito = dalPaciente.EliminarPaciente(idPaciente);
                if (exito)
                {
                    BitacoraBLL.RegistrarMovimiento($"Eliminó al paciente ID: {idPaciente}", "Pacientes");
                    return "OK";
                }
                return "Error al eliminar el paciente.";
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("REFERENCE") || ex.Message.Contains("FOREIGN KEY"))
                    return "No se puede eliminar este paciente porque tiene historial o turnos asociados.";
                return ex.Message;
            }
        }
    }
}
