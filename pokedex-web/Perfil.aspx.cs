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
            try
            {
                if (!IsPostBack)
                {
                    if (Session["trainee"] == null)
                    {
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        Trainee trainee = (Trainee)Session["trainee"];
                        Admin();
                        txtEmail.Text = trainee.Email.ToString();
                        txtNombre.Text = trainee.Nombre != null ? trainee.Nombre.ToString() : null;
                        txtApellido.Text = trainee.Apellido !=null ? trainee.Apellido.ToString() : null;
                        txtFechaNacimiento.Text = trainee.FechaNacimiento != null ? trainee.FechaNacimiento.ToString("yyyy-MM-dd") : null; 

                    }  

                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex.ToString());
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
                Trainee user = (Trainee)Session["trainee"];

                if (txtFile.PostedFile.FileName != "") { 
                
                    string ruta = Server.MapPath("./Imagenes/");
                    txtFile.PostedFile.SaveAs(ruta + "perfil-" + user.Id+".jpg");
                    //string traineeImg = ruta + "perfil-" + user.Id + ".jpg";
                    user.ImgPerfil= "perfil-" + user.Id + ".jpg";
                }
             
                user.Nombre = txtNombre.Text;
                user.Apellido = txtApellido.Text;
                user.FechaNacimiento =DateTime.Parse(txtFechaNacimiento.Text);

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