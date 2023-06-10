<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Contacto.aspx.cs" Inherits="pokedex_web.Contacto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-2"></div>
        <div class="mb-3 col-8">
            <asp:Label Text="Email" runat="server" />
            <asp:TextBox ID="txtEmailContacto" CssClass="form-control" placeholder="ejemplo@mail.com" runat="server" />
        </div>
        <div class="col-2"></div>
        <div class="col-2"></div>
        <div class="mb-3 col-8">
            <asp:Label Text="Asunto" runat="server" />
            <asp:TextBox ID="txtAsunto" CssClass="form-control" runat="server" />
        </div>
        <div class="col-2"></div>
        <div class="col-2"></div>
        <div class="mb-3 col-8">
            <asp:Label Text="Mensaje" runat="server" />
            <asp:TextBox ID="txtMensaje" CssClass="form-control" TextMode="MultiLine" runat="server" />
        </div>
    </div>
    <div class="row">
        <div class="col-2"></div>
        <div class="col-1">
            <asp:Button Text="Enviar" ID="btnContacto" CssClass="btn btn-secondary" OnClick="btnContacto_Click" runat="server" />
        </div>
        <div class="col-9"></div>
    </div>
</asp:Content>
