Partial Class StyleSheetListView
    Inherits Steepvalley.Windows.Forms.ListView

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Required for Windows.Forms Class Composition Designer support
        Container.Add(Me)

    End Sub

    'Component overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(StyleSheetListView))
        Me.ilSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.ilLarge = New System.Windows.Forms.ImageList(Me.components)
        Me.colType = New System.Windows.Forms.ColumnHeader
        Me.colClassID = New System.Windows.Forms.ColumnHeader
        Me.colAssembly = New System.Windows.Forms.ColumnHeader
        Me.SuspendLayout()
        '
        'ilSmall
        '
        Me.ilSmall.ImageStream = CType(resources.GetObject("ilSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSmall.TransparentColor = System.Drawing.Color.Transparent
        Me.ilSmall.Images.SetKeyName(0, "Web_StyleSheet.ico")
        '
        'ilLarge
        '
        Me.ilLarge.ImageStream = CType(resources.GetObject("ilLarge.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilLarge.TransparentColor = System.Drawing.Color.Transparent
        Me.ilLarge.Images.SetKeyName(0, "Web_StyleSheet.ico")
        '
        'colType
        '
        Me.colType.Text = "Type"
        Me.colType.Width = 300
        '
        'colClassID
        '
        Me.colClassID.Text = "Class ID"
        Me.colClassID.Width = 120
        '
        'colAssembly
        '
        Me.colAssembly.Text = "Reference"
        Me.colAssembly.Width = 300
        '
        'StyleSheetListView
        '
        Me.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colType, Me.colClassID, Me.colAssembly})
        Me.FullRowSelect = True
        Me.LargeImageList = Me.ilLarge
        Me.MultiSelect = False
        Me.SmallImageList = Me.ilSmall
        Me.TileColumns = New Integer() {1, 0}
        Me.View = System.Windows.Forms.View.Tile
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents ilSmall As System.Windows.Forms.ImageList
    Private WithEvents ilLarge As System.Windows.Forms.ImageList
    Friend WithEvents colType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colClassID As System.Windows.Forms.ColumnHeader
    Friend WithEvents colAssembly As System.Windows.Forms.ColumnHeader

End Class
