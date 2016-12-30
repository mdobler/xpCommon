<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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

    Private WithEvents cmdClose As System.Windows.Forms.Button
    Private WithEvents lblDescription As System.Windows.Forms.Label
    Private WithEvents llSteepvalley As System.Windows.Forms.LinkLabel
    Private WithEvents tbDescription As System.Windows.Forms.Label
    Private WithEvents tbVersion As System.Windows.Forms.Label
    Private WithEvents tbCompany As System.Windows.Forms.Label
    Private WithEvents tbAppname As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(About))
        Me.cmdClose = New System.Windows.Forms.Button
        Me.lblDescription = New System.Windows.Forms.Label
        Me.llSteepvalley = New System.Windows.Forms.LinkLabel
        Me.tbDescription = New System.Windows.Forms.Label
        Me.tbVersion = New System.Windows.Forms.Label
        Me.tbCompany = New System.Windows.Forms.Label
        Me.tbAppname = New System.Windows.Forms.Label
        Me.picSteepvalley = New System.Windows.Forms.PictureBox
        CType(Me.picSteepvalley, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdClose
        '
        Me.cmdClose.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdClose.Location = New System.Drawing.Point(315, 242)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(75, 23)
        Me.cmdClose.TabIndex = 5
        Me.cmdClose.Text = "&Close"
        '
        'lblDescription
        '
        Me.lblDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDescription.AutoSize = True
        Me.lblDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.ForeColor = System.Drawing.SystemColors.Window
        Me.lblDescription.Location = New System.Drawing.Point(21, 162)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(74, 13)
        Me.lblDescription.TabIndex = 6
        Me.lblDescription.Text = "Description:"
        '
        'llSteepvalley
        '
        Me.llSteepvalley.AutoSize = True
        Me.llSteepvalley.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.llSteepvalley.Location = New System.Drawing.Point(21, 242)
        Me.llSteepvalley.Name = "llSteepvalley"
        Me.llSteepvalley.Size = New System.Drawing.Size(110, 13)
        Me.llSteepvalley.TabIndex = 7
        Me.llSteepvalley.TabStop = True
        Me.llSteepvalley.Text = "www.steepvalley.net"
        '
        'tbDescription
        '
        Me.tbDescription.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbDescription.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDescription.ForeColor = System.Drawing.SystemColors.Window
        Me.tbDescription.Location = New System.Drawing.Point(21, 178)
        Me.tbDescription.Name = "tbDescription"
        Me.tbDescription.Size = New System.Drawing.Size(363, 56)
        Me.tbDescription.TabIndex = 8
        Me.tbDescription.Text = "Description:"
        '
        'tbVersion
        '
        Me.tbVersion.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbVersion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbVersion.ForeColor = System.Drawing.SystemColors.Window
        Me.tbVersion.Location = New System.Drawing.Point(21, 135)
        Me.tbVersion.Name = "tbVersion"
        Me.tbVersion.Size = New System.Drawing.Size(363, 16)
        Me.tbVersion.TabIndex = 9
        Me.tbVersion.Text = "Version Info"
        '
        'tbCompany
        '
        Me.tbCompany.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCompany.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbCompany.ForeColor = System.Drawing.SystemColors.Window
        Me.tbCompany.Location = New System.Drawing.Point(21, 111)
        Me.tbCompany.Name = "tbCompany"
        Me.tbCompany.Size = New System.Drawing.Size(363, 17)
        Me.tbCompany.TabIndex = 10
        Me.tbCompany.Text = "Company Name"
        '
        'tbAppname
        '
        Me.tbAppname.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbAppname.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbAppname.ForeColor = System.Drawing.SystemColors.Window
        Me.tbAppname.Location = New System.Drawing.Point(8, 83)
        Me.tbAppname.Name = "tbAppname"
        Me.tbAppname.Size = New System.Drawing.Size(379, 24)
        Me.tbAppname.TabIndex = 11
        Me.tbAppname.Text = "Application Name"
        '
        'picSteepvalley
        '
        Me.picSteepvalley.BackColor = System.Drawing.Color.FromArgb(CType(CType(187, Byte), Integer), CType(CType(204, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.picSteepvalley.Dock = System.Windows.Forms.DockStyle.Top
        Me.picSteepvalley.Image = CType(resources.GetObject("picSteepvalley.Image"), System.Drawing.Image)
        Me.picSteepvalley.Location = New System.Drawing.Point(0, 0)
        Me.picSteepvalley.Name = "picSteepvalley"
        Me.picSteepvalley.Size = New System.Drawing.Size(394, 75)
        Me.picSteepvalley.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picSteepvalley.TabIndex = 12
        Me.picSteepvalley.TabStop = False
        '
        'About
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.SystemColors.AppWorkspace
        Me.ClientSize = New System.Drawing.Size(394, 268)
        Me.ControlBox = False
        Me.Controls.Add(Me.picSteepvalley)
        Me.Controls.Add(Me.tbAppname)
        Me.Controls.Add(Me.tbCompany)
        Me.Controls.Add(Me.tbVersion)
        Me.Controls.Add(Me.tbDescription)
        Me.Controls.Add(Me.llSteepvalley)
        Me.Controls.Add(Me.lblDescription)
        Me.Controls.Add(Me.cmdClose)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About"
        CType(Me.picSteepvalley, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents picSteepvalley As System.Windows.Forms.PictureBox
End Class
