Public Class XPRoundedRect
    Inherits System.Windows.Forms.Panel

    Private _fillColor1 As Color = Color.FromArgb(200, Color.DarkBlue)
    Private _fillColor2 As Color = Color.FromArgb(10, Color.DarkBlue)
    Private _lineColor1 As Color = Color.FromArgb(200, Color.AliceBlue)
    Private _lineColor2 As Color = Color.FromArgb(10, Color.AliceBlue)
    Private _lineWidth As Integer = 2
    Private _drawingType As DrawingTypes = DrawingTypes.Gradient
    Private _cornerRadius As Integer = 5

    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.ContainerControl, True)

    End Sub

    Public Enum DrawingTypes
        Solid
        Gradient
    End Enum

#Region " Public Properties "
    Public Property FillColor1() As Color
        Get
            Return _fillColor1
        End Get
        Set(ByVal value As Color)
            _fillColor1 = value
            Me.Invalidate()
        End Set
    End Property

    Public Property FillColor2() As Color
        Get
            Return _fillColor2
        End Get
        Set(ByVal value As Color)
            _fillColor2 = value
            Me.Invalidate()
        End Set
    End Property

    Public Property LineColor1() As Color
        Get
            Return _lineColor1
        End Get
        Set(ByVal value As Color)
            _lineColor1 = value
            Me.Invalidate()
        End Set
    End Property

    Public Property LineColor2() As Color
        Get
            Return _lineColor2
        End Get
        Set(ByVal value As Color)
            _lineColor2 = value
            Me.Invalidate()
        End Set
    End Property

    Public Property LineWidth() As Integer
        Get
            Return _lineWidth
        End Get
        Set(ByVal value As Integer)
            _lineWidth = value
            Me.Invalidate()
        End Set
    End Property

    Public Property DrawingType() As DrawingTypes
        Get
            Return _drawingType
        End Get
        Set(ByVal value As DrawingTypes)
            _drawingType = value
            Me.Invalidate()
        End Set
    End Property

    Public Property CornerRadius() As Integer
        Get
            Return _cornerRadius
        End Get
        Set(ByVal value As Integer)
            _cornerRadius = value
            Me.Invalidate()
        End Set
    End Property
#End Region

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim _clientRect As Rectangle = New Rectangle(Me.Padding.Left, Me.Padding.Top, Me.Width - Me.Padding.Left - Me.Padding.Top - 1, Me.Height - Me.Padding.Top - Me.Padding.Bottom - 1)

        Select Case _drawingType
            Case DrawingTypes.Solid
                Using _brush As Brush = New SolidBrush(_fillColor1)
                    e.Graphics.FillPath(_brush, Paths.RoundedRect(_clientRect, _cornerRadius, 1, Corner.All))
                End Using
                Using _pen As Pen = New Pen(_lineColor1, _lineWidth)
                    e.Graphics.DrawPath(_pen, Paths.RoundedRect(_clientRect, _cornerRadius, 1, Corner.All))
                End Using
            Case DrawingTypes.Gradient
                Using _brush As Brush = New LinearGradientBrush(_clientRect, _fillColor1, _fillColor2, LinearGradientMode.Horizontal)
                    e.Graphics.FillPath(_brush, Paths.RoundedRect(_clientRect, _cornerRadius, 1, Corner.All))
                End Using

                Using _brush As Brush = New LinearGradientBrush(_clientRect, _lineColor1, _lineColor2, LinearGradientMode.Horizontal)
                    Using _pen As Pen = New Pen(_brush, _lineWidth)
                        e.Graphics.DrawPath(_pen, Paths.RoundedRect(_clientRect, _cornerRadius, 1, Corner.All))
                    End Using
                End Using
        End Select

        MyBase.OnPaint(e)
    End Sub

End Class
