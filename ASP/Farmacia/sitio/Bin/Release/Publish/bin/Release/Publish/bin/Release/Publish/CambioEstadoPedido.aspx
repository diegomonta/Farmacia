<%@ page language="C#" autoeventwireup="true" inherits="CambioEstadoPedido, App_Web_r1ahw0he" masterpagefile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvPedidos_SelectedIndexChanged"
        Caption="<strong>Pedidos</strong>" EmptyDataText="No hay pedidos disponibles.">
        <Columns>
            <asp:BoundField HeaderText="Numero pedido" DataField="pNumero" />
            <asp:BoundField DataField="pClienteComprador.pNombreUsuario" 
                HeaderText="Cliente" />
            <asp:BoundField HeaderText="Medicamento" DataField="pMedicamentoPedido.pNombre" />
            <asp:BoundField DataField="pCantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="pEstado" HeaderText="Estado" />
            <asp:ButtonField Text="Cambiar estado" ButtonType="Button" 
                CommandName="Select" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
