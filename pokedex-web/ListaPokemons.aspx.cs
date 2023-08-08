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
        public bool filtroAvanzado { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            Trainee trainee = Session["trainee"] != null ? (Trainee)Session["trainee"] : null;

            if (Session["trainee"] == null || !trainee.Admin)
            {
                Response.Redirect("Login.aspx");
            }
            else
            {
                filtroAvanzado = chkFiltroAvanzado.Checked; 
                PokemonNegocio negocio = new PokemonNegocio();
                Session.Add("listaPokemons", negocio.listarConSP());
                dgvPokemons.DataSource = Session["listaPokemons"];
                dgvPokemons.DataBind();
            }
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

        protected void chkFiltroAvanzado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkFiltroAvanzado.Checked)
                filtroAvanzado = true;
            else
                filtroAvanzado = false; 
        }

        protected void ddlCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCriterio.Items.Clear();
            if (ddlCampo.SelectedItem.ToString() == "Número")
            {
                ddlCriterio.Items.Add("Igual a ");
                ddlCriterio.Items.Add("Mayor a ");
                ddlCriterio.Items.Add("Menor a ");
            }
            else
            {
                ddlCriterio.Items.Add("Contiene ");
                ddlCriterio.Items.Add("Comienza con ");
                ddlCriterio.Items.Add("Termina con ");
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                PokemonNegocio negocio = new PokemonNegocio();  //revisar carga de datos
                dgvPokemons.DataSource = negocio.filtrar(
                    ddlCampo.SelectedItem.ToString(),
                    ddlCriterio.SelectedItem.ToString(),
                    txtFiltroAvanzado.Text,
                    ddlEstado.SelectedItem.ToString());

                dgvPokemons.DataBind();



            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                throw;
            }
        }
    }
}