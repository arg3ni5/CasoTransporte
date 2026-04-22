Imports Transporte.Models

Public Class MultaDB

    Private db As New DbHealper

    ' 🔹 INSERT
    Public Function CrearMulta(modMulta As Multa, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "INSERT INTO Multa (IdVehiculo, IdTipoMulta, Fecha, MontoAplicado, Pagada) 
                                  VALUES (@vehiculo, @tipo, @fecha, @monto, @pagada)"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@vehiculo", modMulta.IdVehiculo},
                {"@tipo", modMulta.IdTipoMulta},
                {"@fecha", modMulta.Fecha},
                {"@monto", modMulta.MontoAplicado},
                {"@pagada", modMulta.Pagada}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 DELETE
    Public Function EliminarMulta(idMulta As Integer, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "DELETE FROM Multa WHERE IdMulta = @id"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@id", idMulta}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 UPDATE
    Public Function ModificarMulta(modMulta As Multa, ByRef errorMessage As String) As Boolean
        Try
            Dim query As String = "UPDATE Multa SET 
                                  IdVehiculo=@vehiculo,
                                  IdTipoMulta=@tipo,
                                  Fecha=@fecha,
                                  MontoAplicado=@monto,
                                  Pagada=@pagada
                                  WHERE IdMulta=@id"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@id", modMulta.IdMulta},
                {"@vehiculo", modMulta.IdVehiculo},
                {"@tipo", modMulta.IdTipoMulta},
                {"@fecha", modMulta.Fecha},
                {"@monto", modMulta.MontoAplicado},
                {"@pagada", modMulta.Pagada}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        Catch ex As Exception
            errorMessage = ex.Message
            Return False
        End Try
    End Function

    ' 🔹 SELECT
    Public Function ConsultarMulta(idMulta As Integer, ByRef errorMessage As String) As Multa

        Dim query As String = "SELECT * FROM Multa WHERE IdMulta = @id"

        Dim parametros As New Dictionary(Of String, Object) From {
            {"@id", idMulta}
        }

        Dim dt As DataTable = db.ExecuteQuery(query, parametros, errorMessage)

        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then

            Dim row As DataRow = dt.Rows(0)

            Dim multa As New Multa() With {
                .IdMulta = Convert.ToInt32(row("IdMulta")),
                .IdVehiculo = Convert.ToInt32(row("IdVehiculo")),
                .IdTipoMulta = Convert.ToInt32(row("IdTipoMulta")),
                .Fecha = Convert.ToDateTime(row("Fecha")),
                .MontoAplicado = Convert.ToDecimal(row("MontoAplicado")),
                .Pagada = Convert.ToBoolean(row("Pagada"))
            }

            Return multa
        End If

        Return Nothing
    End Function

End Class
