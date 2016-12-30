<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.tbProp = New System.Windows.Forms.TabPage
        Me.tbXML = New System.Windows.Forms.TabPage
        Me.StyleSheetListView1 = New Steepvalley.Windows.Forms.Styles.StyleSheetListView(Me.components)
        Me.PropertiesView1 = New Steepvalley.Windows.Forms.Styles.PropertiesView
        Me.XmlView1 = New Steepvalley.Windows.Forms.Styles.XMLView
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.tbProp.SuspendLayout()
        Me.tbXML.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.StyleSheetListView1)
        Me.SplitContainer1.Panel1.Padding = New System.Windows.Forms.Padding(3, 3, 0, 3)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.TabControl1)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(0, 3, 0, 1)
        Me.SplitContainer1.Size = New System.Drawing.Size(600, 400)
        Me.SplitContainer1.SplitterDistance = 200
        Me.SplitContainer1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.tbProp)
        Me.TabControl1.Controls.Add(Me.tbXML)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 3)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(396, 396)
        Me.TabControl1.TabIndex = 0
        '
        'tbProp
        '
        Me.tbProp.Controls.Add(Me.PropertiesView1)
        Me.tbProp.Location = New System.Drawing.Point(4, 22)
        Me.tbProp.Name = "tbProp"
        Me.tbProp.Padding = New System.Windows.Forms.Padding(3)
        Me.tbProp.Size = New System.Drawing.Size(388, 370)
        Me.tbProp.TabIndex = 0
        Me.tbProp.Text = "Properties"
        Me.tbProp.UseVisualStyleBackColor = True
        '
        'tbXML
        '
        Me.tbXML.Controls.Add(Me.XmlView1)
        Me.tbXML.Location = New System.Drawing.Point(4, 22)
        Me.tbXML.Name = "tbXML"
        Me.tbXML.Padding = New System.Windows.Forms.Padding(3)
        Me.tbXML.Size = New System.Drawing.Size(385, 373)
        Me.tbXML.TabIndex = 1
        Me.tbXML.Text = "XML"
        Me.tbXML.UseVisualStyleBackColor = True
        '
        'StyleSheetListView1
        '
        Me.StyleSheetListView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.StyleSheetListView1.FullRowSelect = True
        Me.StyleSheetListView1.Location = New System.Drawing.Point(3, 3)
        Me.StyleSheetListView1.MultiSelect = False
        Me.StyleSheetListView1.Name = "StyleSheetListView1"
        Me.StyleSheetListView1.Size = New System.Drawing.Size(197, 394)
        Me.StyleSheetListView1.StyleSheet = Nothing
        Me.StyleSheetListView1.TabIndex = 0
        Me.StyleSheetListView1.TileColumns = New Integer() {1, 0}
        Me.StyleSheetListView1.View = System.Windows.Forms.View.Tile
        '
        'PropertiesView1
        '
        Me.PropertiesView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PropertiesView1.Location = New System.Drawing.Point(3, 3)
        Me.PropertiesView1.Name = "PropertiesView1"
        Me.PropertiesView1.Size = New System.Drawing.Size(382, 364)
        Me.PropertiesView1.Style = Nothing
        Me.PropertiesView1.TabIndex = 0
        '
        'XmlView1
        '
        Me.XmlView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XmlView1.Location = New System.Drawing.Point(3, 3)
        Me.XmlView1.Name = "XmlView1"
        Me.XmlView1.Size = New System.Drawing.Size(379, 367)
        Me.XmlView1.StyleSheet = Nothing
        Me.XmlView1.TabIndex = 0
        '
        'EditorView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "EditorView"
        Me.Size = New System.Drawing.Size(600, 400)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.tbProp.ResumeLayout(False)
        Me.tbXML.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl
    Private WithEvents tbProp As System.Windows.Forms.TabPage
    Private WithEvents tbXML As System.Windows.Forms.TabPage
    Private WithEvents StyleSheetListView1 As Steepvalley.Windows.Forms.Styles.StyleSheetListView
    Private WithEvents PropertiesView1 As Steepvalley.Windows.Forms.Styles.PropertiesView
    Private WithEvents XmlView1 As Steepvalley.Windows.Forms.Styles.XMLView

End Class
