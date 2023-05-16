<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Consulta.aspx.cs" Inherits="Consulta" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="btnAtras" runat="server" Text="Atras" Style="float: right;" OnClick="btnAtras_Click" />
        <table>
            <strong>CONSULTAR ESTADO INSCRICION</strong>
            <tr>
                <td>
                    <asp:Label ID="lblNumero" runat="server" Text="Numero Inscripcion:" />
                </td>
                <td>
                    <asp:TextBox ID="txtNumero" runat="server" />
                </td>
                <td>
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" OnClick="btnConsultar_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblEstado" runat="server" />
                </td>
            </tr>
        </table>
        <asp:Label ID="lblERROR" runat="server" />
    </div>
    </form>
</body>
</html>
