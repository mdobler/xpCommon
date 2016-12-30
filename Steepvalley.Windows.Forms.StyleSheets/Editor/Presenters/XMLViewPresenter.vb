Public Class XMLViewPresenter

#Region " connection to view "
    Private _view As IXMLView
    Public Sub New(ByVal view As IXMLView)
        _view = view
        AddHandler Editor.CurrentSheetChanged, AddressOf OnSheetChanged
    End Sub
#End Region

    Protected Sub OnSheetChanged(ByVal sender As Object, ByVal e As EventArgs)
        _view.StyleSheet = Editor.CurrentSheet
    End Sub
End Class
