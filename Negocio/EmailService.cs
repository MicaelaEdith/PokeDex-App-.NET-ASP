using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Threading.Tasks;


namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Host = "smtp.gmail.com";
            server.Port = 587;
            server.EnableSsl = true;
            server.UseDefaultCredentials = false;
            server.Credentials = new NetworkCredential("mailtesteoapps@gmail.com", "metnhhsaggbtnvox");
        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("noresponder@pokedexweb.com");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            //email.Body = "<h1>Bienvenidx a la App";
            email.Body = cuerpo;

        }
        //no envia mail - ver método // solucionado con gmail ->
        /* Para poder utilizar el servicio SMTP de Gmail para el envio de correos es necesario
         * habilitar Contraseña de Aplicaciones, la contraseña la genera directamente Google
         * y despues se puede usar con SmtpClient de aspx 
         * otra opcion es usar el servicio de MailTrap que ya tiene precargado el script de c# para implementarlo directamente. 
         */
        
        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
               
            }
        }

    }
}