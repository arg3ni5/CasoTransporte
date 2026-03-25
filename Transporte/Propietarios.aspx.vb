Imports Transporte.Models
Imports Transporte.Utils

Public Class Propietarios
    Inherits System.Web.UI.Page

    Private db As New PropietarioDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
            CargarPropietarios()
        End If
    End Sub

    Private Sub CargarPersonas()
        ' Aquí podrías hacer otro DB si quieres nivel pro
        Using conn As New SqlClient.SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString)
            Dim cmd As New SqlClient.SqlCommand("SELECT IdPersona, NombreCompleto FROM Personas", conn)
            conn.Open()

            ddlPersona.DataSource = cmd.ExecuteReader()
            ddlPersona.DataTextField = "NombreCompleto"
            ddlPersona.DataValueField = "IdPersona"
            ddlPersona.DataBind()
        End Using
    End Sub

    Private Sub CargarPropietarios()
        Dim errorMsg As String = ""
        Dim lista = db.ListarPropietarios(errorMsg)

        If lista IsNot Nothing Then
            gvPropietarios.DataSource = lista
            gvPropietarios.DataBind()
        Else
            lblResultado.Text = errorMsg
        End If
    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Dim errorMsg As String = ""

        Dim p As New Propietario With {
            .IdPersona = Convert.ToInt32(ddlPersona.SelectedValue),
            .Telefono = txtTelefono.Text,
            .Direccion = txtDireccion.Text
        }

        If db.CrearPropietario(p, errorMsg) Then
            lblResultado.Text = "Guardado correctamente"
            CargarPropietarios()
        Else
            lblResultado.Text = errorMsg
        End If

    End Sub

    Protected Sub gvPropietarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        Dim id As Integer = Convert.ToInt32(gvPropietarios.DataKeys(e.RowIndex).Value)
        Dim errorMsg As String = ""

        If db.EliminarPropietario(id, errorMsg) Then
            CargarPropietarios()
        Else
            lblResultado.Text = errorMsg
        End If

    End Sub

    Protected Sub gvPropietarios_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim fila As GridViewRow = gvPropietarios.SelectedRow

        ddlPersona.SelectedValue = gvPropietarios.DataKeys(fila.RowIndex).Value.ToString()
        txtTelefono.Text = fila.Cells(2).Text
        txtDireccion.Text = fila.Cells(3).Text

    End Sub

End Class