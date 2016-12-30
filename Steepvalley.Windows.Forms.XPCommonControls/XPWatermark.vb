Imports System.Drawing.Imaging
Imports System.ComponentModel

Public Class XPWatermark
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
        'kbline
        '
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.Name = "XPWatermark"
        Me.Size = New System.Drawing.Size(100, 100)

    End Sub

#End Region

    Private _image As Image = Nothing
    Private _desaturate As Boolean = False
    Private _opacity As Single = 0.2
    Private _gamma As Single = 1.0
    Private _transparentColor As New ColorRange

#Region "public properties"

    <Description("the watermark image"), _
    Category("Appearance"), _
    Browsable(True), _
    Localizable(True), _
    DefaultValue(GetType(Image), "")> _
    Public Property Image() As Image
        Get
            Return _image
        End Get
        Set(ByVal Value As Image)
            _image = Value
            Me.Invalidate()
        End Set
    End Property

    <Description("the opacity of the image (between 0 and 1)"), _
    Category("Appearance"), _
    Browsable(True), _
    Localizable(True), _
    DefaultValue(0.2)> _
    Public Property Opacity() As Single
        Get
            Return _opacity
        End Get
        Set(ByVal Value As Single)
            If Value < 0 Then
                _opacity = 0
            ElseIf Value > 1 Then
                _opacity = 1
            Else
                _opacity = Value
            End If
            Me.Invalidate()
        End Set
    End Property

    <Description("the gamma value of the image"), _
    Category("Appearance"), _
    Browsable(True), _
    Localizable(True), _
    DefaultValue(1)> _
    Public Property Gamma() As Single
        Get
            Return _gamma
        End Get
        Set(ByVal Value As Single)
            _gamma = Value
            Me.Invalidate()
        End Set
    End Property

    <Description("desaturate (grayscale) the image"), _
    Category("Appearance"), _
    Browsable(True), _
    Localizable(True), _
    DefaultValue(False)> _
    Public Property Desaturate() As Boolean
        Get
            Return _desaturate
        End Get
        Set(ByVal Value As Boolean)
            _desaturate = Value
            Me.Invalidate()
        End Set
    End Property

    <Description("the range for the transparent color(s) in the image"), _
    Category("Appearance"), _
    Localizable(True), _
    Browsable(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
    TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Property TransparentColor() As ColorRange
        Get
            Return _transparentColor
        End Get
        Set(ByVal Value As ColorRange)
            _transparentColor = Value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "custom painting"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        If Not _image Is Nothing Then

            Dim lrectWatermark As Rectangle = Helpers.CheckedRectangle(0, 0, Me.Width, Me.Height)

            Dim clrMatrix As ColorMatrix = New ColorMatrix
            clrMatrix.Matrix33 = _opacity
            clrMatrix.Matrix44 = 1

            If _desaturate Then
                clrMatrix.Matrix00 = 1 / 3.0F
                clrMatrix.Matrix01 = 1 / 3.0F
                clrMatrix.Matrix02 = 1 / 3.0F
                clrMatrix.Matrix10 = 1 / 3.0F
                clrMatrix.Matrix11 = 1 / 3.0F
                clrMatrix.Matrix12 = 1 / 3.0F
                clrMatrix.Matrix20 = 1 / 3.0F
                clrMatrix.Matrix21 = 1 / 3.0F
                clrMatrix.Matrix22 = 1 / 3.0F
            End If

            Dim imgAttributes As ImageAttributes = New ImageAttributes
            imgAttributes.SetColorMatrix(clrMatrix, _
                   ColorMatrixFlag.Default, _
                   ColorAdjustType.Bitmap)

            imgAttributes.SetGamma(_gamma, ColorAdjustType.Bitmap)

            imgAttributes.SetColorKey(_transparentColor.Low, _transparentColor.High, ColorAdjustType.Bitmap)

            e.Graphics.DrawImage(_image, _
                        lrectWatermark, _
                        0, 0, _
                        _image.Width, _
                        _image.Height, _
                        GraphicsUnit.Pixel, imgAttributes)

            lrectWatermark = Nothing
            clrMatrix = Nothing
            imgAttributes.Dispose()
        End If

        MyBase.OnPaint(e)
    End Sub
#End Region
End Class

Public Class ColorRange
    Private _high As Color = Nothing
    Private _low As Color = Nothing

    Public Property Low() As Color
        Get
            Return _low
        End Get
        Set(ByVal Value As Color)
            _low = Value
        End Set
    End Property

    Public Property High() As Color
        Get
            Return _high
        End Get
        Set(ByVal Value As Color)
            _high = Value
        End Set
    End Property

    Public Sub New()
    End Sub

    Public Sub New(ByVal low As Color, ByVal high As Color)
        _low = low
        _high = high
    End Sub


    Public Shadows Function ToString() As String
        Return String.Format("{0}, {1}", _low, _high)
    End Function
End Class

