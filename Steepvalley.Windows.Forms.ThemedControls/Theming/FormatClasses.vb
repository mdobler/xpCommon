Public MustInherit Class ThemeFormatBase
    Public Delegate Sub PropertyChangedHandler(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
    Public Event PropertyChanged As PropertyChangedHandler
    Protected Overridable Sub OnPropertyChanged(ByVal e As PropertyChangedEventArgs)
        RaiseEvent PropertyChanged(Me, e)
    End Sub

    Protected Sub New()
        '...
    End Sub
End Class


''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.TaskBoxFormat
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class holds all format information for the xpTaskBox and xpTaskBoxSpecial
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	18.08.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class TaskBoxFormat
    Inherits ThemeFormatBase

    Private _leftHeaderColor As Color
    Private _rightHeaderColor As Color
    Private _bodyColor As Color
    Private _borderColor As Color
    Private _headerTextColor As Color
    Private _headerTextHighlightColor As Color
    Private _bodyTextColor As Color
    Private _headerFont As Font
    Private _bodyFont As Font
    Private _chevronUp As Bitmap
    Private _chevronUpHighlight As Bitmap
    Private _chevronDown As Bitmap
    Private _chevronDownHighlight As Bitmap

#Region "Public Properties"
    Public Property LeftHeaderColor() As Color
        Get
            Return _leftHeaderColor
        End Get
        Set(ByVal Value As Color)
            _leftHeaderColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("LeftHeaderColor"))
        End Set
    End Property

    Public Property RightHeaderColor() As Color
        Get
            Return _rightHeaderColor
        End Get
        Set(ByVal Value As Color)
            _rightHeaderColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("RightHeaderColor"))
        End Set
    End Property

    Public Property BodyColor() As Color
        Get
            Return _bodyColor
        End Get
        Set(ByVal Value As Color)
            _bodyColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BodyColor"))
        End Set
    End Property

    Public Property BorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal Value As Color)
            _borderColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BorderColor"))
        End Set
    End Property

    Public Property HeaderTextColor() As Color
        Get
            Return _headerTextColor
        End Get
        Set(ByVal Value As Color)
            _headerTextColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextColor"))
        End Set
    End Property

    Public Property HeaderTextHighlightColor() As Color
        Get
            Return _headerTextHighlightColor
        End Get
        Set(ByVal Value As Color)
            _headerTextHighlightColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextHighlightColor"))
        End Set
    End Property

    Public Property BodyTextColor() As Color
        Get
            Return _bodyTextColor
        End Get
        Set(ByVal Value As Color)
            _bodyTextColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BodyTextColor"))
        End Set
    End Property

    Public Property HeaderFont() As Font
        Get
            Return _headerFont
        End Get
        Set(ByVal Value As Font)
            _headerFont = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderFont"))
        End Set
    End Property

    Public Property BodyFont() As Font
        Get
            Return _bodyFont
        End Get
        Set(ByVal Value As Font)
            _bodyFont = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BodyFont"))
        End Set
    End Property

    Public Property ChevronUp() As Bitmap
        Get
            Return _chevronUp
        End Get
        Set(ByVal Value As Bitmap)
            _chevronUp = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("ChevronUp"))
        End Set
    End Property

    Public Property ChevronUpHighlight() As Bitmap
        Get
            Return _chevronUpHighlight
        End Get
        Set(ByVal Value As Bitmap)
            _chevronUpHighlight = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("ChevronUpHighlight"))
        End Set
    End Property

    Public Property ChevronDown() As Bitmap
        Get
            Return _chevronDown
        End Get
        Set(ByVal Value As Bitmap)
            _chevronDown = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("ChevronDown"))
        End Set
    End Property

    Public Property ChevronDownHighlight() As Bitmap
        Get
            Return _chevronDownHighlight
        End Get
        Set(ByVal Value As Bitmap)
            _chevronDownHighlight = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("ChevronDownHighlight"))
        End Set
    End Property
#End Region

#Region "constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal lHdrCol As Color, _
        ByVal rHdrCol As Color, _
        ByVal bodyCol As Color, _
        ByVal borderCol As Color, _
        ByVal hdrTxtCol As Color, _
        ByVal hdrTxtOverCol As Color, _
        ByVal bodyTxtCol As Color, _
        ByVal hdrFnt As Font, _
        ByVal bodyFnt As Font, _
        ByVal chevUp As Bitmap, _
        ByVal chevUpOver As Bitmap, _
        ByVal chevDown As Bitmap, _
        ByVal chevDownOver As Bitmap)

        _leftHeaderColor = lHdrCol
        _rightHeaderColor = rHdrCol
        _bodyColor = bodyCol
        _borderColor = borderCol
        _headerTextColor = hdrTxtCol
        _headerTextHighlightColor = hdrTxtOverCol
        _bodyTextColor = bodyTxtCol
        _headerFont = hdrFnt
        _bodyFont = bodyFnt
        _chevronUp = chevUp
        _chevronUpHighlight = chevUpOver
        _chevronDown = chevDown
        _chevronDownHighlight = chevDownOver
    End Sub
#End Region

    Overrides Function ToString() As String
        Return "TaskBoxFormat"
    End Function
End Class

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.TaskPanelFormat
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class holds all format information for the xpTaskPanel
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	18.08.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public Class TaskPanelFormat
    Inherits ThemeFormatBase

    Private _topColor As Color
    Private _bottomColor As Color

#Region "public properties"
    Public Property TopColor() As Color
        Get
            Return _topColor
        End Get
        Set(ByVal Value As Color)
            _topColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("TopColor"))
        End Set
    End Property

    Public Property BottomColor() As Color
        Get
            Return _bottomColor
        End Get
        Set(ByVal Value As Color)
            _bottomColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BottomColor"))
        End Set
    End Property
