using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsCliente
    {
        public String accion { get; set; }
        public int pidcliente { get; set; } 
        public String pcedula { get; set; } // Campo que envia una cedula y recibe un idPersona
        public String pcorreo { get; set; }
        public String ptelefono { get; set; }
        public String pestado { get; set; }
    }
}