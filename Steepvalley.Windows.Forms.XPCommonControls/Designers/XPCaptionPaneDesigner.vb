Namespace Design
    ''' <summary>
    ''' the designer for the XPCaptionPane Control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPCaptionPaneDesigner
        Inherits Steepvalley.Windows.Forms.Common.BaseDesigner

        Private m_Control As XPCaptionPane

        Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPCaptionPane)
        End Sub

        Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
            MyBase.OnPaintAdornments(pe)
        End Sub

    End Class
End Namespace