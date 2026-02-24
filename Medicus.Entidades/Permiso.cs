using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Medicus.Entidades
{
    public class Permiso
    {
        public int IdPermiso { get; set; }
        public int IdGrupo { get; set; }
        public string NombreMenu { get; set; }
        public bool PuedeVer { get; set; }
        public bool PuedeCrear { get; set; }
        public bool PuedeEditar { get; set; }
        public bool PuedeEliminar { get; set; }
        public DateTime? FechaRegistro { get; set; }
    }
}