<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListarPedidoEliminar.aspx.cs"
    Inherits="ListarPedidoEliminar" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField HeaderText="Numero pedido" DataField="pNumero" />
            <asp:BoundField HeaderText="Medicamento" 
                DataField="pMedicamentoPedido.pNombre" />
            <asp:BoundField DataField="pCantidad" HeaderText="Cantidad" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <table>
        <tr>
            <td>
                <asp:Label ID="lblNumero" runat="server" Text="Numero" />
                <asp:TextBox ID="txtNumero" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCliente" runat="server" Text="Cliente comprador" />
                <asp:TextBox ID="txtCliente" runat="server" Enabled="false" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMedcamento" runat="server" Text="Medicamento" />
                <asp:TextBox ID="txtMedicamento" runat="server" Enabled="false" />
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
                <asp:Button ID="btnPedir" runat="server" Text="Pedir" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
