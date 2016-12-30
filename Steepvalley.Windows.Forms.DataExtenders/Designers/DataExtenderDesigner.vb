Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class DataExtenderDesigner
    Inherits System.ComponentModel.Design.ComponentDesigner

    Private _component As ListViewDataExtender

    Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)
        _component = CType(Me.Component, ListViewDataExtender)
    End Sub

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Dim _verbs() As DesignerVerb = {New DesignerVerb("Retrieve Columns", AddressOf RetrieveColumnsEvent)}
            Return New DesignerVerbCollection(_verbs)
        End Get
    End Property

    Protected Sub RetrieveColumnsEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim dlg As New dlgSelectExtendedControl
        dlg.ExtendedControls = _component.ExtendedControls
        If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
            If Not dlg.SelectedControl Is Nothing Then
                _component.RetrieveColumnsFromDatasource(dlg.SelectedControl)
            End If
        End If
    End Sub
End Class
