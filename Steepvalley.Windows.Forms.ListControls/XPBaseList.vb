Imports System.Drawing.Drawing2D
Imports System.ComponentModel

''' <summary>
''' this is an extension to the FlowLayoutPanel which allows you to track the currently
''' selected item.
''' </summary>
''' <remarks></remarks>
<Designer(GetType(Design.XPBaseListDesigner)), DesignTimeVisibleAttribute(True)> _
Public Class XPBaseList

    Dim _selectedCtrl As Control = Nothing
    Dim _borderColor As Color = SystemColors.Highlight
    Dim _borderStyle As ButtonBorderStyle = ButtonBorderStyle.Solid
    Dim _showSelection As Boolean = True

#Region "Event Declarations"
    Public Delegate Sub SelectionChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event SelectionChanged As SelectionChangedHandler
    Protected Overridable Sub OnSelectionChanged(ByVal e As EventArgs)
        RaiseEvent SelectionChanged(Me, e)
    End Sub

    Public Delegate Sub ControlEnterHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ControlEnter As ControlEnterHandler
    Protected Overridable Sub OnControlEnter(ByVal e As EventArgs)
        RaiseEvent ControlEnter(Me, e)
    End Sub

    Public Delegate Sub ControlLeaveHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ControlLeave As ControlLeaveHandler
    Protected Overridable Sub OnControlLeave(ByVal e As EventArgs)
        RaiseEvent ControlLeave(Me, e)
    End Sub
#End Region

#Region "Public Properties"
    <Browsable(True), _
     Description("returns the currently selected item of the list"), _
     Category("Selection")> _
    Public ReadOnly Property SelectedControl() As Control
        Get
            Return _selectedCtrl
        End Get
    End Property

    <Browsable(True), _
     Description("sets or gets the selection border style"), _
     Category("Selection"), _
     DefaultValue(GetType(ButtonBorderStyle), "Solid")> _
    Public Property SelectionBorderStyle() As ButtonBorderStyle
        Get
            Return _borderStyle
        End Get
        Set(ByVal Value As ButtonBorderStyle)
            _borderStyle = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("sets or gets the selection border color"), _
     Category("Selection"), _
     DefaultValue(GetType(Color), "Highlight")> _
    Public Property SelectionBorderColor() As Color
        Get
            Return _borderColor
        End Get
        Set(ByVal Value As Color)
            _borderColor = Value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(True), _
     Description("displays a selection rectangle"), _
     Category("Selection"), _
     DefaultValue(True)> _
    Public Property ShowSelection() As Boolean
        Get
            Return _showSelection
        End Get
        Set(ByVal value As Boolean)
            _showSelection = value
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region "Overriden Methods"
    Protected Overrides Sub OnControlAdded(ByVal e As System.Windows.Forms.ControlEventArgs)
        MyBase.OnControlAdded(e)

        AddHandler e.Control.Enter, AddressOf handlesEnter
        AddHandler e.Control.Leave, AddressOf handlesLeave
    End Sub

    Protected Overrides Sub OnControlRemoved(ByVal e As System.Windows.Forms.ControlEventArgs)
        MyBase.OnControlRemoved(e)

        RemoveHandler e.Control.Enter, AddressOf handlesEnter
        RemoveHandler e.Control.Leave, AddressOf handlesLeave
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        If Not _selectedCtrl Is Nothing And _showSelection Then
            Dim _rect As Rectangle = Helpers.CheckedRectangle( _
                _selectedCtrl.Location.X - 2, _
                _selectedCtrl.Location.Y - 2, _
                _selectedCtrl.Width + 4, _
                _selectedCtrl.Height + 4)

            ControlPaint.DrawBorder(e.Graphics, _rect, _borderColor, _borderStyle)
        End If
    End Sub
#End Region

#Region "Event Handling"
    Private Sub handlesEnter(ByVal sender As Object, ByVal e As EventArgs)
        _selectedCtrl = CType(sender, Control)
        RaiseEvent ControlEnter(sender, e)
        OnSelectionChanged(New EventArgs)
        Me.Invalidate()
    End Sub

    Private Sub handlesLeave(ByVal sender As Object, ByVal e As EventArgs)
        _selectedCtrl = Nothing
        RaiseEvent ControlLeave(sender, e)
        OnSelectionChanged(New EventArgs)
        Me.Invalidate()
    End Sub
#End Region
End Class
