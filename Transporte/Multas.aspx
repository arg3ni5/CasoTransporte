<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Multas.aspx.vb" Inherits="Transporte.Multas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Multas</title>

    <style>
        body {
            font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
            background: linear-gradient(135deg, #667eea, #764ba2);
            margin: 0;
        }

        .container {
            width: 400px;
            margin: 60px auto;
            padding: 25px;
            background: white;
            border-radius: 12px;
            box-shadow: 0 8px 25px rgba(0,0,0,0.2);
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
            color: #333;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            font-weight: 600;
            display: block;
            margin-bottom: 5px;
            color: #555;
        }

        input, select {
            width: 100%;
            padding: 10px;
            border-radius: 6px;
            border: 1px solid #ccc;
            transition: 0.3s;
        }

        input:focus, select:focus {
            border-color: #667eea;
            outline: none;
            box-shadow: 0 0 5px rgba(102,126,234,0.5);
        }

        .btn {
            width: 100%;
            padding: 12px;
            background: #667eea;
            color: white;
            border: none;
            border-radius: 6px;
            font-size: 16px;
            font-weight: bold;
            cursor: pointer;
            transition: 0.3s;
        }

        .btn:hover {
            background: #5a67d8;
        }

        .mensaje {
            margin-top: 15px;
            text-align: center;
            font-weight: bold;
        }

    </style>
</head>

<body>
    <form id="form1" runat="server">

        <div class="container">

            <h2>🚓 Registro de Multas</h2>

            <div class="form-group">
                <label>ID Multa</label>
                <asp:TextBox ID="txtIdMulta" runat="server" />
            </div>

            <div class="form-group">
                <label>Nombre</label>
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>

            <div class="form-group">
                <label>Cédula</label>
                <asp:TextBox ID="txtCedula" runat="server" />
            </div>

            <div class="form-group">
                <label>Tipo de Multa</label>
                <asp:DropDownList ID="ddlTipoMulta" runat="server">
                    <asp:ListItem Text="Exceso de velocidad" />
                    <asp:ListItem Text="Mal estacionado" />
                    <asp:ListItem Text="Sin licencia" />
                </asp:DropDownList>
            </div>

            <div class="form-group">
                <label>Monto</label>
                <asp:TextBox ID="txtMonto" runat="server" />
            </div>

            <div class="form-group">
                <label>Fecha</label>
                <asp:TextBox ID="txtFecha" runat="server" TextMode="Date" />
            </div>

            <div class="form-group">
                <label>Estado</label>
                <asp:DropDownList ID="ddlEstado" runat="server">
                    <asp:ListItem Text="Pendiente" />
                    <asp:ListItem Text="Pagada" />
                </asp:DropDownList>
            </div>

            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Multa" CssClass="btn" OnClick="btnGuardar_Click" />

            <asp:Label ID="lblMensaje" runat="server" CssClass="mensaje" />

        </div>

    </form>
</body>
</html>
