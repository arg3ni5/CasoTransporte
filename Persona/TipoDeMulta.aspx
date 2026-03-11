<%@ Page Language="VB" AutoEventWireup="false" CodeBehind="TipoMultas.aspx.vb" Inherits="Persona.TipoMultas" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Catálogo de Tipos de Multas</title>
</head>
<body>
<form id="form1" runat="server">

    <h2>Catálogo de Tipos de Multas</h2>

    <asp:Label ID="Label1" runat="server" Text="ID Multa"></asp:Label>
    <asp:TextBox ID="txtIdMulta" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Label ID="Label2" runat="server" Text="Descripción"></asp:Label>
    <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Label ID="Label3" runat="server" Text="Monto"></asp:Label>
    <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" />
    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" />
    <asp:Button ID="btnEditar" runat="server" Text="Editar" />
    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" />

    <br /><br />

    <asp:GridView ID="GridViewMultas" runat="server" AutoGenerateColumns="True">
    </asp:GridView>

</form>
</body>
</html>