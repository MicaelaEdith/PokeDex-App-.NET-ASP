<%@ Page Title="" Language="C#" MasterPageFile="~/master.Master" AutoEventWireup="true" CodeBehind="ListaPokemons.aspx.cs" Inherits="pokedex_web.ListaPokemons" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <div class="row">
        <div class="col-2"></div>
        <div class="col">

            <div style="margin-bottom: 1vh">
                <div class="col-4">
                    <asp:Label Text="Filtrar:" runat="server" />
                        <asp:TextBox ID="txtFiltrar" CssClass="form-control bg-body-secondary col-3" AutoPostBack="true" OnTextChanged="txtFiltrar_TextChanged" runat="server" />
                        <asp:CheckBox Text="" ID="chkFiltroAvanzado" AutoPostBack="true" OnCheckedChanged="chkFiltroAvanzado_CheckedChanged" runat="server" />
                        <asp:Label Text=" Filtro Avanzado" runat="server" />
                    </div>
                
            </div>


            <%if (filtroAvanzado)
                {%>

            <div class="row">
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Campo" runat="server" />
                        <asp:DropDownList runat="server" ID="ddlCampo" AutoPostBack="true" CssClass="form-control" OnSelectedIndexChanged="ddlCampo_SelectedIndexChanged">
                            <asp:ListItem Text="Nombre" />
                            <asp:ListItem Text="Tipo" />
                            <asp:ListItem Text="Número" />
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Criterio" runat="server" />
                        <asp:DropDownList ID="ddlCriterio" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Filtro" runat="server" />
                        <asp:TextBox ID="txtFiltroAvanzado" CssClass="form-control" runat="server" />
                    </div>
                </div>
                <div class="col-3">
                    <div class="mb-3">
                        <asp:Label Text="Estado" runat="server" />
                        <asp:DropDownList ID="ddlEstado" CssClass="form-control" runat="server">
                            <asp:ListItem Text="Todos" />
                            <asp:ListItem Text="Activo" />
                            <asp:ListItem Text="Inactivo" />
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-3">
                    <div class="m-3">
                        <asp:Button Text="Buscar" ID="btnBuscar" CssClass="btn btn-secondary " OnClick="btnBuscar_Click" runat="server" />
                    </div>
                </div>
            </div>
            <%} %>


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
