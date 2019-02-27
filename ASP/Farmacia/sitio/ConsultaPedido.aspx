<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ConsultaPedido.aspx.cs" Inherits="ConsultaPedido" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnAtras" runat="server" Text="Atras" Style="float: right;" 
            onclick="btnAtras_Click" />
        <table>
            <strong>CONSULTAR ESTADO PEDIDO</strong>
            <tr>
                <td>
                    <asp:Label ID="lblNumero" runat="server" Text="Numero pedido:" />
                </td>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEstado" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblERROR" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
