''' <summary>
    ''' the control is painted with the specified themeing and hosts any taskbox or
    ''' any other control
    ''' </summary>
    ''' <remarks></remarks>
Public Class XPTaskPanel
    Inherits System.Windows.Forms.Panel
    Implements IThemed

    Private mTheme As ThemeStyle = ThemeStyle.NormalColor
    Private mThemeFormat As TaskPanelFormat = Theming.GetTaskPanelTheme(mTheme)

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ContainerControl, True)

        MyBase.BackColor = Color.Transparent
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
        'TaskPanel
        '
        Me.AutoScroll = True
        Me.DockPadding.Bottom = 8
        Me.DockPadding.Left = 8
        Me.DockPadding.Right = 8

    End Sub

#End Region

#Region "public properties"
    <Description("Sets the theming of the control"), _
     Category("Appearance"), _
     Browsable(True), _
     DefaultValue(GetType(ThemeStyle), "NormalColor")> _
    Public Property Theme() As ThemeStyle Implements IThemed.Theme
        Get
            Return mTheme
        End Get
        Set(ByVal value As ThemeStyle)
            mTheme = value
            mThemeFormat = Theming.GetTaskPanelTheme(mTheme)
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The Theming Info of this control
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	18.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("The Theming Info of this control"), _
     Category("Appearance"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Content), _
     TypeConverter(GetType(ExpandableObjectConverter))> _
    Public Property ThemeFormat() As TaskPanelFormat
        Get
            Return mThemeFormat
        End Get
        Set(ByVal Value As TaskPanelFormat)
            mThemeFormat = Value
            Me.Invalidate()
        End Set
    End Property

#End Region

#Region "overriden methods"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Dim lrectCtrl As Rectangle = Helpers.CheckedRectangle(0, 0, Me.Width, Me.Height)
        Dim lbrushBackground As New LinearGradientBrush(lrectCtrl, mThemeFormat.TopColor, mThemeFormat.BottomColor, LinearGradientMode.Vertical)

        e.Graphics.FillRectangle(lbrushBackground, lrectCtrl)

        lbrushBackground.Dispose()

        MyBase.OnPaint(e)
    End Sub
#End Region
End Class

