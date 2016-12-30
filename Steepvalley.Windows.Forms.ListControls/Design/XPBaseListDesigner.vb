Namespace Design
    ''' <summary>
    ''' this is the designer class for the XPBaseList control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPBaseListDesigner
        Inherits Steepvalley.Windows.Forms.Common.BaseDesigner

        Private m_Control As XPBaseList

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPBaseList)
        End Sub

        'Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        '    MyBase.OnPaintAdornments(pe)
        '    pe.Graphics.DrawRectangle(BorderPen, 0, 0, m_Control.Width - 1, m_Control.Height - 1)
        'End Sub
    End Class
End Namespace