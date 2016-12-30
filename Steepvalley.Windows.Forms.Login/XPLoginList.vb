
Public Class XPLoginList
    Private WithEvents _items As New LoginUserInfoCollection

#Region " Events "
    Public Event Authenticate As EventHandler(Of AuthenticateEventArgs)
    Protected Overridable Sub OnAuthenticate(ByRef e As AuthenticateEventArgs)
        RaiseEvent Authenticate(Me, e)
    End Sub

    Public Event Authenticated As EventHandler(Of AuthenticatedEventArgs)
    Protected Overridable Sub OnAuthenticated(ByVal e As AuthenticatedEventArgs)
        RaiseEvent Authenticated(Me, e)
    End Sub

#End Region

#Region " Private Methods "
    Protected Sub DrawItems()
        Me.Controls.Clear()
        If _items Is Nothing OrElse _items.Count = 0 Then Exit Sub

        Me.SuspendLayout()
        For i As Integer = _items.Count - 1 To 0 Step -1
            Dim ctrl As New XPLogin
            ctrl.Dock = DockStyle.Top
            ctrl.UserInfo = Items(i)

            AddHandler ctrl.Selected, AddressOf ItemSelectedHandler
            AddHandler ctrl.Authenticate, AddressOf ItemAuthenticateHandler
            AddHandler ctrl.Authenticated, AddressOf ItemAuthenticatedHandler

            Me.Controls.Add(ctrl)
        Next


        Me.ResumeLayout()
    End Sub

    'Private Sub _items_AddingNew(ByVal sender As Object, ByVal e As System.ComponentModel.AddingNewEventArgs) Handles _items.AddingNew
    '    DirectCast(e.NewObject, LoginUserInfo).Username = String.Format("Username{0}", Me._items.Count)
    'End Sub

    Private Sub _items_ListChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ListChangedEventArgs) Handles _items.ListChanged

        If e.ListChangedType = ListChangedType.ItemChanged Then
            Redraw()
        Else
            DrawItems()
        End If
    End Sub
#End Region

#Region " Public Methods "
    Public Sub Redraw()

        Me.SuspendLayout()
        For i As Integer = _items.Count - 1 To 0 Step -1
            Me.Controls(i).Invalidate()
        Next
        Me.ResumeLayout()
    End Sub
#End Region

#Region " Properties "
    Private _format As New XPLoginFormat
    Private _selectedIndex As Integer = -1

    <Editor(GetType(System.ComponentModel.Design.CollectionEditor), GetType(System.Drawing.Design.UITypeEditor)), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items() As LoginUserInfoCollection
        Get
            Return _items
        End Get
        Set(ByVal value As LoginUserInfoCollection)
            _items = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public Property SelectedIndex() As Integer
        Get
            Return _selectedIndex
        End Get
        Set(ByVal value As Integer)
            If value >= 0 And value < _items.Count Then
                _selectedIndex = value
            Else
                _selectedIndex = -1
            End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property Format() As XPLoginFormat
        Get
            Return _format
        End Get
        Set(ByVal value As XPLoginFormat)
            _format = value

            'If Not Me.Controls Is Nothing AndAlso Me.Controls.Count > 0 Then
            '    For Each ctrl As XPLogin In Me.Controls
            '        ctrl.Format = _format
            '    Next
            'End If
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
    Public ReadOnly Property SelectedItem() As LoginUserInfo
        Get
            If _selectedIndex >= 0 And _selectedIndex < _items.Count Then
                Return _items(_selectedIndex)
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region " Item Handlers "
    Private Sub ItemSelectedHandler(ByVal sender As Object, ByVal e As EventArgs)
        _selectedIndex = _items.IndexOf(DirectCast(sender, XPLogin).UserInfo)



        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is XPLogin AndAlso Not ctrl.Equals(sender) Then
                DirectCast(ctrl, XPLogin).State = XPLogin.ControlStates.Unselected
            End If
        Next
    End Sub

    Private Sub ItemAuthenticateHandler(ByVal sender As Object, ByVal e As AuthenticateEventArgs)
        OnAuthenticate(e)
    End Sub

    Private Sub ItemAuthenticatedHandler(ByVal sender As Object, ByVal e As AuthenticatedEventArgs)
        OnAuthenticated(e)
    End Sub
#End Region
End Class