Imports Transporte.Models

Public Class MultaDB
    'Private db As New DbHelper
    'Public Function CrearMulta(ByVal modMulta As Models.Multa, ByRef errorMessage As String) As Boolean
    '    Using db.GetConnection()
    '        Dim query As String = "INSERT INTO dbo.Multas (IdVehiculo, IdTipoMulta, Fecha, MontoAplicado, Pagada) VALUES (@IdVehiculo, @IdTipoMulta, @Fecha, @MontoAplicado, @Pagada)"
    '        Dim parameters As New Dictionary(Of String, Object) From {
    '            {"@IdVehiculo", modMulta.IdVehiculo},
    '            {"@IdTipoMulta", modMulta.IdTipoMulta},
    '            {"@Fecha", modMulta.Fecha},
    '            {"@MontoAplicado", modMulta.MontoAplicado},
    '            {"@Pagada", modMulta.Pagada}
    '        }

    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    End Using
    '    Return True
    'End Function

    'Public Function EliminarMulta(idMulta As Integer, ByRef errorMessage As String) As Boolean
    '    Dim query As String = "DELETE FROM dbo.Multas WHERE IdMulta = @IdMulta"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '        {"@IdMulta", idMulta}
    '    }

    '    Return db.ExecuteNonQuery(query, parameters, errorMessage)

    'End Function

    'Public Function ConsultarMulta(idMulta As Integer, ByRef errorMessage As String) As Models.Multa
    '    Dim query As String = "SELECT * FROM dbo.Multas WHERE IdMulta = @IdMulta"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '        {"@IdMulta", idMulta}
    '    }

    '    Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)
    '    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '        Dim row As DataRow = dt.Rows(0)
    '        Dim multa As New Models.Multa() With {
    '            .IdMulta = Convert.ToInt32(row("IdMulta").ToString()),
    '            .IdVehiculo = Convert.ToInt32(row("IdVehiculo").ToString()),
    '            .IdTipoMulta = Convert.ToInt32(row("IdTipoMulta").ToString()),
    '            .Fecha = Convert.ToDateTime(row("Fecha").ToString()),
    '            .MontoAplicado = Convert.ToDecimal(row("MontoAplicado").ToString()),
    '            .Pagada = row("Pagada").ToString()
    '        }
    '        Return multa
    '    End If
    '    Return Nothing

    'End Function

    'Public Function ModificarMulta(modMulta As Models.Multa, ByRef errorMessage As String) As Boolean
    '    Dim query As String = "UPDATE dbo.Multas SET IdVehiculo = @IdVehiculo, IdTipoMulta = @IdTipoMulta, Fecha = @Fecha, MontoAplicado = @MontoAplicado, Pagada = @Pagada WHERE IdMulta = @IdMulta"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '            {"@IdVehiculo", modMulta.IdVehiculo},
    '            {"@IdTipoMulta", modMulta.IdTipoMulta},
    '            {"@Fecha", modMulta.Fecha},
    '            {"@MontoAplicado", modMulta.MontoAplicado},
    '            {"@Pagada", modMulta.Pagada},
    '            {"@IdMulta", modMulta.IdMulta}
    '    }
    '    Return db.ExecuteNonQuery(query, parameters, errorMessage)
    'End Function

End Class
