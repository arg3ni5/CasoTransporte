Public Class frmVehiculos
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnGuardar_Click(sender As Object, e As EventArgs)

        Dim vehiculos As New Models.Vehiculos()

        If txtIDPropietario.Text.Trim() = "" Or txtIDVehiculo.Text.Trim() = "" Or txtPlaca.Text.Trim() = "" Or txtModelo.Text.Trim() = "" Or ddlMarca.Text.Trim() = "0" Then
            lblResultado.Text = "Por favor, complete todos los campos."
            Return
        End If

        vehiculos.TipoID = ddlTipoID.SelectedItem.Value
        vehiculos.IDPropietario = txtIDPropietario.Text
        vehiculos.IDVehiculo = txtIDVehiculo.Text
        vehiculos.Placa = txtPlaca.Text
        vehiculos.Modelo = txtModelo.Text
        vehiculos.Marca = ddlMarca.SelectedItem.Value

        lblResultado.Text = vehiculos.Resumen()

        Dim ErrorMessage As String = ""


    End Sub

End Class