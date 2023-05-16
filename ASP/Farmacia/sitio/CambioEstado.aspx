<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CambioEstado.aspx.cs"
    Inherits="CambioEstado" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged"
        Caption="<strong>Inscripcion</strong>" EmptyDataText="No hay INscricion disponibles.">
        <Columns>
            <asp:BoundField HeaderText="Numero Inscripcion" DataField="pNumero" />
            <asp:BoundField DataField="pClienteComprador.pNombreUsuario" 
                HeaderText="Usuario" />
            <asp:BoundField HeaderText="Curso" DataField="pMedicamentoPedido.pNombre" />
            <asp:BoundField DataField="pEstado" HeaderText="Estado" />
            <asp:ButtonField Text="Cambiar estado" ButtonType="Button" 
                CommandName="Select" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
