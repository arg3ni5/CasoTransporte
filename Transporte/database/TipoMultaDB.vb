Imports Transporte.Models

Public Class TipoMultaDB

    Private db As New DbHealper

    ' 🔹 INSERT
    Public Function CrearTipoMulta(modTipoMulta As TipoMulta, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "INSERT INTO TipoMulta (Descripcion, MontoBase, Activa) 
                                  VALUES (@descripcion, @monto, @activa)"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@descripcion", modTipoMulta.Descripcion},
                {"@monto", modTipoMulta.MontoBase},
                {"@activa", modTipoMulta.Activa}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 DELETE
    Public Function EliminarTipoMulta(idTipoMulta As Integer, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "DELETE FROM TipoMulta WHERE IdTipoMulta = @id"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@id", idTipoMulta}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 UPDATE
    Public Function ModificarTipoMulta(modTipoMulta As TipoMulta, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "UPDATE TipoMulta SET 
                                  Descripcion=@descripcion,
                                  MontoBase=@monto,
                                  Activa=@activa
                                  WHERE IdTipoMulta=@id"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@id", modTipoMulta.IdTipoMulta},
                {"@descripcion", modTipoMulta.Descripcion},
                {"@monto", modTipoMulta.MontoBase},
                {"@activa", modTipoMulta.Activa}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 SELECT
    Public Function ConsultarTipoMulta(idTipoMulta As Integer, ByRef errorMessage As String) As TipoMulta

        Dim query As String = "SELECT * FROM TipoMulta WHERE IdTipoMulta = @id"

        Dim parametros As New Dictionary(Of String, Object) From {
            {"@id", idTipoMulta}
        }

        Dim dt As DataTable = db.ExecuteQuery(query, parametros, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim row As DataRow = dt.Rows(0)

            Dim tipoMulta As New TipoMulta() With {
                .IdTipoMulta = Convert.ToInt32(row("IdTipoMulta")),
                .Descripcion = row("Descripcion").ToString(),
                .MontoBase = Convert.ToDecimal(row("MontoBase")),
                .Activa = Convert.ToBoolean(row("Activa"))
            }

            Return tipoMulta
        End If

        Return Nothing
    End Function

End Class