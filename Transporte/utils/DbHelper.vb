Imports System.Data.SqlClient
Imports System.Configuration

Namespace Utils
    Public Class DbHelper

        Private connectionString As String = ConfigurationManager.ConnectionStrings("II-46ConnectionString").ConnectionString

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

        Public Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As Boolean
            Try
                Using conn As SqlConnection = GetConnection()
                    Using cmd As New SqlCommand(query, conn)

                        If parameters IsNot Nothing Then
                            For Each p In parameters
                                cmd.Parameters.AddWithValue(p.Key, p.Value)
                            Next
                        End If

                        cmd.ExecuteNonQuery()
                        Return True
                    End Using
                End Using
            Catch ex As Exception
                errorMessage = "Error al ejecutar la consulta: " & ex.Message
                Return False
            End Try
        End Function

    End Class
End Namespace