<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="TipoDeMulta.aspx.vb" Inherits="Transporte.TipoDeMulta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Catálogo Tipo de Multa</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>Catálogo de Tipos de Multa</h2>

    <table>

        <tr>
            <td>Descripción:</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server" Width="250px"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Monto:</td>
            <td>
                <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>Estado:</td>
            <td>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Value="1">Activo</asp:ListItem>
                    <asp:ListItem Value="0">Inactivo</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>

    </table>

    <br />

    <asp:Button ID="btnConsulta" runat="server" Text="Consulta" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />
    <asp:Button ID="btnInsertar" runat="server" Text="Insertar" />
    <asp:Button ID="btnModificar" runat="server" Text="Modificar" />

    <br /><br />

    <asp:GridView ID="gvTipoMulta" runat="server" AutoGenerateColumns="False" Width="500px">

        <Columns>

            <asp:BoundField DataField="IdTipoMulta" HeaderText="ID" />

            <asp:BoundField DataField="Descripcion" HeaderText="Descripción" />

            <asp:BoundField DataField="Monto" HeaderText="Monto" />

            <asp:BoundField DataField="Estado" HeaderText="Estado" />

        </Columns>

    </asp:GridView>

</form>
</body>
</html>