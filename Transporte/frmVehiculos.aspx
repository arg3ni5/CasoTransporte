<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmVehiculos.aspx.vb" Inherits="Transporte.frmVehiculos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="ID de Propietario" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlTipoID" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo de ID" Value="0" />
            <asp:ListItem Text="Cédula Física" Value="1" />
            <asp:ListItem Text="DIMEX" Value="2" />
            <asp:ListItem Text="Pasaporte" Value="3" />
        </asp:DropDownList>
    </div>

</asp:Content>
