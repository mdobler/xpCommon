Namespace Design
    ''' <summary>
    ''' the designer for the XPOutlookPane
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPOutlookPaneDesigner
        Inherits BaseDesigner

        Private m_Control As XPOutlookPane

        Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPOutlookPane)
        End Sub

        Protected Overrides Sub OnPaintAdornments(ByVal pe As PaintEventArgs)
            MyBase.OnPaintAdornments(pe)
            pe.Graphics.DrawRectangle(BorderPen, 0, 0, m_Control.Width - 1, m_Control.Height - 1)
            pe.Graphics.DrawRectangle(WorkspacePen, m_Control.WorkspaceRect)
        End Sub
    End Class
End Namespace