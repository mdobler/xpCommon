Imports System.ComponentModel
Imports System.ComponentModel.Design

Public Class StyleSheetExtenderDesigner
    Inherits System.ComponentModel.Design.ComponentDesigner

    Protected m_Verbs As New DesignerVerbCollection
    Protected m_Extender As StyleSheetExtender

    Public Sub New()
        m_Verbs.Add(New DesignerVerb("About", New EventHandler(AddressOf AboutEvent)))
        m_Verbs.Add(New DesignerVerb("Save Current Style", New EventHandler(AddressOf SaveCurrentStyleEvent)))
    End Sub

    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Return m_Verbs
        End Get
    End Property

    Protected Sub AboutEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim d As New About
        d.ShowDialog()
        d.Dispose()
    End Sub

    Protected Sub SaveCurrentStyleEvent(ByVal sender As Object, ByVal e As EventArgs)
        If Not m_Extender Is Nothing Then
            m_Extender.SaveCurrentStyle()
        End If
    End Sub

    Public Overrides Sub Initialize(ByVal component As System.ComponentModel.IComponent)
        MyBase.Initialize(component)
        m_Extender = CType(Me.Component, StyleSheetExtender)
    End Sub
End Class
