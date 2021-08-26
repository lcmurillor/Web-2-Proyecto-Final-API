using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsBodega
    {
        public String accion { get; set; }
        public int pidbodega { get; set; }
        public string pnombre { get; set; }
        public string pubicacion { get; set; }
        public int pidempresa { get; set; }
        public String pestado { get; set; }
    }
}