using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsArticulo
    {
        public String accion { get; set; }
        public int pidarticulo { get; set; }
        public int pidproveedor { get; set; }
        public int pidcategoria { get; set; }
        public String pdescripcion { get; set; }
        public String pestado { get; set; }
    }
}