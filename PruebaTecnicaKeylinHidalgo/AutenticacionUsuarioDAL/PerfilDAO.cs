using AutenticacionUsuarioCommon;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutenticacionUsuarioDAL
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// Fecha de creación: 31/03/2013 14:23:16.
    /// Creador: Sergio-PC\Sergio.
    /// Modificaciones:
    ///     Fecha       Autor      Descripción
    ///     
    /// </remarks>
    public class PerfilDAO
    {
        #region Constructores
        public PerfilDAO() { }
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
            Perfil perfilRespuesta = new Perfil();
            try
            {
                DataSet dsPerfil = new DataSet();

                Database baseDatos = DatabaseFactory.CreateDatabase("SQLConectionString");
                DbCommand comando = baseDatos.GetStoredProcCommand("sp_ConsultarPerfil");
                baseDatos.AddInParameter(comando, "sId", DbType.String, sId);
                baseDatos.AddInParameter(comando, "sPassword", DbType.String, sPassword);

                baseDatos.LoadDataSet(comando, dsPerfil, "Perfil");

                if (dsPerfil != null & dsPerfil.Tables.Count != 0 & dsPerfil.Tables[0].Rows.Count != 0)
                {
                    perfilRespuesta.sNombre = dsPerfil.Tables[0].Rows[0]["sNombre"].ToString();
                    perfilRespuesta.sApellidos = dsPerfil.Tables[0].Rows[0]["sApellidos"].ToString();
                    perfilRespuesta.sDireccion = dsPerfil.Tables[0].Rows[0]["sDireccion"].ToString();
                    perfilRespuesta.sEmail = dsPerfil.Tables[0].Rows[0]["sEmail"].ToString();
                    perfilRespuesta.sTelefono = dsPerfil.Tables[0].Rows[0]["sTelefono"].ToString();
                }
            }
            catch (Exception ex)
            {
                //bool relanzar = ExceptionPolicy.HandleException(ex, "AccesoDatosPolicy");
                //if (relanzar) throw;
            }

            return perfilRespuesta;
        }
        #endregion
    }//Fin de la clase.
}