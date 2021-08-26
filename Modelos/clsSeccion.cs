using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsSeccion
    {
        public String accion { get; set; }
        public int pidseccion { get; set; }
        public int pidbodega { get; set; }
        public String pdescripcion { get; set; }
        public String pestado { get; set; }
    }
}