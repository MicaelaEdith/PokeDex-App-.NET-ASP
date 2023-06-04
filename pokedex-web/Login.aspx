<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="pokedex_web.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <hr />
    <div class="row">
        <div class="mb-2 row justify-content-center">
            <asp:Label Text="E-Mail: " CssClass="col-1 col-form-label" runat="server" />
            <div class="col-sm-8">
                <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-2 row justify-content-center">
            <asp:Label Text="Password" CssClass="col-sm-1 col-form-label" runat="server" />
            <div class="col-sm-8">
                <asp:TextBox ID="txtPassword" CssClass="form-control" runat="server" />
                <asp:Button Text="Ingresar" ID="btnIngresar" CssClass="btn btn-secondary border " runat="server" />
            </div>
        </div>
    </div>
</asp:Content>
