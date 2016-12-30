Imports SteepValley.Windows.Forms.Graphics

Namespace Design
    ''' <summary>
    ''' a designer class for the XPLine class design-time support
    ''' </summary>
    ''' <remarks>this class draws a rectangular area around the area occupied by the line.</remarks>
    Public Class XPLineDesigner
        Inherits BaseDesigner

        Private m_Control As XPLine

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPLine)
        End Sub

        Protected Overrides Sub OnPaintAdornments(ByVal pe As PaintEventArgs)
            MyBase.OnPaintAdornments(pe)
            pe.Graphics.DrawRectangle(BorderPen, 0, 0, m_Control.Width - 1, m_Control.Height - 1)
        End Sub
    End Class
End Namespace
