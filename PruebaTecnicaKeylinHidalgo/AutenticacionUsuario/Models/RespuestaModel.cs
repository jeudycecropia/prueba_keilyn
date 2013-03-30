using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    public class RespuestaModel
    {
        public bool resultado { get; set; }
        public string mensaje { get; set; }
        public string token { get; set; }
    }
}