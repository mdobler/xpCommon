Namespace Design
    ''' <summary>
    ''' this class adds visual clues to the design-time experience with the XPTaskBox class
    ''' It provides a border and a workspace "clue".
    ''' You also need this class to add child controls to the user control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPTaskBoxDesigner
        Inherits Steepvalley.Windows.Forms.Common.BaseDesigner

        Private m_Control As XPTaskBox

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPTaskBox)
        End Sub

        Protected Overrides Sub OnPaintAdornments(ByVal pe As PaintEventArgs)
            MyBase.OnPaintAdornments(pe)
            pe.Graphics.DrawRectangle(WorkspacePen, m_Control.WorkspaceRect)
        End Sub
    End Class
End Namespace
