Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.ComponentModel
Imports SteepValley.Windows.Forms.Common
Imports Steepvalley.Windows.Forms.Common.Graphics


<Designer(GetType(Design.XPLoginDesigner)), DesignTimeVisibleAttribute(True)> _
Public Class XPLogin

    Public Enum ControlStates
        Unselected
        Hover
        Selected
    End Enum

    Private _state As ControlStates = ControlStates.Unselected
    Private _format As New XPLoginFormat

    Private _userInfo As New LoginUserInfo
   

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

        MyBase.BackColor = Color.Transparent
    End Sub

#Region "public properties"
    Public Property Format() As XPLoginFormat
        Get
            Return _format
        End Get
        Set(ByVal value As XPLoginFormat)
            _format = value
            Me.Invalidate()
        End Set
    End Property

    Public Property State() As ControlStates
        Get
            Return _state
        End Get
        Set(ByVal value As ControlStates)
            If Not _state.Equals(value) Then
                _state = value
                Me.Invalidate()
            End If
        End Set
    End Property

    Public Property UserInfo() As LoginUserInfo
        Get
            Return _userInfo
        End Get
        Set(ByVal value As LoginUserInfo)
            _userInfo = value
        End Set
    End Property
#End Region

#Region "private drawing methods"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        DrawBackground(e, New Rectangle(_format.Background.Padding.Left, _format.Background.Padding.Top, Me.Width - _format.Background.Padding.Left - _format.Background.Padding.Right, Me.Height - _format.Background.Padding.Top - _format.Background.Padding.Bottom))
        DrawImage(e, New Rectangle(_format.Background.Padding.Left + _format.Image.Padding.Left, _format.Background.Padding.Top + _format.Image.Padding.Top, _format.Image.Size.Width + _format.Image.Margin.Left + _format.Image.Margin.Right, _format.Image.Size.Height + _format.Image.Margin.Top + _format.Image.Margin.Bottom))

        Dim _titleSize As SizeF = e.Graphics.MeasureString(_userInfo.Username, _format.Title.Font)
        DrawTitle(e, New Rectangle(_format.Background.Padding.Left + _format.Image.Padding.Left + _format.Image.Margin.Left + Format.Image.Size.Width + _format.Image.Margin.Right + _format.Image.Padding.Right, _format.Background.Padding.Top + _format.Image.Padding.Top, CInt(_titleSize.Width), CInt(_titleSize.Height)))

        Dim _subtitleSize As SizeF = e.Graphics.MeasureString(_userInfo.Message, _format.Subtitle.Font)
        DrawSubtitle(e, New Rectangle(_format.Background.Padding.Left + _format.Image.Padding.Left + _format.Image.Margin.Left + Format.Image.Size.Width + _format.Image.Margin.Right + _format.Image.Padding.Right, _format.Background.Padding.Top + _format.Image.Padding.Top + CInt(_titleSize.Height) + 2, CInt(_subtitleSize.Width), CInt(_subtitleSize.Height)))


        If _userInfo.HasPassword And _state = ControlStates.Selected Then
            txtPassword.Visible = True
            cmdLogon.Visible = True

        Else
            txtPassword.Visible = False
            cmdLogon.Visible = False

        End If
    End Sub

    Protected Overridable Sub DrawBackground(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal clientrect As Rectangle)
        If _state = ControlStates.Selected Then
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality

            Using _brush As Brush = New LinearGradientBrush(clientrect, _format.Background.BackgroundColor1, _format.Background.BackgroundColor2, LinearGradientMode.Horizontal)
                e.Graphics.FillPath(_brush, Paths.RoundedRect(clientrect, _format.Background.CornerRadius, 1, Corner.All))
            End Using

            Using _brush As Brush = New LinearGradientBrush(clientrect, _format.Background.BorderColor1, _format.Background.BorderColor2, LinearGradientMode.Horizontal)
                Using _pen As Pen = New Pen(_brush, _format.Background.BorderWidth)
                    e.Graphics.DrawPath(_pen, Paths.RoundedRect(clientrect, _format.Background.CornerRadius, 1, Corner.All))
                End Using
            End Using
        End If
    End Sub

    Protected Overridable Sub DrawImage(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal clientrect As Rectangle)
        Dim rect As Rectangle = clientrect

        'draw image background
        rect = clientrect
        rect.Size = New Size(rect.Width - 2, rect.Height - 2)
        Using _brush As Brush = New SolidBrush(_format.Image.BackgroundColor)
            e.Graphics.FillPath(_brush, Paths.RoundedRect(rect, _format.Image.CornerRadius, 1, Corner.All))
        End Using

        'draw active border
        If _state = ControlStates.Hover Or _state = ControlStates.Selected Then
            e.Graphics.DrawPath(New Pen(_format.Image.ActiveBorder, _format.Image.BorderWidth), _
                       Paths.RoundedRect(rect, _format.Image.CornerRadius, 1, Corner.All))
        Else
            e.Graphics.DrawPath(New Pen(_format.Image.InactiveBorder, _format.Image.BorderWidth), _
                       Paths.RoundedRect(rect, _format.Image.CornerRadius, 1, Corner.All))
        End If

        'draw image
        If _userInfo.UserImage IsNot Nothing Then
            rect.Size = New Size(rect.Width - _format.Image.Margin.Left - _format.Image.Margin.Right, rect.Height - _format.Image.Margin.Top - _format.Image.Margin.Bottom)
            rect.Location = New Point(rect.X + _format.Image.Margin.Left, rect.Y + _format.Image.Margin.Top)
            e.Graphics.DrawImage(_userInfo.UserImage, rect)
        End If

    End Sub

    Protected Overridable Sub DrawTitle(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal clientrect As Rectangle)
        If _state = ControlStates.Hover Or _state = ControlStates.Selected Then
            e.Graphics.DrawString(_userInfo.Username, _format.Title.Font, New SolidBrush(_format.Title.ActiveColor), clientrect.X, clientrect.Y)    'Helpers.ConvertToRectangleF(clientrect)
        Else
            e.Graphics.DrawString(_userInfo.Username, _format.Title.Font, New SolidBrush(_format.Title.InactiveColor), clientrect.X, clientrect.Y)    'Helpers.ConvertToRectangleF(clientrect)
        End If
    End Sub

    Protected Overridable Sub DrawSubtitle(ByVal e As System.Windows.Forms.PaintEventArgs, ByVal clientrect As Rectangle)
        If _state = ControlStates.Hover Or _state = ControlStates.Selected Then
            e.Graphics.DrawString(_userInfo.Message, _format.Subtitle.Font, New SolidBrush(_format.Subtitle.ActiveColor), clientrect.X, clientrect.Y)    'Helpers.ConvertToRectangleF(clientrect)
        Else
            e.Graphics.DrawString(_userInfo.Message, _format.Subtitle.Font, New SolidBrush(_format.Subtitle.InactiveColor), clientrect.X, clientrect.Y)    'Helpers.ConvertToRectangleF(clientrect)
        End If

    End Sub
