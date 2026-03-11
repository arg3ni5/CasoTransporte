Namespace Models
    Public Class TipoMulta
        Private _idTipoMulta As Integer
        Private _descripcion As String
        Private _montoBase As Decimal
        Private _activa As Boolean

        Public Sub New()
        End Sub

        Public Sub New(idTipoMulta As Integer, descripcion As String, montoBase As Decimal, activa As Boolean)
            _idTipoMulta = idTipoMulta
            _descripcion = descripcion
            _montoBase = montoBase
            _activa = activa
        End Sub

        Public Property IdTipoMulta As Integer
            Get
                Return _idTipoMulta
            End Get
            Set(value As Integer)
                _idTipoMulta = value
            End Set
        End Property

        Public Property Descripcion As String
            Get
                Return _descripcion
            End Get
            Set(value As String)
                _descripcion = value
            End Set
        End Property

        Public Property MontoBase As Decimal
            Get
                Return _montoBase
            End Get
            Set(value As Decimal)
                _montoBase = value
            End Set
        End Property

        Public Property Activa As Boolean
            Get
                Return _activa
            End Get
            Set(value As Boolean)
                _activa = value
            End Set
        End Property
    End Class
End Namespace