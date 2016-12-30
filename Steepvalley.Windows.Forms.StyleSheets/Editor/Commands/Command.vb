Imports System.Windows.Forms
Imports System.Reflection
Imports System.ComponentModel
Imports System.ComponentModel.Design

''' <summary>
''' The Command Class will allow you to attach any component to it and then will syncronize
''' certain actions/events of all attached components.
''' </summary>
''' <remarks></remarks>
Public Class Command
    Private _enabled As Boolean = True
    Private _visible As Boolean = True
    Private _text As String = ""

    Private _propagateEnabled As Boolean = True
    Private _propagateVisible As Boolean = True
    Private _propagateText As Boolean = False
    Private _items As New Collections.Generic.List(Of Component)

    Public Event Click(ByVal sender As Object, ByVal e As EventArgs)
    Public Event VisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event EnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public Event TextChanged(ByVal sender As Object, ByVal e As EventArgs)

#Region " Constructors "

    Public Sub New()
    End Sub

    Public Sub New(ByVal propagateEnabled As Boolean)
        Me.New(propagateEnabled, True, False)
    End Sub

    Public Sub New(ByVal propagateEnabled As Boolean, ByVal propagateVisible As Boolean)
        Me.New(propagateEnabled, propagateVisible, False)
    End Sub

    Public Sub New(ByVal propagateEnabled As Boolean, ByVal propagateVisible As Boolean, ByVal propagateText As Boolean)
        Me._propagateEnabled = propagateEnabled
        Me._propagateVisible = propagateVisible
        Me._propagateText = propagateText
    End Sub

#End Region

#Region "public properties"
    ''' <summary>
    ''' sets the text for the controls. is then set for the attached items if appropriate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(""), _
     Description("Changes the Text attribute of all attached components to the current value, if the PropagateText property is set to TRUE")> _
    Public Property Text() As String
        Get
            Return _text
        End Get
        Set(ByVal value As String)
            If Not _text.Equals(value) Then
                _text = value
                SetText()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Is the command (and its attached controls) enabled or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), _
     Description("Changes the Enabled attribute of all attached components to the current value")> _
    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(ByVal value As Boolean)
            If Not _enabled.Equals(value) Then
                _enabled = value
                SetEnabled()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Is the command (and its attached controls) enabled or not
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), _
     Description("Changes the Enabled attribute of all attached components to the current value")> _
    Public Property Visible() As Boolean
        Get
            Return _visible
        End Get
        Set(ByVal value As Boolean)
            If Not _visible.Equals(value) Then
                _visible = value
                SetVisible()
            End If
        End Set
    End Property

    ''' <summary>
    ''' Flag, if the enabled-Property of an attached control is
    ''' propagated to the command or not.
    ''' This will allow you to disable a menu entry and by this
    ''' have all additionally attached objects disabled too
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), _
     Description("Setting this value to TRUE will allow you to propagate the Enabled value from one attached component to all others")> _
    Public Property PropagateEnabled() As Boolean
        Get
            Return _propagateEnabled
        End Get
        Set(ByVal value As Boolean)
            _propagateEnabled = value
        End Set
    End Property

    ''' <summary>
    ''' Flag, if the enabled-Property of an attached control is
    ''' propagated to the command or not.
    ''' This will allow you to hide a menu entry and by this
    ''' have all additionally attached objects hidden too
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DefaultValue(True), _
     Description("Setting this value to TRUE will allow you to propagate the Visible value from one attached component to all others")> _
    Public Property PropagateVisible() As Boolean
        Get
            Return _propagateVisible
        End Get
        Set(ByVal value As Boolean)
            _propagateVisible = value
        End Set
    End Property

    <DefaultValue(False), _
     Description("Setting this value to TRUE will allow you to propagate the Text value from one attached component to all others")> _
    Public Property PropagateText() As Boolean
        Get
            Return _propagateText
        End Get
        Set(ByVal value As Boolean)
            _propagateText = value
        End Set
    End Property
#End Region

    Public Sub Execute()
        OnClick(Me, New EventArgs)
    End Sub

#Region "attach and detach Components to command object"
    Public Sub Add(ByVal item As System.Windows.Forms.Control)
        If Not _items.Contains(item) Then
            _items.Add(item)
            AddHandler item.Click, AddressOf Me.OnClick
            AddHandler item.VisibleChanged, AddressOf Me.OnVisibleChanged
            AddHandler item.EnabledChanged, AddressOf Me.OnEnabledChanged
        End If
    End Sub

    Public Sub Add(ByVal item As System.Windows.Forms.ToolStripItem)
        If Not _items.Contains(item) Then
            _items.Add(item)
            AddHandler item.Click, AddressOf Me.OnClick
            AddHandler item.VisibleChanged, AddressOf Me.OnVisibleChanged
            AddHandler item.EnabledChanged, AddressOf Me.OnEnabledChanged
        End If
    End Sub

    Public Sub Remove(ByVal item As System.Windows.Forms.Control)
        If Not _items.Contains(item) Then
            _items.Add(item)
            RemoveHandler item.Click, AddressOf Me.OnClick
            RemoveHandler item.VisibleChanged, AddressOf Me.OnVisibleChanged
            RemoveHandler item.EnabledChanged, AddressOf Me.OnEnabledChanged
        End If
    End Sub

    Public Sub Remove(ByVal item As System.Windows.Forms.ToolStripItem)
        If Not _items.Contains(item) Then
            _items.Add(item)
            RemoveHandler item.Click, AddressOf Me.OnClick
            RemoveHandler item.VisibleChanged, AddressOf Me.OnVisibleChanged
            RemoveHandler item.EnabledChanged, AddressOf Me.OnEnabledChanged
        End If
    End Sub

    ''' <summary>
    ''' clears all attached items plus their event wiring
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ClearItems()
        For Each itm As Component In Me._items
            If TypeOf itm Is Control Then
                Remove(DirectCast(itm, Control))
            ElseIf TypeOf itm Is ToolStripItem Then
                Remove(DirectCast(itm, ToolStripItem))
            End If
        Next
    End Sub
#End Region

#Region "Component event handlers"
    ''' <summary>
    ''' the method the click event of attached items is wired to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnClick(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent Click(Me, e)
    End Sub

    ''' <summary>
    ''' the method the EnabledChanged event of attached items is wired to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnEnabledChanged(ByVal sender As Object, ByVal e As EventArgs)
        If _propagateEnabled = False Then Exit Sub

        Dim _prevValue As Boolean = _propagateEnabled
        _propagateEnabled = False

        If TypeOf sender Is Control Then
            Me.Enabled = DirectCast(sender, Control).Enabled
        ElseIf TypeOf sender Is ToolStripItem Then
            Me.Enabled = DirectCast(sender, ToolStripItem).Enabled
        End If

        _propagateEnabled = _prevValue
        RaiseEvent EnabledChanged(Me, e)
    End Sub

    ''' <summary>
    ''' the method the VisibleChanged event of attached items is wired to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnVisibleChanged(ByVal sender As Object, ByVal e As EventArgs)
        If _propagateVisible = False Then Exit Sub

        Dim _prevValue As Boolean = _propagateVisible
        _propagateVisible = False

        If TypeOf sender Is Control Then
            Me.Visible = DirectCast(sender, Control).Visible
        ElseIf TypeOf sender Is ToolStripItem Then
            Me.Visible = DirectCast(sender, ToolStripItem).Visible
        End If

        _propagateVisible = _prevValue
        RaiseEvent VisibleChanged(Me, e)
    End Sub

    ''' <summary>
    ''' the method the TextChanged event of attached items is wired to.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Overridable Sub OnTextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If _propagateText = False Then Exit Sub

        Dim _prevValue As Boolean = _propagateText
        _propagateText = False

        If TypeOf sender Is Control Then
            Me.Text = DirectCast(sender, Control).Text
        ElseIf TypeOf sender Is ToolStripItem Then
            Me.Text = DirectCast(sender, ToolStripItem).Text
        End If

        _propagateText = _prevValue
        RaiseEvent TextChanged(Me, e)
    End Sub
#End Region

#Region "protected methods"
    ''' <summary>
    ''' sets the visible property of all attached items that support this property
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetVisible()
        For Each itm As Component In _items
            Try
                If TypeOf itm Is Control Then
                    Me.Visible = DirectCast(itm, Control).Visible
                ElseIf TypeOf itm Is ToolStripItem Then
                    Me.Visible = DirectCast(itm, ToolStripItem).Visible
                End If
            Catch ex As Exception
                'do nothing if not possible
            End Try
        Next
    End Sub

    ''' <summary>
    ''' sets the enabled property of all attached items that support this property
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetEnabled()
        For Each itm As Component In _items
            Try
                If TypeOf itm Is Control Then
                    DirectCast(itm, Control).Enabled = Me.Enabled
                ElseIf TypeOf itm Is ToolStripItem Then
                    DirectCast(itm, ToolStripItem).Enabled = Me.Enabled
                End If
            Catch ex As Exception
                'do nothing if not possible
            End Try

        Next
    End Sub

    ''' <summary>
    ''' sets the text property of all attached items that support this property
    ''' </summary>
    ''' <remarks></remarks>
    Protected Overridable Sub SetText()
        If Not _propagateText Then Exit Sub

        For Each itm As Component In _items
            Try
                If TypeOf itm Is Control Then
                    Me.Text = DirectCast(itm, Control).Text
                ElseIf TypeOf itm Is ToolStripItem Then
                    Me.Text = DirectCast(itm, ToolStripItem).Text
                End If
            Catch ex As Exception
                'do nothing if not possible
            End Try

        Next
    End Sub
#End Region
End Class
