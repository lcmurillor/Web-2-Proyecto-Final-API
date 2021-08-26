using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsEmpleado
    {
        public String accion { get; set; }
        public int pidempleado { get; set; }
        public int pidsucursal { get; set; }
        public int pidempresa { get; set; }
        public String pcedula { get; set; } // Campo que envia una cedula y recibe un idPersona
        public String ppuesto { get; set; }
        public String pestado { get; set; }
    }
}