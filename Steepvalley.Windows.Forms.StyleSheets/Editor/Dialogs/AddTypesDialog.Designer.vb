<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddTypesDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AddTypesDialog))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.OK_Button = New System.Windows.Forms.Button
        Me.Cancel_Button = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.cmbAssemly = New System.Windows.Forms.ComboBox
        Me.lvTypes = New Steepvalley.Windows.Forms.ListView(Me.components)
        Me.ilSmall = New System.Windows.Forms.ImageList(Me.components)
        Me.AvailablePropertiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttachedPropertiesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.AvailablePropertiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachedPropertiesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Assembly:"
        '
        'cmbAssemly
        '
        Me.cmbAssemly.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbAssemly.FormattingEnabled = True
        Me.cmbAssemly.Location = New System.Drawing.Point(72, 17)
        Me.cmbAssemly.Name = "cmbAssemly"
        Me.cmbAssemly.Size = New System.Drawing.Size(314, 21)
        Me.cmbAssemly.TabIndex = 2
        '
        'lvTypes
        '
        Me.lvTypes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvTypes.CheckBoxes = True
        Me.lvTypes.HideSelection = False
        Me.lvTypes.Location = New System.Drawing.Point(12, 44)
        Me.lvTypes.Name = "lvTypes"
        Me.lvTypes.Size = New System.Drawing.Size(374, 186)
        Me.lvTypes.SmallImageList = Me.ilSmall
        Me.lvTypes.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.lvTypes.TabIndex = 3
        Me.lvTypes.TileColumns = New Integer() {1}
        Me.lvTypes.View = System.Windows.Forms.View.List
        '
        'ilSmall
        '
        Me.ilSmall.ImageStream = CType(resources.GetObject("ilSmall.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ilSmall.TransparentColor = System.Drawing.Color.Magenta
        Me.ilSmall.Images.SetKeyName(0, "typedef.bmp")
        '
        'AvailablePropertiesBindingSource
        '
        Me.AvailablePropertiesBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Styles.ItemProperty)
        '
        'AttachedPropertiesBindingSource
        '
        Me.AttachedPropertiesBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Styles.ItemProperty)
        '
        'AddTypesDialog
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(394, 268)
        Me.Controls.Add(Me.lvTypes)
        Me.Controls.Add(Me.cmbAssemly)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AddTypesDialog"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Properties"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.AvailablePropertiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachedPropertiesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Private WithEvents OK_Button As System.Windows.Forms.Button
    Private WithEvents Cancel_Button As System.Windows.Forms.Button
    Private WithEvents Label1 As System.Windows.Forms.Label
    Private WithEvents cmbAssemly As System.Windows.Forms.ComboBox
    Private WithEvents lvTypes As Steepvalley.Windows.Forms.ListView
    Private WithEvents ilSmall As System.Windows.Forms.ImageList
    Private WithEvents AttachedPropertiesBindingSource As System.Windows.Forms.BindingSource
    Private WithEvents AvailablePropertiesBindingSource As System.Windows.Forms.BindingSource

End Class
