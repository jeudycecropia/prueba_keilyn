using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    /// <summary>
    /// Modelo con los atributos del perfil
    /// </summary>
    public class PerfilModel
    {
        /// <summary>
        /// Constructor default
        /// </summary>
        public PerfilModel(){}

        /// <summary>
        /// Constructor con los atributos del perfil
        /// </summary>
        /// <param name="sNombre">Nombre del usuario</param>
        /// <param name="sApellidos">Apellidos del usuario</param>
        /// <param name="sEmail">Email del usuario</param>
        /// <param name="sDireccion">Dirección del usuario</param>
        /// <param name="sTelefono">Teléfono del usuario</param>
        public PerfilModel(string sNombre, string sApellidos, string sEmail, string sDireccion, string sTelefono)
        {
            this.sNombre = sNombre;
            this.sApellidos = sApellidos;
            this.sEmail = sEmail;
            this.sDireccion = sDireccion;
            this.sTelefono = sTelefono;
        }

        //Atributos de la clase
        public string sId { get; set; }
        public string sPassword { get; set; }
        public string sNombre { get; set; }
        public string sApellidos { get; set; }
        public string sEmail { get; set; }
        public string sDireccion { get; set; }
        public string sTelefono { get; set; }
    }
}