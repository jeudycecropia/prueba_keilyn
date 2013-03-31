using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutenticacionUsuario.Models
{
    /// <summary>
    /// Modelo de las respuestas de los métodos
    /// </summary>
    public class RespuestaModel
    {
        /// <summary>
        /// Constructor default
        /// </summary>
        public RespuestaModel(){}

        /// <summary>
        /// Constructor con los atributos
        /// </summary>
        /// <param name="correcto">Indica si la transacción fue exitosa.</param>
        /// <param name="resultado">Mensaje de error, en caso que la transacción fallara.</param>
        /// <param name="perfil">Perfil del usuario, en caso que la transacción sea exitosa.</param>
        public RespuestaModel(bool correcto, string resultado, PerfilModel perfil)
        {
            this.correcto = correcto;
            this.resultado = resultado;
            this.perfil = perfil;
        }
        
        //Atributos de la clase
        public bool correcto { get; set; }
        public string resultado { get; set; }
        public PerfilModel perfil { get; set; }
    }
}