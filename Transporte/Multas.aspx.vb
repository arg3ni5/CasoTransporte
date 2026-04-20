Imports System
Imports System.Data.SqlClient

Public Class Multas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Try
            ' 🔍 Validaciones básicas
            If txtIdMulta.Text = "" Or txtNombre.Text = "" Or txtCedula.Text = "" Or txtMonto.Text = "" Or txtFecha.Text = "" Then
                lblMensaje.Text = "Por favor complete todos los campos."
                lblMensaje.ForeColor = Drawing.Color.Red
                Exit Sub
            End If

            ' 📥 Captura de datos
            Dim id As String = txtIdMulta.Text
            Dim nombre As String = txtNombre.Text
            Dim cedula As String = txtCedula.Text
            Dim tipo As String = ddlTipoMulta.SelectedValue
            Dim monto As Decimal = Convert.ToDecimal(txtMonto.Text)
            Dim fecha As Date = Convert.ToDateTime(txtFecha.Text)
            Dim estado As String = ddlEstado.SelectedValue

            ' 🔌 Conexión a la base de datos
            Dim conexion As New SqlConnection("Data Source=TU_SERVIDOR;Initial Catalog=TU_BASE_DATOS;Integrated Security=True")

            Dim query As String = "INSERT INTO Multas (IdMulta, Nombre, Cedula, TipoMulta, Monto, Fecha, Estado) 
                                  VALUES (@id, @nombre, @cedula, @tipo, @monto, @fecha, @estado)"

            Dim cmd As New SqlCommand(query, conexion)

            cmd.Parameters.AddWithValue("@id", id)
            cmd.Parameters.AddWithValue("@nombre", nombre)
            cmd.Parameters.AddWithValue("@cedula", cedula)
            cmd.Parameters.AddWithValue("@tipo", tipo)
            cmd.Parameters.AddWithValue("@monto", monto)
            cmd.Parameters.AddWithValue("@fecha", fecha)
            cmd.Parameters.AddWithValue("@estado", estado)

            conexion.Open()
            cmd.ExecuteNonQuery()
            conexion.Close()

            ' ✅ Mensaje de éxito
            lblMensaje.Text = "Multa guardada correctamente."
            lblMensaje.ForeColor = Drawing.Color.Green

            ' 🧹 Limpiar campos
            LimpiarCampos()

        Catch ex As Exception
            lblMensaje.Text = "Error: " & ex.Message
            lblMensaje.ForeColor = Drawing.Color.Red
        End Try

    End Sub

    Private Sub LimpiarCampos()
        txtIdMulta.Text = ""
        txtNombre.Text = ""
        txtCedula.Text = ""
        txtMonto.Text = ""
        txtFecha.Text = ""
        ddlTipoMulta.SelectedIndex = 0
        ddlEstado.SelectedIndex = 0
    End Sub

End Class