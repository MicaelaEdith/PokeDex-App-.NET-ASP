using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class Administrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!isAdmin())
                Response.Redirect("Perfil.aspx");

        }

        private bool isAdmin()
        {
            if (Session["usuario"] != null)
            {
                if (((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.Admin)
                    return true;
                else
                   return false;
            }
            else
                return false;

        }
    }
}