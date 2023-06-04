<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="pokedex_web.Perfil" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label Text="logeado" ID="lbl" runat="server" />
    <asp:Button Text="Administrar" ID="btnAdministrar" OnClick="btnAdministrar_Click" Visible="false" CssClass="btn btn-secondary" runat="server" />
    <asp:Button Text="Cerra sesión" ID="btnCerrar" CssClass="btn btn-secondary" OnClick="btnCerrar_Click" runat="server" />
    
</asp:Content>
