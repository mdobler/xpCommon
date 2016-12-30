<TypeConverter(GetType(UserInfoTypeConverter))> _
Public Class LoginUserInfo
    '    Implements IEditableObject
    Implements INotifyPropertyChanged

    Private _username As String = "Username"
    Private _image As Image = My.Resources.user.ToBitmap
    Private _password As String = ""
    Private _hasPassword As Boolean = False
    Private _message As String = ""

    Public Sub New()
    End Sub

    Public Sub New(ByVal user As String, ByVal pwd As String, ByVal msg As String, ByVal img As Image, ByVal hasPassword As Boolean)
        Me.New()
        _username = user
        _password = pwd
        _message = msg
        _image = img
        _hasPassword = hasPassword
    End Sub

    Public Property Username() As String
        Get
            Return _username
        End Get
        Set(ByVal value As String)
            _username = value
            OnPropertyChanged(New PropertyChangedEventArgs("UserName"))
        End Set
    End Property

    Public Property Message() As String
        Get
            Return _message
        End Get
        Set(ByVal value As String)
            _message = value
            OnPropertyChanged(New PropertyChangedEventArgs("Message"))
        End Set
    End Property

    Public Property UserImage() As Image
        Get
            Return _image
        End Get
        Set(ByVal value As Image)
            _image = value
            OnPropertyChanged(New PropertyChangedEventArgs("UserImage"))
        End Set
    End Property

    Public Property HasPassword() As Boolean
        Get
            Return _hasPassword
        End Get
        Set(ByVal value As Boolean)
            _hasPassword = value
            OnPropertyChanged(New PropertyChangedEventArgs("HasPassword"))
        End Set
    End Property

    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
            OnPropertyChanged(New PropertyChangedEventArgs("Password"))
        End Set
    End Property

    '#Region "IEditableObject Interface"
    '    Public Sub BeginEdit() Implements IEditableObject.BeginEdit

    '    End Sub

    '    Public Sub CancelEdit() Implements IEditableObject.CancelEdit

    '    End Sub

    '    Public Sub EndEdit() Implements IEditableObject.EndEdit

    '    End Sub
    '#End Region

#Region "INotifyPropertyChanged Interface"
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs) Implements INotifyPropertyChanged.PropertyChanged

    Protected Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub
#End Region

    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If TypeOf obj Is LoginUserInfo Then
            Return _username.Equals(DirectCast(obj, LoginUserInfo).Username)
        End If
        Return MyBase.Equals(obj)
    End Function
End Class