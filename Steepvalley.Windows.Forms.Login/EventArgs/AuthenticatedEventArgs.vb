Public Class AuthenticatedEventArgs
    Inherits EventArgs

    Private _user As String = ""
    Private _pwd As String = ""

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal user As String, ByVal password As String)
        _user = user
        _pwd = password
    End Sub

    Public ReadOnly Property User() As String
        Get
            Return _user
        End Get
    End Property

    Public ReadOnly Property Password() As String
        Get
            Return _pwd
        End Get
    End Property
End Class
