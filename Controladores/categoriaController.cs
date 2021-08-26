using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class categoriaController
    {
        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public String MantenimientoCategoria(clsCategoria categoria)
        {
            String url = urlBase + "spcategoria/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(categoria);
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

        public dynamic GetCategorias()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("categoria/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsCategoria GetCategoria(int id)
        {
            string url = urlBase + "categoria/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsCategoria categoria = new clsCategoria
                {
                    accion = "",
                    pidcategoria = (json["idcategoria"]),
                    pdescripcion = (json["descripcion"]),
                    pestado = (json["estado"])
                };
                return categoria;
            }

            return new clsCategoria();
        }
    }
}
