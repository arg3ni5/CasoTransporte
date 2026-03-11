Imports Transporte.Models

Public Class MultaDB

    Private db As New DbHelper
    Public Function CrearMulta(ByVal modMulta As Models.Multa, ByRef errorMessage As String) As Boolean
        Using db.GetConnection()
            Dim query As String = "INSERT INTO dbo.TipoMulta (Descripcion, MontoBase, Activa) VALUES (@Descripcion, @MontoBase, @Activa)"
            Dim parameters As New Dictionary(Of String, Object) From {
                {"@Descripcion", modTipoMulta.Descripcion},
                {"@MontoBase", modTipoMulta.MontoBase},
                {"@Activa", modTipoMulta.Activa}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using
        Return True
    End Function

    Public Function EliminarMulta(idMulta As Integer, ByRef errorMessage As String) As Boolean
        Dim query As String = "DELETE FROM dbo.TipoMulta WHERE IdTipoMulta = @IdTipoMulta"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@IdMulta", idMulta}
        }

        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Public Function ConsultarMulta(idMulta As Integer, ByRef errorMessage As String) As Models.TipoMulta
        Dim query As String = "SELECT * FROM dbo.TipoMulta WHERE IdTipoMulta = @IdTipoMulta"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@IdMulta", idMulta}
        }

        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim tipoMulta As New Models.TipoMulta() With {
                .IdTipoMulta = Convert.ToInt32(row("IdTipoMulta").ToString()),
                .Descripcion = row("Descripcion").ToString(),
                .MontoBase = Convert.ToDecimal(row("MontoBase")),
                .Activa = row("Activa").ToString()
            }
            Return tipoMulta
        End If
        Return Nothing

    End Function

    Public Function ModificarMulta(modTipoMulta As Models.TipoMulta, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE dbo.TipoMulta SET Descripcion = @Descripcion, MontoBase = @MontoBase, Activa = @Activa WHERE IdTipoMulta = @IdTipoMulta"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Descripcion", modTipoMulta.Descripcion},
            {"@MontoBase", modTipoMulta.MontoBase},
            {"@Activa", modTipoMulta.Activa},
            {"@IdTipoMulta", modTipoMulta.IdTipoMulta}
        }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function

End Class
