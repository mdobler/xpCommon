Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class XPLabel
    Inherits System.Windows.Forms.UserControl

#Region " Vom Windows Form Designer generierter Code "

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

        Me.BackColor = Color.Transparent
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
        '
        'XPLabel
        '
        Me.Name = "XPLabel"
        Me.Size = New System.Drawing.Size(150, 24)

    End Sub

#End Region

    Private _stringTrimming As StringTrimming = StringTrimming.EllipsisCharacter
    Private _textAlign As ContentAlignment = ContentAlignment.TopLeft
    Private _antiAlias As Boolean = True
    Private _text As String
    Private _drawShadow As Boolean = False
    Private _shadowOffset As New Point(1, 1)
    Private _shadowColor As Color = Color.DarkGray
    Private _shadowTransparency As Integer = 128
    Private _textAngle As Integer = 0

#Region "Shadow Properties"
    <Browsable(True), _
     Description("lets you draw a drop shadow"), _
     Category("Shadow"), _
     DefaultValue(False)> _
     Public Property DrawShadow() As Boolean
        Get
            Return _drawShadow
        End Get
        Set(ByVal value As Boolean)
            _drawShadow = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets shadow's color"), _
     Category("Shadow"), _
     DefaultValue(GetType(Color), "DarkGray")> _
    Public Property ShadowColor() As Color
        Get
            Return _shadowColor
        End Get
        Set(ByVal value As Color)
            _shadowColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets the shadow offset"), _
     Category("Shadow"), _
     DefaultValue(GetType(Point), "1,1")> _
     Public Property ShadowOffset() As Point
        Get
            Return _shadowOffset
        End Get
        Set(ByVal value As Point)
            _shadowOffset = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets alpha value (transparency) of the shadow"), _
     Category("Shadow"), _
     DefaultValue(128)> _
    Public Property ShadowTransparency() As Integer
        Get
            Return _shadowTransparency
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                _shadowTransparency = 0
            ElseIf value > 255 Then
                _shadowTransparency = 255
            Else
                _shadowTransparency = value
            End If
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Public Properties"
    <Browsable(True), _
     Description("sets or gets the alignment of the label text"), _
     Category("Appearance"), _
     DefaultValue(GetType(ContentAlignment), "TopLeft")> _
    Public Property TextAlign() As ContentAlignment
        Get
            Return _textAlign
        End Get
        Set(ByVal Value As ContentAlignment)
            _textAlign = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets the trimming of the label text, if the text won't fit"), _
     Category("Appearance"), _
     DefaultValue(GetType(StringTrimming), "EllipsisCharacter")> _
    Public Property StringTrimming() As StringTrimming
        Get
            Return _stringTrimming
        End Get
        Set(ByVal Value As StringTrimming)
            _stringTrimming = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets the anti-aliasing setting"), _
     Category("Appearance"), _
     DefaultValue(True)> _
    Public Property AntiAlias() As Boolean
        Get
            Return _antiAlias
        End Get
        Set(ByVal Value As Boolean)
            _antiAlias = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets the displayed label text"), _
     Category("Appearance"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     DefaultValue("XPLabel")> _
    Public Overrides Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal Value As String)
            _text = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets drawing angle of the text"), _
     Category("Appearance"), _
     DefaultValue(0)> _
    Public Property TextAngle() As Integer
        Get
            Return _textAngle
        End Get
        Set(ByVal value As Integer)
            If value < -360 Then
                _textAngle = 0
            ElseIf value > 360 Then
                _textAngle = 360
            Else
                _textAngle = value
            End If
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Custom Drawing"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim _format As New System.Drawing.StringFormat
        _format.Trimming = _stringTrimming
        _format.FormatFlags = StringFormatFlags.LineLimit

        Select Case _textAlign
            Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                _format.LineAlignment = StringAlignment.Near
            Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                _format.LineAlignment = StringAlignment.Center
            Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                _format.LineAlignment = StringAlignment.Far
        End Select

        Select Case _textAlign
            Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                _format.Alignment = StringAlignment.Near
            Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                _format.Alignment = StringAlignment.Center
            Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                _format.Alignment = StringAlignment.Far
        End Select

        'Dim _textFit As SizeF = e.Graphics.MeasureString(Me.Text, Me.Font)

        'anti aliasing
        If _antiAlias = True Then e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality


        'draw text in angle
        If _textAngle <> 0 Then
            Dim _mx As New Matrix
            _mx.RotateAt(_textAngle, New PointF(CSng(Me.ClientSize.Height / 2), CSng(Me.ClientSize.Width / 2)))
            e.Graphics.Transform = _mx
            _mx.Dispose()
        End If

        'drop shadow
        If Me.DrawShadow Then
            e.Graphics.DrawString(_text, Me.Font, _
                        New SolidBrush(Color.FromArgb(Me.ShadowTransparency, Me.ShadowColor)), _
                        Helpers.CheckedRectangleF( _
                            2 + Me.ShadowOffset.X, _
                            2 + Me.ShadowOffset.Y, _
                            Me.Width - 4 + Me.ShadowOffset.X, _
                            Me.Height - 4 + Me.ShadowOffset.Y), _format)
        End If

        'label text
        e.Graphics.DrawString(_text, Me.Font, New SolidBrush(Me.ForeColor), Helpers.CheckedRectangleF(2, 2, Me.Width - 4, Me.Height - 4), _format)



        _format.Dispose()

        MyBase.OnPaint(e)
    End Sub
#End Region
End Class
