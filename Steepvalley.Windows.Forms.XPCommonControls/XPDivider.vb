Imports System.ComponentModel

Public Enum Direction
    Vertical
    Horizontal
End Enum

Public Class XPDivider
    Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()
        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()
        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.DoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.SupportsTransparentBackColor, True)
    End Sub

    'UserControl überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub
#End Region

#Region "declarations"
    Private _direction As Direction = Direction.Vertical
    Private _pointcolor As Color = Color.DarkGray
    Private _shadowcolor As Color = Color.White
    Private _pointSize As Size = New Size(3, 3)
    Private _shadowSize As Size = New Size(5, 5)
    Private _spacingSize As Size = New Size(2, 2)
    Private _margin As Size = New Size(5, 5)
    Private _brushPoint As New SolidBrush(_pointcolor)
    Private _brushShadow As New SolidBrush(_shadowcolor)


#End Region

#Region "public properties"
    <Browsable(True), _
     Description("the direction of the divider"), _
     Category("Layout"), _
     DefaultValue(GetType(Direction), "Vertical")> _
    Public Property Direction() As Direction
        Get
            Return _direction
        End Get

        Set(ByVal Value As Direction)
            _direction = Value
            Me.Invalidate()
        End Set

    End Property

    <Browsable(True), _
     Description("the color of the divider line"), _
     Category("Layout"), _
     DefaultValue(GetType(Color), "DarkGray")> _
    Public Property LineColor() As Color
        Get
            Return _pointcolor
        End Get

        Set(ByVal Value As Color)
            _pointcolor = Value
            _brushPoint = New SolidBrush(_pointcolor)
            Me.Invalidate()
        End Set

    End Property

    <Browsable(True), _
     Description("the shadow color"), _
     Category("Layout"), _
     DefaultValue(GetType(Color), "White")> _
    Public Property ShadowColor() As Color
        Get
            Return _shadowcolor
        End Get

        Set(ByVal Value As Color)
            _shadowcolor = Value
            _brushShadow = New SolidBrush(_shadowcolor)
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("the size of the divider points"), _
     Category("Layout"), _
     DefaultValue(GetType(Size), "3;3")> _
    Public Property PointSize() As Size
        Get
            Return _pointSize
        End Get

        Set(ByVal Value As Size)
            _pointSize = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("the size of the point shadow"), _
     Category("Layout"), _
     DefaultValue(GetType(Size), "5;5")> _
    Public Property ShadowSize() As Size
        Get
            Return _shadowSize
        End Get

        Set(ByVal Value As Size)
            _shadowSize = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("the size of spacing between the points"), _
     Category("Layout"), _
     DefaultValue(GetType(Size), "2;2")> _
    Public Property SpacingSize() As Size
        Get
            Return _spacingSize
        End Get

        Set(ByVal Value As Size)
            _spacingSize = Value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "painting"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim _x As Integer = _margin.Width
        Dim _y As Integer = _margin.Height
        Select Case _direction
            Case Direction.Horizontal
                _y = CInt((Me.Height - _shadowSize.Height) / 2)
                While _x + _pointSize.Width + _margin.Width <= Me.Width
                    e.Graphics.FillRectangle(_brushShadow, Helpers.CheckedRectangle(_x, _y, _shadowSize.Width, _shadowSize.Height))
                    e.Graphics.FillRectangle(_brushPoint, Helpers.CheckedRectangle(_x, _y, _pointSize.Width, _pointSize.Height))
                    _x += _pointSize.Width + _spacingSize.Width
                End While
            Case Direction.Vertical
                _x = CInt((Me.Width - _shadowSize.Width) / 2)
                While _y + _pointSize.Height + _margin.Height <= Me.Height
                    e.Graphics.FillRectangle(_brushShadow, Helpers.CheckedRectangle(_x, _y, _shadowSize.Width, _shadowSize.Height))
                    e.Graphics.FillRectangle(_brushPoint, Helpers.CheckedRectangle(_x, _y, _pointSize.Width, _pointSize.Height))
                    _y += _pointSize.Height + _spacingSize.Height
                End While
        End Select

        MyBase.OnPaint(e)
    End Sub
#End Region
End Class