#End Region

#Region "constructors"
    Sub New()

    End Sub

    Public Sub New(ByVal topCol As Color, ByVal bottomCol As Color)
        _topColor = topCol
        _bottomColor = bottomCol
    End Sub
#End Region

    Overrides Function ToString() As String
        Return "TaskPanelFormat"
    End Function
End Class

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.SoftBarrierFormat
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this clas holds all information for the xpSoftBarrier
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	18.08.2004	Created
''' </history>
''' ''' -----------------------------------------------------------------------------
<Serializable()> Public Class SoftBarrierFormat
    Inherits ThemeFormatBase

    Private _headerHeight As Integer
    Private _headerTextColor As Color
    Private _headerTextFont As Font
    Private _leftHeaderColor As Color
    Private _rightHeaderColor As Color
    Private _topBodyColor As Color
    Private _bottomBodyColor As Color

#Region "public properties"
    Public Property HeaderHeight() As Integer
        Get
            Return _headerHeight
        End Get
        Set(ByVal Value As Integer)
            _headerHeight = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderHeight"))
        End Set
    End Property

    Public Property HeaderTextColor() As Color
        Get
            Return _headerTextColor
        End Get
        Set(ByVal Value As Color)
            _headerTextColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextColor"))
        End Set
    End Property

    Public Property HeaderTextFont() As Font
        Get
            Return _headerTextFont
        End Get
        Set(ByVal Value As Font)
            _headerTextFont = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextFont"))
        End Set
    End Property

    Public Property LeftHeaderColor() As Color
        Get
            Return _leftHeaderColor
        End Get
        Set(ByVal Value As Color)
            _leftHeaderColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("LeftHeaderColor"))
        End Set
    End Property

    Public Property RightHeaderColor() As Color
        Get
            Return _rightHeaderColor
        End Get
        Set(ByVal Value As Color)
            _rightHeaderColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("RightHeaderColor"))
        End Set
    End Property

    Public Property TopBodyColor() As Color
        Get
            Return _topBodyColor
        End Get
        Set(ByVal Value As Color)
            _topBodyColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("TopBodyColor"))
        End Set
    End Property

    Public Property BottomBodyColor() As Color
        Get
            Return _bottomBodyColor
        End Get
        Set(ByVal Value As Color)
            _bottomBodyColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BottomBodyColor"))
        End Set
    End Property
#End Region

#Region "constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal lHdrCol As Color, _
        ByVal rHdrCol As Color, _
        ByVal topBodyCol As Color, _
        ByVal bottomBodyCol As Color, _
        ByVal hdrTxtCol As Color, _
        ByVal hdrTxtFnt As Font, _
        ByVal hdrHeight As Integer)

        _leftHeaderColor = lHdrCol
        _rightHeaderColor = rHdrCol
        _topBodyColor = topBodyCol
        _bottomBodyColor = bottomBodyCol
        _headerTextColor = hdrTxtCol
        _headerTextFont = hdrTxtFnt
        _headerHeight = hdrHeight
    End Sub
#End Region

    Overrides Function ToString() As String
        Return "SoftBarrierFormat"
    End Function
End Class

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.LetterBoxFormat
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class holds all format information for the letterbox format
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	18.08.2004	Created
''' </history>
''' ''' -----------------------------------------------------------------------------
<Serializable()> Public Class LetterBoxFormat
    Inherits ThemeFormatBase

    Private _headerTextColor As Color
    Private _headerTextFont As Font
    Private _headerColor As Color
    Private _footerColor As Color
    Private _topBodyColor As Color
    Private _bottomBodyColor As Color

#Region "public properties"
    Public Property HeaderTextColor() As Color
        Get
            Return _headerTextColor
        End Get
        Set(ByVal Value As Color)
            _headerTextColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextColor"))
        End Set
    End Property

    Public Property HeaderTextFont() As Font
        Get
            Return _headerTextFont
        End Get
        Set(ByVal Value As Font)
            _headerTextFont = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderTextFont"))
        End Set
    End Property

    Public Property HeaderColor() As Color
        Get
            Return _headerColor
        End Get
        Set(ByVal Value As Color)
            _headerColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("HeaderColor"))
        End Set
    End Property

    Public Property FooterColor() As Color
        Get
            Return _footerColor
        End Get
        Set(ByVal Value As Color)
            _footerColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("FooterColor"))
        End Set
    End Property

    Public Property TopBodyColor() As Color
        Get
            Return _topBodyColor
        End Get
        Set(ByVal Value As Color)
            _topBodyColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("TopBodyColor"))
        End Set
    End Property

    Public Property BottomBodyColor() As Color
        Get
            Return _bottomBodyColor
        End Get
        Set(ByVal Value As Color)
            _bottomBodyColor = Value
            Me.OnPropertyChanged(New PropertyChangedEventArgs("BottomBodyColor"))
        End Set
    End Property
#End Region

#Region "constructors"
    Public Sub New()

    End Sub

    Public Sub New(ByVal hdrCol As Color, _
        ByVal ftrCol As Color, _
        ByVal topBodyCol As Color, _
        ByVal bottomBodyCol As Color, _
        ByVal hdrTxtCol As Color, _
        ByVal hdrTxtFnt As Font)

        _headerTextColor = hdrTxtCol
        _headerTextFont = hdrTxtFnt
        _headerColor = hdrCol
        _footerColor = ftrCol
        _topBodyColor = topBodyCol
        _bottomBodyColor = bottomBodyCol
    End Sub
#End Region

    Overrides Function ToString() As String
        Return "LetterBoxFormat"
    End Function
End Class
