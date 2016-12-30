Public Class Form2

    Private Sub XpLoginList1_Authenticate(ByVal sender As Object, ByVal e As Login.AuthenticateEventArgs) Handles XpLoginList1.Authenticate
        If e.Password <> "test" Then
            e.Message = "Please Provide Correct Password"
            e.Authenticated = False
        Else
            e.Authenticated = True
        End If
    End Sub

    Private Sub XpLoginList1_Authenticated(ByVal sender As Object, ByVal e As Login.AuthenticatedEventArgs) Handles XpLoginList1.Authenticated
        System.Windows.Forms.MessageBox.Show("Anmeldung korrekt")
    End Sub

End Class