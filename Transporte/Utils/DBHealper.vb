Imports System.Data.SqlClient ' Asegúrate de tener esta referencia
Imports System.Configuration ' Para acceder a la cadena de conexión desde el archivo de configuración

Public Class DbHealper
    Private connectionString As String = ConfigurationManager.ConnectionStrings("Nombrededb").ConnectionString ' Asegúrate de que "Nombrededb" coincida con el nombre de tu cadena de conexión en el archivo de configuración

    ' Método para abrir conexión
    Public Function GetConnection() As SqlConnection ' Cambiar a SqlConnection si estás usando SQL Server
        Dim conn As New SqlConnection(connectionString) ' Cambiar a SqlConnection si estás usando SQL Server
        Try ' Manejo de excepciones para abrir la conexión
            conn.Open() ' Abrir la conexión
        Catch ex As Exception ' Capturar cualquier error al abrir la conexión
            conn.Dispose() ' Asegurarse de liberar recursos si la conexión falla
            Throw New Exception("Error al abrir la conexión: " & ex.Message) ' Lanzar una nueva excepción con un mensaje más claro
        End Try ' Fin del bloque Try-Catch
        Return conn ' Devolver la conexión abierta
    End Function ' Fin del método GetConnection

    ' INSERT TipoMulta
<<<<<<< HEAD
    Public Function InsertTipoMulta(descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean ' Método para insertar un nuevo registro en la tabla TipoMulta
        Dim query As String = "INSERT INTO TipoMulta (Descripcion, MontoBase, Activa) VALUES (@Descripcion, @MontoBase, @Activa)" ' Consulta SQL para insertar un nuevo registro en la tabla TipoMulta
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Descripcion", descripcion},
            {"@MontoBase", montoBase},
            {"@Activa", activa} ' Agregar los parámetros necesarios para la consulta SQL, utilizando un diccionario para facilitar la gestión de los parámetros
        }
        Return ExecuteNonQuery(query, parameters, errorMessage) ' Llamar al método genérico ExecuteNonQuery para ejecutar la consulta SQL, pasando la consulta, los parámetros y una variable para capturar cualquier mensaje de error
    End Function

    ' UPDATE TipoMulta
    Public Function UpdateTipoMulta(id As Integer, descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean ' Método para actualizar un registro existente en la tabla TipoMulta
        Dim query As String = "UPDATE TipoMulta SET Descripcion=@Descripcion, MontoBase=@MontoBase, Activa=@Activa WHERE IdTipoMulta=@Id" ' Consulta SQL para actualizar un registro existente en la tabla TipoMulta, utilizando el IdTipoMulta para identificar el registro a actualizar
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id},
            {"@Descripcion", descripcion},
            {"@MontoBase", montoBase},
            {"@Activa", activa} ' Agregar los parámetros necesarios para la consulta SQL, utilizando un diccionario para facilitar la gestión de los parámetros
        }
        Return ExecuteNonQuery(query, parameters, errorMessage) ' Llamar al método genérico ExecuteNonQuery para ejecutar la consulta SQL, pasando la consulta, los parámetros y una variable para capturar cualquier mensaje de error
    End Function

    ' DELETE TipoMulta
    Public Function DeleteTipoMulta(id As Integer, ByRef errorMessage As String) As Boolean ' Método para eliminar un registro existente en la tabla TipoMulta
        Dim query As String = "DELETE FROM TipoMulta WHERE IdTipoMulta=@Id" ' Consulta SQL para eliminar un registro existente en la tabla TipoMulta, utilizando el IdTipoMulta para identificar el registro a eliminar
        Dim parameters As New Dictionary(Of String, Object) From {
            {"@Id", id} ' Agregar el parámetro necesario para la consulta SQL, utilizando un diccionario para facilitar la gestión de los parámetros
        }
        Return ExecuteNonQuery(query, parameters, errorMessage) ' Llamar al método genérico ExecuteNonQuery para ejecutar la consulta SQL, pasando la consulta, los parámetros y una variable para capturar cualquier mensaje de error
    End Function

    ' SELECT TipoMulta
    Public Function GetTipoMulta(Optional id As Integer? = Nothing, Optional ByRef errorMessage As String = "") As DataTable ' Método para obtener registros de la tabla TipoMulta, con la opción de filtrar por IdTipoMulta
        Dim query As String = "SELECT IdTipoMulta, Descripcion, MontoBase, Activa FROM TipoMulta" ' Consulta SQL para seleccionar registros de la tabla TipoMulta, incluyendo los campos IdTipoMulta, Descripcion, MontoBase y Activa
        Dim parameters As Dictionary(Of String, Object) = Nothing ' Inicializar la variable de parámetros como Nothing, ya que no se necesitan parámetros si no se filtra por IdTipoMulta

        If id.HasValue Then ' Si se proporciona un IdTipoMulta, agregar una cláusula WHERE a la consulta SQL para filtrar por ese IdTipoMulta
            query &= " WHERE IdTipoMulta=@Id" ' Agregar la cláusula WHERE a la consulta SQL para filtrar por IdTipoMulta
            parameters = New Dictionary(Of String, Object) From {
                {"@Id", id.Value} ' Agregar el parámetro necesario para la consulta SQL, utilizando un diccionario para facilitar la gestión de los parámetros
            }
        End If ' Fin del bloque If para verificar si se proporcionó un IdTipoMulta

        Return ExecuteQuery(query, parameters, errorMessage) ' Llamar al método genérico ExecuteQuery para ejecutar la consulta SQL, pasando la consulta, los parámetros (si se proporcionaron) y una variable para capturar cualquier mensaje de error, y devolver el resultado como un DataTable
    End Function

    ' Método genérico para ejecutar INSERT/UPDATE/DELETE
    Private Function ExecuteNonQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As Boolean ' Método genérico para ejecutar consultas SQL de tipo INSERT, UPDATE o DELETE, pasando la consulta, los parámetros y una variable para capturar cualquier mensaje de error
        If String.IsNullOrWhiteSpace(query) Then ' Verificar que la consulta no esté vacía o solo contenga espacios en blanco, y lanzar una excepción si es así
            Throw New ArgumentException("La consulta no puede estar vacía") ' Verificar que la consulta no esté vacía o solo contenga espacios en blanco, y lanzar una excepción si es así
        End If ' Fin del bloque If para verificar que la consulta no esté vacía o solo contenga espacios en blanco
        Using conn As SqlConnection = GetConnection() ' Utilizar el método GetConnection para obtener una conexión abierta a la base de datos, y asegurarse de que se cierre correctamente al finalizar el bloque Using
            Using cmd As New SqlCommand(query, conn) ' Crear un nuevo SqlCommand con la consulta SQL y la conexión, y asegurarse de que se liberen los recursos correctamente al finalizar el bloque Using
                If parameters IsNot Nothing Then ' Si se proporcionaron parámetros, agregarlos al SqlCommand utilizando un bucle For Each para iterar sobre el diccionario de parámetros y agregar cada uno al SqlCommand
                    For Each p In parameters ' Iterar sobre el diccionario de parámetros utilizando un bucle For Each para agregar cada parámetro al SqlCommand
                        cmd.Parameters.AddWithValue(p.Key, p.Value) ' Agregar el parámetro al SqlCommand utilizando el método AddWithValue, pasando la clave del diccionario como el nombre del parámetro y el valor del diccionario como el valor del parámetro
                    Next ' Fin del bloque For Each para iterar sobre el diccionario de parámetros y agregar cada uno al SqlCommand
                End If ' Fin del bloque If para verificar si se proporcionaron parámetros y agregarlos al SqlCommand

                Try ' Intentar ejecutar la consulta SQL utilizando el método ExecuteNonQuery del SqlCommand, y devolver True si se ejecuta correctamente
                    cmd.ExecuteNonQuery() ' Ejecutar la consulta SQL utilizando el método ExecuteNonQuery del SqlCommand, que devuelve el número de filas afectadas por la consulta, pero no se utiliza en este caso ya que solo se necesita saber si la consulta se ejecutó correctamente o no
                    Return True ' Devolver True si la consulta se ejecutó correctamente, indicando que la operación de INSERT, UPDATE o DELETE fue exitosa
                Catch ex As Exception ' Capturar cualquier excepción que ocurra al ejecutar la consulta SQL, y asignar un mensaje de error a la variable errorMessage para proporcionar información sobre el error
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message ' Capturar cualquier excepción que ocurra al ejecutar la consulta SQL, y asignar un mensaje de error a la variable errorMessage para proporcionar información sobre el error, incluyendo el mensaje de la excepción original
                    Return False ' Devolver False si ocurrió un error al ejecutar la consulta SQL, indicando que la operación de INSERT, UPDATE o DELETE no fue exitosa
                End Try ' Fin del bloque Try-Catch para manejar cualquier excepción que ocurra al ejecutar la consulta SQL, y proporcionar información sobre el error a través de la variable errorMessage
            End Using ' Fin del bloque Using para el SqlCommand, asegurando que se liberen los recursos correctamente
        End Using ' Fin del bloque Using para la conexión, asegurando que se cierre correctamente al finalizar el bloque Using
    End Function ' Fin del método ExecuteNonQuery para ejecutar consultas SQL de tipo INSERT, UPDATE o DELETE

    ' Método genérico para ejecutar SELECT
    Private Function ExecuteQuery(query As String, parameters As Dictionary(Of String, Object), ByRef errorMessage As String) As DataTable ' Método genérico para ejecutar consultas SQL de tipo SELECT, pasando la consulta, los parámetros y una variable para capturar cualquier mensaje de error, y devolver el resultado como un DataTable
        If String.IsNullOrWhiteSpace(query) Then ' Verificar que la consulta no esté vacía o solo contenga espacios en blanco, y lanzar una excepción si es así
            Throw New ArgumentException("La consulta no puede estar vacía") '   Verificar que la consulta no esté vacía o solo contenga espacios en blanco, y lanzar una excepción si es así
        End If ' Fin del bloque If para verificar que la consulta no esté vacía o solo contenga espacios en blanco
        Dim dt As New DataTable() ' Crear un nuevo DataTable para almacenar el resultado de la consulta SQL, que se devolverá al final del método
        Using conn As SqlConnection = GetConnection() ' Utilizar el método GetConnection para obtener una conexión abierta a la base de datos, y asegurarse de que se cierre correctamente al finalizar el bloque Using
            Using cmd As New SqlCommand(query, conn) ' Crear un nuevo SqlCommand con la consulta SQL y la conexión, y asegurarse de que se liberen los recursos correctamente al finalizar el bloque Using
                If parameters IsNot Nothing Then ' Si se proporcionaron parámetros, agregarlos al SqlCommand utilizando un bucle For Each para iterar sobre el diccionario de parámetros y agregar cada uno al SqlCommand
                    For Each p In parameters ' Iterar sobre el diccionario de parámetros utilizando un bucle For Each para agregar cada parámetro al SqlCommand
                        cmd.Parameters.AddWithValue(p.Key, p.Value) '  Agregar el parámetro al SqlCommand utilizando el método AddWithValue, pasando la clave del diccionario como el nombre del parámetro y el valor del diccionario como el valor del parámetro
                    Next ' Fin del bloque For Each para iterar sobre el diccionario de parámetros y agregar cada uno al SqlCommand
                End If ' Fin del bloque If para verificar si se proporcionaron parámetros y agregarlos al SqlCommand
                Try ' Intentar ejecutar la consulta SQL utilizando un SqlDataAdapter para llenar el DataTable con el resultado de la consulta, y devolver el DataTable si se ejecuta correctamente
                    Using adapter As New SqlDataAdapter(cmd) ' Crear un nuevo SqlDataAdapter con el SqlCommand, que se utilizará para llenar el DataTable con el resultado de la consulta SQL, y asegurarse de que se liberen los recursos correctamente al finalizar el bloque Using
                        adapter.Fill(dt) ' Llenar el DataTable con el resultado de la consulta SQL utilizando el método Fill del SqlDataAdapter, que ejecuta la consulta y llena el DataTable con los datos devueltos por la consulta
                    End Using ' Fin del bloque Using para el SqlDataAdapter, asegurando que se liberen los recursos correctamente
                    Return dt ' Devolver el DataTable con el resultado de la consulta SQL, indicando que la operación de SELECT fue exitosa
                Catch ex As Exception ' Capturar cualquier excepción que ocurra al ejecutar la consulta SQL, y asignar un mensaje de error a la variable errorMessage para proporcionar información sobre el error
                    errorMessage = "Error al ejecutar la consulta: " & ex.Message ' Capturar cualquier excepción que ocurra al ejecutar la consulta SQL, y asignar un mensaje de error a la variable errorMessage para proporcionar información sobre el error, incluyendo el mensaje de la excepción original
                    Return Nothing ' Devolver Nothing si ocurrió un error al ejecutar la consulta SQL, indicando que la operación de SELECT no fue exitosa
                End Try ' Fin del bloque Try-Catch para manejar cualquier excepción que ocurra al ejecutar la consulta SQL, y proporcionar información sobre el error a través de la variable errorMessage
            End Using ' Fin del bloque Using para el SqlCommand, asegurando que se liberen los recursos correctamente
        End Using ' Fin del bloque Using para la conexión, asegurando que se cierre correctamente al finalizar el bloque Using
    End Function ' Fin del método ExecuteQuery para ejecutar consultas SQL de tipo SELECT, y devolver el resultado como un DataTable
