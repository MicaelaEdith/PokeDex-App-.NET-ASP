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
                //Configuración inicial de la pantalla

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

                //Configuración de carga de datos para modificar
                string id = Request.QueryString["id"] != null ? Request.QueryString["id"].ToString() : "";
                if (id != "" && !IsPostBack)
                {
                    btnAgregar.Text = "Modificar";
                    btnEliminar.Visible = true;
                    btnInactivar.Visible = true;

                    PokemonNegocio negocio = new PokemonNegocio();
                    Pokemon seleccionado = (negocio.listar(id))[0];

                    //Pre Carga de datos

                    txtID.Text = id;
                    txtNombre.Text = seleccionado.Nombre;
                    txtNumero.Text = seleccionado.Numero.ToString();
                    drpTipo.SelectedValue = seleccionado.Tipo.Id.ToString();
                    drpDebilidad.SelectedValue = seleccionado.Debilidad.Id.ToString();

                    txtDescripcion.Text = seleccionado.Descripcion;
                    txtUrlImagen.Text = seleccionado.UrlImagen;

                    imgPokemon.ImageUrl = txtUrlImagen.Text;


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

                if (Request.QueryString["id"] != null)
                {
                    nuevo.Id =int.Parse(Request.QueryString["id"]);
                    negocio.ModificarConSP(nuevo);
                }
                else
                    negocio.AgregarConSP(nuevo);

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

                try
                {
                    if (!string.IsNullOrEmpty(txtUrlImagen.Text))
                    {
                        imgPokemon.ImageUrl = txtUrlImagen.Text;
                    }
                    else
                    {
                        imgPokemon.ImageUrl = "Img/imgNoDisponible.jpg";
                    }


                }
                catch (System.Net.WebException ex)
                {

                    imgPokemon.ImageUrl = "Img/imgNoDisponible.jpg";
                    
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            ckbEliminar.Visible = true;
            btnConfirmarEliminar.Visible = true;
        }

        protected void btnConfirmarEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();

                if (ckbEliminar.Checked)
                {
                    negocio.Eliminar(int.Parse(txtID.Text));
                    Response.Redirect("ListaPokemons.aspx");
                }
                
            }
            catch (Exception ex)
            {

                Session.Add("Error ",ex);
            }
        }

        protected void btnInactivar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();
                negocio.EliminarLogico(int.Parse(txtID.Text));
                Response.Redirect("ListaPokemons.aspx");

            }
            catch (Exception ex)
            {
                Session.Add("Error ", ex);

            }
        }
    }
}