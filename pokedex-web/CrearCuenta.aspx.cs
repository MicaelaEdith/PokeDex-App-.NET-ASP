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
    public partial class CrearCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword1.Text == txtPassword2.Text)
                {

                    Trainee user = new Trainee();
                    TraineeNegocio traineeNegocio = new TraineeNegocio();

                    user.Email = txtUser.Text;
                    user.Pass = txtPassword2.Text;
                    user.Id = traineeNegocio.insertarNuevo(user);
                    Session.Add("trainee", user);

                    Response.Redirect("Default.aspx");
                }
                else
                    lblErrorPass.Visible = true;
            }
            catch (Exception ex)
            {

                Session.Add("Error ", ex.ToString());
                throw;
            }
        }
    }
}