End Class ' Fin de la clase DbHealper, que proporciona métodos para interactuar con la base de datos, incluyendo operaciones de INSERT, UPDATE, DELETE y SELECT para la tabla TipoMulta, utilizando un enfoque genérico para ejecutar consultas SQL y manejar errores de manera eficiente.
=======
    'Public Function InsertTipoMulta(descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean
    '    Dim query As String = "INSERT INTO TipoMulta (Descripcion, MontoBase, Activa) VALUES (@Descripcion, @MontoBase, @Activa)"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '        {"@Descripcion", descripcion},
    '        {"@MontoBase", montoBase},
    '        {"@Activa", activa}
    '    }
    '    Return ExecuteNonQuery(query, parameters, errorMessage)
    'End Function

    '' UPDATE TipoMulta
    'Public Function UpdateTipoMulta(id As Integer, descripcion As String, montoBase As Decimal, activa As Boolean, ByRef errorMessage As String) As Boolean
    '    Dim query As String = "UPDATE TipoMulta SET Descripcion=@Descripcion, MontoBase=@MontoBase, Activa=@Activa WHERE IdTipoMulta=@Id"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '        {"@Id", id},
    '        {"@Descripcion", descripcion},
    '        {"@MontoBase", montoBase},
    '        {"@Activa", activa}
    '    }
    '    Return ExecuteNonQuery(query, parameters, errorMessage)
    'End Function

    '' DELETE TipoMulta
    'Public Function DeleteTipoMulta(id As Integer, ByRef errorMessage As String) As Boolean
    '    Dim query As String = "DELETE FROM TipoMulta WHERE IdTipoMulta=@Id"
    '    Dim parameters As New Dictionary(Of String, Object) From {
    '        {"@Id", id}
    '    }
    '    Return ExecuteNonQuery(query, parameters, errorMessage)
    'End Function

    '' SELECT TipoMulta
    'Public Function GetTipoMulta(Optional id As Integer? = Nothing, Optional ByRef errorMessage As String = "") As DataTable
    '    Dim query As String = "SELECT IdTipoMulta, Descripcion, MontoBase, Activa FROM TipoMulta"
    '    Dim parameters As Dictionary(Of String, Object) = Nothing

    '    If id.HasValue Then
    '        query &= " WHERE IdTipoMulta=@Id"
    '        parameters = New Dictionary(Of String, Object) From {
    '            {"@Id", id.Value}
    '        }
    '    End If

    '    Return ExecuteQuery(query, parameters, errorMessage)
    'End Function

    ' Método genérico para ejecutar INSERT/UPDATE/DELETE
    Public Function ExecuteNonQuery(query As String, parameters As List(Of SqlParameter), ByRef errorMessage As String) As Boolean
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía")
        End If

        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)

                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters.ToArray())
                End If

                cmd.CommandType = CommandType.StoredProcedure

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
    Public Function ExecuteQuery(ByRef errorMessage As String, query As String, esStoredProcedure As Boolean, Optional parameters As List(Of SqlParameter) = Nothing) As DataTable
        If String.IsNullOrWhiteSpace(query) Then
            Throw New ArgumentException("La consulta no puede estar vacía")
        End If

        Dim dt As New DataTable()
        Using conn As SqlConnection = GetConnection()
            Using cmd As New SqlCommand(query, conn)
                If parameters IsNot Nothing Then
                    cmd.Parameters.AddRange(parameters.ToArray())
                End If

                If esStoredProcedure Then
                    cmd.CommandType = CommandType.StoredProcedure
                End If

                Try
                    If conn.State = ConnectionState.Closed Then
                        conn.Open()
                    End If

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
>>>>>>> dcce4205555c08578f67900f394ecdd0b6db04e6
