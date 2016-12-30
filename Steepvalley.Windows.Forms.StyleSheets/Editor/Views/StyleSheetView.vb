Friend Class StyleSheetView
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

#Region " IView Interface Implementation "
    Public Event StyleSheetChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements IStyleSheetView.StyleSheetChanged
    Public Event StyleSelected(ByVal sender As Object, ByVal e As StyleSelectedEventArgs) Implements IStyleSheetView.StyleSelected

    Private _item As StyleSheet
    Public Property StyleSheet() As StyleSheet Implements IStyleSheetView.StyleSheet
        Get
            Return _item
        End Get
        Set(ByVal value As StyleSheet)
            If _item Is Nothing OrElse _item.Equals(value) Then
                _item = value
                Databind()
            End If
        End Set
    End Property
#End Region

#Region " overriden actions "
    Protected Overrides Sub OnAfterSelect(ByVal e As System.Windows.Forms.TreeViewEventArgs)
        MyBase.OnAfterSelect(e)
        Select Case Me.SelectedNode.Level
            Case 0
                'do nothing
            Case 1
                Editor.CurrentStyle = _item.Styles.Item(_item.Styles.IndexOf(Me.SelectedNode.Name))
            Case 2
                Editor.CurrentStyle = _item.Styles.Item(_item.Styles.IndexOf(Me.SelectedNode.Parent.Name, Me.SelectedNode.Text))
        End Select
    End Sub
#End Region

#Region " private methods "
    Private Sub Databind()
        Me.SuspendLayout()
        Me.Nodes.Clear()

        Dim aNode As System.Windows.Forms.TreeNode
        Dim tNode As System.Windows.Forms.TreeNode
        Dim cNode As System.Windows.Forms.TreeNode

        If _item IsNot Nothing Then
            _item.Styles.SortByType()

            For Each a As Generic.KeyValuePair(Of String, String) In _item.GetAssemblyNames
                aNode = Me.Nodes.Add(a.Key, a.Value, 0)
                For Each t As Generic.KeyValuePair(Of String, String) In _item.GetTypeNames(a.Key)
                    tNode = aNode.Nodes.Add(t.Key, t.Value, 1)
                    For Each c As Generic.KeyValuePair(Of String, String) In _item.GetTypeClassNames(a.Key, t.Key)
                        cNode = tNode.Nodes.Add(c.Key, t.Value, 2)
                    Next
                Next
            Next
        End If

        Me.ResumeLayout()
    End Sub
#End Region
End Class
