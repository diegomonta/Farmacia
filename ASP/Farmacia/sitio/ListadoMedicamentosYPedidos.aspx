<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ListadoMedicamentosYPedidos.aspx.cs"
    Inherits="ListadoMedicamentosYPedidos" MasterPageFile="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="Farmaceutica" />
    <asp:DropDownList ID="ddlFarmaceutica" runat="server" 
        onselectedindexchanged="ddlFarmaceutica_SelectedIndexChanged" />
    <asp:GridView ID="gvMedicamentos" runat="server" AutoGenerateColumns="False" headertext="asdasd"
        OnSelectedIndexChanged="gvMedicamentos_SelectedIndexChanged" EmptyDataText="No hay medicamentos disponibles para esta farmacia."
        Caption="<strong>Medicamentos</strong>">
        <Columns>
            <asp:BoundField HeaderText="Nombre" DataField="pNombre" />
            <asp:BoundField HeaderText="Precio" DataField="pPrecio" />
            <asp:ButtonField Text="Seleccionar" ButtonType="Button" CommandName="Select" />
        </Columns>
    </asp:GridView>
    <asp:Label ID="lblERROR" runat="server" />
</asp:Content>
