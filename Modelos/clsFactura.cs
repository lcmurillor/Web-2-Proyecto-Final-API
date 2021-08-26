using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsFactura
    {
        public String accion { get; set; }
        public int pidfactura { get; set; }
        public int pnumerofactura { get; set; }
        public DateTime pfecha { get; set; }
        public int pidempleado { get; set; }
        public int pidsucursal { get; set; }
        public int pidempresa { get; set; }
        public int pidcliente { get; set; }
        public string ptipo { get; set; }
        public String pestado { get; set; }
    }
}