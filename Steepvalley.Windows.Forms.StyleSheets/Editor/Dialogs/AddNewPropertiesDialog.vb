Imports System.Windows.Forms
Imports System.Reflection

Public Class AddNewPropertiesDialog


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

    #End Region

    Private Sub Databind(ByVal style As Style)

        lvProperties.Items.Clear()

        If Not style Is Nothing Then
            Me.Text = String.Format("Add Properties for [{0}]", style.TypeName)

            For Each prop As ItemProperty In style.GetAllPropertyItems
                Dim itm As New ListViewItem(prop.Name, 0)
                itm.Tag = prop

                lvProperties.Items.Add(itm)
                If style.Properties.Contains(prop.Name) Then
                    itm.Checked = True
                    'tagobjekt wechseln, damit die einstellungen erhalten bleiben
                    itm.Tag = style.Properties.Item(style.Properties.IndexOf(prop.Name))
                End If
            Next
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
            Dim retval As New ItemPropertyCollection
            For Each itm As ListViewItem In lvProperties.CheckedItems
                retval.Add(CType(itm.Tag, ItemProperty))
            Next
            Return retval
        End Get
    End Property

End Class
