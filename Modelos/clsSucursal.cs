using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsSucursal
    {
        public String accion { get; set; }
        public int pidsucursal { get; set; }
        public int pidempresa { get; set; }
        public String pnombre { get; set; }
        public String pubicacion { get; set; }
        public String pestado { get; set; }
    }
}