using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AutenticacionUsuario.Controllers
{
    public class LogoutController : ApiController
    {
        public bool DeletePerfil(string token)
        {
            string tokenSesion = HttpContext.Current.Session["token"].ToString();
            if (!string.IsNullOrEmpty(tokenSesion) & token.Equals(tokenSesion))
            {
                HttpContext.Current.Session.Remove("token");
                HttpContext.Current.Session.Remove("perfil");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
