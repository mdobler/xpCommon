Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Steepvalley.Windows.Forms.Common.Graphics

Public Class PaneProfessionalRenderer
    Implements IPaneRenderer

#Region " IXPPanelRenderer Interface Implementation "
    Private Const _split As Double = 0.2

    Public Overridable Sub RenderBackground(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBackground
        Dim _inner As New RectangleF(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 1)

        Dim _inner1 As New RectangleF(_inner.X, _inner.Y, CSng(_inner.Width * 0.8), CSng(_inner.Height * 0.15))
        Dim _inner2 As New RectangleF(_inner.X, _inner.Y, CSng(_inner.Width * 0.7), CSng(_inner.Height * 0.2))

        g.FillRectangle(New LinearGradientBrush(_inner, Color.LightSteelBlue, Color.SteelBlue, LinearGradientMode.ForwardDiagonal), _inner)

        g.FillPath(New LinearGradientBrush(_inner1, Color.FromArgb(50, Color.White), Color.FromArgb(75, Color.White), LinearGradientMode.Vertical), Paths.ConvexCorner(_inner1))
        g.FillPath(New LinearGradientBrush(_inner2, Color.FromArgb(50, Color.White), Color.FromArgb(75, Color.White), LinearGradientMode.Vertical), Paths.ConvexCorner(_inner2))

    End Sub

    Public Overridable Sub RenderBorder(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBorder
        Dim _inner As New Rectangle(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 1)
        g.DrawRectangle(Pens.SteelBlue, _inner)
        _inner.Inflate(-1, -1)
        g.DrawRectangle(Pens.White, _inner)
    End Sub
#End Region
End Class
