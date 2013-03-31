using AutenticacionUsuarioCommon;
using AutenticacionUsuarioDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutenticacionUsuarioBL
{
    /// <summary>
    /// Acceso a datos de perfil
    /// </summary>
    public class PerfilBL
    {
        #region Constructores
        public PerfilBL() { }
        #endregion

        #region Métodos
         /// <summary>
        /// Consulta si un usuario existe y trae su perfil
        /// </summary>
        /// <param name="sId">Id del usuario</param>
        /// <param name="sPassword">Password del usuario</param>
        /// <returns>Retorna los datos del perfil</returns>
        public Perfil ConsultarPerfil(string sId, string sPassword)
        {
            return new PerfilDAO().ConsultarPerfil(sId, sPassword);
        }
        #endregion
    }//Fin de la clase.
}