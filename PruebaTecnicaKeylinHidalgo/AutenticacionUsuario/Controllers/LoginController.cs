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
    /// <summary>
    /// Controlador para manejar el login
    /// </summary>
    public class LoginController : ApiController
    {
        PerfilModel[] perfilesModel = new PerfilModel[]
        {
            new PerfilModel
            {
                sId = "k",
                sPassword = "1",
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

        [System.Web.Http.HttpPost]
        /// <summary>
        /// Método post para el login del usuario
        /// </summary>
        /// <param name="login">Credenciales del usuario</param>
        /// <returns>Token si la transacción es correcta, en su defecto retorna mensaje de error.</returns>
        public RespuestaModel PostLogin(PerfilModel login)
        {
            //Usuarios con el id igual al solicitado
            var perfilUsuario = perfilesModel.FirstOrDefault((p) => p.sId == login.sId);
            //Se llama a la sesión
            var session = HttpContext.Current.Session;

            //Si no hay usuarios con ese id
            if (perfilUsuario == null)
            {
                //Retornar mensaje de error
                return new RespuestaModel { correcto = false, resultado = "Usuario no existe" };
            }
            else
            {
                //Usuarios filtrados previamente por el id, ahora se filtran por el password
                PerfilModel[] perfilesFiltradosUsuario = new PerfilModel[] { (PerfilModel)perfilUsuario };
                var perfilFiltradoUsuario = perfilesFiltradosUsuario.FirstOrDefault((p) => p.sPassword == login.sPassword);

                //Si no hay usuarios con ese password
                if (perfilFiltradoUsuario == null)
                {
                    //Retornar mensaje de error
                    return new RespuestaModel { correcto = false, resultado = "Password incorrecto" };
                }
                else
                {
                    //Se genera un token para el usuario
                    string tokenGenerado = new Random().Next(1, 999999999).ToString() + RandomString(4);

                    //Se sube a sesión lo necesario para autenticar al usuario
                    session["perfil"] = perfilFiltradoUsuario;
                    session["token"] = tokenGenerado;

                    //Se retorna el token
                    return new RespuestaModel { correcto = true, resultado = tokenGenerado };
                }
            }
        }

        /// <summary>
        /// Generador de las letras del token
        /// </summary>
        /// <param name="size">Cantidad de letras deseadas</param>
        /// <returns>Cadena aleatoria generada</returns>
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
