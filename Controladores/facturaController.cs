using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class facturaController
    {
        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public String MantenimientoFactura(clsFactura factura)
        {
            String url = urlBase + "spfactura/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(factura);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
            WebResponse res = req.GetResponse();
            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                result = reader.ReadToEnd().Trim();
            }
            return result;
        }

        public dynamic GetFacturas()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("factura/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsFactura GetFactura(int id)
        {
            string url = urlBase + "factura/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsFactura factura = new clsFactura
                {
                    accion = "",
                    pidfactura = (json["idfactura"]),
                    pidempresa = (json["idempresa"]),
                    pidsucursal = (json["idsucursal"]),
                    pnumerofactura  = (json["numerofactura"]),
                    pfecha = (json["fecha"]),
                    pidempleado = (json["idempleado"]),
                    pidcliente = (json["idcliente"]),
                    ptipo = (json["tipo"]),
                    pestado = (json["estado"])
                };
                return factura;
            }

            return new clsFactura();
        }

        //DETALLE FACTURA

        public String MantenimientoFacturaDetalle(clsFacturaDetalle detalleFactura)
        {
            String url = urlBase + "spdetallefactura/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(detalleFactura);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
            WebResponse res = req.GetResponse();
            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                result = reader.ReadToEnd().Trim();
            }
            return result;
        }

        public dynamic GetFacturaDetalles(int idFactura)
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("detallefactura/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return GetFacturaDetallexFactura(idFactura, tabla);
        }

        public clsFacturaDetalle GetFacturaDetalle(int id)
        {
            string url = urlBase + "detallefactura/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsFacturaDetalle detallefactura = new clsFacturaDetalle
                {
                    accion = "",
                    piddetallefactura = (json["iddetallefactura"]),
                    pidfactura = (json["idfactura"]),
                    pnumerolinea = (json["numerolinea"]),
                    pidarticulo = (json["idarticulo"]),
                    pcantidad = (json["cantidad"]),
                    pprecio = (json["precio"]),
                    pdescuento = (json["descuento"]),
                    pimpuesto = (json["impuesto"]),
                    pestado = (json["estado"])
                };
                return detallefactura;
            }

            return new clsFacturaDetalle();
        }

        private dynamic GetFacturaDetallexFactura(int id, dynamic tabla)
        {
            dynamic t = null;
            List<clsFacturaDetalle> detalleFactura = new List<clsFacturaDetalle>();

            foreach (var item in tabla.items)
            {
                if (item.idfactura == id)
                {
                    detalleFactura.Add(new clsFacturaDetalle
                    {
                        accion = "",
                        piddetallefactura = item.iddetallefactura,
                        pidfactura = item.idfactura,
                        pnumerolinea = item.numerolinea,
                        pidarticulo = item.idarticulo,
                        pcantidad = item.cantidad,
                        pprecio = item.precio,
                        pdescuento = item.descuento,
                        pimpuesto = item.impuesto,
                        pestado = item.estado
                    });
                }
            }

            t = detalleFactura;

            return t;
        }
    }
}
