Public Class CaptionPaneSystemRenderer
    Inherits PaneSystemRenderer
    Implements ICaptionPaneRenderer

    Public Sub RenderCaption(ByVal ctrl As CaptionPane, ByVal g As System.Drawing.Graphics) Implements ICaptionPaneRenderer.RenderCaption
        Dim _c As Rectangle
        If ctrl.CaptionPosition = CaptionPane.Positioning.Top Then
            _c = New Rectangle(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.CaptionHeight)
        Else
            _c = New Rectangle(ctrl.Padding.Left, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 1 - ctrl.CaptionHeight, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.CaptionHeight)
        End If

        g.FillRectangle(New SolidBrush(Color.FromArgb(100, Color.White)), _c)
        TextRenderer.DrawText(g, ctrl.CaptionText, ctrl.Font, _c, ctrl.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis Or TextFormatFlags.WordEllipsis)
    End Sub
End Class
