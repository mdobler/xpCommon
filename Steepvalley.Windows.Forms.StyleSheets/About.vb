Imports System.Reflection
Imports System.Globalization

Friend Class About
    Inherits System.Windows.Forms.Form

    Private Sub About_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DisplayInfo()
        llSteepvalley.Links.Clear()
        llSteepvalley.Links.Add(0, llSteepvalley.Text.Length, "http://www.steepvalley.net/controls/controls.htm")
    End Sub

    Private Sub DisplayInfo()
        Me.tbAppname.Text = My.Application.Info.Title
        Me.tbVersion.Text = String.Format("Version {0}", My.Application.Info.Version)
        Me.tbCompany.Text = My.Application.Info.CompanyName
        Me.tbDescription.Text = My.Application.Info.Description

    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub llSteepvalley_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llSteepvalley.LinkClicked
        Dim target As String = CType(e.Link.LinkData, String)
        System.Diagnostics.Process.Start(target)
    End Sub
End Class
