Public Class Propietario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    ' =========================
    ' GUARDAR
    ' =========================
    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Try
            If String.IsNullOrEmpty(txtTelefono.Text) Or String.IsNullOrEmpty(txtDireccion.Text) Then
                lblResultado.CssClass = "alert alert-warning"
                lblResultado.Text = "Complete todos los campos"
                Return
            End If

            If ViewState("IdPersona") Is Nothing Then
                SqlDataSource1.Insert()
                lblResultado.CssClass = "alert alert-success"
                lblResultado.Text = "Registro guardado correctamente"
            Else
                SqlDataSource1.Update()
                lblResultado.CssClass = "alert alert-warning"
                lblResultado.Text = "Registro actualizado correctamente"
            End If

            gvPropietarios.DataBind()
            Limpiar()

        Catch ex As Exception
            lblResultado.CssClass = "alert alert-danger"
            lblResultado.Text = ex.Message
        End Try

    End Sub

    ' =========================
    ' EDITAR
    ' =========================
    Protected Sub gvPropietarios_SelectedIndexChanged(sender As Object, e As EventArgs)

        Dim row As GridViewRow = gvPropietarios.SelectedRow
        Dim id As Integer = Convert.ToInt32(gvPropietarios.SelectedDataKey.Value)

        ddlPersona.SelectedValue = id
        txtTelefono.Text = row.Cells(2).Text
        txtDireccion.Text = row.Cells(3).Text

        ViewState("IdPersona") = id

    End Sub

    ' =========================
    ' ELIMINAR
    ' =========================
    Protected Sub gvPropietarios_RowDeleting(sender As Object, e As GridViewDeleteEventArgs)

        lblResultado.CssClass = "alert alert-danger"
        lblResultado.Text = "Registro eliminado correctamente"

    End Sub

    ' =========================
    ' LIMPIAR
    ' =========================
    Private Sub Limpiar()
        txtTelefono.Text = ""
        txtDireccion.Text = ""
        ddlPersona.SelectedIndex = 0
        ViewState("IdPersona") = Nothing
    End Sub

End Class