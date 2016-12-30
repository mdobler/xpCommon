<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class XPLogin
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
        Me.cmdLogon = New System.Windows.Forms.Button
        Me.txtPassword = New Steepvalley.Windows.Forms.Login.XPLoginTextBox
        Me.SuspendLayout()
        '
        'cmdLogon
        '
        Me.cmdLogon.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdLogon.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.cmdLogon.FlatAppearance.BorderSize = 0
        Me.cmdLogon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdLogon.Image = Global.Steepvalley.Windows.Forms.Login.My.Resources.Resources.rightarrow24
        Me.cmdLogon.Location = New System.Drawing.Point(295, 50)
        Me.cmdLogon.Name = "cmdLogon"
        Me.cmdLogon.Size = New System.Drawing.Size(32, 30)
        Me.cmdLogon.TabIndex = 11
        Me.cmdLogon.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.txtPassword.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtPassword.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(92, 50)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Padding = New System.Windows.Forms.Padding(8)
        Me.txtPassword.Size = New System.Drawing.Size(204, 30)
        Me.txtPassword.TabIndex = 4
        '
        'XPLogin
        '
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.cmdLogon)
        Me.Controls.Add(Me.txtPassword)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "XPLogin"
        Me.Padding = New System.Windows.Forms.Padding(2)
        Me.Size = New System.Drawing.Size(332, 86)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtPassword As Steepvalley.Windows.Forms.Login.XPLoginTextBox
    Friend WithEvents cmdLogon As System.Windows.Forms.Button

End Class