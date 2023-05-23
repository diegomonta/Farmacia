<%@ page language="C#" autoeventwireup="true" inherits="LogIn, App_Web_bom3n3cg" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>ESCUELA DE SEGURIDAD INFORMATICA</title>
    <style>
        /* Estilos CSS aquí */
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>INGRESO</h1>
            <p>
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
                            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
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
                </table>
                <asp:Button ID="btnConsulta" runat="server" Text="Recuperar Contraseña" onclick="btnConsulta_Click" />
            </p>
        </div>
    </form>
    <script>
        // Agrega validación de cliente para el formulario
        function validateForm() {
            var usuario = document.getElementById('<%=txtUsuario.ClientID%>').value;
            var password = document.getElementById('<%=txtPass.ClientID%>').value;

            if (usuario === '' || password === '') {
                alert('Por favor, complete todos los campos.');
                return false;
            }

            return true;
        }
    </script>
</body>
</html>