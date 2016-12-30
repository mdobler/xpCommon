<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddPropertiesDialog
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
        Me.components = New System.ComponentModel.Container
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.lbAvailableProperties = New System.Windows.Forms.ListBox
        Me.AvailablePropertiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.lbAttachedProperties = New System.Windows.Forms.ListBox
        Me.AttachedPropertiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.cmdAddAll = New System.Windows.Forms.Button
        Me.cmdAddSelected = New System.Windows.Forms.Button
        Me.cmdRemoveSelected = New System.Windows.Forms.Button
        Me.cmdRemoveAll = New System.Windows.Forms.Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.AvailablePropertiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachedPropertiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(243, 236)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lbAvailableProperties, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lbAttachedProperties, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(4, 4)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(385, 226)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'lbAvailableProperties
        '
        Me.lbAvailableProperties.DataSource = Me.AvailablePropertiesBindingSource
        Me.lbAvailableProperties.DisplayMember = "Name"
        Me.lbAvailableProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbAvailableProperties.FormattingEnabled = True
        Me.lbAvailableProperties.IntegralHeight = False
        Me.lbAvailableProperties.Location = New System.Drawing.Point(3, 3)
        Me.lbAvailableProperties.Name = "lbAvailableProperties"
        Me.lbAvailableProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbAvailableProperties.Size = New System.Drawing.Size(161, 220)
        Me.lbAvailableProperties.TabIndex = 0
        Me.lbAvailableProperties.ValueMember = "Name"
        '
        'AvailablePropertiesBindingSource
        '
        Me.AvailablePropertiesBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Styles.ItemProperty)
        '
        'lbAttachedProperties
        '
        Me.lbAttachedProperties.DataSource = Me.AttachedPropertiesBindingSource
        Me.lbAttachedProperties.DisplayMember = "Name"
        Me.lbAttachedProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lbAttachedProperties.FormattingEnabled = True
        Me.lbAttachedProperties.IntegralHeight = False
        Me.lbAttachedProperties.Location = New System.Drawing.Point(220, 3)
        Me.lbAttachedProperties.Name = "lbAttachedProperties"
        Me.lbAttachedProperties.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lbAttachedProperties.Size = New System.Drawing.Size(162, 220)
        Me.lbAttachedProperties.TabIndex = 1
        Me.lbAttachedProperties.ValueMember = "Name"
        '
        'AttachedPropertiesBindingSource
        '
        Me.AttachedPropertiesBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Styles.ItemProperty)
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.cmdAddAll, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdAddSelected, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdRemoveSelected, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.cmdRemoveAll, 0, 4)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(170, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 6
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(44, 220)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'cmdAddAll
        '
        Me.cmdAddAll.Location = New System.Drawing.Point(3, 53)
        Me.cmdAddAll.Name = "cmdAddAll"
        Me.cmdAddAll.Size = New System.Drawing.Size(38, 23)
        Me.cmdAddAll.TabIndex = 0
        Me.cmdAddAll.Text = ">>"
        Me.cmdAddAll.UseVisualStyleBackColor = True
        '
        'cmdAddSelected
        '
        Me.cmdAddSelected.Location = New System.Drawing.Point(3, 83)
        Me.cmdAddSelected.Name = "cmdAddSelected"
        Me.cmdAddSelected.Size = New System.Drawing.Size(38, 23)
        Me.cmdAddSelected.TabIndex = 1
        Me.cmdAddSelected.Text = ">"
        Me.cmdAddSelected.UseVisualStyleBackColor = True
        '
        'cmdRemoveSelected
        '
        Me.cmdRemoveSelected.Location = New System.Drawing.Point(3, 113)
        Me.cmdRemoveSelected.Name = "cmdRemoveSelected"
        Me.cmdRemoveSelected.Size = New System.Drawing.Size(38, 23)
        Me.cmdRemoveSelected.TabIndex = 2
        Me.cmdRemoveSelected.Text = "<"
        Me.cmdRemoveSelected.UseVisualStyleBackColor = True
        '
        'cmdRemoveAll
        '
        Me.cmdRemoveAll.Location = New System.Drawing.Point(3, 143)
        Me.cmdRemoveAll.Name = "cmdRemoveAll"
        Me.cmdRemoveAll.Size = New System.Drawing.Size(38, 23)
        Me.cmdRemoveAll.TabIndex = 3
        Me.cmdRemoveAll.Text = "<<"
        Me.cmdRemoveAll.UseVisualStyleBackColor = True
        '
        'AddPropertiesDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(394, 268)
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddPropertiesDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Properties"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.AvailablePropertiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachedPropertiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents lbAvailableProperties As System.Windows.Forms.ListBox
    Private WithEvents lbAttachedProperties As System.Windows.Forms.ListBox
    Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents OK_Button As System.Windows.Forms.Button
    Private WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents AttachedPropertiesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AvailablePropertiesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents cmdAddAll As System.Windows.Forms.Button
    Private WithEvents cmdAddSelected As System.Windows.Forms.Button
    Private WithEvents cmdRemoveSelected As System.Windows.Forms.Button
    Private WithEvents cmdRemoveAll As System.Windows.Forms.Button

End Class
