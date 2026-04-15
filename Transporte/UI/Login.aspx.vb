Imports Transporte.Models
Imports Transporte.Utils

Public Class Login
    Inherits System.Web.UI.Page

    Private dbUsuario As New UsuarioDB()

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnLogin_Click(sender As Object, e As EventArgs)
        Dim errorMessage As String

        Dim encryptor As New Simple3Des("frase$-secreta-123")
        Dim PasswordHash = encryptor.EncryptData(txtPass.Text)

        Dim result = dbUsuario.Login(txtUsername.Text, PasswordHash, errorMessage)

        If result.Rows.Count = 0 Then
            SwalUtils.ShowSwalError(Me, "Error de Login", errorMessage)
        Else
            Dim user = result.Rows(0)
            Session("User") = user("Username")
            Session("Rol") = user("Rol")

            If user("Rol") = "ADMIN" Then
                Response.Redirect("../Usuarios.aspx", False)
            Else
                Response.Redirect("/", False)
            End If
        End If
    End Sub
End Class