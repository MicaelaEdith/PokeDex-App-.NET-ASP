using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

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
                Session.Add("isAdmin", true);
                
            }

        }

        protected void btnAdministrar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaPokemons.aspx");
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            try
            {
                TraineeNegocio negocio = new TraineeNegocio();
                string ruta = Server.MapPath("./Imagenes/");
                Trainee user = (Trainee)Session["trainee"];
                txtFile.PostedFile.SaveAs(ruta + "perfil-" + user.Id+".jpg");
                string traineeImg = ruta + "perfil-" + user.Id + ".jpg";
               
                user.ImgPerfil= "perfil-" + user.Id + ".jpg";
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                //user.FechaNacimiento = txtFechaNacimiento.Text;

                negocio.actualizar(user);

                Image img=(Image)Master.FindControl("imgPerfil");
                img.ImageUrl = "~/Imagenes/"+user.ImgPerfil;



            }
            catch (Exception ex)
            {

                Session.Add("Error", ex.ToString());
            }

        }
    }
}