<%@ Page Title="Propietarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Propietarios.aspx.vb" Inherits="Transporte.Propietarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!-- PERSONA -->
    <div class="form-group mb-3">
        <asp:Label ID="lblPersona" runat="server" Text="Persona"></asp:Label>
        
        <asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control">
        </asp:DropDownList>
    </div>

    <!-- TELÉFONO -->
    <div class="form-group mb-3">
        <asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvTelefono" runat="server"
            ErrorMessage="Ingrese teléfono"
            ControlToValidate="txtTelefono"
            ValidationGroup="grpGuardar"
            CssClass="text-danger d-block" />

        <asp:RegularExpressionValidator ID="revTelefono" runat="server"
            ControlToValidate="txtTelefono"
            ValidationExpression="^[0-9]{8}$"
            ErrorMessage="Debe tener 8 dígitos"
            ValidationGroup="grpGuardar"
            CssClass="text-danger d-block" />
    </div>

    <!-- DIRECCIÓN -->
    <div class="form-group mb-3">
        <asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>

        <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
            ErrorMessage="Ingrese dirección"
            ControlToValidate="txtDireccion"
            ValidationGroup="grpGuardar"
            CssClass="text-danger d-block" />
    </div>

    <!-- BOTÓN -->
    <asp:Button ID="btnGuardar" runat="server"
        Text="Guardar"
        CssClass="btn btn-primary my-2"
        ValidationGroup="grpGuardar"
        OnClick="btnGuardar_Click" />

    <!-- MENSAJE -->
    <asp:Label ID="lblResultado" runat="server" CssClass="alert d-block"></asp:Label>

    <!-- GRID -->
    <asp:GridView ID="gvPropietarios"
        runat="server"
        CssClass="table table-striped table-hover mt-3"
        AutoGenerateColumns="False"
        DataKeyNames="IdPersona"
        OnSelectedIndexChanged="gvPropietarios_SelectedIndexChanged"
        OnRowDeleting="gvPropietarios_RowDeleting">

        <Columns>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server"
                        CommandName="Select"
                        CssClass="btn btn-primary btn-sm">
                        Editar
                    </asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="NombreCompleto" HeaderText="Nombre" />
            <asp:BoundField DataField="Telefono" HeaderText="Teléfono" />
            <asp:BoundField DataField="Direccion" HeaderText="Dirección" />

            <asp:CommandField ShowDeleteButton="True"
                DeleteText="Eliminar"
                ControlStyle-CssClass="btn btn-danger btn-sm" />

        </Columns>
    </asp:GridView>

</asp:Content>