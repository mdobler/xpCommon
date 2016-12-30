Imports Steepvalley.Windows.Forms.Containers
Imports System.Windows.Forms

Public Class Form4

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim _renderer As New PaneCustomRenderer
        _renderer.BackgroundBrush = New Drawing.Drawing2D.LinearGradientBrush(New Drawing.RectangleF(0, 0, 100, 100), Drawing.Color.Orange, Drawing.Color.Red, Drawing.Drawing2D.LinearGradientMode.Vertical)
        _renderer.BorderPen = New Drawing.Pen(Drawing.Color.DarkRed, TrackBorder.Value)
        _renderer.Margin = New Padding(Me.trackMargin.Value)
        _renderer.Radiens = New Steepvalley.Windows.Forms.Common.Graphics.CornerRadiens(Me.trackRadius.Value)

        'Me.XpPanel1.Renderer = _renderer
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim _renderer As New PaneProfessionalRenderer

        'Me.XpPanel1.Renderer = _renderer
        Me.CaptionPane1.Renderer = New CaptionPaneProfessionalRenderer
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        'Me.XpPanel1.Renderer = New PaneSystemRenderer
        Me.CaptionPane1.Renderer = New CaptionPaneSystemRenderer
    End Sub
End Class