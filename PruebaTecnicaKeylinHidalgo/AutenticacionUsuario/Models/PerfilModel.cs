using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    public class PerfilModel
    {
        public string sId { get; set; }
        public string sPassword { get; set; }
        public string sNombre { get; set; }
        public string sApellidos { get; set; }
        public string sEmail { get; set; }
        public string sDireccion { get; set; }
        public string sTelefono { get; set; }
    }
}