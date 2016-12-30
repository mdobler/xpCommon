Imports System.Windows.Forms
Imports System.Drawing

Friend Class StyleSheetListView
    Implements IStyleSheetView

#Region " connect to presenter "
    Dim _presenter As StyleSheetPresenter
    Public Sub New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Fügen Sie Initialisierungen nach dem InitializeComponent()-Aufruf hinzu.
        _presenter = New StyleSheetPresenter(Me)
    End Sub
#End Region

#Region " IStyleSheetView Implementation "
    Public Event StyleSheetChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IStyleSheetView.StyleSheetChanged
    Public Event StyleSelected(ByVal sender As Object, ByVal e As StyleSelectedEventArgs) Implements IStyleSheetView.StyleSelected

    Private _stylesheet As New StyleSheet
    Public Property StyleSheet() As StyleSheet Implements IStyleSheetView.StyleSheet
        Get
            Return _stylesheet
        End Get
        Set(ByVal Value As StyleSheet)
            _stylesheet = Value
            Databind()
        End Set
    End Property
#End Region

#Region " private methods "
    Private Sub Databind()
        Me.Items.Clear()
        Me.Groups.Clear()

        If _stylesheet Is Nothing OrElse _stylesheet.Styles.Count = 0 Then Exit Sub

        Me.SuspendLayout()
        For Each s As Style In _stylesheet.Styles
            Dim itm As New ListViewItem(New String() {s.TypeNameShort, s.ClassID, s.Reference.Name}, 0)
            itm.Tag = s
            Me.Items.Add(itm)
        Next
        Me.ResumeLayout()

        Me.AutoGroup(2)
    End Sub
#End Region

    Private Sub StyleSheetListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SelectedIndexChanged
        If Me.SelectedIndices.Count = 0 Then Exit Sub
        RaiseEvent StyleSelected(Me, New StyleSelectedEventArgs(DirectCast(Me.Items(Me.SelectedIndices(0)).Tag, Style)))
    End Sub
End Class
