Namespace Models

    Public Class Vehiculos

        Private _TipoID As String
        Private _IDPropietario As String
        Private _IDVehiculo As String
        Private _Placa As String
        Private _Modelo As String
        Private _Marca As String

        Public Property TipoID As String
            Get
                Return _TipoID
            End Get
            Set(value As String)
                _TipoID = value
            End Set
        End Property

        Public Property IDPropietario As String
            Get
                Return _IDPropietario
            End Get
            Set(value As String)
                _IDPropietario = value
            End Set
        End Property

        Public Property IDVehiculo As String
            Get
                Return _IDVehiculo
            End Get
            Set(value As String)
                _IDVehiculo = value
            End Set
        End Property

        Public Property Placa As String
            Get
                Return _Placa
            End Get
            Set(value As String)
                _Placa = value
            End Set
        End Property

        Public Property Modelo As String
            Get
                Return _Modelo
            End Get
            Set(value As String)
                _Modelo = value
            End Set
        End Property

        Public Property Marca As String
            Get
                Return _Marca
            End Get
            Set(value As String)
                _Marca = value
            End Set
        End Property

        Public Function Resumen() As String
            Return $"ID: {IDVehiculo}, Placa: {Placa}, Modelo: {Modelo}, Marca: {Marca}"
        End Function

    End Class

End Namespace


