<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="FormularioPokemon.aspx.cs" Inherits="pokedex_web.FormularioPokemon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section style="margin-top: 2vh">
        <div class="row">
            <div class="col-6">
                <div class="mb-3">
                    <label for="txtID" class="form-label">ID</label>
                    <asp:TextBox runat="server" ID="txtID" CssClass="form-control" />
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
                    <label for="txtNumero" class="form-label">Número</label>
                    <asp:TextBox runat="server" ID="txtNumero" CssClass="form-control" />
                    <label for="txtDescripcion" class="form-label">Descripción</label>
                    <asp:TextBox runat="server" TextMode="MultiLine" ID="txtDescripcion" CssClass="form-control" />

                    <div style="margin-top: 2vh">
                        <div class="row">
                            <div class="col-1">
                                <asp:Label Text="lblTipo" runat="server">Tipo</asp:Label>
                            </div>
                            <div class="col">
                                <asp:DropDownList ID="drpTipo" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>


                            <div class="col-2">
                                <asp:Label Text="lblDebilidad" runat="server">Debilidad</asp:Label>
                            </div>
                            <div class="col">
                                <asp:DropDownList ID="drpDebilidad" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>

                        </div>
                    </div>
                </div>
            </div>

            <div class="col-6">
                <asp:ScriptManager runat="server"></asp:ScriptManager>

                <asp:UpdatePanel ID="udpUrlImagen" runat="server">
                    <ContentTemplate>
                        <div class="mb-3">
                            <label for="txtUrlImagen" class="form-label">Url Imagen</label>
                            <asp:TextBox runat="server" AutoPostBack="true" ID="txtUrlImagen" CssClass="form-control" OnTextChanged="txtUrlImagen_TextChanged" />
                            <br />
                            <asp:Image ID="imgPokemon" runat="server" ImageUrl="Img/imgNoDisponible.jpg" Width="50%" />
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>

                <div class="mb-3">
                    <asp:Button Text="Agregar" ID="btnAgregar" OnClick="btnAgregar_Click" CssClass="btn btn-secondary col-md-2 text-sm-start w-auto" runat="server" />

                    <a href="default.aspx" class="btn btn-secondary col-sm-2 text-sm-start ms-1 w-auto">Cancelar</a>
                    <asp:Button Text="Eliminar Pokemon" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-dark col-md-4 ms-1 w-auto" Visible="false" runat="server" />
                    <asp:Button Text="Inactivar" ID="btnInactivar" CssClass="btn btn-secondary col-md-2 text-sm-start ms-1 w-auto" OnClick="btnInactivar_Click" Visible="false" runat="server" />
                </div>
                <div>
                    <asp:CheckBox Text=" Confirmar eliminación de Pokemon" ID="ckbEliminar" Visible="false" runat="server" />
                    <asp:Button Text="Eliminar" CssClass="btn btn-danger ms-2" ID="btnConfirmarEliminar" OnClick="btnConfirmarEliminar_Click" Visible="false" runat="server" />

                </div>
            </div>
        </div>

    </section>


</asp:Content>
