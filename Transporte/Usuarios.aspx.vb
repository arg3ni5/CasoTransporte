Imports System.Configuration
Imports System.Data.SqlClient
Imports Transporte.Models
Imports Transporte.Utils
Public Class Usuarios1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            CargarPersonas()
        End If
    End Sub

    Private Sub CargarPersonas()
        Dim connString As String = ConfigurationManager.ConnectionStrings("ConexionDB").ConnectionString

        Using conn As New SqlConnection(connString)
            Dim query As String = "SELECT IdPersona, Username, PasswordHash, Rol, Activo FROM Usuarios"
            Dim cmd As New SqlCommand(query, conn)
            Dim da As New SqlDataAdapter(cmd)
            Dim dt As New DataTable()

            da.Fill(dt)

            gvUsuarios.DataSource = dt
            gvUsuarios.DataBind()
        End Using
    End Sub

    Protected Sub gvUsuarios_RowCommand(sender As Object, e As GridViewCommandEventArgs)

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)
        Dim usuarios As New Models.Usuarios()
        If txtIdPersona.Text = "" Or txtUsername.Text = "" Or txtPassword.Text = "" Or ddlRol.SelectedValue = "" Then
            SwalUtils.ShowSwalError(Me, "Por favor, complete todos los campos obligatorios.")
            Return
        End If
        usuarios.IdPersona = Convert.ToInt32(txtIdPersona.Text.Trim())
        usuarios.Username = txtUsername.Text.Trim()


    End Sub
End Class