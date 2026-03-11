Namespace Models
    Public Class Multa
        Private _idMulta As Integer
        Private _idVehiculo As Integer
        Private _idTipoMulta As Integer
        Private _fecha As DateTime
        Private _montoAplicado As Decimal
        Private _pagada As Boolean

        Public Sub New()
        End Sub

        Public Sub New(idMulta As Integer, idVehiculo As Integer, idTipoMulta As Integer, fecha As Date, montoAplicado As Decimal, pagada As Boolean)
            _idMulta = idMulta
            _idVehiculo = idVehiculo
            _idTipoMulta = idTipoMulta
            _fecha = fecha
            _montoAplicado = montoAplicado
            _pagada = pagada
        End Sub

        Public Property IdMulta As Integer
            Get
                Return _idMulta
            End Get
            Set(value As Integer)
                _idMulta = value
            End Set
        End Property

        Public Property IdVehiculo As Integer
            Get
                Return _idVehiculo
            End Get
            Set(value As Integer)
                _idVehiculo = value
            End Set
        End Property

        Public Property IdTipoMulta As Integer
            Get
                Return _idTipoMulta
            End Get
            Set(value As Integer)
                _idTipoMulta = value
            End Set
        End Property

        Public Property Fecha As Date
            Get
                Return _fecha
            End Get
            Set(value As Date)
                _fecha = value
            End Set
        End Property

        Public Property MontoAplicado As Decimal
            Get
                Return _montoAplicado
            End Get
            Set(value As Decimal)
                _montoAplicado = value
            End Set
        End Property

        Public Property Pagada As Boolean
            Get
                Return _pagada
            End Get
            Set(value As Boolean)
                _pagada = value
            End Set
        End Property
    End Class
End Namespace
