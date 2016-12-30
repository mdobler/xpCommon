Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Design

Namespace Graphics
    <Flags()> _
    Public Enum Corner
        None = 0
        TopLeft = 1
        TopRight = 2
        BottomLeft = 4
        BottomRight = 8
        All = TopLeft Or TopRight Or BottomLeft Or BottomRight
    End Enum

    ''' <summary>
    ''' predefined paths for drawing routines
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Paths

#Region "RoundedRect"
        Public Shared Function RoundedRect(ByVal rect As RectangleF, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Dim p As New Drawing2D.GraphicsPath
            Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height, m As Integer = margin, r As Integer = cornerradius

            p.StartFigure()
            'top left arc
            If CBool(roundedcorners And Corner.TopLeft) Then
                p.AddArc(Helpers.CheckedRectangleF(x + m, y + m, 2 * r, 2 * r), 180, 90)
            Else
                p.AddLine(New PointF(x + m, y + m + r), New PointF(x + m, y + m))
                p.AddLine(New PointF(x + m, y + m), New PointF(x + m + r, y + m))
            End If

            'top line
            p.AddLine(New PointF(x + m + r, y + m), New PointF(x + w - m - r, y + m))

            'top right arc
            If CBool(roundedcorners And Corner.TopRight) Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m - 2 * r, y + m, 2 * r, 2 * r), 270, 90)
            Else
                p.AddLine(New PointF(x + w - m - r, y + m), New PointF(x + w - m, y + m))
                p.AddLine(New PointF(x + w - m, y + m), New PointF(x + w - m, y + m + r))
            End If

            'right line
            p.AddLine(New PointF(x + w - m, y + m + r), New PointF(x + w - m, y + h - m - r))

            'bottom right arc
            If CBool(roundedcorners And Corner.BottomRight) Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m - 2 * r, y + h - m - 2 * r, 2 * r, 2 * r), 0, 90)
            Else
                p.AddLine(New PointF(x + w - m, y + h - m - r), New PointF(x + w - m, y + h - m))
                p.AddLine(New PointF(x + w - m, y + h - m), New PointF(x + w - m - r, y + h - m))
            End If

            'bottom line
            p.AddLine(New PointF(x + w - m - r, y + h - m), New PointF(x + m + r, y + h - m))

            'bottom left arc
            If CBool(roundedcorners And Corner.BottomLeft) Then
                p.AddArc(Helpers.CheckedRectangleF(x + m, y + h - m - 2 * r, 2 * r, 2 * r), 90, 90)
            Else
                p.AddLine(New PointF(x + m + r, y + h - m), New PointF(x + m, y + h - m))
                p.AddLine(New PointF(x + m, y + h - m), New PointF(x + m, y + h - m - r))
            End If

            'left line
            p.AddLine(New PointF(x + m, y + h - m - r), New PointF(x + m, y + m + r))

            'close figure...
            p.CloseFigure()

            Return p
        End Function

        Public Shared Function RoundedRect(ByVal location As Point, ByVal size As Size, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, margin, roundedcorners)
        End Function

        Public Shared Function RoundedRect(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(x, y, width, height), cornerradius, margin, roundedcorners)
        End Function

        Public Shared Function RoundedRect(ByVal rect As Rectangle, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(rect.Left, rect.Top, rect.Width, rect.Height), cornerradius, margin, roundedcorners)
        End Function

        Public Shared Function RoundedRect(ByVal location As PointF, ByVal size As SizeF, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(location.X, location.Y, size.Width, size.Height), cornerradius, margin, roundedcorners)
        End Function
#End Region

#Region "Asymetric Rounded Rect"
        

        Public Shared Function RoundedRect(ByVal rect As RectangleF, ByVal cornerRadiens As CornerRadiens, ByVal margin As Padding) As Drawing2D.GraphicsPath
            Dim p As New Drawing2D.GraphicsPath
            Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height

            Dim m1 As Integer = margin.Left, m2 As Integer = margin.Top, m3 As Integer = margin.Right, m4 As Integer = margin.Bottom
            Dim r1 As Integer = cornerRadiens.TopLeft, r2 As Integer = cornerRadiens.TopRight, r3 As Integer = cornerRadiens.BottomRight, r4 As Integer = cornerRadiens.BottomLeft


            p.StartFigure()
            'top left arc
            If r1 > 0 Then
                p.AddArc(Helpers.CheckedRectangleF(x + m1, y + m2, 2 * r1, 2 * r1), 180, 90)
            End If

            'top line
            p.AddLine(New PointF(x + m1 + r1, y + m2), New PointF(x + w - m3 - r2, y + m2))

            'top right arc
            If r2 > 0 Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m3 - 2 * r2, y + m2, 2 * r2, 2 * r2), 270, 90)
            End If

            'right line
            p.AddLine(New PointF(x + w - m3, y + m2 + r2), New PointF(x + w - m3, y + h - m4 - r3))

            'bottom right arc
            If r3 > 0 Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m3 - 2 * r3, y + h - m4 - 2 * r3, 2 * r3, 2 * r3), 0, 90)
            End If

            'bottom line
            p.AddLine(New PointF(x + w - m3 - r3, y + h - m4), New PointF(x + m1 + r4, y + h - m4))

            'bottom left arc
            If r4 > 0 Then
                p.AddArc(Helpers.CheckedRectangleF(x + m1, y + h - m4 - 2 * r4, 2 * r4, 2 * r4), 90, 90)
            End If

            'left line
            p.AddLine(New PointF(x + m1, y + h - m4 - r4), New PointF(x + m1, y + m2 + r1))

            'close figure...
            p.CloseFigure()

            Return p
        End Function

        Public Shared Function RoundedRect(ByVal location As Point, ByVal size As Size, ByVal cornerRadiens As CornerRadiens, ByVal margin As Padding) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(location.X, location.Y, size.Width, size.Height), cornerRadiens, margin)
        End Function

        Public Shared Function RoundedRect(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal cornerRadiens As CornerRadiens, ByVal margin As Padding) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(x, y, width, height), cornerRadiens, margin)
        End Function

        Public Shared Function RoundedRect(ByVal rect As Rectangle, ByVal cornerRadiens As CornerRadiens, ByVal margin As Padding) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(rect.Left, rect.Top, rect.Width, rect.Height), cornerRadiens, margin)
        End Function

        Public Shared Function RoundedRect(ByVal location As PointF, ByVal size As SizeF, ByVal cornerRadiens As CornerRadiens, ByVal margin As Padding) As Drawing2D.GraphicsPath
            Return RoundedRect(Helpers.CheckedRectangleF(location.X, location.Y, size.Width, size.Height), cornerRadiens, margin)
        End Function
