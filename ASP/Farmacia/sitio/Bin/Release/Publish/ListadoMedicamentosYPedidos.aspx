<%@ page language="C#" autoeventwireup="true" inherits="ListadoMedicamentosYPedidos, App_Web_r1ahw0he" masterpagefile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Farmaceutica" />
    <asp:DropDownList ID="ddlFarmaceutica" runat="server" OnSelectedIndexChanged="ddlFarmaceutica_SelectedIndexChanged"
        AutoPostBack="true">
        <asp:ListItem Selected="True"></asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged"
        EmptyDataText="No hay medicamentos disponibles para esta farmacia." Caption="<strong>Medicamentos</strong>">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="pNombre" />
            <asp:BoundField HeaderText="Precio" DataField="pPrecio" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Button ID="btnTodos" runat="server" Text="TODOS" BackColor="silver" OnClick="btnTodos_Click" />
    <asp:Button ID="btnGenerados" runat="server" Text="GENERADOS" BackColor="silver"
        OnClick="btnGenerados_Click" />
    <asp:Button ID="btnEntregados" runat="server" Text="ENTREGADOS" BackColor="silver"
        OnClick="btnEntregados_Click" />
    <br />
    <asp:GridView ID="gvPedidos" runat="server" AutoGenerateColumns="False" EmptyDataText="No hay pedidos disponibles para este medicamento con este filtro."
        Caption="<strong>Pedidos</strong>">
        <Columns>
            <asp:BoundField HeaderText="Numero" DataField="pNumero" />
            <asp:BoundField HeaderText="Cliente" 
                DataField="pClienteComprador.pNombreUsuario" />
            <asp:BoundField DataField="pCantidad" HeaderText="Cantidad" />
            <asp:BoundField DataField="pEstado" HeaderText="Estado" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
