Public Class clsListaAnimes

    Private _ident As Integer
    Private _nome As String
    Private _descricao As String
    Private _recomendacao As String
    Private _link As String

    Public Sub New(ByVal ident As Integer, ByVal nome As String, ByVal descricao As String, ByVal recomendacao As String, ByVal link As String)
        Me.Ident = ident
        Me.Nome = nome
        Me.Descricao = descricao
        Me.Recomendacao = recomendacao
        Me.Link = link
    End Sub

    Public Property Ident() As Integer
        Get
            Return _ident
        End Get
        Set(ByVal Valor As Integer)
            _ident = Valor
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal Valor As String)
            _nome = Valor
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set(ByVal Valor As String)
            _descricao = Valor
        End Set
    End Property

    Public Property Recomendacao() As String
        Get
            Return _recomendacao
        End Get
        Set(ByVal Valor As String)
            _recomendacao = Valor
        End Set
    End Property

    Public Property Link() As String
        Get
            Return _link
        End Get
        Set(ByVal Valor As String)
            _link = Valor
        End Set
    End Property

End Class
