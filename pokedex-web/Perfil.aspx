<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="pokedex_web.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        @media screen and (max-width:768px) {
            #ppal {
                display: flex;
                flex-direction: column;
            }
        }      
    </style>
    <div id="ppal" style="display: flex; margin-top:3vh;">
        <div style="display: flex; flex-direction: column; margin-right: 2vw;" class="col-md-5">
            <asp:Label Text="Email" class="form-label mb-1" runat="server" />
            <asp:TextBox runat="server" ID="txtEmail" class="form-control mb-2" ReadOnly="true"/>
            <asp:Label Text="Nombre" class="form-label mb-1" runat="server" />
            <asp:TextBox runat="server" ID="txtNombre" class="form-control mb-2" />
            <asp:Label Text="Apellido" class="form-label mb-1" runat="server" />
            <asp:TextBox runat="server" ID="txtApellido" class="form-control mb-2" />
            <asp:Label Text="Fecha de nacimiento" class="form-label mb-1" runat="server" />
            <asp:TextBox runat="server" ID="txtFechaNacimiento" class="form-control mb-2" TextMode="Date" />
        </div>
        <div style="display: flex; flex-direction: column" class="col-md-5">
            <asp:Label Text="Imagen de Perfil" class="form-label" runat="server" />
            <input type="file" class="form-control mb-2" name="name" runat="server" id="txtFile"/>
            <asp:Image ImageUrl="https://plantillasdememes.com/img/plantillas/imagen-no-disponible01601774755.jpg"
                runat="server" CssClass="img-fluid mb-3" style="border-radius:5px;" />
        </div>
    </div>
    <div>
        <asp:Button Text="Aceptar" ID="btnAceptar" OnClick="btnAceptar_Click" CssClass="btn btn-secondary" Style="margin-bottom: 2vh; margin-top: 1vh;" runat="server" />
        <asp:Button Text="Cerra sesión" ID="btnCerrar" CssClass="btn btn-secondary float-end" OnClick="btnCerrar_Click" runat="server" />
    </div>
</asp:Content>
