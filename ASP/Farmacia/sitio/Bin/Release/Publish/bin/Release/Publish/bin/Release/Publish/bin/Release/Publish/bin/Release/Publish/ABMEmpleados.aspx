<%@ page language="C#" autoeventwireup="true" inherits="ABMEmpleados, App_Web_tstmsncs" masterpagefile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--TABLA ABM EMPLEADOS-->
    <table border="0" cellpadding="0" cellspacing="0">
        <strong>A.B.M EMPLEADOS</strong>
        <!--FORMULARIO-->
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
                <asp:TextBox ID="txtPass" runat="server" />
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
        <!--ALTA BAJA MODIFICACION BOTONES-->
        <tr>
            <td>
                <asp:Button ID="btnAlta" runat="server" Text="Alta" OnClick="btnAlta_Click" />
            </td>
            <td>
                <asp:Button ID="btnBaja" runat="server" Text="Baja" OnClick="btnBaja_Click" />
            </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
            </td>
            <td>
                <asp:Button ID="btnLimpiar" Text="Limpiar" runat="server" OnClick="btnLimpiar_Click" />
            </td>
            <td>
                <asp:Button ID="btnCancelar" Text="Cancelar" runat="server" OnClick="btnCancelar_Click" />
            </td>
        </tr>
    </table>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
