<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PropertiesView
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
        Me.pnlStyleInfo = New System.Windows.Forms.Panel
        Me.lblTypeInfo = New System.Windows.Forms.Label
        Me.StyleBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lblType = New System.Windows.Forms.Label
        Me.lblClassID = New System.Windows.Forms.Label
        Me.txtClassID = New System.Windows.Forms.TextBox
        Me.pgEdit = New System.Windows.Forms.PropertyGrid
        Me.pnlStyleInfo.SuspendLayout()
        CType(Me.StyleBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlStyleInfo
        '
        Me.pnlStyleInfo.Controls.Add(Me.lblTypeInfo)
        Me.pnlStyleInfo.Controls.Add(Me.lblType)
        Me.pnlStyleInfo.Controls.Add(Me.lblClassID)
        Me.pnlStyleInfo.Controls.Add(Me.txtClassID)
        Me.pnlStyleInfo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStyleInfo.Location = New System.Drawing.Point(0, 0)
        Me.pnlStyleInfo.Name = "pnlStyleInfo"
        Me.pnlStyleInfo.Size = New System.Drawing.Size(376, 60)
        Me.pnlStyleInfo.TabIndex = 2
        '
        'lblTypeInfo
        '
        Me.lblTypeInfo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StyleBindingSource, "TypeName", True))
        Me.lblTypeInfo.Location = New System.Drawing.Point(79, 11)
        Me.lblTypeInfo.Name = "lblTypeInfo"
        Me.lblTypeInfo.Size = New System.Drawing.Size(294, 13)
        Me.lblTypeInfo.TabIndex = 3
        '
        'StyleBindingSource
        '
        Me.StyleBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Styles.Style)
        '
        'lblType
        '
        Me.lblType.AutoSize = True
        Me.lblType.Location = New System.Drawing.Point(3, 11)
        Me.lblType.Name = "lblType"
        Me.lblType.Size = New System.Drawing.Size(34, 13)
        Me.lblType.TabIndex = 2
        Me.lblType.Text = "Type:"
        '
        'lblClassID
        '
        Me.lblClassID.AutoSize = True
        Me.lblClassID.Location = New System.Drawing.Point(3, 37)
        Me.lblClassID.Name = "lblClassID"
        Me.lblClassID.Size = New System.Drawing.Size(49, 13)
        Me.lblClassID.TabIndex = 1
        Me.lblClassID.Text = "Class ID:"
        '
        'txtClassID
        '
        Me.txtClassID.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtClassID.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.StyleBindingSource, "ClassID", True))
        Me.txtClassID.Location = New System.Drawing.Point(79, 34)
        Me.txtClassID.Name = "txtClassID"
        Me.txtClassID.Size = New System.Drawing.Size(297, 20)
        Me.txtClassID.TabIndex = 0
        '
        'pgEdit
        '
        Me.pgEdit.BackColor = System.Drawing.SystemColors.Window
        Me.pgEdit.CommandsBackColor = System.Drawing.SystemColors.Control
        Me.pgEdit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pgEdit.Location = New System.Drawing.Point(0, 60)
        Me.pgEdit.Name = "pgEdit"
        Me.pgEdit.Size = New System.Drawing.Size(376, 316)
        Me.pgEdit.TabIndex = 3
        Me.pgEdit.ToolbarVisible = False
        '
        'PropertiesView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.pgEdit)
        Me.Controls.Add(Me.pnlStyleInfo)
        Me.Name = "PropertiesView"
        Me.Size = New System.Drawing.Size(376, 376)
        Me.pnlStyleInfo.ResumeLayout(False)
        Me.pnlStyleInfo.PerformLayout()
        CType(Me.StyleBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents pgEdit As System.Windows.Forms.PropertyGrid
    Private WithEvents txtClassID As System.Windows.Forms.TextBox
    Private WithEvents lblTypeInfo As System.Windows.Forms.Label
    Private WithEvents lblType As System.Windows.Forms.Label
    Private WithEvents lblClassID As System.Windows.Forms.Label
    Private WithEvents pnlStyleInfo As System.Windows.Forms.Panel
    Private WithEvents StyleBindingSource As System.Windows.Forms.BindingSource

End Class
