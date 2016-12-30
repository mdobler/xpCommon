Imports System.Windows.Forms
Imports System.Reflection

Public Class AddPropertiesDialog

    Private _attachedProps As ItemPropertyCollection
    Private _availableProps As ItemPropertyCollection


#Region " ctor "
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByVal style As Style)
        Me.New()
        Databind(style)
    End Sub
#End Region

#Region " UI events "
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub cmdAddAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddAll.Click
        For Each itm As Object In Me.AvailablePropertiesBindingSource.List
            Me.AttachedPropertiesBindingSource.Add(itm)
        Next

        Me.AvailablePropertiesBindingSource.Clear()
    End Sub

    Private Sub cmdRemoveAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveAll.Click
        For Each itm As Object In Me.AttachedPropertiesBindingSource.List
            Me.AvailablePropertiesBindingSource.Add(itm)
        Next

        Me.AttachedPropertiesBindingSource.Clear()
    End Sub

    Private Sub cmdAddSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAddSelected.Click
        For Each i As Integer In Me.lbAvailableProperties.SelectedIndices
            Me.AttachedPropertiesBindingSource.Add(Me.lbAvailableProperties.Items(i))
            Me.AvailablePropertiesBindingSource.RemoveAt(i)
        Next
    End Sub

    Private Sub cmdRemoveSelected_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemoveSelected.Click
        For Each i As Integer In Me.lbAttachedProperties.SelectedIndices
            Me.AvailablePropertiesBindingSource.Add(Me.lbAvailableProperties.Items(i))
            Me.AttachedPropertiesBindingSource.RemoveAt(i)
        Next
    End Sub

    Private Sub lbAvailableProperties_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAvailableProperties.DoubleClick
        cmdAddSelected_Click(sender, e)
    End Sub

    Private Sub lbAttachedProperties_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAttachedProperties.DoubleClick
        cmdRemoveSelected_Click(sender, e)
    End Sub

#End Region

    Private Sub Databind(ByVal style As Style)
        If Not style Is Nothing Then
            _attachedProps = DirectCast(style.Properties.Clone, ItemPropertyCollection)
            _availableProps = style.GetAvailablePropertyItems

            Me.AttachedPropertiesBindingSource.DataSource = _attachedProps
            Me.AvailablePropertiesBindingSource.DataSource = _availableProps
            Me.AttachedPropertiesBindingSource.Sort = "Name"
            Me.AvailablePropertiesBindingSource.Sort = "Name"
        Else
            Me.AttachedPropertiesBindingSource.DataSource = Nothing
            Me.AvailablePropertiesBindingSource.DataSource = Nothing
        End If
    End Sub

    Private _style As Style
    Public WriteOnly Property Style() As Style
        Set(ByVal value As Style)
            _style = value
            Databind(value)
        End Set
    End Property

    Public ReadOnly Property Properties() As ItemPropertyCollection
        Get
            Return _attachedProps
        End Get
    End Property

End Class
