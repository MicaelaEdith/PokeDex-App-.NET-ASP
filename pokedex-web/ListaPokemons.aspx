<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ListaPokemons.aspx.cs" Inherits="pokedex_web.ListaPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">

            <div>
                <div class="col-4">
                    <asp:Label Text="Filtrar:" runat="server" />
                    <asp:TextBox ID="txtFiltrar" CssClass="form-control bg-body-secondary col-3" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" runat="server" />
                </div>
            </div>
            <br />
            <asp:GridView ID="dgvPokemons" runat="server" DataKeyNames="Id" CssClass="table" AutoGenerateColumns="false" OnSelectedIndexChanged="dgvPokemons_SelectedIndexChanged" OnPageIndexChanging="dgvPokemons_PageIndexChanging" AllowPaging="true" PageSize="10">
                <Columns>
                    <asp:BoundField HeaderText="Nombre" DataField="Nombre" />
                    <asp:BoundField HeaderText="Número" DataField="Numero" />
                    <asp:BoundField HeaderText="Tipo" DataField="Tipo.Descripcion" />
                    <asp:CheckBoxField HeaderText="Activo" DataField="Activo" />
                    <asp:CommandField HeaderText="Modificar" ShowSelectButton="true" SelectText="🖊 " />
                </Columns>
            </asp:GridView>
            <a href="FormularioPokemon.aspx" class="btn btn-secondary">Agregar</a>
        </div>
        <div class="col-2"></div>
    </div>
</asp:Content>
