<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditorDialog
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditorDialog))
        Me.mnuMain = New System.Windows.Forms.MenuStrip
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuNew = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuOpen = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.mnuSave = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuSaveAs = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuPrint = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuPrintPreview = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuExit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuEdit = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuAddAssembly = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRemoveAssembly = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAddStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRemoveStyle = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripSeparator
        Me.mnuAddProperties = New System.Windows.Forms.ToolStripMenuItem
        Me.mnuRemoveProperty = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tbNew = New System.Windows.Forms.ToolStripButton
        Me.tbOpen = New System.Windows.Forms.ToolStripButton
        Me.tbSave = New System.Windows.Forms.ToolStripButton
        Me.tbPrint = New System.Windows.Forms.ToolStripButton
        Me.toolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator
        Me.ssMain = New System.Windows.Forms.StatusStrip
        Me.dlgOpen = New System.Windows.Forms.OpenFileDialog
        Me.viewEditor = New Steepvalley.Windows.Forms.Styles.EditorView
        Me.mnuMain.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuMain
        '
        Me.mnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuEdit, Me.HelpToolStripMenuItem})
        Me.mnuMain.Location = New System.Drawing.Point(0, 0)
        Me.mnuMain.Name = "mnuMain"
        Me.mnuMain.Size = New System.Drawing.Size(664, 24)
        Me.mnuMain.TabIndex = 0
        Me.mnuMain.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuNew, Me.mnuOpen, Me.toolStripSeparator, Me.mnuSave, Me.mnuSaveAs, Me.toolStripSeparator1, Me.mnuPrint, Me.mnuPrintPreview, Me.toolStripSeparator2, Me.mnuExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(35, 20)
        Me.mnuFile.Text = "&File"
        '
        'mnuNew
        '
        Me.mnuNew.Image = CType(resources.GetObject("mnuNew.Image"), System.Drawing.Image)
        Me.mnuNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuNew.Name = "mnuNew"
        Me.mnuNew.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.mnuNew.Size = New System.Drawing.Size(152, 22)
        Me.mnuNew.Text = "&New"
        '
        'mnuOpen
        '
        Me.mnuOpen.Image = CType(resources.GetObject("mnuOpen.Image"), System.Drawing.Image)
        Me.mnuOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuOpen.Name = "mnuOpen"
        Me.mnuOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.mnuOpen.Size = New System.Drawing.Size(152, 22)
        Me.mnuOpen.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New System.Drawing.Size(149, 6)
        '
        'mnuSave
        '
        Me.mnuSave.Image = CType(resources.GetObject("mnuSave.Image"), System.Drawing.Image)
        Me.mnuSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuSave.Name = "mnuSave"
        Me.mnuSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.mnuSave.Size = New System.Drawing.Size(152, 22)
        Me.mnuSave.Text = "&Save"
        '
        'mnuSaveAs
        '
        Me.mnuSaveAs.Name = "mnuSaveAs"
        Me.mnuSaveAs.Size = New System.Drawing.Size(152, 22)
        Me.mnuSaveAs.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New System.Drawing.Size(149, 6)
        '
        'mnuPrint
        '
        Me.mnuPrint.Image = CType(resources.GetObject("mnuPrint.Image"), System.Drawing.Image)
        Me.mnuPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrint.Name = "mnuPrint"
        Me.mnuPrint.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.mnuPrint.Size = New System.Drawing.Size(152, 22)
        Me.mnuPrint.Text = "&Print"
        '
        'mnuPrintPreview
        '
        Me.mnuPrintPreview.Image = CType(resources.GetObject("mnuPrintPreview.Image"), System.Drawing.Image)
        Me.mnuPrintPreview.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.mnuPrintPreview.Name = "mnuPrintPreview"
        Me.mnuPrintPreview.Size = New System.Drawing.Size(152, 22)
        Me.mnuPrintPreview.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New System.Drawing.Size(149, 6)
        '
        'mnuExit
        '
        Me.mnuExit.Name = "mnuExit"
        Me.mnuExit.Size = New System.Drawing.Size(152, 22)
        Me.mnuExit.Text = "E&xit"
        '
        'mnuEdit
        '
        Me.mnuEdit.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuAddAssembly, Me.mnuRemoveAssembly, Me.ToolStripMenuItem1, Me.mnuAddStyle, Me.mnuRemoveStyle, Me.ToolStripMenuItem2, Me.mnuAddProperties, Me.mnuRemoveProperty})
        Me.mnuEdit.Name = "mnuEdit"
        Me.mnuEdit.Size = New System.Drawing.Size(37, 20)
        Me.mnuEdit.Text = "&Edit"
        '
        'mnuAddAssembly
        '
        Me.mnuAddAssembly.Name = "mnuAddAssembly"
        Me.mnuAddAssembly.Size = New System.Drawing.Size(172, 22)
        Me.mnuAddAssembly.Text = "Add Assembly"
        '
        'mnuRemoveAssembly
        '
        Me.mnuRemoveAssembly.Name = "mnuRemoveAssembly"
        Me.mnuRemoveAssembly.Size = New System.Drawing.Size(172, 22)
        Me.mnuRemoveAssembly.Text = "Remove Assembly"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(169, 6)
        '
        'mnuAddStyle
        '
        Me.mnuAddStyle.Name = "mnuAddStyle"
        Me.mnuAddStyle.Size = New System.Drawing.Size(172, 22)
        Me.mnuAddStyle.Text = "Add Style"
        '
        'mnuRemoveStyle
        '
        Me.mnuRemoveStyle.Name = "mnuRemoveStyle"
        Me.mnuRemoveStyle.Size = New System.Drawing.Size(172, 22)
        Me.mnuRemoveStyle.Text = "Remove Style"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(169, 6)
        '
        'mnuAddProperties
        '
        Me.mnuAddProperties.Name = "mnuAddProperties"
        Me.mnuAddProperties.Size = New System.Drawing.Size(172, 22)
        Me.mnuAddProperties.Text = "Add Properties"
        '
        'mnuRemoveProperty
        '
        Me.mnuRemoveProperty.Name = "mnuRemoveProperty"
        Me.mnuRemoveProperty.Size = New System.Drawing.Size(172, 22)
        Me.mnuRemoveProperty.Text = "Remove Property"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AboutToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(40, 20)
        Me.HelpToolStripMenuItem.Text = "&Help"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(126, 22)
        Me.AboutToolStripMenuItem.Text = "&About..."
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tbNew, Me.tbOpen, Me.tbSave, Me.tbPrint, Me.toolStripSeparator6})
        Me.tsMain.Location = New System.Drawing.Point(0, 24)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(664, 25)
        Me.tsMain.TabIndex = 1
        Me.tsMain.Text = "ToolStrip1"
        '
        'tbNew
        '
        Me.tbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbNew.Image = CType(resources.GetObject("tbNew.Image"), System.Drawing.Image)
        Me.tbNew.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbNew.Name = "tbNew"
        Me.tbNew.Size = New System.Drawing.Size(23, 22)
        Me.tbNew.Text = "&New"
        '
        'tbOpen
        '
        Me.tbOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbOpen.Image = CType(resources.GetObject("tbOpen.Image"), System.Drawing.Image)
        Me.tbOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbOpen.Name = "tbOpen"
        Me.tbOpen.Size = New System.Drawing.Size(23, 22)
        Me.tbOpen.Text = "&Open"
        '
        'tbSave
        '
        Me.tbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbSave.Image = CType(resources.GetObject("tbSave.Image"), System.Drawing.Image)
        Me.tbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbSave.Name = "tbSave"
        Me.tbSave.Size = New System.Drawing.Size(23, 22)
        Me.tbSave.Text = "&Save"
        '
        'tbPrint
        '
        Me.tbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tbPrint.Image = CType(resources.GetObject("tbPrint.Image"), System.Drawing.Image)
        Me.tbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tbPrint.Name = "tbPrint"
        Me.tbPrint.Size = New System.Drawing.Size(23, 22)
        Me.tbPrint.Text = "&Print"
        '
        'toolStripSeparator6
        '
        Me.toolStripSeparator6.Name = "toolStripSeparator6"
        Me.toolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ssMain
        '
        Me.ssMain.Location = New System.Drawing.Point(0, 475)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(664, 22)
        Me.ssMain.TabIndex = 2
        Me.ssMain.Text = "StatusStrip1"
        '
        'dlgOpen
        '
        Me.dlgOpen.Filter = "Winform Stylesheets (*.wfs)|*.wfs|All files (*.*)|*.*"
        '
        'viewEditor
        '
        Me.viewEditor.Dock = System.Windows.Forms.DockStyle.Fill
        Me.viewEditor.Location = New System.Drawing.Point(0, 49)
        Me.viewEditor.Name = "viewEditor"
        Me.viewEditor.Size = New System.Drawing.Size(664, 426)
        Me.viewEditor.TabIndex = 3
        '
        'EditorDialog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(664, 497)
        Me.Controls.Add(Me.viewEditor)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.mnuMain)
        Me.MainMenuStrip = Me.mnuMain
        Me.Name = "EditorDialog"
        Me.Text = "Winforms Stylesheet Editor"
        Me.mnuMain.ResumeLayout(False)
        Me.mnuMain.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub


    Private WithEvents mnuMain As System.Windows.Forms.MenuStrip
    Private WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuNew As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuOpen As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuSave As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuSaveAs As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuPrint As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuPrintPreview As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents mnuExit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents mnuEdit As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Private WithEvents tsMain As System.Windows.Forms.ToolStrip
    Private WithEvents tbNew As System.Windows.Forms.ToolStripButton
    Private WithEvents tbOpen As System.Windows.Forms.ToolStripButton
    Private WithEvents tbSave As System.Windows.Forms.ToolStripButton
    Private WithEvents tbPrint As System.Windows.Forms.ToolStripButton
    Private WithEvents toolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Private WithEvents ssMain As System.Windows.Forms.StatusStrip
    Private WithEvents dlgOpen As System.Windows.Forms.OpenFileDialog
    Private WithEvents viewEditor As Steepvalley.Windows.Forms.Styles.EditorView
    Friend WithEvents mnuAddAssembly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveAssembly As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAddStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveStyle As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents mnuAddProperties As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuRemoveProperty As System.Windows.Forms.ToolStripMenuItem
End Class
