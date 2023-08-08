using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace pokedex_web
{
    public partial class Favoritos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["trainee"] == null)
            {
                Session.Add("Error", "No hay ninguna sesión abierta.");
                Response.Redirect("Login.aspx");
               
            }


        }
    }
}