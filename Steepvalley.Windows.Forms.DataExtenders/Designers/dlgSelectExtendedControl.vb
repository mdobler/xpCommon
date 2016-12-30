Imports System.Windows.Forms

Public Class dlgSelectExtendedControl

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Public WriteOnly Property ExtendedControls() As Control()
        Set(ByVal value As Control())
            lbControls.Items.Clear()

            For Each c As Control In value
                lbControls.Items.Add(c)
            Next
        End Set
    End Property

    Public ReadOnly Property SelectedControl() As Control
        Get
            If Not lbControls.SelectedItem Is Nothing Then
                Return DirectCast(lbControls.SelectedItem, Control)
            Else
                Return Nothing
            End If
        End Get
    End Property
End Class
