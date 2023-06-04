using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace pokedex_web
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (Session["usuario"] == null)
            {
                Session.Add("Error", "No hay ninguna sesión abierta.");
                Response.Redirect("Login.aspx");
                Admin();
            }
            else   
                Admin();
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session["usuario"] = null;
            Response.Redirect("Default.aspx");
        }

        private void Admin()
        {
            if (((Dominio.Usuario)Session["usuario"]).TipoUsuario == Dominio.TipoUsuario.Admin)
            {
                btnAdministrar.Visible = true;
                
            }

        }

        protected void btnAdministrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Administrar.aspx");
        }
    }
}