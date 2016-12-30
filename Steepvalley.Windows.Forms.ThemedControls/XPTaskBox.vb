<Designer(GetType(Design.XPTaskBoxDesigner)), DesignTimeVisibleAttribute(True)> _
    Public Class XPTaskBox
    Inherits System.Windows.Forms.UserControl
    Implements IThemed

    Private mstrHeaderText As String = ""
    Private mintHeight As Integer
    Private mIcon As Icon
    Private mExpanded As Boolean = True
    Private mHighlighted As Boolean = False
    Private mDisableOnCollapse As Boolean = True

    Protected mTheme As ThemeStyle = ThemeStyle.NormalColor
    Protected WithEvents mThemeFormat As TaskBoxFormat = Theming.GetTaskBoxThemeGeneric(mTheme)

    Private mControlState As New Hashtable

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

    ' UserControl1 überschreibt den Löschvorgang zur Bereinigung der Komponentenliste.
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
        Me.SuspendLayout()
        '
        'XPTaskBox
        '
        Me.Name = "XPTaskBox"
        Me.Padding = New System.Windows.Forms.Padding(4, 44, 4, 4)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Properties"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the theming of the control
    ''' </summary>
    ''' <value>ThemeStyle</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Sets the theming of the control"), _
     Category("Appearance"), _
     Browsable(True), _
     DefaultValue(GetType(ThemeStyle), "NormalColor")> _
    Public Overridable Property Theme() As ThemeStyle Implements IThemed.Theme
        Get
            Return mTheme
        End Get
        Set(ByVal value As ThemeStyle)
            mTheme = value
            mThemeFormat = Theming.GetTaskBoxThemeGeneric(mTheme)
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the icon that is displayed in the title bar
    ''' </summary>
    ''' <value>Icon</value>
    ''' <remarks>
    ''' 
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Icon"), _
    Category("Appearance"), _
    Localizable(True), _
    DefaultValue(GetType(Icon), "")> _
    Public Property Icon() As Icon
        Get
            Return mIcon
        End Get
        Set(ByVal value As Icon)
            mIcon = value
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Shows the taskbox expanded or collapsed
    ''' </summary>
    ''' <value>Boolean. True if the taskbox is expanded</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    '''     [Mike]  25.04.2004  added ChangeHeight because of bug when initializing the control
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Shows the toolbox expanded or collapsed"), _
    Category("Appearance"), _
    DefaultValue(True)> _
    Public Property IsExpanded() As Boolean
        Get
            Return mExpanded
        End Get
        Set(ByVal value As Boolean)
            mExpanded = value
            ChangeHeight()
            Me.Invalidate()
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' disables all controls inside the task box if the task box is collapsed
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	17.05.2005	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("disables all controls inside the task box if the task box is collapsed"), _
     Category("Appearance"), _
     DefaultValue(True)> _
    Public Property DisableOnCollapse() As Boolean
        Get
            Return mDisableOnCollapse
        End Get
        Set(ByVal value As Boolean)
            mDisableOnCollapse = value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Shows the taskbox highlighted (selected)
    ''' </summary>
    ''' <value>Boolean.</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Shows the toolbox highlighted (selected)"), _
    Category("Appearance"), _
    DefaultValue(False)> _
    Public Property Highlighted() As Boolean
        Get
            Return mHighlighted
        End Get
        Set(ByVal value As Boolean)
            mHighlighted = value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Caption text.
    ''' </summary>
    ''' <value>String</value>
    ''' <remarks>
    ''' the text that is displayed in the title region of the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Caption text."), _
    DefaultValue("Title"), _
    Category("Appearance"), _
    Browsable(True), _
    Localizable(True)> _
    Public Property HeaderText() As String
        Get
            Return mstrHeaderText
        End Get
        Set(ByVal value As String)
            mstrHeaderText = value
            Me.Invalidate()
        End Set
    End Property


    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the usable region as RectangleF
    ''' </summary>
    ''' <value>Rectangle</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("returns the usable region as Rectangle"), _
    Browsable(False)> _
    Friend ReadOnly Property WorkspaceRect() As Rectangle
        Get
            Return Helpers.CheckedRectangle(3, 41, Me.Width - 7, Me.Height - 40 - 4)
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
    Public Property ThemeFormat() As TaskBoxFormat
        Get
            Return mThemeFormat
        End Get
        Set(ByVal Value As TaskBoxFormat)
            mThemeFormat = Value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Custom Painting"
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality

        Dim lrectHeader As RectangleF = Helpers.CheckedRectangleF(0, 16, Me.Width, 24)
        Dim lrectHeaderText As RectangleF
        Dim lrectBody As RectangleF = Helpers.CheckedRectangleF(0, 40, Me.Width, Me.Height - 40)
        Dim lrectAll As RectangleF = Helpers.CheckedRectangleF(0, 16, Me.Width, Me.Height - 16)

        Dim gp As New GraphicsPath
        Dim lbrushHeader As New LinearGradientBrush(lrectHeader, mThemeFormat.LeftHeaderColor, mThemeFormat.RightHeaderColor, LinearGradientMode.Horizontal)
        Dim lpenBorder As New Pen(mThemeFormat.BorderColor, 1)
        Dim stringFmt As New StringFormat

        stringFmt.Alignment = StringAlignment.Near
        stringFmt.LineAlignment = StringAlignment.Center
        stringFmt.Trimming = StringTrimming.EllipsisCharacter
        stringFmt.FormatFlags = StringFormatFlags.NoWrap

        lpenBorder.Alignment = PenAlignment.Inset

        'body
        If mExpanded Then
            gp = Paths.RoundedRect(lrectAll, 5, 1, Corner.All)
            e.Graphics.FillPath(New SolidBrush(mThemeFormat.BodyColor), gp)
        End If

        'titelleiste
        If mExpanded Then
            gp = Paths.RoundedRect(lrectHeader, 5, 1, Corner.TopLeft Or Corner.TopRight)
        Else
            gp = Paths.RoundedRect(lrectHeader, 5, 1, Corner.All)
        End If
        e.Graphics.FillPath(lbrushHeader, gp)

        ' Draw the outline around the work area
        If mExpanded Then
            gp = Paths.RoundedRect(lrectAll, 5, 1, Corner.All)
        End If
        e.Graphics.DrawPath(lpenBorder, gp)

        'draw icon
        If Not mIcon Is Nothing Then
            e.Graphics.DrawIcon(New Icon(mIcon, New Size(32, 32)), New Rectangle(4, 8, 32, 32))
            lrectHeaderText = Helpers.CheckedRectangleF(40, 16, Me.Width - 64, 24)
        Else
            lrectHeaderText = Helpers.CheckedRectangleF(8, 16, Me.Width - 24, 24)
        End If

        e.Graphics.DrawImage( _
            CType(IIf(mExpanded, _
                IIf(mHighlighted, _
                    mThemeFormat.ChevronUpHighlight, _
                    mThemeFormat.ChevronUp), _
                IIf(mHighlighted, _
                    mThemeFormat.ChevronDownHighlight, _
                    mThemeFormat.ChevronDown)), Image), _
                Helpers.CheckedRectangle(Me.Width - 24, 19, 21, 21))

        ' Caption text.
        e.Graphics.DrawString(mstrHeaderText, mThemeFormat.HeaderFont, CType(IIf(mHighlighted, New SolidBrush(mThemeFormat.HeaderTextHighlightColor), New SolidBrush(mThemeFormat.HeaderTextColor)), SolidBrush), lrectHeaderText, stringFmt)

        'dispose all objects
        lrectHeader = Nothing
        lrectHeaderText = Nothing
        lrectBody = Nothing
        lrectAll = Nothing
        gp.Dispose()
        lbrushHeader.Dispose()
        lpenBorder.Dispose()
        stringFmt.Dispose()

        MyBase.OnPaint(e)
    End Sub


#End Region

#Region "Mouse Actions"
    Protected Overrides Sub OnMouseMove(ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Change cursor to hand when over caption area.
        Dim bChanged As Boolean = False

        If e.Y <= 32 Then
            System.Windows.Forms.Cursor.Current = Cursors.Hand
            If mHighlighted = False Then
                mHighlighted = True
                bChanged = True
            End If
        Else
            System.Windows.Forms.Cursor.Current = Cursors.Default
            If mHighlighted = True Then
                mHighlighted = False
                bChanged = True
            End If
        End If

        If bChanged Then
            Me.Invalidate()
        End If

    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As System.Windows.Forms.MouseEventArgs)
        ' Don't do anything if did not click on caption.
        If e.Y > 32 Then
            Return
        End If

        ' Toggle expanded flag.
        mExpanded = Not mExpanded

        ' Expand or collapse the control based on its current state
        ChangeHeight()
        Me.Refresh()
    End Sub

    Protected Overrides Sub OnMouseLeave(ByVal e As System.EventArgs)
        If mHighlighted Then
            mHighlighted = False
            Me.Invalidate()
        End If
    End Sub
#End Region

#Region "events"
    Public Delegate Sub CollapsedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Collapsed As CollapsedHandler
    Protected Overridable Sub OnCollapsed(ByVal e As EventArgs)
        RaiseEvent Collapsed(Me, e)
    End Sub

    Public Delegate Sub ExpandedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event Expanded As ExpandedHandler
    Protected Overridable Sub OnExpanded(ByVal e As EventArgs)
        RaiseEvent Expanded(Me, e)
    End Sub
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Changes the height of the control according to its state
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ChangeHeight()
        If Not mExpanded Then
            ' Remember height so we can restore it later.
            mintHeight = Me.Height

            ' Set the new height and let others know we have been collapsed
            Me.Height = 40
            OnCollapsed(New EventArgs)
            If mDisableOnCollapse Then HideChildControls()
        Else
            Me.Height = mintHeight
            OnExpanded(New EventArgs)
            If mDisableOnCollapse Then ShowChildControls()
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' expands the taskbox
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub Expand()
        If Not mExpanded Then
            mExpanded = True
            ChangeHeight()
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' collapses the taskbox to a title bar
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub Collapse()
        If mExpanded Then
            mExpanded = False
            ChangeHeight()
        End If
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' hides all child controls on the taskbox
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub HideChildControls()
        mControlState.Clear()
        For Each child As Control In Me.Controls
            mControlState.Add(child.Name, child.Visible)
            child.Visible = False
        Next
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' shows all childControls that were initialy visible
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub ShowChildControls()
        For Each child As Control In Me.Controls
            If mControlState.ContainsKey(child.Name) Then
                child.Visible = CBool(mControlState.Item(child.Name))
            Else
                child.Visible = True
            End If
        Next
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' if a property changes in the theme format then redraw the control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	18.08.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Sub mThemeFormat_PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Handles mThemeFormat.PropertyChanged
        Me.Invalidate()
    End Sub
End Class
