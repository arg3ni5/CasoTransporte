Imports System.Data.SqlClient
Imports System.Configuration

Public Class DbHealper
    Private connectionString As String = ConfigurationManager.ConnectionStrings("Nombrededb").ConnectionString

    ' Método para abrir conexión
    Public Function GetConnection() As SqlConnection
        Dim conn As New SqlConnection(connectionString)
        Try
            conn.Open()
        Catch ex As Exception
            conn.Dispose()
            Throw New Exception("Error al abrir la conexión: " & ex.Message)
        End Try
        Return conn
    End Function

    ' INSERT TipoMulta
    Public Function InsertTipoMulta(descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean
        Dim query As String = "INSERT INTO TipoMulta (Descripcion, MontoBase, Activa) VALUES (@Descripcion, @MontoBase, @Activa)"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Descripcion", descripcion},
            {"@MontoBase", montoBase},
            {"@Activa", activa}
        }
        Return ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    ' UPDATE TipoMulta
    Public Function UpdateTipoMulta(id As Integer, descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean
        Dim query As String = "UPDATE TipoMulta SET Descripcion=@Descripcion, MontoBase=@MontoBase, Activa=@Activa WHERE IdTipoMulta=@Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id},
            {"@Descripcion", descripcion},
            {"@MontoBase", montoBase},
            {"@Activa", activa}
        }
        Return ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    ' DELETE TipoMulta
    Public Function DeleteTipoMulta(id As Integer, ByRef errorMessage As String) As Boolean
        Dim query As String = "DELETE FROM TipoMulta WHERE IdTipoMulta=@Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Return ExecuteNonQuery(query, parameters, errorMessage)
    End Function

    ' SELECT TipoMulta
    Public Function GetTipoMulta(Optional id As Integer? = Nothing, Optional ByRef errorMessage As String = "") As DataTable
        Dim query As String = "SELECT IdTipoMulta, Descripcion, MontoBase, Activa FROM TipoMulta"
        Dim parameters As Dictionary(Of String, Object) = Nothing

        If id.HasValue Then
            query &= " WHERE IdTipoMulta=@Id"
            parameters = New Dictionary(Of String, Object) From {
                {"@Id", id.Value}
            }
        End If

        Return ExecuteQuery(query, parameters, errorMessage)
    End Function

    ' Método genérico para ejecutar INSERT/UPDATE/DELETE
    Private Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As Boolean
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía")
        End If
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Try
                    cmd.ExecuteNonQuery()
                    Return True
                Catch ex As Exception
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message
                    Return False
                End Try
            End Using
        End Using
    End Function

    ' Método genérico para ejecutar SELECT
    Private Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As DataTable
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía")
        End If
        Dim dt As New DataTable()
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    For Each p In parameters
                        cmd.Parameters.AddWithValue(p.Key, p.Value)
                    Next
                End If
                Try
                    Using adapter As New SqlDataAdapter(cmd)
                        adapter.Fill(dt)
                    End Using
                    Return dt
                Catch ex As Exception
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message
                    Return Nothing
                End Try
            End Using
        End Using
    End Function
End Class