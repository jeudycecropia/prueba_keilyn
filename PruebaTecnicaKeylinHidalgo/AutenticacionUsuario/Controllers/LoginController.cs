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
using AutenticacionUsuarioCommon;
using AutenticacionUsuarioBL;

namespace AutenticacionUsuario.Controllers
{
    /// <summary>
    /// Controlador para manejar el login
    /// </summary>
    public class LoginController : ApiController
    {
        [System.Web.Http.HttpPost]
        /// <summary>
        /// Método post para el login del usuario
        /// </summary>
        /// <param name="login">Credenciales del usuario</param>
        /// <returns>Token si la transacción es correcta, en su defecto retorna mensaje de error.</returns>
        public RespuestaModel PostLogin(Perfil login)
        {
            //Consulta a base de datos para obtener el perfil solicitado
            Perfil perfilUsuario = new PerfilBL().ConsultarPerfil(login.sId, login.sPassword);

            //Se llama a la sesión
            var session = HttpContext.Current.Session;

            //Si no hay usuarios con ese id
            if (perfilUsuario == null || string.IsNullOrEmpty(perfilUsuario.sNombre))
            {
                //Retornar mensaje de error
                return new RespuestaModel { correcto = false, resultado = "Usuario no existe" };
            }
            else
            {
                //Se genera un token para el usuario
                string tokenGenerado = new Random().Next(1, 999999999).ToString() + RandomString(4);

                //Se sube a sesión lo necesario para autenticar al usuario
                session["perfil"] = perfilUsuario;
                session["token"] = tokenGenerado;

                //Se retorna el token
                return new RespuestaModel { correcto = true, resultado = tokenGenerado };
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
