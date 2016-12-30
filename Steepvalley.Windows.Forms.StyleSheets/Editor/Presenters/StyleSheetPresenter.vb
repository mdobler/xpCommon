Public Class StyleSheetPresenter

#Region " connection to view "
    Private _view As IStyleSheetView
    Public Sub New(ByVal view As IStyleSheetView)
        _view = view
        'AddHandler ViperApplication.ItemChanged, AddressOf OnItemChanged
        'AddHandler _view.ChildResultSelected, AddressOf OnChildResultSelected

        AddHandler Editor.CurrentSheetChanged, AddressOf OnSheetChanged
        AddHandler _view.StyleSelected, AddressOf OnStyleSelected
    End Sub
#End Region

    Protected Sub OnSheetChanged(ByVal sender As Object, ByVal e As EventArgs)
        _view.StyleSheet = Editor.CurrentSheet
    End Sub

    Protected Sub OnStyleSelected(ByVal sender As Object, ByVal e As StyleSelectedEventArgs)
        Editor.CurrentStyle = e.Style
    End Sub
End Class
