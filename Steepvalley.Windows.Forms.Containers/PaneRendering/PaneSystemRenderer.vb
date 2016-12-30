Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Steepvalley.Windows.Forms.Common.Graphics

Public Class PaneSystemRenderer
    Implements IPaneRenderer

#Region " IXPPanelRenderer Interface Implementation "
    Public Sub RenderBackground(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBackground
        Dim _inner As New RectangleF(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 1)

        g.FillRectangle(New LinearGradientBrush(_inner, SystemColors.Highlight, SystemColors.GradientInactiveCaption, LinearGradientMode.Vertical), _inner)

    End Sub

    Public Sub RenderBorder(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBorder
        Dim _inner As New Rectangle(ctrl.Padding.Left, ctrl.Padding.Top, ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - 1)
        g.DrawRectangle(SystemPens.Highlight, _inner)
        '_inner.Inflate(-1, -1)
        'g.DrawRectangle(Pens.White, _inner)
    End Sub
#End Region
End Class