#End Region

#Region "events"
    Public Event Selected As EventHandler
    Protected Overridable Sub OnSelected(ByVal e As EventArgs)
        RaiseEvent Selected(Me, e)
    End Sub

    Public Event Authenticate As EventHandler(Of AuthenticateEventArgs)
    Protected Overridable Sub OnAuthenticate(ByRef e As AuthenticateEventArgs)
        RaiseEvent Authenticate(Me, e)
    End Sub

    Public Event Authenticated As EventHandler(Of AuthenticatedEventArgs)
    Protected Overridable Sub OnAuthenticated(ByVal e As AuthenticatedEventArgs)
        RaiseEvent Authenticated(Me, e)
    End Sub

#End Region

#Region "private actions"
    Private Sub XPLogin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        If Me.State = ControlStates.Selected Then
            '            Me.State = ControlStates.Hover
        Else
            Me.State = ControlStates.Selected
            Me.txtPassword.Focus()
            OnSelected(New EventArgs)
        End If
    End Sub

    Private Sub XPLogin_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        If Not Me.State = ControlStates.Selected Then Me.State = ControlStates.Hover
    End Sub

    Private Sub XPLogin_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        If Not Me.State = ControlStates.Selected Then Me.State = ControlStates.Unselected
    End Sub

    Private Sub XPLogin_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Me.Height = _format.Background.Padding.Top + _format.Image.Padding.Top + _format.Image.Margin.Top + _format.Image.Size.Height + _format.Image.Margin.Bottom + _format.Image.Padding.Bottom + _format.Background.Padding.Bottom
        Me.txtPassword.Left = _format.Background.Padding.Left + _format.Image.Padding.Left + _format.Image.Margin.Left + Format.Image.Size.Width + _format.Image.Margin.Right + _format.Image.Padding.Right
        Me.txtPassword.Width = Me.Width - Me.txtPassword.Left - (Me.Width - cmdLogon.Left) - 4
    End Sub
#End Region

    Private Sub cmdLogon_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdLogon.Click
        TryAuthenticate()
    End Sub

    Private Sub TryAuthenticate()
        Dim msg As String = _userInfo.Message
        Dim auth As Boolean = False
        Dim args As AuthenticateEventArgs = New AuthenticateEventArgs(_userInfo.Username, txtPassword.Text, msg, auth)

        If _userInfo.HasPassword = False Or (Not _userInfo.Password.Equals(String.Empty) And _userInfo.Password.Equals(txtPassword.Text)) Then
            args.Authenticated = True
        End If

        If args.Authenticated = False Then
            OnAuthenticate(args)
        End If

        If args.Authenticated = True Then
            OnAuthenticated(New AuthenticatedEventArgs(_userInfo.Username, txtPassword.Text))
        Else
            _userInfo.Message = args.Message
            Me.Invalidate()
            txtPassword.Text = ""
            txtPassword.Focus()
        End If

    End Sub

    Private Sub txtPassword_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            TryAuthenticate()
        End If
    End Sub

    
End Class