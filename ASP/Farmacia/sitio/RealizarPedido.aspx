<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RealizarPedido.aspx.cs" Inherits="RealizarPedido"
    MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="pNombre" />
            <asp:BoundField HeaderText="Precio" DataField="pPrecio" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblCodigo" runat="server" Text="Codigo" />
                <asp:TextBox ID="txtCodigo" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFarmaceutica" runat="server" Text="Farmaceutica" />
                <asp:TextBox ID="txtFarmaceutica" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion" />
                <asp:TextBox ID="txtDescripcion" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPrecio" runat="server" Text="Precio" />
                <asp:TextBox ID="txtPrecio" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre" />
                <asp:TextBox ID="txtNombre" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCantidad" runat="server" Text="Cantidad" />
                <asp:TextBox ID="txtCantidad" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnPedir" runat="server" Text="Pedir" 
                    onclick="btnPedir_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
