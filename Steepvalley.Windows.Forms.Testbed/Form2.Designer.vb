<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        Dim XpLoginFormat1 As Steepvalley.Windows.Forms.Login.XPLoginFormat = New Steepvalley.Windows.Forms.Login.XPLoginFormat
        Dim BackgroundFormat1 As Steepvalley.Windows.Forms.Login.XPLoginFormat.BackgroundFormat = New Steepvalley.Windows.Forms.Login.XPLoginFormat.BackgroundFormat
        Dim ImageFormat1 As Steepvalley.Windows.Forms.Login.XPLoginFormat.ImageFormat = New Steepvalley.Windows.Forms.Login.XPLoginFormat.ImageFormat
        Dim SubtitleFormat1 As Steepvalley.Windows.Forms.Login.XPLoginFormat.SubtitleFormat = New Steepvalley.Windows.Forms.Login.XPLoginFormat.SubtitleFormat
        Dim TitleFormat1 As Steepvalley.Windows.Forms.Login.XPLoginFormat.TitleFormat = New Steepvalley.Windows.Forms.Login.XPLoginFormat.TitleFormat
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Me.XpLetterBox1 = New Steepvalley.Windows.Forms.ThemedControls.XPLetterBox
        Me.OscarCollectionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XpLoginList1 = New Steepvalley.Windows.Forms.Login.XPLoginList(Me.components)
        Me.XpLetterBox1.SuspendLayout()
        CType(Me.OscarCollectionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XpLetterBox1
        '
        Me.XpLetterBox1.BackColor = System.Drawing.Color.Transparent
        Me.XpLetterBox1.Controls.Add(Me.XpLoginList1)
        Me.XpLetterBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XpLetterBox1.DrawVerticalSplitLine = True
        Me.XpLetterBox1.Location = New System.Drawing.Point(0, 0)
        Me.XpLetterBox1.Name = "XpLetterBox1"
        Me.XpLetterBox1.Padding = New System.Windows.Forms.Padding(0, 48, 0, 48)
        Me.XpLetterBox1.Size = New System.Drawing.Size(615, 442)
        Me.XpLetterBox1.TabIndex = 1
        Me.XpLetterBox1.ThemeFormat.BottomBodyColor = System.Drawing.Color.FromArgb(CType(CType(90, Byte), Integer), CType(CType(126, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.XpLetterBox1.ThemeFormat.FooterColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.XpLetterBox1.ThemeFormat.HeaderColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(51, Byte), Integer), CType(CType(153, Byte), Integer))
        Me.XpLetterBox1.ThemeFormat.HeaderTextColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(223, Byte), Integer), CType(CType(245, Byte), Integer))
        Me.XpLetterBox1.ThemeFormat.HeaderTextFont = New System.Drawing.Font("Franklin Gothic Medium", 14.0!, System.Drawing.FontStyle.Bold)
        Me.XpLetterBox1.ThemeFormat.TopBodyColor = System.Drawing.Color.FromArgb(CType(CType(85, Byte), Integer), CType(CType(130, Byte), Integer), CType(CType(210, Byte), Integer))
        '
        'OscarCollectionBindingSource
        '
        Me.OscarCollectionBindingSource.DataSource = GetType(Steepvalley.Windows.Forms.Testbed.OscarCollection)
        '
        'XpLoginList1
        '
        Me.XpLoginList1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XpLoginList1.BackColor = System.Drawing.Color.Transparent
        BackgroundFormat1.BackgroundColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(112, Byte), Integer))
        BackgroundFormat1.BackgroundColor2 = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(25, Byte), Integer), CType(CType(112, Byte), Integer))
        BackgroundFormat1.BorderColor1 = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        BackgroundFormat1.BorderColor2 = System.Drawing.Color.FromArgb(CType(CType(20, Byte), Integer), CType(CType(240, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(255, Byte), Integer))
        BackgroundFormat1.BorderWidth = 1
        BackgroundFormat1.CornerRadius = 10
        BackgroundFormat1.Padding = New System.Windows.Forms.Padding(2, 2, 2, 12)
        XpLoginFormat1.Background = BackgroundFormat1
        ImageFormat1.ActiveBorder = System.Drawing.Color.Orange
        ImageFormat1.BackgroundColor = System.Drawing.Color.White
        ImageFormat1.BorderWidth = 2
        ImageFormat1.CornerRadius = 5
        ImageFormat1.InactiveBorder = System.Drawing.SystemColors.InactiveBorder
        ImageFormat1.Margin = New System.Windows.Forms.Padding(4)
        ImageFormat1.Padding = New System.Windows.Forms.Padding(8)
        ImageFormat1.Size = New System.Drawing.Size(48, 48)
        XpLoginFormat1.Image = ImageFormat1
        SubtitleFormat1.ActiveColor = System.Drawing.Color.White
        SubtitleFormat1.Font = New System.Drawing.Font("Trebuchet MS", 8.0!)
        SubtitleFormat1.InactiveColor = System.Drawing.Color.AntiqueWhite
        XpLoginFormat1.Subtitle = SubtitleFormat1
        TitleFormat1.ActiveColor = System.Drawing.Color.White
        TitleFormat1.Font = New System.Drawing.Font("Trebuchet MS", 12.0!, System.Drawing.FontStyle.Bold)
        TitleFormat1.InactiveColor = System.Drawing.Color.AntiqueWhite
        XpLoginFormat1.Title = TitleFormat1
        Me.XpLoginList1.Format = XpLoginFormat1
        Me.XpLoginList1.Items.Add(New Steepvalley.Windows.Forms.Login.LoginUserInfo("Fred", "", "Enter ""test"" as Password", CType(resources.GetObject("XpLoginList1.Items"), System.Drawing.Image), True))
        Me.XpLoginList1.Items.Add(New Steepvalley.Windows.Forms.Login.LoginUserInfo("Barney", "", "Enter ""test"" as Password", CType(resources.GetObject("XpLoginList1.Items1"), System.Drawing.Image), True))
        Me.XpLoginList1.Location = New System.Drawing.Point(324, 64)
        Me.XpLoginList1.Name = "XpLoginList1"
        Me.XpLoginList1.Size = New System.Drawing.Size(279, 316)
        Me.XpLoginList1.TabIndex = 0
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(615, 442)
        Me.Controls.Add(Me.XpLetterBox1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.XpLetterBox1.ResumeLayout(False)
        CType(Me.OscarCollectionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OscarCollectionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XpLetterBox1 As Steepvalley.Windows.Forms.ThemedControls.XPLetterBox
    Friend WithEvents XpLoginList1 As Steepvalley.Windows.Forms.Login.XPLoginList
End Class
