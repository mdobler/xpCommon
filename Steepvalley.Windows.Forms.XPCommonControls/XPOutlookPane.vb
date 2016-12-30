' Base class for the three panes. Draws caption at top with using
' a different gradient fill if the pane is active or inactive.

Imports System.ComponentModel
Imports Steepvalley.Windows.Forms.Design

<Designer(GetType(XPOutlookPaneDesigner)), DesignTimeVisibleAttribute(True)> _
Public Class XPOutlookPane
    Inherits System.Windows.Forms.UserControl

    ' events
    ' raise when the pane becomes active
    Public Event PaneActive(ByVal sender As Object, ByVal e As EventArgs)

    ' internal members
    ' pane caption
    Private caption As XPCaption
    Private _bordercol As Color = Color.DarkBlue

    ' properties
    <Description("the pane caption details"), Category("Appearance"), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public ReadOnly Property CaptionControl() As XPCaption
        Get
            Return caption
        End Get
    End Property

    <Description("The pane caption."), Category("Appearance")> _
    Public Property CaptionText() As String
        Get
            Return caption.Text
        End Get

        Set(ByVal value As String)
            caption.Text = value
        End Set
    End Property

    Public ReadOnly Property Active() As Boolean
        Get
            Return caption.Active
        End Get
    End Property

    <Description("Border Color"), Category("Appearance"), DefaultValue(GetType(Color), "DarkBlue")> _
    Public Property BorderColor() As Color
        Get
            Return _bordercol
        End Get
        Set(ByVal Value As Color)
            _bordercol = Value
            Me.Invalidate()
        End Set
    End Property

    ' ctor
    Public Sub New()
        MyBase.New()

        ' set double buffer styles
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.ContainerControl, True)

        ' This call is required by the Windows.Forms Form Designer.
        InitializeComponent()
    End Sub

#Region " Windows Form Designer generated code "
    Private components As System.ComponentModel.Container = Nothing

    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If

        MyBase.Dispose(disposing)
    End Sub


    Private Sub InitializeComponent()
        Me.caption = New SteepValley.Windows.Forms.XPCaption
        Me.SuspendLayout()
        '
        'caption
        '
        Me.caption.Dock = System.Windows.Forms.DockStyle.Top
        Me.caption.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.caption.Location = New System.Drawing.Point(1, 1)
        Me.caption.Name = "caption"
        Me.caption.Size = New System.Drawing.Size(182, 24)
        Me.caption.TabIndex = 0
        '
        'XPOutlookPane
        '
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.Controls.Add(Me.caption)
        Me.DockPadding.All = 1
        Me.Name = "XPOutlookPane"
        Me.Size = New System.Drawing.Size(184, 248)
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' internal methods

    ' received focus, make this the active pane
    Protected Overrides Sub OnEnter(ByVal e As System.EventArgs)
        MyBase.OnEnter(e)
        caption.Active = True
        RaiseEvent PaneActive(Me, EventArgs.Empty)
    End Sub

    ' lost focus, not the active pane
    Protected Overrides Sub OnLeave(ByVal e As System.EventArgs)
        MyBase.OnLeave(e)
        caption.Active = False
    End Sub

    ' draw border around the pane
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim rc As Rectangle = Helpers.CheckedRectangle(0, 0, Me.Width - 1, Me.Height - 1)
        rc.Inflate(-Me.DockPadding.All + 1, -Me.DockPadding.All + 1)
        e.Graphics.DrawRectangle(New Pen(_bordercol, 1), rc)
        MyBase.OnPaint(e)
    End Sub

    Protected Overrides Sub OnResize(ByVal e As System.EventArgs)
        MyBase.OnResize(e)

        ' manually resize the caption width if in the visual designer
        If Me.DesignMode Then
            caption.Width = Me.Width
        End If
    End Sub

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
            Return Helpers.CheckedRectangle(0, caption.Height + 1, Me.Width - 1, Me.Height - caption.Height - 2)
        End Get
    End Property
End Class
