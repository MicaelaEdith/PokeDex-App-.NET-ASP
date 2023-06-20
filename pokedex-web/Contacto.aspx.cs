using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace pokedex_web
{
    public partial class Contacto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnContacto_Click(object sender, EventArgs e)
        {
            EmailService emailService = new EmailService();
            emailService.armarCorreo(txtEmailContacto.Text, txtAsunto.Text, txtMensaje.Text);

            try
            {
                emailService.enviarEmail();
                Response.Redirect("Default.aspx");
            }
            catch (Exception ex)
            {

                Session.Add("Error: ",ex);
                Response.Redirect("Default.aspx");

            }

        }
    }
}