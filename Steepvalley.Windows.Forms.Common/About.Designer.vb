<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.pnlLayout = New System.Windows.Forms.Panel
        Me.picLogo = New System.Windows.Forms.PictureBox
        Me.ApplicationTitle = New System.Windows.Forms.Label
        Me.tbCompany = New System.Windows.Forms.Label
        Me.Version = New System.Windows.Forms.Label
        Me.tbDescription = New System.Windows.Forms.Label
        Me.llSteepvalley = New System.Windows.Forms.LinkLabel
        Me.lblDescription = New System.Windows.Forms.Label
        Me.cmdClose = New System.Windows.Forms.Button
        Me.pnlLayout.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlLayout
        '
        Me.pnlLayout.BackColor = System.Drawing.Color.White
        Me.pnlLayout.Controls.Add(Me.picLogo)
        Me.pnlLayout.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlLayout.Location = New System.Drawing.Point(0, 0)
        Me.pnlLayout.Name = "pnlLayout"
        Me.pnlLayout.Size = New System.Drawing.Size(496, 75)
        Me.pnlLayout.TabIndex = 28
        '
        'picLogo
        '
        Me.picLogo.BackColor = System.Drawing.Color.White
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(0, 9)
        Me.picLogo.Margin = New System.Windows.Forms.Padding(0)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(320, 50)
        Me.picLogo.TabIndex = 12
        Me.picLogo.TabStop = False
        '
        'ApplicationTitle
        '
        Me.ApplicationTitle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ApplicationTitle.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ApplicationTitle.ForeColor = System.Drawing.SystemColors.Window
        Me.ApplicationTitle.Location = New System.Drawing.Point(22, 107)
        Me.ApplicationTitle.Name = "ApplicationTitle"
        Me.ApplicationTitle.Size = New System.Drawing.Size(358, 24)
        Me.ApplicationTitle.TabIndex = 27
        Me.ApplicationTitle.Text = "Application Name"
        '
        'tbCompany
        '
        Me.tbCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCompany.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompany.ForeColor = System.Drawing.SystemColors.Window
        Me.tbCompany.Location = New System.Drawing.Point(47, 134)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.Size = New System.Drawing.Size(333, 17)
        Me.tbCompany.TabIndex = 26
        Me.tbCompany.Text = "Company Name"
        '
        'Version
        '
        Me.Version.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Version.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Version.ForeColor = System.Drawing.SystemColors.Window
        Me.Version.Location = New System.Drawing.Point(47, 158)
        Me.Version.Name = "Version"
        Me.Version.Size = New System.Drawing.Size(333, 16)
        Me.Version.TabIndex = 25
        Me.Version.Text = "Version Info"
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescription.ForeColor = System.Drawing.SystemColors.Window
        Me.tbDescription.Location = New System.Drawing.Point(47, 204)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(333, 53)
        Me.tbDescription.TabIndex = 24
        Me.tbDescription.Text = "Description:"
        '
        'llSteepvalley
        '
        Me.llSteepvalley.AutoSize = True
        Me.llSteepvalley.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.llSteepvalley.Location = New System.Drawing.Point(23, 266)
        Me.llSteepvalley.Name = "llSteepvalley"
        Me.llSteepvalley.Size = New System.Drawing.Size(105, 13)
        Me.llSteepvalley.TabIndex = 23
        Me.llSteepvalley.TabStop = True
        Me.llSteepvalley.Text = "www.steepvalley.net"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.SystemColors.Window
        Me.lblDescription.Location = New System.Drawing.Point(47, 188)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(74, 13)
        Me.lblDescription.TabIndex = 22
        Me.lblDescription.Text = "Description:"
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(409, 261)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 21
        Me.cmdClose.Text = "&OK"
        '
        'About
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(496, 303)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlLayout)
        Me.Controls.Add(Me.ApplicationTitle)
        Me.Controls.Add(Me.tbCompany)
        Me.Controls.Add(Me.Version)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.llSteepvalley)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cmdClose)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlLayout.ResumeLayout(False)
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents picLogo As System.Windows.Forms.PictureBox
    Friend WithEvents pnlLayout As System.Windows.Forms.Panel
    Private WithEvents ApplicationTitle As System.Windows.Forms.Label
    Private WithEvents tbCompany As System.Windows.Forms.Label
    Private WithEvents Version As System.Windows.Forms.Label
    Private WithEvents tbDescription As System.Windows.Forms.Label
    Private WithEvents llSteepvalley As System.Windows.Forms.LinkLabel
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents cmdClose As System.Windows.Forms.Button

End Class
