using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{ 
    public class UsuarioNegocio
    {

    AccesoDatos datos = new AccesoDatos();
         public bool Loguear(Usuario usuario)
        {
            try
            {
                datos.setearConsulta("Select Id, TipoUser from USUARIOS where usuario=@user AND pass=@pass");
                datos.setearParametro("@user", usuario.User);
                datos.setearParametro("@pass", usuario.Pass);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Normal;
                    return true;
                }
                return false;
            }
            catch (Exception ex)    
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
            
            }
    }
}
