''' <summary>
''' this control mimics the system control. It can display an icon and a header text
''' in the header of the control and can host any control inside its body
''' </summary>
''' <remarks></remarks>
<Designer(GetType(Design.XPSoftBarrierDesigner)), DesignTimeVisibleAttribute(True)> _
Public Class XPSoftBarrier
    Inherits System.Windows.Forms.UserControl
    Implements IThemed

    Private mstrHeaderText As String = ""
    Private m_Icon As Icon
    Private mTheme As ThemeStyle = ThemeStyle.NormalColor
    Private mThemeFormat As SoftBarrierFormat = Theming.GetSoftBarrierTheme(mTheme)
    Private mShowHeader As Boolean = True

#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist f�r den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzuf�gen
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ContainerControl, True)

        MyBase.BackColor = Color.Transparent
    End Sub

    'UserControl �berschreibt den L�schvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' F�r Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist f�r den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'XPSoftBarrier
        '
        Me.DockPadding.Top = 48
        Me.Name = "XPSoftBarrier"

    End Sub

#End Region

#Region " Public Properties "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the theming of the control
    ''' </summary>
    ''' <value>ThemeStyle</value>
    ''' <remarks>
    ''' use this property to set the Themestyle manually
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
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
            mThemeFormat = Theming.GetSoftBarrierTheme(mTheme)
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Caption text.
    ''' </summary>
    ''' <value>String</value>
    ''' <remarks>
    ''' the caption text that is displayed in the header area of the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Caption text."), _
    DefaultValue(""), _
    Category("Appearance"), _
    Localizable(True)> _
    Public Property HeaderText() As String
        Get
            Return mstrHeaderText
        End Get

        Set(ByVal value As String)
            mstrHeaderText = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Hides or Displays the header
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	18.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Hides or Displays the header"), _
    DefaultValue(""), _
    Category("Appearance"), _
    Localizable(True)> _
    Public Property ShowHeader() As Boolean
        Get
            Return mShowHeader
        End Get
        Set(ByVal Value As Boolean)
            mShowHeader = Value
            If mShowHeader Then
                Me.DockPadding.Top = mThemeFormat.HeaderHeight
            Else
                Me.DockPadding.Top = 0
            End If
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Icon to be displayed in the left top corner
    ''' </summary>
    ''' <value>icon</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Icon to be displayed in the left top corner"), _
     Category("Appearance"), _
     DefaultValue(GetType(Icon), "")> _
    Public Property Icon() As Icon
        Get
            Return m_Icon
        End Get

        Set(ByVal value As Icon)
            m_Icon = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the usable region as Rectangle
    ''' </summary>
    ''' <value>Rectangle</value>
    ''' <remarks>
    ''' this Property is used to check for the available Workspace.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("returns the usable region as RectangleF"), _
    Browsable(False)> _
    Friend ReadOnly Property WorkspaceRect() As Rectangle
        Get
            Dim mThemeFormat As SoftBarrierFormat = Theming.GetSoftBarrierTheme(mTheme)
            If mShowHeader Then
                Return Helpers.CheckedRectangle(0, mThemeFormat.HeaderHeight + 1, Me.Width - 1, Me.Height - mThemeFormat.HeaderHeight - 2)
            Else
                Return Helpers.CheckedRectangle(0, 0, Me.Width - 1, Me.Height - 1)
            End If

        End Get
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
    Public Property ThemeFormat() As SoftBarrierFormat
        Get
            Return mThemeFormat
        End Get
        Set(ByVal Value As SoftBarrierFormat)
            mThemeFormat = Value
            Me.Invalidate()
        End Set
    End Property

#End Region

#Region "custom drawing routines"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	11.03.2005	debugged
    '''         Always check if height or width of the drawing rectangles are not 0
    '''         This is done through a new function in the Helpers class...
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim rectHeader As RectangleF
        Dim rectText As RectangleF
        Dim brushHeader As LinearGradientBrush
        Dim rectBody As RectangleF
        Dim brushBody As LinearGradientBrush

        Dim stringFmt As New StringFormat
        stringFmt.Alignment = StringAlignment.Near
        stringFmt.LineAlignment = StringAlignment.Center
        stringFmt.Trimming = StringTrimming.EllipsisCharacter

        If mShowHeader Then
            rectHeader = Helpers.CheckedRectangleF(0, 0, Me.Width, mThemeFormat.HeaderHeight)
            brushHeader = New LinearGradientBrush(rectHeader, mThemeFormat.LeftHeaderColor, mThemeFormat.RightHeaderColor, LinearGradientMode.Horizontal)
            rectBody = Helpers.CheckedRectangleF(0, mThemeFormat.HeaderHeight, Me.Width, Me.Height - mThemeFormat.HeaderHeight)
            'zeichnen der titelleiste
            e.Graphics.FillRectangle(brushHeader, rectHeader)

            brushHeader.Dispose()
        Else
            rectBody = Helpers.CheckedRectangleF(0, 0, Me.Width, Me.Height)
        End If

        brushBody = New LinearGradientBrush(rectBody, mThemeFormat.TopBodyColor, mThemeFormat.BottomBodyColor, LinearGradientMode.ForwardDiagonal)

        'zeichnen des workspace-bereiches
        e.Graphics.FillRectangle(brushBody, rectBody)
        brushBody.Dispose()

        If mShowHeader Then
            'zeichnen des Icons
            If Not m_Icon Is Nothing Then
                e.Graphics.DrawIcon(New Icon(m_Icon, 48, 48), New Rectangle(10, 10, 48, 48))
                rectText = Helpers.CheckedRectangleF(68, 0, Me.Width - 78, mThemeFormat.HeaderHeight)
            Else
                rectText = Helpers.CheckedRectangleF(10, 0, Me.Width - 20, mThemeFormat.HeaderHeight)
            End If

            'zeichnen des Titels
            e.Graphics.DrawString(mstrHeaderText, mThemeFormat.HeaderTextFont, _
                New SolidBrush(mThemeFormat.HeaderTextColor), rectText, stringFmt)
        End If

        MyBase.OnPaint(e)
    End Sub


#End Region
End Class

