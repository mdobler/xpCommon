Public Class AuthenticateEventArgs
    Inherits EventArgs

    Private _user As String = ""
    Private _msg As String = ""
    Private _pwd As String = ""
    Private _authenticated As Boolean = False

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal user As String, ByVal password As String, Optional ByVal message As String = "", Optional ByVal authenticated As Boolean = False)
        _user = user
        _pwd = password
        _msg = message
        _authenticated = authenticated
    End Sub

    Public ReadOnly Property User() As String
        Get
            Return _user
        End Get
    End Property

    Public Property Message() As String
        Get
            Return _msg
        End Get
        Set(ByVal value As String)
            _msg = value
        End Set
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _pwd
        End Get
    End Property

    Public Property Authenticated() As Boolean
        Get
            Return _authenticated
        End Get
        Set(ByVal value As Boolean)
            _authenticated = value
        End Set
    End Property
End Class
