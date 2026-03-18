Imports System.Data.SqlClient

Public Class TipoMultaDB
    Private db As New DbHealper
    'Public Function CrearTipoMulta(modTipoMulta As Models.TipoMulta, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Inserta_TipoMulta"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@Descripcion", modTipoMulta.Descripcion),
    '            New SqlParameter("@MontoBase", modTipoMulta.MontoBase),
    '            New SqlParameter("@Activa", modTipoMulta.Activa)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function EliminarTipoMulta(idTipoMulta As Integer, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Eliminar_TipoMulta"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdTipoMulta", idTipoMulta)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function ModificarTipoMulta(modTipoMulta As Models.TipoMulta, ByRef errorMessage As String) As Boolean
    '    Try
    '        Dim query As String = "sp_Modifica_TipoMulta"
    '        Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdTipoMulta", modTipoMulta.IdTipoMulta),
    '            New SqlParameter("@Descripcion", modTipoMulta.Descripcion),
    '            New SqlParameter("@MontoBase", modTipoMulta.MontoBase),
    '            New SqlParameter("@Activa", modTipoMulta.Activa)
    '        }
    '        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    '    Catch ex As Exception
    '        Return False
    '    End Try
    'End Function

    'Public Function ConsultarTipoMulta(idTipoMulta As Integer, ByRef errorMessage As String) As Models.TipoMulta
    '    Dim query As String = "sp_Consulta_TipoMulta"
    '    Dim parameters As New List(Of SqlParameter) From {
    '            New SqlParameter("@IdTipoMulta", idTipoMulta)
    '        }
    '    Dim dt As DataTable = db.ExecuteQuery(query, parameters, True, errorMessage)

    '    If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
    '        Dim row As DataRow = dt.Rows(0)
    '        Dim tipoMulta As New Models.TipoMulta() With {
    '            .IdTipoMulta = Convert.ToInt32(row("IdTipoMulta").ToString()),
    '            .Descripcion = row("Descripcion").ToString(),
    '            .MontoBase = Convert.ToDecimal(row("MontoBase")),
    '            .Activa = row("Activa").ToString()
    '        }
    '        Return tipoMulta
    '    End If
    '    Return Nothing
    'End Function
End Class