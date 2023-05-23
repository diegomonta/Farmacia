<%@ page language="C#" autoeventwireup="true" inherits="Administrador, App_Web_ugypbezv" masterpagefile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .error {
            color: red;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- TABLA ABM EMPLEADOS -->
    <table border="0" cellpadding="0" cellspacing="0">
        <strong>AJUSTE ADMINISTRADOR</strong>
        <!-- FORMULARIO -->
        <tr>
            <td>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario:" />
            </td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" />
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblPass" runat="server" Text="Password:" />
            </td>
            <td>
                <asp:TextBox ID="txtPass" runat="server" TextMode="Password" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre:" />
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCorreo" runat="server" Text="Correo:" />
            </td>
            <td>
                <asp:TextBox ID="TxtCorreo" runat="server"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblInicioJornada" runat="server" Text="Inicio jornada:" />
            </td>
            <td>
                <asp:Label ID="lblInicioJornadaHoras" runat="server" Text="Horas: " />
                <asp:DropDownList ID="ddlInicioJornadaHoras" runat="server" />
                <asp:Label ID="lblInicioJornadaMinutos" runat="server" Text="Minutos: " />
                <asp:DropDownList ID="ddlInicioJornadaMinutos" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblFinJornada" runat="server" Text="Fin jornada:" />
            </td>
            <td>
                <asp:Label ID="lblFinJornadaHoras" runat="server" Text="Horas: " />
                <asp:DropDownList ID="ddlFinJornadaHoras" runat="server" />
                <asp:Label ID="lblFinJornadaMinutos" runat="server" Text="Minutos: " />
                <asp:DropDownList ID="ddlFinJornadaMinutos" runat="server" />
            </td>
        </tr>
    </table>
    <table>
        <!-- ALTA BAJA MODIFICACION BOTONES -->
        <tr>
            <td>
                <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" OnClientClick="return ConfirmarOperacion();" />
            </td>
            <td>
                <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" OnClientClick="return ConfirmarOperacion();" />
            </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" OnClientClick="return ConfirmarOperacion();" />
            </td>
            <td>
                <asp:Button ID="btnLimpiar" Text="Limpiar" runat="server" OnClick="btnLimpiar_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblERROR" runat="server" CssClass="error" />
    <script type="text/javascript">
        function ConfirmarOperacion() {
            var pass = document.getElementById("<%= txtPass.ClientID %>").value;

            // Validación de fortaleza de contraseña en el lado del cliente
            if (pass.length < 8 || !/\d/.test(pass) || !/[a-zA-Z]/.test(pass)) {
                alert("La contraseña debe tener al menos 8 caracteres, un número y una letra.");
                return false;
            }

            // Validación de inicio y fin de jornada
            var inicioJornadaHoras = document.getElementById("<%= ddlInicioJornadaHoras.ClientID %>").value;
            var inicioJornadaMinutos = document.getElementById("<%= ddlInicioJornadaMinutos.ClientID %>").value;
            var finJornadaHoras = document.getElementById("<%= ddlFinJornadaHoras.ClientID %>").value;
            var finJornadaMinutos = document.getElementById("<%= ddlFinJornadaMinutos.ClientID %>").value;

            if (inicioJornadaHoras >= finJornadaHoras) {
                alert("La hora de inicio de jornada debe ser anterior a la hora de fin de jornada.");
                return false;
            }

            return true;
        }
    </script>
</asp:Content>