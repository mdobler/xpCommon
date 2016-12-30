Public Class PropertiesPresenter

#Region " connection to view "
    Private _view As IPropertiesView
    Public Sub New(ByVal view As IPropertiesView)
        _view = view
        AddHandler Editor.CurrentStyleChanged, AddressOf OnStyleChanged
    End Sub
#End Region

    Protected Sub OnStyleChanged(ByVal sender As Object, ByVal e As EventArgs)
        _view.Style = Editor.CurrentStyle
    End Sub
End Class
