using AutenticacionUsuario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AutenticacionUsuario.Controllers
{
    /// <summary>
    /// Clase para el deslogueo del usuario
    /// </summary>
    public class LogoutController : ApiController
    {
        [System.Web.Http.HttpDelete]
        /// <summary>
        /// Realiza el borrado de los datos de la sesión para desloguear al usuario
        /// </summary>
        /// <param name="token">Cadena generada durante el login del usuario</param>
        /// <returns>Indica si el deslogueo fue exitoso</returns>
        public RespuestaModel DeleteLogout(string token)
        {
            //Token de la sesión
            string tokenSesion = HttpContext.Current.Session["token"].ToString();

            //Si el token solicitado y el de la sesión son iguales
            if (!string.IsNullOrEmpty(tokenSesion) & token.Equals(tokenSesion))
            {
                //Se borran los datos de sesión
                HttpContext.Current.Session.Remove("perfil");
                HttpContext.Current.Session.Remove("token");

                return new RespuestaModel { correcto = true };
            }
            else
            {
                return new RespuestaModel { correcto = false, resultado = "Token inválido." };
            }
        }
    }
}
