Public Class XPLoginFormat
    Public Class BackgroundFormat
        Private _padding As Padding = New Padding(2, 2, 2, 12)
        Public Property Padding() As Padding
            Get
                Return _padding
            End Get
            Set(ByVal value As Padding)
                _padding = value
            End Set
        End Property

        Private _borderColor1 As Color = Color.FromArgb(200, Color.AliceBlue)
        Public Property BorderColor1() As Color
            Get
                Return _borderColor1
            End Get
            Set(ByVal value As Color)
                _borderColor1 = value
            End Set
        End Property

        Private _borderColor2 As Color = Color.FromArgb(20, Color.AliceBlue)
        Public Property BorderColor2() As Color
            Get
                Return _borderColor2
            End Get
            Set(ByVal value As Color)
                _borderColor2 = value
            End Set
        End Property

        Private _backgroundColor1 As Color = Color.FromArgb(200, Color.MidnightBlue)
        Public Property BackgroundColor1() As Color
            Get
                Return _backgroundColor1
            End Get
            Set(ByVal value As Color)
                _backgroundColor1 = value
            End Set
        End Property

        Private _backgroundColor2 As Color = Color.FromArgb(20, Color.MidnightBlue)
        Public Property BackgroundColor2() As Color
            Get
                Return _backgroundColor2
            End Get
            Set(ByVal value As Color)
                _backgroundColor2 = value
            End Set
        End Property

        Private _borderWidth As Integer = 1
        Public Property BorderWidth() As Integer
            Get
                Return _borderWidth
            End Get
            Set(ByVal value As Integer)
                _borderWidth = value
            End Set
        End Property

        Private _cornerRadius As Integer = 10
        Public Property CornerRadius() As Integer
            Get
                Return _cornerRadius
            End Get
            Set(ByVal value As Integer)
                _cornerRadius = value
            End Set
        End Property
    End Class

    Public Class ImageFormat
        Private _activeBorder As Color = Color.Orange
        Public Property ActiveBorder() As Color
            Get
                Return _activeBorder
            End Get
            Set(ByVal value As Color)
                _activeBorder = value
            End Set
        End Property

        Private _inactiveBorder As Color = SystemColors.InactiveBorder
        Public Property InactiveBorder() As Color
            Get
                Return _inactiveBorder
            End Get
            Set(ByVal value As Color)
                _inactiveBorder = value
            End Set
        End Property

        Private _BorderWidth As Integer = 2
        Public Property BorderWidth() As Integer
            Get
                Return _BorderWidth
            End Get
            Set(ByVal value As Integer)
                _BorderWidth = value
            End Set
        End Property

        Private _cornerRadius As Integer = 5
        Public Property CornerRadius() As Integer
            Get
                Return _cornerRadius
            End Get
            Set(ByVal value As Integer)
                _cornerRadius = value
            End Set
        End Property

        Private _backgroundColor As Color = Color.White
        Public Property BackgroundColor() As Color
            Get
                Return _backgroundColor
            End Get
            Set(ByVal value As Color)
                _backgroundColor = value
            End Set
        End Property

        Private _size As Size = New Size(48, 48)
        Public Property Size() As Size
            Get
                Return _size
            End Get
            Set(ByVal value As Size)
                _size = value
            End Set
        End Property

        Private _padding As Padding = New Padding(8)
        Public Property Padding() As Padding
            Get
                Return _padding
            End Get
            Set(ByVal value As Padding)
                _padding = value
            End Set
        End Property

        Private _margin As Padding = New Padding(4)
        Public Property Margin() As Padding
            Get
                Return _margin
            End Get
            Set(ByVal value As Padding)
                _margin = value
            End Set
        End Property
    End Class

    Public Class TitleFormat
        Private _font As Font = New Font(SystemFonts.CaptionFont.FontFamily, 12, FontStyle.Bold)
        Public Property Font() As Font
            Get
                Return _font
            End Get
            Set(ByVal value As Font)
                _font = value
            End Set
        End Property

        Private _activeColor As Color = Color.White
        Public Property ActiveColor() As Color
            Get
                Return _activeColor
            End Get
            Set(ByVal value As Color)
                _activeColor = value
            End Set
        End Property

        Private _inactiveColor As Color = Color.AntiqueWhite
        Public Property InactiveColor() As Color
            Get
                Return _inactiveColor
            End Get
            Set(ByVal value As Color)
                _inactiveColor = value
            End Set
        End Property
    End Class

    Public Class SubtitleFormat
        Private _font As Font = New Font(SystemFonts.CaptionFont.FontFamily, 8, FontStyle.Regular)
        Public Property Font() As Font
            Get
                Return _font
            End Get
            Set(ByVal value As Font)
                _font = value
            End Set
        End Property

        Private _activeColor As Color = Color.White
        Public Property ActiveColor() As Color
            Get
                Return _activeColor
            End Get
            Set(ByVal value As Color)
                _activeColor = value
            End Set
        End Property

        Private _inactiveColor As Color = Color.AntiqueWhite
        Public Property InactiveColor() As Color
            Get
                Return _inactiveColor
            End Get
            Set(ByVal value As Color)
                _inactiveColor = value
            End Set
        End Property
    End Class

    Private _background As New BackgroundFormat
    Public Property Background() As BackgroundFormat
        Get
            Return _background
        End Get
        Set(ByVal value As BackgroundFormat)
            _background = value
        End Set
    End Property

    Private _image As New ImageFormat
    Public Property Image() As ImageFormat
        Get
            Return _image
        End Get
        Set(ByVal value As ImageFormat)
            _image = value
        End Set
    End Property

    Private _title As New TitleFormat
    Public Property Title() As TitleFormat
        Get
            Return _title
        End Get
        Set(ByVal value As TitleFormat)
            _title = value
        End Set
    End Property

    Private _subtitle As New SubtitleFormat
    Public Property Subtitle() As SubtitleFormat
        Get
            Return _subtitle
        End Get
        Set(ByVal value As SubtitleFormat)
            _subtitle = value
        End Set
    End Property

End Class