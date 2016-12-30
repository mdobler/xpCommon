Friend Class PropertiesView
    Implements IPropertiesView


#Region " connect to presenter "
    Dim _presenter As PropertiesPresenter
    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _presenter = New PropertiesPresenter(Me)
    End Sub
#End Region

    Private _item As Style
    Public Property Style() As Style Implements IPropertiesView.Style
        Get
            Return _item
        End Get
        Set(ByVal value As Style)
            _item = value

            If _item IsNot Nothing Then
                pgEdit.SelectedObject = New StyleTypeDescriptor(New StyleProxy(_item))
                StyleBindingSource.DataSource = _item
            Else
                pgEdit.SelectedObject = Nothing
            End If

        End Set
    End Property

    Public Event ItemChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IPropertiesView.StyleChanged

    Private Sub pgEdit_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles pgEdit.PropertyValueChanged
        RaiseEvent ItemChanged(Me, New EventArgs)
    End Sub
End Class
