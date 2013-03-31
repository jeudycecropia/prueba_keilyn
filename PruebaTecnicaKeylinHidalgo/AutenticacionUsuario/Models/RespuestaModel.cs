using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    public class RespuestaModel
    {
        public RespuestaModel(){}

        public RespuestaModel(bool correcto, string resultado, PerfilModel perfil)
        {
            this.correcto = correcto;
            this.resultado = resultado;
            this.perfil = perfil;
        }

        public bool correcto { get; set; }
        public string resultado { get; set; }
        public PerfilModel perfil { get; set; }
    }
}