Namespace Design
    ''' <summary>
    ''' this class adds visual clues to the design-time experience with the XPTaskBox class
    ''' It provides a border and a workspace "clue".
    ''' You also need this class to add child controls to the user control
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ListViewDesigner
        Inherits Steepvalley.Windows.Forms.Common.BaseDesigner

        Private m_Control As ListView

        Public Sub New()
            MyBase.New()
            MyBase.AddVerb("Clear Columns", New EventHandler(AddressOf ClearColumnsEvent))
        End Sub

        Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
            MyBase.Initialize(component)
            m_Control = CType(Me.Control, ListView)
        End Sub

        Protected Sub ClearColumnsEvent(ByVal sender As Object, ByVal e As EventArgs)
            Call m_Control.Columns.Clear()
        End Sub
    End Class
End Namespace
