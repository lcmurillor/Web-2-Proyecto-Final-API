using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsUsuario
    {
        public String accion { get; set; }
        public String pnombre { get; set; }
        public String pclave { get; set; }
        public int pidempleado { get; set; } // Campo que envia una idempleado y recibe un idusuario
        public String prol { get; set; }
        public String pestado { get; set; }
    }
}