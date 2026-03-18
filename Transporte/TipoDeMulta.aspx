<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="TipoDeMulta.aspx.vb" Inherits="Transporte.TipoDeMulta" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Tipos de Multa</title>

    <style>
        body {
            font-family: Arial;
            background-color: #f4f6f9;
        }

        .container {
            width: 400px;
            margin: 50px auto;
        }

        .card {
            background: white;
            padding: 25px;
            border-radius: 10px;
            box-shadow: 0px 0px 10px rgba(0,0,0,0.1);
        }

        h2 {
            text-align: center;
            margin-bottom: 20px;
        }

        .form-group {
            margin-bottom: 15px;
        }

        label {
            display: block;
            font-weight: bold;
            margin-bottom: 5px;
        }

        input, select {
            width: 100%;
            padding: 8px;
            border-radius: 5px;
            border: 1px solid #ccc;
        }

        .buttons {
            text-align: center;
            margin-top: 20px;
        }

        .btn {
            padding: 8px 15px;
            margin: 5px;
            border: none;
            border-radius: 5px;
            cursor: pointer;
        }

        .btn-primary { background-color: #007bff; color: white; }
        .btn-success { background-color: #28a745; color: white; }
        .btn-warning { background-color: #ffc107; }
        .btn-danger { background-color: #dc3545; color: white; }

        .btn:hover {
            opacity: 0.9;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="card">

                <h2>Tipos de Multa</h2>

                <div class="form-group">
                    <label>Descripción</label>
                    <asp:DropDownList ID="ddlDescripcion" runat="server">
                        <asp:ListItem Text="Exceso de velocidad" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Estacionado en lugar prohibido" Value="2"></asp:ListItem>
                        <asp:ListItem Text="No utiliza casco" />
                        <asp:ListItem Text="Maneja en estado ebriedad" />
                        <asp:ListItem Text="Maneja sin licencia" />
                        <asp:ListItem Text="Irrespeto un alto" />
                        <asp:ListItem Text="No utiliza el cinturon de seguridad" />
                        <asp:ListItem Text="Utiliza el celular mientras maneja" />




                    </asp:DropDownList>
                </div>

                <div class="form-group">
                    <label>Monto</label>
                    <asp:TextBox ID="txtMonto" runat="server"></asp:TextBox>
                </div>

                <div class="form-group">
                    <label>Estado</label>
                    <asp:DropDownList ID="ddlEstado" runat="server">
                        <asp:ListItem Text="Activo" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Inactivo" Value="0"></asp:ListItem>
                    </asp:DropDownList>
                </div>

                <div class="buttons">
                    <asp:Button ID="btnNuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary" />
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-success" />
                    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btn btn-warning" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger" />
                </div>

            </div>
        </div>
    </form>
</body>
</html>