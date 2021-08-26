using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class articuloController
    {

        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public String MantenimientoArticulo(clsArticulo articulo)
        {
            String url = urlBase + "sparticulo/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(articulo);
                writer.Write(json);
                writer.Flush();
                writer.Close();
            }
            WebResponse res = req.GetResponse();
            using (var oSR = new StreamReader(res.GetResponseStream()))
            {
                result = oSR.ReadToEnd().Trim();
            }
            return result;
        }

        public dynamic GetArticulos()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("articulo/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsArticulo GetArticulo(int id)
        {
            string url = urlBase + "articulo/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsArticulo articulo = new clsArticulo
                {
                    accion = "",
                    pidarticulo = (json["idarticulo"]),
                    pidproveedor = (json["idproveedor"]),
                    pidcategoria = (json["idcategoria"]),
                    pdescripcion = (json["descripcion"]),
                    pestado = (json["estado"])
                };
                return articulo;
            }

            return new clsArticulo();
        }
    }
}
