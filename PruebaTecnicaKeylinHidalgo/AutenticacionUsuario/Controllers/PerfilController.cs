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
    /// Controlador para el perfil del usuario
    /// </summary>
    public class PerfilController : ApiController
    {
        [System.Web.Http.HttpGet]
        /// <summary>
        /// Método get para obtener el perfil del usuario
        /// </summary>
        /// <param name="token">Token generado en el login</param>
        /// <returns>Perfil que coincida con el token generado</returns>
        public RespuestaModel GetPerfil(string token)
        {
            //Token de la sesión
            string tokenSesion = HttpContext.Current.Session["token"].ToString();

            //Si el token es correcto
            if (!string.IsNullOrEmpty(tokenSesion) & token.Equals(tokenSesion))
            {
                //Se retorna el perfil de la sesión
                return new RespuestaModel { correcto = true, perfil = (PerfilModel)HttpContext.Current.Session["perfil"] };
            }
            else
            {
                //Se retorna el mensaje de error
                return new RespuestaModel { correcto = false, resultado = "Token inválido" };
            }
        }
    }
}
