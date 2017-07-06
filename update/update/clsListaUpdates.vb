Public Class clsListaUpdates

    Private _ident As Integer
    Private _listaVer As String
    Private _dllVer As String
    Private _query As String

    Public Sub New(ByVal ident As Integer, ByVal listaVer As String, ByVal dllVer As String, ByVal query As String)
        Me.Ident = ident
        Me.ListaVer = listaVer
        Me.DllVer = dllVer
        Me.pQuery = query
    End Sub

    Public Property Ident() As Integer
        Get
            Return _ident
        End Get
        Set(ByVal Valor As Integer)
            _ident = Valor
        End Set
    End Property

    Public Property ListaVer() As String
        Get
            Return _listaVer
        End Get
        Set(ByVal Valor As String)
            _listaVer = Valor
        End Set
    End Property

    Public Property DllVer() As String
        Get
            Return _dllVer
        End Get
        Set(ByVal Valor As String)
            _dllVer = Valor
        End Set
    End Property

    Public Property pQuery() As String
        Get
            Return _query
        End Get
        Set(ByVal Valor As String)
            _query = Valor
        End Set
    End Property
End Class
