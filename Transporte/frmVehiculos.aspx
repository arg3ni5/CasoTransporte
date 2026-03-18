<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="frmVehiculos.aspx.vb" Inherits="Transporte.frmVehiculos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-group">
        <asp:Label ID="Label1" runat="server" Text="Tipo de ID" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="ddlTipoID" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione un tipo de ID" Value="0" />
            <asp:ListItem Text="Cédula Física" Value="1" />
            <asp:ListItem Text="DIMEX" Value="2" />
            <asp:ListItem Text="Pasaporte" Value="3" />
        </asp:DropDownList>
    </div>

    <div class="form-group">
        <asp:Label ID="Label6" runat="server" Text="ID del propietario" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtIDPropietario" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label2" runat="server" Text="ID del Vehículo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="TextIDVehiculo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label3" runat="server" Text="Placa del vehículo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtPlaca" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label4" runat="server" Text="Modelo del vehículo" CssClass="control-label"></asp:Label>
        <asp:TextBox ID="txtModelo" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <div class="form-group">
        <asp:Label ID="Label5" runat="server" Text="Marca del vehículo" CssClass="control-label"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
            <asp:ListItem Text="Seleccione la marca" Value="0" />
            <asp:ListItem Text="Toyota" Value="1" />
            <asp:ListItem Text="Honda" Value="2" />
            <asp:ListItem Text="Ford" Value="3" />
            <asp:ListItem Text="Mercedes-Benz" Value="4" />
        </asp:DropDownList>
    </div>

</asp:Content>
