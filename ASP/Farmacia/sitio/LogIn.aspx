<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <strong>LOG IN</strong>
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
                <asp:Button ID="btnLogIn" runat="server" Text="LogIn" OnClick="btnLogIn_Click" />
            </td>
            <td>
                <asp:Label ID="lblERROR" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="btnRegistrarCliente" runat="server" Text="Registro cliente" 
                    onclick="btnRegistrarCliente_Click" />
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
