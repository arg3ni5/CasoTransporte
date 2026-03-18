Imports System.Data.SqlClient
Imports Transporte.Models

Public Class MultaDB
    Private db As New DbHealper

    'Public Function CrearMulta(modMulta As Models.Multa, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Inserta_Multa"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdVehiculo", modMulta.IdVehiculo),
    '            New SqlParameter("@IdTipoMulta", modMulta.IdTipoMulta),
    '            New SqlParameter("@Fecha", modMulta.Fecha),
    '            New SqlParameter("@MontoAplicado", modMulta.MontoAplicado),
    '            New SqlParameter("@Pagada", modMulta.Pagada)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function EliminarMulta(idMulta As Integer, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Elimina_Multa"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdMulta", idMulta)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function ModificarMulta(modMulta As Models.Multa, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Modifica_Multa"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdVehiculo", modMulta.IdVehiculo),
    '            New SqlParameter("@IdTipoMulta", modMulta.IdTipoMulta),
    '            New SqlParameter("@Fecha", modMulta.Fecha),
    '            New SqlParameter("@MontoAplicado", modMulta.MontoAplicado),
    '            New SqlParameter("@Pagada", modMulta.Pagada)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
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



End Class
