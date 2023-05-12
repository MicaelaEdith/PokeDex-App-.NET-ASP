<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="col">

            <div class="mb-3">
                <label for="txtID" class="form-label">ID</label>
                <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                <label for="txtNumero" class="form-label">Número</label>
                <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
                <label for="txtDescripcion" class="form-label">Descripción</label>
                <asp:TextBox runat="server" TextMode="MultiLine" ID="TextDescripcion" CssClass="form-control" />
                <asp:Label Text="dlTipo" runat="server">Tipo</asp:Label>
                <asp:DropDownList ID="drpTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                <br />
                <asp:Label Text="dlDebilidad" runat="server">Debilidad</asp:Label>
                <asp:DropDownList ID="dprDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
                <br />
                <asp:Button Text="Agregar" ID="btnAgregar" CssClass="btn btn-secondary" runat="server" />
                <a href="default.aspx" class="btn btn-secondary">Cancelar</a>
            </div>

        </div>
        <div class="col-2"></div>
    </div>


</asp:Content>
