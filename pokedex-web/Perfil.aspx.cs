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
            if (Session["trainee"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                Trainee trainee = (Trainee)Session["trainee"];
                Admin();
            }  
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Default.aspx");
        }

        private void Admin()
        {
            if (((Dominio.Trainee)Session["trainee"]).Admin)
            {
                btnAdministrar.Visible = true;
                Session.Add("isAdmin", true);
                
            }

        }

        protected void btnAdministrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPokemons.aspx");
        }
    }
}