Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class XPBox
    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        Me.SetStyle(ControlStyles.DoubleBuffer Or _
            ControlStyles.ResizeRedraw Or _
            ControlStyles.SupportsTransparentBackColor Or _
            ControlStyles.UserPaint Or _
            ControlStyles.AllPaintingInWmPaint, True)
    End Sub

#Region "private members"
    Private _shadow As Boolean = False
    Private _shadowOffset As Point = New Point(2, 2)
    Private _radius As Integer = 0
    Private _borderPen As Pen = Pens.White
    Private _fillBrush As Brush = Brushes.White
    Private _shadowBrush As Brush = New SolidBrush(Color.FromArgb(50, Color.Black))
    Private gp As GraphicsPath
#End Region

#Region "properties"
    Public Property Shadow() As Boolean
        Get
            Return _shadow
        End Get
        Set(ByVal value As Boolean)
            _shadow = value
            Me.Invalidate()
        End Set
    End Property

    Public Property CornerRadius() As Integer
        Get
            Return _radius
        End Get
        Set(ByVal value As Integer)
            _radius = value
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderPen() As Pen
        Get
            Return _borderPen
        End Get
        Set(ByVal value As Pen)
            _borderPen = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShadowOffset() As Point
        Get
            Return _shadowOffset
        End Get
        Set(ByVal value As Point)
            _shadowOffset = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShadowBrush() As Brush
        Get
            Return _shadowBrush
        End Get
        Set(ByVal value As Brush)
            _shadowBrush = value
            Me.Invalidate()
        End Set
    End Property

    Public Property ShadowColor() As Color
        Get
            Return CType(_shadowBrush, SolidBrush).Color
        End Get
        Set(ByVal value As Color)
            _shadowBrush = New SolidBrush(value)
            Me.Invalidate()
        End Set
    End Property

    Public Property FillBrush() As Brush
        Get
            Return _fillBrush
        End Get
        Set(ByVal value As Brush)
            _fillBrush = value
            Me.Invalidate()
        End Set
    End Property

    Public Property FillColor() As Color
        Get
            Return CType(_fillBrush, SolidBrush).Color
        End Get
        Set(ByVal value As Color)
            _fillBrush = New SolidBrush(value)
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderWidth() As Single
        Get
            Return _borderPen.Width
        End Get
        Set(ByVal value As Single)
            _borderPen = New Pen(_borderPen.Color, value)
            Me.Invalidate()
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return _borderPen.Color
        End Get
        Set(ByVal value As Color)
            _borderPen = New Pen(value, _borderPen.Width)
            Me.Invalidate()
        End Set
    End Property
#End Region

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim rect As Rectangle


        rect = Helpers.CheckedRectangle(Me.Padding.Left, Me.Padding.Top, Me.Width - Me.Padding.Left - Me.Padding.Right - 1, Me.Height - Me.Padding.Top - Me.Padding.Bottom - 1)
        If _shadow Then
            rect.Size = New Size(rect.Width - _shadowOffset.X, rect.Height - _shadowOffset.Y)
            rect.Location = New Point(rect.X + _shadowOffset.X, rect.Y + _shadowOffset.Y)
            gp = Paths.RoundedRect(rect, _radius, , Corner.All)
            e.Graphics.FillPath(_shadowBrush, gp)

            rect.Location = New Point(Me.Padding.Top, Me.Padding.Left)
        End If
        gp = Paths.RoundedRect(rect, _radius, , Corner.All)

        e.Graphics.FillPath(_fillBrush, gp)
        If _borderPen.Width > 0 Then
            e.Graphics.DrawPath(_borderPen, gp)

        End If
    End Sub


End Class
