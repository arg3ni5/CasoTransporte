Public Class TipoDeMulta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load

    End Sub

    Protected Sub ddlDescripcion_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim monto As Integer = 0
        Dim opcion As Integer = Convert.ToInt32(ddlDescripcion.SelectedValue)

        Select Case ddlDescripcion.SelectedValue.Trim()

            Case "1"
                txtMonto.Text = "200,195.06 colones"

            Case "2"
                txtMonto.Text = "122,597.53 colones"

            Case "3"
                txtMonto.Text = "122,597.58 colones"

            Case "4"
                txtMonto.Text = "362,839.56 colones"


            Case "5"
                txtMonto.Text = "122,800.96 colones"

            Case "6"
                txtMonto.Text = "245,195.06 colones"

            Case "7"
                txtMonto.Text = "130,525.11 colones"

            Case "8"
                txtMonto.Text = "80,000 colones"

            Case Else
                txtMonto.Text = ""

        End Select



    End Sub

End Class