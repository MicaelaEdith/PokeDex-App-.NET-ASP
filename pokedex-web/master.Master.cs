using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace pokedex_web
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["trainee"] != null)
            {
                if (((Trainee)Session["trainee"]).ImgPerfil != null)
                    imgPerfil.ImageUrl = "~/Imagenes/" + ((Trainee)Session["trainee"]).ImgPerfil;
                else
                    imgPerfil.ImageUrl = "~/Imagenes/face-id.svg";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}