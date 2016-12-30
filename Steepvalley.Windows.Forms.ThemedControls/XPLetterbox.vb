''' <summary>
''' The "LetterBox" design is described in "Windows XP Design Guidelines" and can be found 
''' i.e. on the logon screen of Windows XP.
''' It has a header and a footer bar, a body region and a horizontal stripe between header 
''' and body and footer and body. You can also display a vertical stripe in the middle
''' of the body region.
''' 
''' This control is semi-themed. It supports the XP designs "NormalColor", "HomeStead" and 
''' "Metallic". It does this by manually drawing the letterbox. The big plus:
''' You can use this control on any .net enabled computer, you don't need Win XP to have
''' the theming.
''' 
''' For details on the theming look for the theming class
''' </summary>
''' <remarks></remarks>
<Designer(GetType(Design.XPLetterBoxDesigner)), DesignTimeVisibleAttribute(True)> _
Public Class XPLetterBox
    Inherits System.Windows.Forms.UserControl
    Implements IThemed

    Private mintHeaderHeight As Integer = 48
    Private mintFooterHeight As Integer = 48
    Private mstrHeaderText As String = ""
    Private mbDrawHeader As Boolean = True
    Private mbDrawFooter As Boolean = True
    Private mbDrawVerticalSplitLine As Boolean = False
    Private mIcon As Icon
    Private mTheme As ThemeStyle = ThemeStyle.NormalColor
    Private mThemeFormat As LetterBoxFormat = Theming.GetLetterboxTheme(mTheme)


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
        'XPLetterBox
        '
        Me.DockPadding.Bottom = 48
        Me.DockPadding.Top = 48
        Me.Name = "XPLetterBox"

    End Sub

#End Region

#Region " Public Properties "
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the theming of the control
    ''' </summary>
    ''' <value> a ThemeStyle enumeration</value>
    ''' <remarks>
    ''' you can manually override the system's theme simply by setting the 
    ''' property to a value of the ThemeStyle enumeration
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
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
            mThemeFormat = Theming.GetLetterboxTheme(mTheme)
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Caption text
    ''' </summary>
    ''' <value>String</value>
    ''' <remarks>
    ''' this string will be displayed as caption text in the header area. 
    ''' Font and Color are set by the corresponding theme info
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
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
    ''' Icon to be displayed in the left top corner
    ''' </summary>
    ''' <value>Icon</value>
    ''' <remarks>
    ''' When setting this property a 32x32 pixel icon is displayed in the left top corner
    ''' of the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Icon to be displayed in the left top corner"), _
    Category("Appearance"), _
    DefaultValue(GetType(Icon), "")> _
    Public Property Icon() As Icon
        Get
            Return mIcon
        End Get

        Set(ByVal value As Icon)
            mIcon = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Height of the Standard header
    ''' </summary>
    ''' <value>Integer</value>
    ''' <remarks>
    ''' by changing the value you can resize the header portion of the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Height of the Standard header"), _
     Category("Appearance"), _
     DefaultValue(48)> _
    Public Property HeaderHeight() As Integer
        Get
            Return mintHeaderHeight
        End Get

        Set(ByVal value As Integer)
            mintHeaderHeight = value
            Me.DockPadding.Top = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Height of the Standard footer
    ''' </summary>
    ''' <value>Integer</value>
    ''' <remarks>
    ''' by changing the value you can resize the footer portion of the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Height of the Standard footer"), _
    Category("Appearance"), _
     DefaultValue(48)> _
    Public Property FooterHeight() As Integer
        Get
            Return mintFooterHeight
        End Get

        Set(ByVal value As Integer)
            mintFooterHeight = value
            Me.DockPadding.Bottom = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Draw a vertical split line in the middle of the control
    ''' </summary>
    ''' <value>Boolean</value>
    ''' <remarks>
    ''' when set to true a thin vertical gradient line is drawn in the center of the 
    ''' body area
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Draw a vertical split line in the middle of the control"), _
    Category("Appearance"), _
    DefaultValue(False)> _
    Public Property DrawVerticalSplitLine() As Boolean
        Get
            Return mbDrawVerticalSplitLine
        End Get

        Set(ByVal value As Boolean)
            mbDrawVerticalSplitLine = value
            Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the usable region as RectangleF
    ''' </summary>
    ''' <value>Rectangle</value>
    ''' <remarks>
    ''' used for the designer. internal only
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	13.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("returns the usable region as RectangleF"), _
    Browsable(False)> _
    Friend ReadOnly Property WorkspaceRect() As Rectangle
        Get
            Return Helpers.CheckedRectangle(0, mintHeaderHeight + 1, Me.Width - 1, Me.Height - CInt(IIf(mbDrawHeader, mintHeaderHeight, 0)) - CInt(IIf(mbDrawFooter, mintFooterHeight, 0)) - 2)
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
    Public Property ThemeFormat() As LetterBoxFormat
        Get
            Return mThemeFormat
        End Get
        Set(ByVal Value As LetterBoxFormat)
            mThemeFormat = Value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Custom Painting"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim rectHeader As RectangleF = Helpers.CheckedRectangleF(0, 0, Me.Width, mintHeaderHeight)
        Dim rectFooter As RectangleF = Helpers.CheckedRectangleF(0, Me.Height - mintFooterHeight, Me.Width, mintFooterHeight)
        Dim rectText As RectangleF
        Dim rectBody As RectangleF = Helpers.CheckedRectangleF(0, mintHeaderHeight, Me.Width, Me.Height - CInt(IIf(mbDrawHeader, mintHeaderHeight, 0)) - CInt(IIf(mbDrawFooter, mintFooterHeight, 0)))
        Dim brushBody As New LinearGradientBrush(rectBody, mThemeFormat.TopBodyColor, mThemeFormat.BottomBodyColor, LinearGradientMode.ForwardDiagonal)

        Dim stringFmt As New StringFormat
        stringFmt.Alignment = StringAlignment.Near
        stringFmt.LineAlignment = StringAlignment.Center
        stringFmt.Trimming = StringTrimming.EllipsisCharacter

        'zeichnen des workspace-bereiches
        e.Graphics.FillRectangle(brushBody, rectBody)

        If mbDrawHeader Then
            'zeichnen der titelleiste
            e.Graphics.FillRectangle(New SolidBrush(mThemeFormat.HeaderColor), rectHeader)

            'zeichnen des trenners
            e.Graphics.FillRectangle( _
                New LinearGradientBrush( _
                    Helpers.CheckedRectangleF(0, mintHeaderHeight, CInt(1 + Me.Width / 2), 2), _
                    mThemeFormat.HeaderColor, _
                    ControlPaint.Light(mThemeFormat.HeaderColor), LinearGradientMode.Horizontal), _
                    Helpers.CheckedRectangleF(0, mintHeaderHeight, CInt(1 + Me.Width / 2), 2))

            e.Graphics.FillRectangle( _
                New LinearGradientBrush( _
                    Helpers.CheckedRectangleF(CInt(Me.Width / 2), mintHeaderHeight, CInt(Me.Width / 2), 2), _
                    ControlPaint.Light(mThemeFormat.HeaderColor), _
                    mThemeFormat.HeaderColor, LinearGradientMode.Horizontal), _
                    Helpers.CheckedRectangleF(CInt(Me.Width / 2), mintHeaderHeight, CInt(Me.Width / 2), 2))


            'zeichnen des Icons
            If Not mIcon Is Nothing Then
                e.Graphics.DrawIcon(New Icon(mIcon, 48, 48), New Rectangle(10, 10, 48, 48))
                rectText = Helpers.CheckedRectangleF(68, 0, Me.Width - 78, mintHeaderHeight)
            Else
                rectText = Helpers.CheckedRectangleF(10, 0, Me.Width - 20, mintHeaderHeight)
            End If

            'zeichnen des Titels
            e.Graphics.DrawString(mstrHeaderText, mThemeFormat.HeaderTextFont, _
                New SolidBrush(mThemeFormat.HeaderTextColor), rectText, stringFmt)
        End If

        If mbDrawFooter Then
            'zeichnen der titelleiste
            e.Graphics.FillRectangle(New SolidBrush(mThemeFormat.FooterColor), rectFooter)

            'zeichnen des trenners
            e.Graphics.FillRectangle( _
                New LinearGradientBrush( _
                    Helpers.CheckedRectangleF(0, Me.Height - mintFooterHeight, CInt(1 + Me.Width / 2), 2), _
                    mThemeFormat.FooterColor, _
                    Color.FromArgb(253, 157, 53), LinearGradientMode.Horizontal), _
                    Helpers.CheckedRectangleF(0, Me.Height - mintFooterHeight, CInt(1 + Me.Width / 2), 2))

            e.Graphics.FillRectangle( _
                New LinearGradientBrush( _
                    Helpers.CheckedRectangleF(CInt(Me.Width / 2), Me.Height - mintFooterHeight, CInt(Me.Width / 2), 2), _
                    Color.FromArgb(253, 157, 53), _
                    mThemeFormat.FooterColor, LinearGradientMode.Horizontal), _
                    Helpers.CheckedRectangleF(CInt(Me.Width / 2), Me.Height - mintFooterHeight, CInt(Me.Width / 2), 2))


            'zeichnen des Icons
            If Not mIcon Is Nothing Then
                e.Graphics.DrawIcon(New Icon(mIcon, 48, 48), New Rectangle(10, 10, 48, 48))
                rectText = Helpers.CheckedRectangleF(68, 0, Me.Width - 78, mintHeaderHeight)
            Else
                rectText = Helpers.CheckedRectangleF(10, 0, Me.Width - 20, mintHeaderHeight)
            End If

            'zeichnen des Titels
            e.Graphics.DrawString(mstrHeaderText, mThemeFormat.HeaderTextFont, _
                New SolidBrush(mThemeFormat.HeaderTextColor), rectText, stringFmt)
        End If

        'draws a vertical split line like on the logon screen
        If mbDrawVerticalSplitLine Then
            Dim rectsplit As RectangleF = Helpers.CheckedRectangleF(rectBody.Left + rectBody.Width / 2, rectBody.Top, 0.5, rectBody.Height)
            Dim brushsplit As New LinearGradientBrush(rectsplit, mThemeFormat.TopBodyColor, mThemeFormat.BottomBodyColor, LinearGradientMode.Vertical)
            Dim blendsplit As New ColorBlend
            Dim cols As Color() = {mThemeFormat.TopBodyColor, Color.WhiteSmoke, mThemeFormat.BottomBodyColor}
            Dim pts As Single() = {0, 0.5, 1}

            blendsplit.Colors = cols
            blendsplit.Positions = pts
            brushsplit.InterpolationColors = blendsplit
            e.Graphics.FillRectangle(brushsplit, rectsplit)

            brushsplit.Dispose()
        End If

        MyBase.OnPaint(e)
    End Sub

#End Region

End Class


