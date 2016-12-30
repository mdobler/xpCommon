Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Steepvalley.Windows.Forms.Common.Graphics

Public Class CaptionPaneProfessionalRenderer
    Inherits PaneProfessionalRenderer
    Implements ICaptionPaneRenderer

    Public Shadows Sub RenderBackground(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements ICaptionPaneRenderer.RenderBackground
        Dim _inner As New RectangleF(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 2, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 2)
        Dim _inner1 As New RectangleF(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 2, 20)

        g.FillPath(New LinearGradientBrush(_inner, Color.LightSteelBlue, Color.AliceBlue, LinearGradientMode.ForwardDiagonal), Paths.RoundedRect(_inner, New CornerRadiens(4), New Padding(0)))
        g.FillPath(New SolidBrush(Color.FromArgb(50, Color.White)), Paths.RoundedRect(_inner1, New CornerRadiens(4, 4, 0, 0), New Padding(0)))

    End Sub

    Public Shadows Sub RenderBorder(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements ICaptionPaneRenderer.RenderBorder
        Dim _inner As New RectangleF(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 2, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 2)

        _inner.X += 1
        _inner.Y += 1
        g.DrawPath(Pens.White, Paths.RoundedRect(_inner, New CornerRadiens(4), New Padding(0)))
        _inner.X -= 1
        _inner.Y -= 1
        g.DrawPath(Pens.SteelBlue, Paths.RoundedRect(_inner, New CornerRadiens(4), New Padding(0)))


    End Sub

    Public Sub RenderCaption(ByVal ctrl As CaptionPane, ByVal g As System.Drawing.Graphics) Implements ICaptionPaneRenderer.RenderCaption
        Dim _c As Rectangle
        If ctrl.CaptionPosition = CaptionPane.Positioning.Top Then
            _c = New Rectangle(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 2, ctrl.CaptionHeight)
            g.FillPath(New SolidBrush(Color.LightSteelBlue), Paths.RoundedRect(_c, New CornerRadiens(4, 4, 0, 0), New Padding(0)))
        Else
            _c = New Rectangle(ctrl.Padding.Left, ctrl.Height - ctrl.Padding.Bottom - 2 - ctrl.CaptionHeight, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 2, ctrl.CaptionHeight)
            g.FillPath(New SolidBrush(Color.LightSteelBlue), Paths.RoundedRect(_c, New CornerRadiens(0, 0, 4, 4), New Padding(0)))
        End If

        _c.Inflate(-3, -1)
        TextRenderer.DrawText(g, ctrl.CaptionText, ctrl.Font, _c, ctrl.ForeColor, TextFormatFlags.VerticalCenter Or TextFormatFlags.Left Or TextFormatFlags.EndEllipsis Or TextFormatFlags.WordEllipsis)

    End Sub
End Class
