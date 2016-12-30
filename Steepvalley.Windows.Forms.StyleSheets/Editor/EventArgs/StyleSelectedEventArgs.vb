Public Class StyleSelectedEventArgs
    Inherits EventArgs

    Public Style As Style

    Public Sub New(ByVal style As Style)
        Me.Style = style
    End Sub
End Class
