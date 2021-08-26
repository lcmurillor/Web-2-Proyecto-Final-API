using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsFacturaDetalle
    {
        public String accion { get; set; }
        public int piddetallefactura { get; set; }
        public int pidfactura { get; set; }
        public int pnumerolinea { get; set; }
        public int pidarticulo { get; set; }
        public int pcantidad { get; set; }
        public decimal pprecio { get; set; }
        public int pdescuento { get; set; }
        public int pimpuesto { get; set; }
        public String pestado { get; set; }
    }
}