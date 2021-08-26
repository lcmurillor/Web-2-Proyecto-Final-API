using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class personaController
    {
        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public dynamic GetPersonas()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("persona/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsPersona GetPersona(string id)
        {
            string url = urlBase + "persona/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsPersona persona = new clsPersona
                {
                    idpersona = (json["idpersona"]),
                    cedula = (json["cedula"]),
                    nombre = (json["nombre"]),
                    apellido1 = (json["apellido1"]),
                    apellido2 = (json["apellido2"]),
                    estado = (json["estado"])
                };
                return persona;
            }

            return new clsPersona();
        }
    }
}
