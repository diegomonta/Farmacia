<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="RegistroUsuario, App_Web_ugypbezv" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <title>Registro Cliente</title>
    <style>
        /* Estilos CSS */
    </style>
    <script>
        function validarFormulario() {
            // Realiza validaciones adicionales en el lado del cliente
            var usuario = document.getElementById('<%= txtUsuario.ClientID %>').value;
            var pass = document.getElementById('<%= txtPass.ClientID %>').value;

            // Ejemplo de validación: Verificar que los campos no estén vacíos
            if (usuario.trim() === '' || pass.trim() === '') {
                alert('Por favor, complete todos los campos.');
                return false;
            }

            // Agrega más validaciones según tus necesidades

            return true;
        }
    </script>
        <div class="container">
        <div class="title">REGISTRO ESTUDIANTE</div>
            <div class="form-group">
                <label for="txtUsuario">Usuario:</label>
                <asp:TextBox ID="txtUsuario" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtPass">Password:</label>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtDireccionFacturacion">Curso que cursa:</label>
                <asp:TextBox ID="txtDireccionFacturacion" runat="server" />
            </div>
            <div class="form-group">
                <label for="txtTelefono">Telefono:</label>
                <asp:TextBox ID="txtTelefono" runat="server" />
            </div>
            <div class="form-group">
                <asp:Button ID="btnSignIn" runat="server" Text="Sign In" OnClick="btnSignIn_Click" CssClass="btn" />
            </div>
                <td>
                    <asp:Label ID="lblERROR" runat="server" />
                </td>
    </div>
    </asp:Content>