#End Region

#Region " geschwungen "
        Public Shared Function ConvexCorner(ByVal rect As RectangleF) As Drawing2D.GraphicsPath
            Dim p As New Drawing2D.GraphicsPath
            p.StartFigure()
            p.AddLine(rect.Left, rect.Top, rect.Width - rect.Left, rect.Top)
            p.AddBezier( _
                New PointF(rect.Width - rect.Left, rect.Top), _
                New PointF(rect.Left + CSng(rect.Width * 0.6), rect.Top + CSng(rect.Height * 0.2)), _
                New PointF(rect.Left + CSng(rect.Width * 0.2), rect.Top + CSng(rect.Height * 0.6)), _
                New PointF(rect.Left, rect.Top + rect.Height))
            p.CloseFigure()
            Return p
        End Function

#End Region

#Region "MSNLike"
        Public Shared Function MSNLike(ByVal rect As RectangleF, Optional ByVal tabwidth As Integer = 100, Optional ByVal tabheight As Integer = 20, Optional ByVal cornerradius As Integer = 5, Optional ByVal margin As Integer = 2, Optional ByVal roundedcorners As Corner = Corner.All) As Drawing2D.GraphicsPath
            Dim p As New Drawing2D.GraphicsPath
            Dim x As Single = rect.X, y As Single = rect.Y, w As Single = rect.Width, h As Single = rect.Height, m As Single = margin, r As Integer = cornerradius, tw As Integer = tabwidth, th As Integer = tabheight

            p.StartFigure()
            'top left arc
            If CBool(roundedcorners And Corner.TopLeft) Then
                p.AddArc(Helpers.CheckedRectangleF(x + m, y + m + th, 2 * r, 2 * r), 180, 90)
            Else
                p.AddLine(New PointF(x + m, y + m + r + th), New PointF(x + m, y + m + th))
                p.AddLine(New PointF(x + m, y + m + th), New PointF(x + m + r, y + m + th))
            End If

            'top line standard
            p.AddLine(New PointF(x + m + r, y + m + th), New PointF(x + w - m - tw - th, y + m + th))

            'bezier zwischen linie std und linie tab
            p.AddBezier( _
                New PointF(x + w - m - tw - th, y + m + th), _
                New PointF(x + w - m - tw, y + m + th), _
                New PointF(x + w - m - tw, y + m), _
                New PointF(x + w - m - tw + th, y + m))

            'linie tab bis ende
            p.AddLine(New PointF(x + w - m - tw + th, y + m), New PointF(x + w - m - r, y + m))

            'top right arc
            If CBool(roundedcorners And Corner.TopRight) Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m - 2 * r, y + m, 2 * r, 2 * r), 270, 90)
            Else
                p.AddLine(New PointF(x + w - m - r, y + m), New PointF(x + w - m, y + m))
                p.AddLine(New PointF(x + w - m, y + m), New PointF(x + w - m, y + m + r))
            End If

            'right line
            p.AddLine(New PointF(x + w - m, y + m + r), New PointF(x + w - m, y + h - m - r))

            'bottom right arc
            If CBool(roundedcorners And Corner.BottomRight) Then
                p.AddArc(Helpers.CheckedRectangleF(x + w - m - 2 * r, y + h - m - 2 * r, 2 * r, 2 * r), 0, 90)
            Else
                p.AddLine(New PointF(x + w - m, y + h - m - r), New PointF(x + w - m, y + h - m))
                p.AddLine(New PointF(x + w - m, y + h - m), New PointF(x + w - m - r, y + h - m))
            End If

            'bottom line
            p.AddLine(New PointF(x + w - m - r, y + h - m), New PointF(x + m + r, y + h - m))

            'bottom left arc
            If CBool(roundedcorners And Corner.BottomLeft) Then
                p.AddArc(Helpers.CheckedRectangleF(x + m, y + h - m - 2 * r, 2 * r, 2 * r), 90, 90)
            Else
                p.AddLine(New PointF(x + m + r, y + h - m), New PointF(x + m, y + h - m))
                p.AddLine(New PointF(x + m, y + h - m), New PointF(x + m, y + h - m - r))
            End If

            'left line
            p.AddLine(New PointF(x + m, y + h - m - r), New PointF(x + m, y + m + r))

            'close figure...
            p.CloseFigure()

            Return p
        End Function
#End Region
    End Class
End Namespace

