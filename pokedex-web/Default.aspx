<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="pokedex_web.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>PokeApp</h1>
    <div class="row row-cols-1 row-cols-md-4 g-4">
        <%
            foreach(Dominio.Pokemon poke in ListaPokemon)
            { %>



                <div class="col">
                    <div class="card text-center">
                        <img src="<%: poke.UrlImagen %>" class="card-img-top" alt="...">
                        <div class="card-body">
                            <h4 class="card-title"> <%: poke.Nombre +" - N° "+ poke.Numero  %> </h4>
                            <p style="height:8vh" class="card-text"><%: poke.Descripcion%></p>
                            <a class="text-decoration-none btn btn-secondary" href="DetallePokemon.aspx?id=<%:poke.Id %>"> Ver detalle</a>
                        </div> 
                    </div>
                </div>


         <% } %>
    </div>
</asp:Content>
