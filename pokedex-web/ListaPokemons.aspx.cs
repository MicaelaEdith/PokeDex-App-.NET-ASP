using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace pokedex_web
{
    public partial class ListaPokemons : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PokemonNegocio negocio = new PokemonNegocio();
            Session.Add("listaPokemons", negocio.listarConSP());
            dgvPokemons.DataSource = Session["listaPokemons"];
            dgvPokemons.DataBind();
            

        }

        protected void dgvPokemons_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = dgvPokemons.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioPokemon.aspx?id=" + id);

        }

        protected void dgvPokemons_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvPokemons.PageIndex = e.NewPageIndex;
            dgvPokemons.DataBind();
        }

        protected void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
                List<Pokemon> lista = (List<Pokemon>)Session["listaPokemons"];
                List<Pokemon> listaFiltrada = lista.FindAll(x => x.Nombre.ToUpper().Contains(txtFiltrar.Text.ToUpper()));
                dgvPokemons.DataSource = listaFiltrada;
                dgvPokemons.DataBind();
            
        }
    }
}