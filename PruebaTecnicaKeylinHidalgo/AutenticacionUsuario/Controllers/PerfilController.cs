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
    public class PerfilController : ApiController
    {
        public RespuestaModel GetPerfil(string token)
        {
            string tokenSesion = HttpContext.Current.Session["token"].ToString();

            if (!string.IsNullOrEmpty(tokenSesion) & token.Equals(tokenSesion))
            {
                return new RespuestaModel { correcto = true, perfil = (PerfilModel)HttpContext.Current.Session["perfil"] };
            }
            else
            {
                return new RespuestaModel { correcto = false, resultado = "Token inválido" };
            }
        }
    }
}
