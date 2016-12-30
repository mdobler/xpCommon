' Custom control that draws the caption for each pane. Contains an active 
' state and draws the caption different for each state. Caption is drawn
' with a gradient fill and antialias font.

Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Graphics

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.PaneCaption
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class was copied from the FotoVision sample application on www.windowsforms.net
''' http://msdn.microsoft.com/smartclient/codesamples/FotoVision/default.aspx?pull=/library/en-us/dnnetcomp/html/fotovisiondesktop.asp
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	10.08.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class XPCaption
    Inherits System.Windows.Forms.UserControl

    ' const values
    Private Class Consts
        Public Const DefaultHeight As Integer = 20
        Public Const DefaultFontName As String = "arial"
        Public Const DefaultFontSize As Integer = 9
        Public Const PosOffset As Integer = 4
    End Class

    ' internal members
    Private _active As Boolean = False
    Private _antiAlias As Boolean = True
    Private _allowActive As Boolean = True

    Private _colorActiveText As Color = Color.Black
    Private _colorInactiveText As Color = Color.White

    Private _colorActiveLow As Color = Color.FromArgb(255, 165, 78)
    Private _colorActiveHigh As Color = Color.FromArgb(255, 225, 155)
    Private _colorInactiveLow As Color = Color.FromArgb(3, 55, 145)
    Private _colorInactiveHigh As Color = Color.FromArgb(90, 135, 215)

    ' gdi objects
    Private _brushActiveText As SolidBrush
    Private _brushInactiveText As SolidBrush
    Private _brushActive As LinearGradientBrush
    Private _brushInactive As LinearGradientBrush
    Private _format As StringFormat


    ' public properties

    ' the caption of the control
    <Category("Appearance"), Browsable(True), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Description("Text that is displayed in the label.")> _
    Public Shadows Property Text() As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal Value As String)
            MyBase.Text = Value
            Invalidate()
        End Set
    End Property

    ' if the caption is active or not
    <Description("The active state of the caption, draws the caption with different gradient colors."), _
    Category("Appearance"), DefaultValue(False)> _
    Public Property Active() As Boolean
        Get
            Return _active
        End Get
        Set(ByVal value As Boolean)
            _active = value
            Invalidate()
        End Set
    End Property

    ' if should maintain an active and inactive state
    <Description("True always uses the inactive state colors, false maintains an active and inactive state."), _
    Category("Appearance"), DefaultValue(True)> _
    Public Property AllowActive() As Boolean
        Get
            Return _allowActive
        End Get
        Set(ByVal value As Boolean)
            _allowActive = value
            Invalidate()
        End Set
    End Property

    ' if the caption is active or not
    <Description("If should draw the text as antialiased."), _
     Category("Appearance"), DefaultValue(True)> _
    Public Property AntiAlias() As Boolean
        Get
            Return _antiAlias
        End Get
        Set(ByVal value As Boolean)
            _antiAlias = value
            Invalidate()
        End Set
    End Property

#Region " color properties "

    <Description("Color of the text when active."), _
    Category("Appearance"), DefaultValue(GetType(Color), "Black")> _
    Public Property ActiveTextColor() As Color
        Get
            Return _colorActiveText
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.Black
            _colorActiveText = Value
            _brushActiveText = New SolidBrush(_colorActiveText)
            Invalidate()
        End Set
    End Property

    <Description("Color of the text when inactive."), _
    Category("Appearance"), DefaultValue(GetType(Color), "White")> _
    Public Property InactiveTextColor() As Color
        Get
            Return _colorInactiveText
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.White
            _colorInactiveText = Value
            _brushInactiveText = New SolidBrush(_colorInactiveText)
            Invalidate()
        End Set
    End Property

    <Description("Low color of the active gradient."), _
    Category("Appearance"), DefaultValue(GetType(Color), "255, 165, 78")> _
    Public Property ActiveGradientLowColor() As Color
        Get
            Return _colorActiveLow
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.FromArgb(255, 165, 78)
            _colorActiveLow = Value
            CreateGradientBrushes()
            Invalidate()
        End Set
    End Property

    <Description("High color of the active gradient."), _
    Category("Appearance"), DefaultValue(GetType(Color), "255, 225, 155")> _
    Public Property ActiveGradientHighColor() As Color
        Get
            Return _colorActiveHigh
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.FromArgb(255, 225, 155)
            _colorActiveHigh = Value
            CreateGradientBrushes()
            Invalidate()
        End Set
    End Property

    <Description("Low color of the inactive gradient."), _
      Category("Appearance"), DefaultValue(GetType(Color), "3, 55, 145")> _
      Public Property InactiveGradientLowColor() As Color
        Get
            Return _colorInactiveLow
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.FromArgb(3, 55, 145)
            _colorInactiveLow = Value
            CreateGradientBrushes()
            Invalidate()
        End Set
    End Property

    <Description("High color of the inactive gradient."), _
      Category("Appearance"), DefaultValue(GetType(Color), "90, 135, 215")> _
      Public Property InactiveGradientHighColor() As Color
        Get
            Return _colorInactiveHigh
        End Get
        Set(ByVal Value As Color)
            If Value.Equals(Color.Empty) Then Value = Color.FromArgb(90, 135, 215)
            _colorInactiveHigh = Value
            CreateGradientBrushes()
            Invalidate()
        End Set
    End Property

#End Region

    ' internal properties

    ' brush used to draw the caption
    Private ReadOnly Property TextBrush() As SolidBrush
        Get
            Return DirectCast(IIf(_active AndAlso _allowActive, _
             _brushActiveText, _brushInactiveText), SolidBrush)
        End Get
    End Property

    ' gradient brush for the background
    Private ReadOnly Property BackBrush() As LinearGradientBrush
        Get
            Return DirectCast(IIf(_active AndAlso _allowActive, _
             _brushActive, _brushInactive), LinearGradientBrush)
        End Get
    End Property

    ' ctor
    Public Sub New()
        MyBase.New()

        ' this call is required by the Windows Form Designer
        InitializeComponent()

        ' set double buffer styles
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.UserPaint Or _
         ControlStyles.AllPaintingInWmPaint Or ControlStyles.ResizeRedraw, True)

        ' init the height
        Me.Height = Consts.DefaultHeight

        ' format used when drawing the text
        _format = New StringFormat
        _format.FormatFlags = StringFormatFlags.NoWrap
        _format.LineAlignment = StringAlignment.Center
        _format.Trimming = StringTrimming.EllipsisCharacter

        ' init the font
        Me.Font = New Font(Consts.DefaultFontName, Consts.DefaultFontSize, FontStyle.Bold)

        ' create gdi objects
        Me.ActiveTextColor = _colorActiveText
        Me.InactiveTextColor = _colorInactiveText

        ' setting the height above actually does this, but leave
        ' in incase change the code (and forget to init the 
        ' gradient brushes)
        CreateGradientBrushes()
    End Sub

    ' internal methods

    ' the caption needs to be drawn
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        DrawCaption(e.Graphics)
        MyBase.OnPaint(e)
    End Sub

    ' draw the caption
    Private Sub DrawCaption(ByVal g As Drawing.Graphics)
        ' background
        g.FillRectangle(Me.BackBrush, Me.DisplayRectangle)

        ' caption
        If _antiAlias Then
            g.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias
        End If

        ' need a rectangle when want to use ellipsis
        Dim bounds As RectangleF = Helpers.CheckedRectangleF(Consts.PosOffset, 0, _
         Me.DisplayRectangle.Width - Consts.PosOffset, Me.DisplayRectangle.Height)

        g.DrawString(Me.Text, Me.Font, Me.TextBrush, bounds, _format)
    End Sub

    ' clicking on the caption does not give focus,
    ' handle the mouse down event and set focus to self
    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If Me._allowActive Then Me.Focus()
    End Sub

    Protected Overrides Sub OnSizeChanged(ByVal e As System.EventArgs)
        MyBase.OnSizeChanged(e)

        ' create the gradient brushes based on the new size
        CreateGradientBrushes()
    End Sub

    Private Sub CreateGradientBrushes()
        ' can only create brushes when have a width and height
        If Me.Width > 0 AndAlso Me.Height > 0 Then
            If Not (_brushActive Is Nothing) Then _brushActive.Dispose()
            _brushActive = New LinearGradientBrush(Me.DisplayRectangle, _
             _colorActiveHigh, _colorActiveLow, LinearGradientMode.Vertical)

            If Not (_brushInactive Is Nothing) Then _brushInactive.Dispose()
            _brushInactive = New LinearGradientBrush(Me.DisplayRectangle, _
              _colorInactiveHigh, _colorInactiveLow, LinearGradientMode.Vertical)
        End If
    End Sub


#Region " Windows Form Designer generated code "

    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'PaneCaption
        '
        Me.Name = "PaneCaption"
        Me.Size = New System.Drawing.Size(150, 30)
    End Sub

#End Region

End Class
