Public Class SiteMaster
    Inherits MasterPage
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim user = Session("User")
            If Session("User") IsNot Nothing Then
                userName.InnerText = Session("User").ToString()
            Else
                userName.InnerText = "INVITADO"
            End If
        End If
    End Sub

    Protected Sub logout_Click(sender As Object, e As EventArgs)
        Session.Clear()
        Response.Redirect("/UI/Login", False)
    End Sub
End Class