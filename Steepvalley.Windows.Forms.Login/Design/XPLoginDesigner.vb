Namespace Design
    ''' <summary>
    ''' this is the designer class for the XPBaseList control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPLoginDesigner
        Inherits Steepvalley.Windows.Forms.Common.BaseDesigner

        Private m_Control As XPLogin

        Public Sub New()
            MyBase.New()
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, XPLogin)
        End Sub

        'Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        '    MyBase.OnPaintAdornments(pe)
        'End Sub

    End Class


End Namespace