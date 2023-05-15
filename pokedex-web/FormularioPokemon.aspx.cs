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
    public partial class FormularioPokemon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtID.Enabled = false;

            try
            {
                if (!IsPostBack)
                {
                    ElementoNegocio negocio = new ElementoNegocio();
                    List<Elemento> lista = negocio.listar();

                    drpTipo.DataSource = lista;
                    drpTipo.DataValueField = "Id";
                    drpTipo.DataTextField = "Descripcion";

                    drpTipo.DataBind();


                    drpDebilidad.DataSource = lista;
                    drpDebilidad.DataValueField = "Id";
                    drpDebilidad.DataTextField = "Descripcion";

                    drpDebilidad.DataBind();


                }
            }
            catch (Exception ex)
            {

                Session.Add("Error: ", ex);
                throw;
            }


        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Pokemon nuevo = new Pokemon();
                PokemonNegocio negocio = new PokemonNegocio();


                nuevo.Numero = int.Parse(txtNumero.Text);
                nuevo.Nombre = txtNombre.Text;
                nuevo.Descripcion = txtDescripcion.Text;
                nuevo.UrlImagen = txtUrlImagen.Text;

                nuevo.Tipo = new Elemento();
                nuevo.Tipo.Id = int.Parse(drpTipo.SelectedValue);


                nuevo.Debilidad = new Elemento();
                nuevo.Debilidad.Id = int.Parse(drpDebilidad.SelectedValue);

                negocio.Agregar(nuevo);
                Response.Redirect("ListaPokemons.aspx",false);


            }
            catch (Exception ex)
            {
                Session.Add("Error: ", ex);
                throw;
            }

        }

        protected void txtUrlImagen_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtUrlImagen.Text != "")
                
                    imgPokemon.ImageUrl = txtUrlImagen.Text;
                
                else
                    imgPokemon.ImageUrl = "Img/imgNoDisponible.jpg";
            }
            catch (Exception)
            {
                imgPokemon.ImageUrl = "Img/imgNoDisponible.jpg";
                throw;
            } 
        }

    }
}