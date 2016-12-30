Friend Class XMLView
    Implements IXMLView

#Region " connect to presenter "
    Dim _presenter As XMLViewPresenter
    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _presenter = New XMLViewPresenter(Me)
    End Sub
#End Region

#Region " IView Interface Implementation "
    Private _item As StyleSheet
    Public Property StyleSheet() As StyleSheet Implements IXMLView.StyleSheet
        Get
            Return _item
        End Get
        Set(ByVal value As StyleSheet)
            If _item Is Nothing OrElse Not _item.Equals(value) Then
                _item = value
                ShowXMLInBrowser()
            End If
        End Set
    End Property
#End Region

    Dim _tempfile As String = ""
    Private Sub ShowXMLInBrowser()
        If _item Is Nothing Then Exit Sub

        If System.IO.File.Exists(_tempfile) Then System.IO.File.Delete(_tempfile)

        _tempfile = System.IO.Path.GetTempFileName
        _tempfile = System.IO.Path.ChangeExtension(_tempfile, ".xml")
        If _item.ToXML(_tempfile) Then
            wbXML.Navigate(New System.Uri(_tempfile))
        End If

        System.IO.File.Delete(_tempfile)
    End Sub

End Class
