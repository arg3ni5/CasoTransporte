Imports Transporte.Models

Namespace Utils
    Public Class PropietarioDB

        Private db As New DbHelper()

        ' =========================
        ' INSERTAR
        ' =========================
        Public Function CrearPropietario(p As Propietario, ByRef errorMessage As String) As Boolean

            Dim query As String = "INSERT INTO Propietarios (IdPersona, Telefono, Direccion) 
                                  VALUES (@IdPersona, @Telefono, @Direccion)"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@IdPersona", p.IdPersona},
                {"@Telefono", p.Telefono},
                {"@Direccion", p.Direccion}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        End Function


        ' =========================
        ' ACTUALIZAR
        ' =========================
        Public Function ActualizarPropietario(p As Propietario, ByRef errorMessage As String) As Boolean

            Dim query As String = "UPDATE Propietarios 
                                  SET Telefono=@Telefono, Direccion=@Direccion 
                                  WHERE IdPersona=@IdPersona"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@IdPersona", p.IdPersona},
                {"@Telefono", p.Telefono},
                {"@Direccion", p.Direccion}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        End Function


        ' =========================
        ' ELIMINAR
        ' =========================
        Public Function EliminarPropietario(idPersona As Integer, ByRef errorMessage As String) As Boolean

            Dim query As String = "DELETE FROM Propietarios WHERE IdPersona=@IdPersona"

            Dim parametros As New Dictionary(Of String, Object) From {
                {"@IdPersona", idPersona}
            }

            Return db.ExecuteNonQuery(query, parametros, errorMessage)

        End Function


        ' =========================
        ' CONSULTAR UNO
        ' =========================
        Public Function ConsultarPropietario(idPersona As Integer, ByRef errorMessage As String) As Propietario

            Dim p As New Propietario()

            Try
                Using conn = db.GetConnection()
                    Dim query As String = "
                        SELECT p.IdPersona, pe.NombreCompleto, p.Telefono, p.Direccion
                        FROM Propietarios p
                        INNER JOIN Personas pe ON p.IdPersona = pe.IdPersona
                        WHERE p.IdPersona = @IdPersona"

                    Using cmd As New SqlClient.SqlCommand(query, conn)
                        cmd.Parameters.AddWithValue("@IdPersona", idPersona)

                        Using reader = cmd.ExecuteReader()
                            If reader.Read() Then
                                p.IdPersona = Convert.ToInt32(reader("IdPersona"))
                                p.NombreCompleto = reader("NombreCompleto").ToString()
                                p.Telefono = reader("Telefono").ToString()
                                p.Direccion = reader("Direccion").ToString()
                            End If
                        End Using
                    End Using
                End Using

                Return p

            Catch ex As Exception
                errorMessage = ex.Message
                Return Nothing
            End Try

        End Function


        ' =========================
        ' LISTAR TODOS
        ' =========================
        Public Function ListarPropietarios(ByRef errorMessage As String) As List(Of Propietario)

            Dim lista As New List(Of Propietario)

            Try
                Using conn = db.GetConnection()
                    Dim query As String = "
                        SELECT p.IdPersona, pe.NombreCompleto, p.Telefono, p.Direccion
                        FROM Propietarios p
                        INNER JOIN Personas pe ON p.IdPersona = pe.IdPersona"

                    Using cmd As New SqlClient.SqlCommand(query, conn)
                        Using reader = cmd.ExecuteReader()

                            While reader.Read()
                                Dim p As New Propietario With {
                                    .IdPersona = Convert.ToInt32(reader("IdPersona")),
                                    .NombreCompleto = reader("NombreCompleto").ToString(),
                                    .Telefono = reader("Telefono").ToString(),
                                    .Direccion = reader("Direccion").ToString()
                                }

                                lista.Add(p)
                            End While

                        End Using
                    End Using
                End Using

                Return lista

            Catch ex As Exception
                errorMessage = ex.Message
                Return Nothing
            End Try

        End Function

    End Class
End Namespace