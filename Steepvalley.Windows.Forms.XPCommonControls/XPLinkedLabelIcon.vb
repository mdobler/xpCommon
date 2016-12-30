'usercontrol that draws a linked label plus an icon in front of that linked label
Imports System.ComponentModel
Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : XPCommonControls.XPLinkedLabelIcon
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this control provides a LinkLabel with icon
''' </summary>
''' <remarks>
''' the regular LinkLabel control does support images, but it draws it without checking 
''' the text alignment.
''' this extension to the LinkLabel control supports 16x16 pixel icon resources that are 
''' drawn to the left of the Link. Most other properties of the original are supported.
''' </remarks>
''' <history>
''' 	[Mike]	13.03.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class XPLinkedLabelIcon
    Inherits System.Windows.Forms.UserControl

    Private mIcon As Icon
    Private mAutoSize As Boolean

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
        'SetStyle(ControlStyles.ContainerControl, True)

        MyBase.BackColor = Color.Transparent
        mAutoSize = mLinkedLabel.AutoSize
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
    Private WithEvents mLinkedLabel As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.mLinkedLabel = New System.Windows.Forms.LinkLabel
        Me.SuspendLayout()
        '
        'mLinkedLabel
        '
        Me.mLinkedLabel.AutoSize = True
        Me.mLinkedLabel.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.mLinkedLabel.Location = New System.Drawing.Point(64, 8)
        Me.mLinkedLabel.Name = "mLinkedLabel"
        Me.mLinkedLabel.Size = New System.Drawing.Size(59, 16)
        Me.mLinkedLabel.TabIndex = 0
        Me.mLinkedLabel.TabStop = True
        Me.mLinkedLabel.Text = "LinkLabel1"
        '
        'XPLinkedLabelIcon
        '
        Me.Controls.Add(Me.mLinkedLabel)
        Me.Name = "XPLinkedLabelIcon"
        Me.Size = New System.Drawing.Size(256, 40)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Public Events"
    'Public Event LinkedLabelClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    'changed to standard event args

    Public Event LinkClicked As EventHandler
    Protected Overridable Sub OnLinkClicked(ByVal e As EventArgs)
        RaiseEvent LinkClicked(Me, e)
    End Sub

    'Public Event AutoSizeChanged As EventHandler
    'Protected Overridable Sub OnAutoSizeChanged(ByVal e As EventArgs)
    '    RaiseEvent AutoSizeChanged(Me, e)
    'End Sub
#End Region

#Region "Public Properties"
    'wichtig: ohne das DesignerSerializationVisibility Attribut wird der Wert
    'in der Form nicht serialisiert/abgespeichert!
    <Browsable(True), _
     Localizable(True), _
     Category("Appearance"), _
     DefaultValue(""), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Overrides Property Text() As String
        Get
            Return mLinkedLabel.Text
        End Get
        Set(ByVal value As String)
            mLinkedLabel.Text = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Category("Appearance"), _
     DefaultValue(GetType(Icon), "")> _
    Public Property Icon() As Icon
        Get
            Return mIcon
        End Get
        Set(ByVal value As Icon)
            mIcon = New Icon(value, New Size(16, 16))
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Category("Appearance"), _
     DefaultValue(GetType(Color), "Red")> _
    Public Property ActiveLinkColor() As Color
        Get
            Return mLinkedLabel.ActiveLinkColor
        End Get
        Set(ByVal value As Color)
            mLinkedLabel.ActiveLinkColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Category("Appearance"), _
     DefaultValue(GetType(Color), "143,140,127")> _
    Public Property DisabledLinkColor() As Color
        Get
            Return mLinkedLabel.DisabledLinkColor
        End Get
        Set(ByVal value As Color)
            mLinkedLabel.DisabledLinkColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
     DefaultValue(GetType(Color), "NormalColor")> _
    Public Property LinkColor() As Color
        Get
            Return mLinkedLabel.LinkColor
        End Get
        Set(ByVal value As Color)
            mLinkedLabel.LinkColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
     DefaultValue(GetType(Color), "128,0,128")> _
    Public Property VisitedLinkColor() As Color
        Get
            Return mLinkedLabel.VisitedLinkColor
        End Get
        Set(ByVal value As Color)
            mLinkedLabel.VisitedLinkColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Category("Appearance"), _
     DefaultValue(False)> _
    Public Property LinkVisited() As Boolean
        Get
            Return mLinkedLabel.LinkVisited
        End Get
        Set(ByVal value As Boolean)
            mLinkedLabel.LinkVisited = value
        End Set
    End Property

    <Browsable(True), _
    Category("Appearance"), _
     DefaultValue(True)> _
    Public Property UseMnemonic() As Boolean
        Get
            Return mLinkedLabel.UseMnemonic
        End Get
        Set(ByVal value As Boolean)
            mLinkedLabel.UseMnemonic = value
        End Set
    End Property

    <Browsable(True), _
     Category("Behavior"), _
     DefaultValue(True)> _
    Public Overrides Property AutoSize() As Boolean
        Get
            Return mAutoSize
        End Get
        Set(ByVal value As Boolean)
            mAutoSize = value
            mLinkedLabel.AutoSize = mAutoSize
        End Set
    End Property

    <Browsable(True), _
     Category("Behavior"), _
     DefaultValue(GetType(LinkBehavior), "SystemDefault")> _
    Public Property LinkBehavior() As LinkBehavior
        Get
            Return mLinkedLabel.LinkBehavior
        End Get
        Set(ByVal value As LinkBehavior)
            mLinkedLabel.LinkBehavior = value
        End Set
    End Property

    <Browsable(True), _
     Category("Behavior"), _
     DefaultValue(GetType(LinkArea), "0,10")> _
    Public Property LinkArea() As LinkArea
        Get
            Return mLinkedLabel.LinkArea
        End Get
        Set(ByVal value As LinkArea)
            mLinkedLabel.LinkArea = value
        End Set
    End Property

    <Browsable(True), _
    Category("Behavior")> _
    Public ReadOnly Property Links() As LinkLabel.LinkCollection
        Get
            Return mLinkedLabel.Links
        End Get
    End Property
#End Region

#Region "Custom Painting"
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        Me.SuspendLayout()

        'groesse festlegen
        If mLinkedLabel.AutoSize Then
            Me.Width = CInt(IIf(mIcon Is Nothing, 0, 18)) + mLinkedLabel.Width
            Me.Height = mLinkedLabel.Height
        End If

        Dim rectIcon As Rectangle = Helpers.CheckedRectangle(CInt((Me.Height - 16) / 2), 0, 16, 16)
        Dim iX As Integer = 0

        If Not mIcon Is Nothing Then
            e.Graphics.DrawIcon(mIcon, rectIcon)
            iX = 18
        End If

        mLinkedLabel.Location = New Point(iX, 0)

        Me.ResumeLayout(True)

        MyBase.OnPaint(e)
    End Sub
#End Region

#Region "Raising Events"
    Private Sub mLinkedLabel_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles mLinkedLabel.LinkClicked
        Me.OnLinkClicked(New EventArgs)
    End Sub

    'Private Sub mLinkedLabel_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mLinkedLabel.AutoSizeChanged
    '    Me.OnAutoSizeChanged(e)
    'End Sub
#End Region

#Region "overriding the autosize mode"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the dock changed event must be catched in order to reset the autosize-property
    ''' of the linked label. If the autosize of the linked label would be set to true and 
    ''' the docking would be set to another value than "none" a constant resizing / repainting 
    ''' would occur --> 100% CPU and memory leak!!!
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' 
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	09.03.2005	bug fixed from version 2.2.0 to 2.2.1
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Protected Overrides Sub OnDockChanged(ByVal e As System.EventArgs)
        MyBase.OnDockChanged(e)

        If Me.Dock = DockStyle.None Then
            mLinkedLabel.AutoSize = mAutoSize
        Else
            mAutoSize = Me.AutoSize
            mLinkedLabel.AutoSize = False
        End If
    End Sub
#End Region

End Class
