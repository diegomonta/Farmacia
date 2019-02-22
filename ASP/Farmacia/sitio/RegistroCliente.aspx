<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RegistroCliente.aspx.cs"
    Inherits="RegistroCliente" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <strong>REGISTRO CLIENTE</strong>
            <tr>
                <td>
                    <asp:Label ID="lblUsuario" Text="Usuario:" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtUsuario" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblPass" Text="Password:" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblNombre" Text="Nombre:" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtNombre" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblDireccionFacturacion" Text="Direccion facturacion:" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtDireccionFacturacion" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblTelefono" Text="Telefono:" runat="server" />
                </td>
                <td>
                    <asp:TextBox ID="txtTelefono" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" />
                </td>
                <td>
                    <asp:Label ID="lblERROR" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
