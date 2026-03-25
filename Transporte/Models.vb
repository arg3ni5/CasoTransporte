Namespace Models

    Public Class Propietarios

        Private _idPersona As Integer

        Private _telefono As String

        Private _direccion As String

        Private _nombreCompleto As String

        Public Sub New()

        End Sub

        Public Sub New(idPersona As Integer, telefono As String, direccion As String)

            Me.IdPersona = idPersona

            Me.Telefono = telefono

            Me.Direccion = direccion

        End Sub

        Public Sub New(idPersona As Integer, nombreCompleto As String, telefono As String, direccion As String)

            Me.IdPersona = idPersona

            Me.NombreCompleto = nombreCompleto

            Me.Telefono = telefono

            Me.Direccion = direccion

        End Sub

        Public Property IdPersona As Integer

            Get

                Return _idPersona

            End Get

            Set(value As Integer)

                _idPersona = value

            End Set

        End Property

        Public Property Telefono As String

            Get

                Return _telefono

            End Get

            Set(value As String)

                _telefono = value

            End Set

        End Property

        Public Property Direccion As String

            Get

                Return _direccion

            End Get

            Set(value As String)

                _direccion = value

            End Set

        End Property

        Public Property NombreCompleto As String

            Get

                Return _nombreCompleto

            End Get

            Set(value As String)

                _nombreCompleto = value

            End Set

        End Property

        Public Function Resumen() As String

            Return $"IdPersona: {IdPersona} - Nombre: {NombreCompleto} - Teléfono: {Telefono} - Dirección: {Direccion}"

        End Function

    End Class

End Namespace
