using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Medicus.Entidades
{
    public class Bitacora
    {
        public int IdBitacora { get; set; }
        public int IdUsuario { get; set; }
        public string UsuarioNombre { get; set; }
        public string Accion { get; set; }
        public string Modulo { get; set; }
        public DateTime Fecha { get; set; }
    }
}