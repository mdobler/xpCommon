Namespace Graphics
    ''' <summary>
    ''' this is a collection of shared methods to help drawing the controls
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Helpers
        ''' <summary>
        ''' this function returns the first non-transparent color of a control's parent(s)
        ''' loops through all parents to find the first non transparent color
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function GetNonTransparentBackColor(ByVal ctrl As Control) As Color
            Dim bc As Color, p As Control
            Try
                p = ctrl.Parent
                bc = p.BackColor
                While bc.Equals(Color.Transparent) And Not p.Parent Is Nothing
                    p = p.Parent
                    bc = p.BackColor
                End While

                If bc.Equals(Color.Transparent) Then bc = SystemColors.Control

                Return bc
            Catch ex As Exception
                Return SystemColors.Control
            End Try
        End Function

        ''' <summary>
        ''' this function returns a checked rectangle (width and height always > 1)
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <param name="width"></param>
        ''' <param name="height"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckedRectangleF(ByVal x As Single, ByVal y As Single, ByVal width As Single, ByVal height As Single) As RectangleF
            Return New RectangleF(x, y, CSng(IIf(width <= 0, 1, width)), CSng(IIf(height <= 0, 1, height)))
        End Function

        ''' <summary>
        ''' this function returns a checked rectangle (width and height always > 1)
        ''' </summary>
        ''' <param name="x"></param>
        ''' <param name="y"></param>
        ''' <param name="width"></param>
        ''' <param name="height"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function CheckedRectangle(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer) As Rectangle
            Return New Rectangle(x, y, CInt(IIf(width <= 0, 1, width)), CInt(IIf(height <= 0, 1, height)))
        End Function

        ''' <summary>
        ''' converts a rectangel structure to a RectangleF structure
        ''' </summary>
        ''' <param name="rect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertToRectangleF(ByVal rect As Rectangle) As RectangleF
            Return New RectangleF(rect.X, rect.Y, rect.Width, rect.Height)
        End Function

        ''' <summary>
        ''' converts a RectangleF structure to a rectangle structure
        ''' </summary>
        ''' <param name="rect"></param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Shared Function ConvertToRectangle(ByVal rect As RectangleF) As Rectangle
            Return New Rectangle(CInt(rect.X), CInt(rect.Y), CInt(rect.Width), CInt(rect.Height))
        End Function
    End Class
End Namespace
