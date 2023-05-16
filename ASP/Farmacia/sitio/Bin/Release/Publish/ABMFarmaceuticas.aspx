<%@ page language="C#" autoeventwireup="true" masterpagefile="~/MasterPage.master" inherits="ABMFarmacias, App_Web_r1ahw0he" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--TABLA ABM FARMACEUTICAS-->
    <table border="0" cellpadding="0" cellspacing="0">
        <strong>INSCRIPCION DE MATERIAS</strong>
        <!--FORMULARIO-->
        <tr>
            <td>
                <asp:Label ID="lblRuc" runat="server" Text="Identificador materia:" />
            </td>
            <td>
                <asp:TextBox ID="txtRuc" runat="server" />
            </td>
            <td>
                <asp:Button ID="btnBuscar" Text="Buscar" runat="server" OnClick="btnBuscar_Click" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblNombre" runat="server" Text="Nombre materia:" />
            </td>
            <td>
                <asp:TextBox ID="txtNombre" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblCorreoElectronico" runat="server" Text="caracteristica materia:" />
            </td>
            <td>
                <asp:TextBox ID="txtCorreoElectronico" runat="server" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblDireccion" runat="server" Text="horario" />
            </td>
            <td>
                <asp:TextBox ID="txtDireccion" runat="server" />
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
