<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoCursos.aspx.cs"
    Inherits="ListadoCursos" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Materia" />
    <asp:DropDownList ID="ddlFarmaceutica" runat="server" OnSelectedIndexChanged="ddlFarmaceutica_SelectedIndexChanged"
        AutoPostBack="true">
        <asp:ListItem Selected="True"></asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged"
        EmptyDataText="No hay cursos disponibles para esta Materia." Caption="<strong>Cursos</strong>">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="pNombre" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnTodos" runat="server" Text="TODOS" BackColor="silver" OnClick="btnTodos_Click" />
    <asp:Button ID="btnGenerados" runat="server" Text="GENERADOS" BackColor="silver"
        OnClick="btnGenerados_Click" />
    <asp:Button ID="btnEntregados" runat="server" Text="Aprobados" BackColor="silver"
        OnClick="btnEntregados_Click" />
    <br />
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay Inscripciones disponibles para este Curso con este filtro."
        Caption="<strong>Inscripciones</strong>">
        <Columns>
            <asp:BoundField HeaderText="Numero" DataField="pNumero" />
            <asp:BoundField HeaderText="Cliente" 
                DataField="pClienteComprador.pNombreUsuario" />
            <asp:BoundField DataField="pEstado" HeaderText="Estado" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
