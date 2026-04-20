<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Multas.aspx.vb" Inherits="Multas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multas</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <h2>Registro de Multas</h2>

            <asp:Label Text="ID Multa:" runat="server" />
            <asp:TextBox ID="txtIdMulta" runat="server" /><br />

            <asp:Label Text="Nombre:" runat="server" />
            <asp:TextBox ID="txtNombre" runat="server" /><br />

            <asp:Label Text="Cédula:" runat="server" />
            <asp:TextBox ID="txtCedula" runat="server" /><br />

            <asp:Label Text="Tipo de Multa:" runat="server" />
            <asp:DropDownList ID="ddlTipoMulta" runat="server">
                <asp:ListItem Text="Exceso de velocidad" />
                <asp:ListItem Text="Mal estacionado" />
                <asp:ListItem Text="Sin licencia" />
            </asp:DropDownList><br />

            <asp:Label Text="Monto:" runat="server" />
            <asp:TextBox ID="txtMonto" runat="server" /><br />

            <asp:Label Text="Fecha:" runat="server" />
            <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" /><br />

            <asp:Label Text="Estado:" runat="server" />
            <asp:DropDownList ID="ddlEstado" runat="server">
                <asp:ListItem Text="Pendiente" />
                <asp:ListItem Text="Pagada" />
            </asp:DropDownList><br /><br />

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />

            <asp:Label ID="lblMensaje" runat="server" />

        </div>
    </form>
</body>
</html>
