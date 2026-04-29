Imports System.Data.SqlClient
Imports Persona.Utils
Public Class PersonaDB
    Private db As New DbHealper()
    'Crear Persona
    Public Function CrearPersona(ByVal pPersona As Models.Persona, ByRef errorMessage As String) As Boolean
        'Lógica para crear una nueva persona en la base de datos
        Using db.GetConnection()
            Dim query As String = "INSERT INTO Personas (TipoDocumento, Documento, Nombre, Apellidos, FechaNac, Correo) 
            VALUES (@TipoDocumento, @Documento, @Nombre, @Apellidos, @FechaNac, @Correo)"


            Dim parameters As New Dictionary(Of String, Object) From {
              {"@Nombre", pPersona.Nombre},
              {"@FechaNac", pPersona.FechaNacimiento},
              {"@Correo", pPersona.Correo},
              {"@Apellidos", pPersona.Apellidos},
              {"@Documento", pPersona.NumeroDocumento},
              {"@TipoDocumento", pPersona.TipoDocumento}
            }

            Return db.ExecuteNonQuery(query, parameters, errorMessage)
        End Using
        Return True
    End Function
    Public Function EliminarPersona(ByVal id As Integer, ByRef errorMessage As String) As Boolean

        Dim query As String = "DELETE FROM Personas WHERE IDPersona = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
                {"@Id", id}
            }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)

    End Function

    Public Function ConsultarPersona(id As String, ByRef errorMessage As String) As Models.Persona
        Dim query As String = "SELECT * FROM Personas WHERE IDPersona = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id}
        }
        Dim dt As DataTable = db.ExecuteQuery(query, parameters, errorMessage)
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            Dim row As DataRow = dt.Rows(0)
            Dim persona As New Models.Persona() With {
                .Nombre = row("Nombre").ToString(),
                .Apellidos = row("Apellidos").ToString(),
                .FechaNacimiento = Convert.ToDateTime(row("FechaNac")),
                .Correo = row("Correo").ToString(),
                .NumeroDocumento = row("Documento").ToString(),
                .TipoDocumento = row("TipoDocumento").ToString()
            }
            Return persona
        End If
        Return Nothing
    End Function

    Public Function ActualizarPersona(persona As Models.Persona, errorMessage As String) As Boolean
        Dim query As String = "UPDATE Personas SET Nombre = @Nombre, Apellidos = @Apellidos, FechaNac = @FechaNac, Correo = @Correo, Documento = @Documento, TipoDocumento = @TipoDocumento WHERE IDPersona = @Id"
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Nombre", persona.Nombre},
            {"@Apellidos", persona.Apellidos},
            {"@FechaNac", persona.FechaNacimiento},
            {"@Correo", persona.Correo},
            {"@Documento", persona.NumeroDocumento},
            {"@TipoDocumento", persona.TipoDocumento},
            {"@Id", persona.IdPersona}
        }
        Return db.ExecuteNonQuery(query, parameters, errorMessage)
    End Function
End Class
