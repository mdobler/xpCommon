Imports steepvalley.Windows.Forms.Common.Graphics
Imports System.Windows.Forms
Imports System.Drawing

Public Class Form3

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim p As System.Drawing.Drawing2D.GraphicsPath

        p = Paths.RoundedRect(0, 0, Me.PictureBox1.Width, Me.PictureBox1.Height, _
                New CornerRadiens(CInt(tbRadTL.Text), CInt(tbRadTR.Text), CInt(tbRadBL.Text), CInt(tbRadBR.Text)), _
                New Padding(CInt(tbMarginL.Text), CInt(tbMarginT.Text), CInt(tbMarginR.Text), CInt(tbMarginB.Text)))

        Dim g As System.Drawing.Graphics = PictureBox1.CreateGraphics
        Dim pen As New Pen(Color.Red, 3)
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.Clear(PictureBox1.BackColor)
        g.DrawPath(Pens.Red, p)
        g.Dispose()
        p.Dispose()
    End Sub


End Class