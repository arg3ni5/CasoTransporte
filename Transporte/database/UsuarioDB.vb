Public Class UsuarioDB
    Private db As New DBHelper()
    Public Function CrearUsuario(ByVal pUsuario As Models.Usuarios, ByRef errorMessage As String) As Boolean
        ' Lógica para crear un nuevo usuario en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Usuarios (IdPersona, Username, PasswordHash, Rol, Activo) 
                              VALUES (@IdPersona, @Username, @PasswordHash, @Rol, @Activo)"

            Dim parameters As New Dictionary(Of String, Object) From {
                {"@IdPersona", pUsuario.IdPersona},
                {"@Username", pUsuario.Username},
                {"@PasswordHash", pUsuario.PasswordHash},
                {"@Rol", pUsuario.Rol},
                {"@Activo", pUsuario.Activo}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using

        Return False
    End Function

End Class
