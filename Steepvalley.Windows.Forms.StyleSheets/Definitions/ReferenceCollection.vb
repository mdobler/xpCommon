Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable()> Public NotInheritable Class ReferenceCollection
    Inherits System.Collections.Generic.List(Of Reference)

    Public Overloads Sub Add(ByVal name As String, ByVal assemblyName As String, ByVal hintPath As String)
        Me.Add(New Reference(name, assemblyName, hintPath))
    End Sub

    Public Overloads Function IndexOf(ByVal name As String) As Integer
        Dim i As Integer = 0
        Dim retval As Integer = -1

        For Each itm As Reference In Me
            If itm.Name = name Then
                retval = i
                Exit For
            End If
            i += 1
        Next
        Return retval
    End Function

    Public Overloads Function Contains(ByVal name As String) As Boolean
        If Me.IndexOf(name) >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
