using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class inventarioController
    {
        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public String MantenimientoInventario(clsInventario inventario)
        {
            String url = urlBase + "spinventario/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(inventario);
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

        public dynamic GetInventarios()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("inventario/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsInventario GetInventario(int id)
        {
            string url = urlBase + "inventario/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsInventario inventario = new clsInventario
                {
                    accion = "",
                    pidinventario = (json["idinventario"]),
                    pidempresa = (json["idempresa"]),
                    pidsucursal = (json["idsucursal"]),
                    pidarticulo = (json["idarticulo"]),
                    pcantidad = (json["cantidad"]),
                    pprecio = (json["preciounit"]),
                    pmaximo = (json["maximo"]),
                    pminimo = (json["minimo"]),
                    pcaducidad = (json["caducidad"]),
                    pestado = (json["estado"])
                };
                return inventario;
            }

            return new clsInventario();
        }
    }
}
