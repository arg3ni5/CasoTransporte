<%@ Page Title="Propietarios" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site.Master" CodeBehind="Propietario.aspx.vb" Inherits="Transporte.Propietario" %>
 
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <!-- PERSONA -->
<div class="form-group">
<asp:Label ID="lblPersona" runat="server" Text="Persona"></asp:Label>
<asp:DropDownList ID="ddlPersona" runat="server" CssClass="form-control"
            DataSourceID="SqlPersonas"
            DataTextField="NombreCompleto"
            DataValueField="IdPersona">
</asp:DropDownList>
</div>
 
    <asp:SqlDataSource ID="SqlPersonas" runat="server"
        ConnectionString="<%$ ConnectionStrings:TrasnporteDB %>"
        SelectCommand="SELECT IdPersona, NombreCompleto FROM Personas">
</asp:SqlDataSource>
 
    <!-- TELÉFONO -->
<div class="form-group">
<asp:Label ID="lblTelefono" runat="server" Text="Teléfono"></asp:Label>
<asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
    <asp:RequiredFieldValidator ID="rfvTelefono" runat="server"
        ErrorMessage="Ingrese teléfono"
        ControlToValidate="txtTelefono"
        ValidationGroup="grpGuardar"
        CssClass="text-danger" />
 
    <asp:RegularExpressionValidator ID="revTelefono" runat="server"
        ControlToValidate="txtTelefono"
        ValidationExpression="^[0-9]{8}$"
        ErrorMessage="Debe tener 8 dígitos"
        ValidationGroup="grpGuardar"
        CssClass="text-danger" />
 
    <!-- DIRECCIÓN -->
<div class="form-group">
<asp:Label ID="lblDireccion" runat="server" Text="Dirección"></asp:Label>
<asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
</div>
 
    <asp:RequiredFieldValidator ID="rfvDireccion" runat="server"
        ErrorMessage="Ingrese dirección"
        ControlToValidate="txtDireccion"
        ValidationGroup="grpGuardar"
        CssClass="text-danger" />
 
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
        CssClass="table table-striped"
        AutoGenerateColumns="False"
        DataKeyNames="IdPersona"
        DataSourceID="SqlDataSource1"
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
 
    <!-- DATASOURCE -->
<asp:SqlDataSource ID="SqlDataSource1" runat="server"
        ConnectionString="<%$ ConnectionStrings:TrasnporteDB%>"
 
        SelectCommand="
        SELECT 
            p.IdPersona,
            pe.NombreCompleto,
            p.Telefono,
            p.Direccion
        FROM Propietarios p
        INNER JOIN Personas pe ON p.IdPersona = pe.IdPersona"
 
        InsertCommand="
        INSERT INTO Propietarios (IdPersona, Telefono, Direccion)
        VALUES (@IdPersona, @Telefono, @Direccion)"
 
        UpdateCommand="
        UPDATE Propietarios 
        SET Telefono=@Telefono, Direccion=@Direccion 
        WHERE IdPersona=@IdPersona"
 
        DeleteCommand="
        DELETE FROM Propietarios 
        WHERE IdPersona=@IdPersona">
 
        <InsertParameters>
<asp:ControlParameter Name="IdPersona" ControlID="ddlPersona" PropertyName="SelectedValue" />
<asp:ControlParameter Name="Telefono" ControlID="txtTelefono" PropertyName="Text" />
<asp:ControlParameter Name="Direccion" ControlID="txtDireccion" PropertyName="Text" />
</InsertParameters>
 
        <UpdateParameters>
<asp:ControlParameter Name="Telefono" ControlID="txtTelefono" PropertyName="Text" />
<asp:ControlParameter Name="Direccion" ControlID="txtDireccion" PropertyName="Text" />
<asp:ControlParameter Name="IdPersona" ControlID="ddlPersona" PropertyName="SelectedValue" />
</UpdateParameters>
 
        <DeleteParameters>
<asp:Parameter Name="IdPersona" Type="Int32" />
</DeleteParameters>
 
    </asp:SqlDataSource>
 
</asp:Content>