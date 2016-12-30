Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Steepvalley.Windows.Forms.Common.Graphics

Friend Class XPLoginTextBox

    Private gp As New GraphicsPath
    Private shadowBrush As SolidBrush = New SolidBrush(Color.FromArgb(50, Color.Black))
    Private outerBrush As SolidBrush = New SolidBrush(Color.White)

    Public Sub New()
        MyBase.New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ContainerControl, True)

        Me.BackColor = Color.FromArgb(0, 0, 0, 0)
    End Sub

    Private Sub XPLoginTextBox_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Height = txtLogin.Height + Me.Padding.Top + Me.Padding.Bottom
    End Sub

    Private Sub txtLogin_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLogin.FontChanged
        Me.Height = txtLogin.Height + Me.Padding.Top + Me.Padding.Bottom
    End Sub

    'Public Overrides Property Font() As System.Drawing.Font
    '    Get
    '        Return txtLogin.Font
    '    End Get
    '    Set(ByVal value As System.Drawing.Font)
    '        txtLogin.Font = value
    '    End Set
    'End Property

    Public Overrides Property Text() As String
        Get
            Return txtLogin.Text
        End Get
        Set(ByVal value As String)
            txtLogin.Text = value
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        gp = Paths.RoundedRect(Helpers.CheckedRectangle(4, 4, Me.Width - 4, Me.Height - 4), 3, 1, Corner.All)
        e.Graphics.FillPath(shadowBrush, gp)

        'draw textbox
        gp = Paths.RoundedRect(Helpers.CheckedRectangle(2, 2, Me.Width - 4, Me.Height - 4), 3, 1, Corner.All)
        e.Graphics.FillPath(outerBrush, gp)

    End Sub

End Class