using AutenticacionUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace AutenticacionUsuario.Controllers
{
    //[System.Web.Http.Authorize]
    public class LoginController : ApiController
    {
        PerfilModel[] perfilesModel = new PerfilModel[]
        {
            new PerfilModel
            {
                sId = "khidalgo",
                sPassword = "123abc",
                sNombre = "Keylin",
                sApellidos = "Hidalgo Barrios",
                sEmail = "keylin@gmail.com",
                sDireccion = "Cartago",
                sTelefono = "8877665544"
            },
            new PerfilModel
            {
                sId = "lblanco",
                sPassword = "abcdef",
                sNombre = "Lorenzo",
                sApellidos = "Blanco Fonseca",
                sEmail = "lorenzo@gmail.com",
                sDireccion = "San Jose",
                sTelefono = "22274567"
            }
        }; 

        //[HttpPost]
        public RespuestaModel PostLogin(LoginModel login)
        {
            //string id = "khidalgo"; 
            //string password = "123abc";
            //Match id
            var perfilUsuario = perfilesModel.FirstOrDefault((p) => p.sId == login.sId);
            var session = HttpContext.Current.Session;

            RespuestaModel respuesta;
            if (perfilUsuario == null)
            {
                respuesta = new RespuestaModel { resultado = false, mensaje = "Usuario no existe" };
            }
            else
            {
                //Match password
                PerfilModel[] perfilesFiltradosUsuario = new PerfilModel[] { (PerfilModel)perfilUsuario };

                var perfilFiltradoUsuario = perfilesFiltradosUsuario.FirstOrDefault((p) => p.sPassword == login.sPassword);

                if (perfilFiltradoUsuario == null)
                {
                    respuesta = new RespuestaModel { resultado = false, mensaje = "Password incorrecto" };
                }
                else
                {
                    string tokenGenerado = new Random().Next(1, 999999999).ToString() + RandomString(4);

                    ////Se sube a sesión lo necesario para autenticar al usuario
                    //session["perfil"] = perfilFiltradoUsuario;
                    //session["token"] = tokenGenerado;

                    respuesta = new RespuestaModel { resultado = true, token = tokenGenerado };
                }
            }

            return respuesta;
        }

        private static string RandomString(int size)
        {
            Random _rng = new Random();
            string _chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] buffer = new char[size];

            for (int i = 0; i < size; i++)
            {
                buffer[i] = _chars[_rng.Next(_chars.Length)];
            }
            return new string(buffer);
        }

    }
}
