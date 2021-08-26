using FacturacionAPI.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;

namespace FacturacionAPI.Controladores
{
    public class usuarioController
    {
        private String urlBase = "https://y5ll6xrtigvu2gk-bdfactura01.adb.us-sanjose-1.oraclecloudapps.com/ords/admin/";

        public String MantenimientoUsuario(clsUsuario usuario)
        {
            String url = urlBase + "spusuario/";
            String result = "";

            WebRequest req = WebRequest.Create(url);
            req.Method = "post";
            req.ContentType = "application/json";
            using (var writer = new StreamWriter(req.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(usuario);
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

        public dynamic GetUsuarios()
        {
            dynamic tabla = null;
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(urlBase);

            var req = http.GetAsync("usuario/").Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                tabla = JsonConvert.DeserializeObject(result);
            }

            return tabla;
        }

        public clsUsuario GetUsuario(int id)
        {
            string url = urlBase + "usuario/";
            HttpClient http = new HttpClient();
            http.BaseAddress = new Uri(url);

            var req = http.GetAsync(id.ToString()).Result;

            if (req.IsSuccessStatusCode)
            {
                var result = req.Content.ReadAsStringAsync().Result;
                dynamic json = JsonConvert.DeserializeObject(result);
                clsUsuario usuario = new clsUsuario
                {
                    accion = "",
                    pidempleado = (json["idusuario"]),
                    pnombre = (json["nombre"]),
                    pclave = (json["clave"]),
                    prol = (json["rol"]),
                    pestado = (json["estado"])
                };
                return usuario;
            }

            return new clsUsuario();
        }

        public dynamic login(string nombre, string clave)
        {
            dynamic sesion = new List<string>();
            dynamic usuarios = GetUsuarios();

            foreach (var item in usuarios.items)
            {
                if (nombre.Equals(item.nombre.ToString()) && clave.Equals(item.clave.ToString()))
                {
                    empleadoController cEmpleado = new empleadoController();
                    clsEmpleado empleado = cEmpleado.GetEmpleado(item.idempleado);
                    empresaController cEmpresa = new empresaController();
                    clsEmpresa empresa = cEmpresa.GetEmpresa(empleado.pidempresa);
                    sucursalController cSucursal = new sucursalController();
                    clsSucursal sucursal = cSucursal.GetSucursal(empleado.pidsucursal);
                    personaController cPersona = new personaController();
                    clsPersona persona = cPersona.GetPersona(empleado.pcedula);

                    sesion.Add(empresa.pnombre);
                    sesion.Add(sucursal.pnombre);
                    sesion.Add(empleado.pidempleado.ToString());
                    sesion.Add(persona.nombre.Trim() + " " + persona.apellido1.Trim());
                    sesion.Add(item.rol.ToString());
                }
            }

            return sesion;
        }
    }
}
