using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    public class PerfilModel
    {
        public PerfilModel(){}
        public PerfilModel(string sNombre, string sApellidos, string sEmail, string sDireccion, string sTelefono)
        {
            this.sNombre = sNombre;
            this.sApellidos = sApellidos;
            this.sEmail = sEmail;
            this.sDireccion = sDireccion;
            this.sTelefono = sTelefono;
        }

        public string sId { get; set; }
        public string sPassword { get; set; }
        public string sNombre { get; set; }
        public string sApellidos { get; set; }
        public string sEmail { get; set; }
        public string sDireccion { get; set; }
        public string sTelefono { get; set; }
    }
}