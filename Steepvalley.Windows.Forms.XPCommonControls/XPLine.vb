Imports System.ComponentModel
Imports SteepValley.Windows.Forms.Design

Namespace Graphics

    ''' -----------------------------------------------------------------------------
    ''' Project	 : XPCommonControls
    ''' Class	 : XPCommonControls.XPLine
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' a very simple, still missing control.
    ''' <para>Now supports transparent backgrounds</para>
    ''' </summary>
    ''' <remarks>
    ''' this control draws a vertical, horizontal or diagonal line into the 
    ''' control's area. It can be either flat or edged.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    '''     [Mike]  08.08.2004  Added support for transparent background
    ''' </history>
    ''' -----------------------------------------------------------------------------
    ''' 
    <Designer(GetType(XPLineDesigner)), DesignTimeVisibleAttribute(True)> _
    Public Class XPLine
        Inherits System.Windows.Forms.UserControl

        Private mOrientation As Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.Horizontal
        Private mAppearance As LineStyle = LineStyle.Edged
        Private mLineColor As Color = SystemColors.ControlDark
        Private mLineWidth As Integer = 1
        Private mShadowColor As Color = SystemColors.ControlLight
        Private mShadowOffsetX As Integer = 1
        Private mShadowOffsetY As Integer = 1

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
            Me.Name = "XPLine"
            Me.Size = New System.Drawing.Size(100, 100)

        End Sub

#End Region

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The orientation of the line
        ''' </summary>
        ''' <value>LinearGradientMode</value>
        ''' <remarks>
        ''' you can choose between Horizontal, Vertical, ForwardDiagonal and BackwardDiagonal.
        ''' this sets the direction of the line inside the bounding box.
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	13.03.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("The orientation of the line"), _
         Category("Appearance"), _
         Browsable(True), _
         DefaultValue(GetType(Drawing2D.LinearGradientMode), "Horizontal")> _
        Public Property Orientation() As Drawing2D.LinearGradientMode
            Get
                Return mOrientation
            End Get
            Set(ByVal value As Drawing2D.LinearGradientMode)
                mOrientation = value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' The Style of the Line (Edged or Flat)
        ''' </summary>
        ''' <value>LineStyle</value>
        ''' <remarks>
        ''' draws the line in a flat (single pixel) or edged (shadow) mode. It uses
        ''' the controls forecolor as line color
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	13.03.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("The Style of the Line (Edged or Flat)"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(LineStyle), "Edged")> _
        Public Property Appearance() As LineStyle
            Get
                Return mAppearance
            End Get
            Set(ByVal value As LineStyle)
                mAppearance = value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' the line color. this is the color, the line is drawn with
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	11.09.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("The Color of the Line"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(Color), "ControlDark")> _
        Public Property LineColor() As Color
            Get
                Return mLineColor
            End Get
            Set(ByVal Value As Color)
                mLineColor = Value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' the shadow colro of the line
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	11.09.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("The Color of the shadow (in Edged Mode"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(Color), "ControlLight")> _
        Public Property ShadowColor() As Color
            Get
                Return mShadowColor
            End Get
            Set(ByVal Value As Color)
                mShadowColor = Value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' the width of the line
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	11.09.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("the width of the line"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(1)> _
        Public Property LineWidth() As Integer
            Get
                Return mLineWidth
            End Get
            Set(ByVal Value As Integer)
                mLineWidth = Value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' the offset for the shadow (in edged mode only)
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	11.09.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("the x-offset (horizontal) of the shadow line"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(1)> _
        Public Property ShadowOffsetX() As Integer
            Get
                Return mShadowOffsetX
            End Get
            Set(ByVal Value As Integer)
                mShadowOffsetX = Value
                Me.Invalidate()
            End Set
        End Property

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' the offset for the shadow (in edged mode only)
        ''' </summary>
        ''' <value></value>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	11.09.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        <Description("the y-offset (vertical) of the shadow line"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(1)> _
        Public Property ShadowOffsetY() As Integer
            Get
                Return mShadowOffsetY
            End Get
            Set(ByVal Value As Integer)
                mShadowOffsetY = Value
                Me.Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim ptTopLeftDark As PointF
            Dim ptBottomRightDark As PointF
            Dim ptTopLeftLight As PointF
            Dim ptBottomRightLight As PointF

            e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality

            Me.SuspendLayout()
            Select Case mOrientation
                Case Drawing2D.LinearGradientMode.Vertical
                    ptTopLeftDark = New PointF(CInt(Me.Width / 2), Me.DockPadding.Top)
                    ptBottomRightDark = New PointF(CInt(Me.Width / 2), Me.Height - Me.DockPadding.Bottom)
                Case Drawing2D.LinearGradientMode.Horizontal
                    ptTopLeftDark = New PointF(Me.DockPadding.Left, CInt(Me.Height / 2))
                    ptBottomRightDark = New PointF(Me.Width - Me.DockPadding.Right, CInt(Me.Height / 2))
                Case Drawing2D.LinearGradientMode.ForwardDiagonal
                    ptTopLeftDark = New PointF(Me.DockPadding.Left, Me.DockPadding.Top)
                    ptBottomRightDark = New PointF(Me.Width - Me.DockPadding.Right, Me.Height - Me.DockPadding.Bottom)
                Case Drawing2D.LinearGradientMode.BackwardDiagonal
                    ptTopLeftDark = New PointF(Me.DockPadding.Left, Me.Height - Me.DockPadding.Bottom)
                    ptBottomRightDark = New PointF(Me.Width - Me.DockPadding.Right, Me.DockPadding.Top)
            End Select
            ptTopLeftLight = New PointF(ptTopLeftDark.X + mShadowOffsetX, ptTopLeftDark.Y + mShadowOffsetY)
            ptBottomRightLight = New PointF(ptBottomRightDark.X + mShadowOffsetX, ptBottomRightDark.Y + mShadowOffsetY)


            If mAppearance = LineStyle.Edged Then
                e.Graphics.DrawLine(New Pen(Me.mShadowColor, mLineWidth), ptTopLeftLight, ptBottomRightLight)
            End If
            e.Graphics.DrawLine(New Pen(Me.mLineColor, mLineWidth), ptTopLeftDark, ptBottomRightDark)

            Me.ResumeLayout(True)

            MyBase.OnPaint(e)
        End Sub

        Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
            MyBase.OnResize(e)
            Me.Invalidate()
        End Sub

        Public Enum LineStyle
            Flat
            Edged
        End Enum
    End Class

End Namespace