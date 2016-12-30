''' <summary>
''' root class of library. currentyl only shows an about dialog
''' </summary>
''' <remarks></remarks>
Module XPCommonControls
    Public Sub About()
        Dim dlg As New About
        dlg.ShowDialog()
    End Sub

    Public Sub About(ByVal owner As System.Windows.Forms.IWin32Window)
        Dim dlg As New About
        dlg.ShowDialog(owner)
    End Sub
End Module