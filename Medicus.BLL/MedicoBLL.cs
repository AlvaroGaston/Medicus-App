using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medicus.DAL;
using Medicus.Entidades;



namespace Medicus.BLL
{
    public class MedicoBLL
    {
        private MedicoDAL dalMedico = new MedicoDAL();

        public List<Medico> ListarMedicos() => dalMedico.ListarMedicos();

        public string AgregarMedico(Medico obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Apellido) ||
                string.IsNullOrWhiteSpace(obj.Especialidad) || string.IsNullOrWhiteSpace(obj.Matricula))
            {
                return "El Nombre, Apellido, Especialidad y Matrícula son obligatorios.";
            }

            try
            {
                bool exito = dalMedico.AgregarMedico(obj);
                if (exito)
                {
                    BitacoraBLL.RegistrarMovimiento($"Registró al médico Matrícula: {obj.Matricula}", "Médicos");
                    return "OK";
                }
                return "Error al registrar el médico.";
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("UNIQUE")) return "Ya existe un médico registrado con esa Matrícula.";
                return ex.Message;
            }
        }

        public string ModificarMedico(Medico obj)
        {
            if (string.IsNullOrWhiteSpace(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Apellido) || string.IsNullOrWhiteSpace(obj.Especialidad))
                return "El Nombre, Apellido y Especialidad son obligatorios.";

            try
            {
                bool exito = dalMedico.ModificarMedico(obj);
                if (exito)
                {
                    BitacoraBLL.RegistrarMovimiento($"Modificó los datos del médico ID: {obj.IdMedico}", "Médicos");
                    return "OK";
                }
                return "Error al actualizar el médico.";
            }
            catch (System.Exception ex)
            {
                if (ex.Message.Contains("UNIQUE")) return "La Matrícula ingresada ya pertenece a otro médico.";
                return ex.Message;
            }
        }

        public string CambiarEstado(int idMedico, bool estado)
        {
            bool exito = dalMedico.CambiarEstado(idMedico, estado);
            if (exito)
            {
                string txtEstado = estado ? "Activo" : "Inactivo";
                BitacoraBLL.RegistrarMovimiento($"Cambió el estado del médico ID: {idMedico} a {txtEstado}", "Médicos");
                return "OK";
            }
            return "Error al cambiar el estado del médico.";
        }
    }
}