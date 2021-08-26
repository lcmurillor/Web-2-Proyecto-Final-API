using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionAPI.Modelos
{
    public class clsInventario
    {
        public String accion { get; set; }
        public int pidinventario { get; set; }
        public int pidempresa { get; set; }
        public int pidsucursal { get; set; }
        public int pidarticulo { get; set; }
        public int pcantidad { get; set; }
        public int pmaximo { get; set; }
        public int pminimo { get; set; }
        public DateTime pcaducidad { get; set; }
        public String pestado { get; set; }
        public decimal pprecio { get; set; }
    }
}