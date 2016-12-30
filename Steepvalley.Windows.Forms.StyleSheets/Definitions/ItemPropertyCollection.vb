Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable()> Public NotInheritable Class ItemPropertyCollection
    Inherits System.Collections.Generic.List(Of ItemProperty)
    Implements ICloneable


    Public Overloads Sub Add(ByVal name As String, ByVal value As String)
        Me.Add(New ItemProperty(name, value))
    End Sub

    Public Overloads Function IndexOf(ByVal propertyName As String) As Integer
        Dim i As Integer = 0
        Dim retval As Integer = -1

        For Each itm As ItemProperty In Me
            If itm.Name = propertyName Then
                retval = i
                Exit For
            End If
            i += 1
        Next
        Return retval
    End Function

    Public Overloads Function Contains(ByVal propertyName As String) As Boolean
        If Me.IndexOf(propertyName) >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

#Region " ICloneable Interface Implementation "
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Steepvalley.Serialization.ObjectCloner.Clone(Me)
    End Function
#End Region
End Class
