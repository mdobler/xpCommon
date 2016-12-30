Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable()> Public NotInheritable Class StyleCollection
    Inherits System.Collections.Generic.List(Of Style)

    Public Overloads Sub Add(ByVal reference As Reference, ByVal typeName As String, Optional ByVal classID As String = "")
        Me.Add(New Style(reference, typeName, classID))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal typeName As String, ByVal properties As ItemPropertyCollection)
        Me.Add(New Style(reference, typeName, properties))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal typeName As String, ByVal classID As String, ByVal properties As ItemPropertyCollection)
        Me.Add(New Style(reference, typeName, classID, properties))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal typeName As String, ByVal ParamArray properties() As ItemProperty)
        Me.Add(New Style(reference, typeName, properties))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal typeName As String, ByVal classID As String, ByVal ParamArray properties() As ItemProperty)
        Me.Add(New Style(reference, typeName, classID, properties))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal type As Type)
        Me.Add(New Style(reference, type.FullName))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal type As Type, ByVal ParamArray properties() As ItemProperty)
        Me.Add(New Style(reference, type.FullName, properties))
    End Sub

    Public Overloads Sub Add(ByVal reference As Reference, ByVal type As Type, ByVal classID As String, ByVal ParamArray properties() As ItemProperty)
        Me.Add(New Style(reference, type.FullName, classID, properties))
    End Sub

    Public Overloads Function IndexOf(ByVal typeName As String) As Integer
        Dim i As Integer = 0
        Dim retval As Integer = -1

        For Each itm As Style In Me
            If itm.TypeName = typeName And itm.ClassID = "" Then
                retval = i
                Exit For
            End If
            i += 1
        Next
        Return retval
    End Function

    Public Overloads Function IndexOf(ByVal typeName As String, ByVal classID As String) As Integer
        Dim i As Integer = 0
        Dim retval As Integer = -1

        For Each itm As Style In Me
            If itm.TypeName = typeName And itm.ClassID = classID Then
                retval = i
                Exit For
            End If
            i += 1
        Next
        Return retval
    End Function

    Public Overloads Function Contains(ByVal typeName As String) As Boolean
        If Me.IndexOf(typeName) >= 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overloads Function Contains(ByVal typeName As String, ByVal classID As String) As Boolean
        If Me.IndexOf(typeName, classID) >= 0 Then
            Return True
        Else
            Return False

        End If
    End Function

    Public Overloads Function Remove(ByVal reference As Reference) As Boolean
        Dim retval As Boolean = False
        For Each itm As Style In Me
            If itm.Reference.Equals(reference) Then
                If Me.Remove(itm) Then
                    retval = True
                End If
            End If
        Next
        Return retval
    End Function

    Public Sub SortByTypeName()
        Me.Sort(New StyleComparerByName)
    End Sub

    Public Sub SortByType()
        Me.Sort(New StyleComparerByType)
    End Sub
End Class

#Region "comparer class"
Friend Class StyleComparerByName
    Implements System.Collections.Generic.IComparer(Of Style)

    Public Function Compare(ByVal x As Style, ByVal y As Style) As Integer Implements System.Collections.Generic.IComparer(Of Style).Compare
        ' Two object that are nothing equal each other. 
        If x Is Nothing AndAlso y Is Nothing Then
            Return 0
        End If

        ' Any non nothing object is greater than an object that is nothing. 
        ' If obj 1 is nothing then obj2 is greater than it. 
        If x Is Nothing And Not y Is Nothing Then
            Return 1
        End If

        ' Any non nothing object is greater than an object that is nothing. 
        ' If obj2 is nothing then obj1 is greater than it. 
        If Not x Is Nothing And y Is Nothing Then
            Return -1
        End If

        ' Once the above checks are complete we can actually do the comparison. 
        If TypeOf x Is Style And TypeOf y Is Style Then
            Return (CType(x, Style).TypeName.CompareTo(CType(y, Style).TypeName))
        End If
    End Function
End Class

Friend Class StyleComparerByType
    Implements System.Collections.Generic.IComparer(Of Style)

    Public Function Compare(ByVal x As Style, ByVal y As Style) As Integer Implements System.Collections.Generic.IComparer(Of Style).Compare
        ' Two object that are nothing equal each other. 
        If x Is Nothing AndAlso y Is Nothing Then
            Return 0
        End If

        ' Any non nothing object is greater than an object that is nothing. 
        ' If obj 1 is nothing then obj2 is greater than it. 
        If x Is Nothing And Not y Is Nothing Then
            Return 1
        End If

        ' Any non nothing object is greater than an object that is nothing. 
        ' If obj2 is nothing then obj1 is greater than it. 
        If Not x Is Nothing And y Is Nothing Then
            Return -1
        End If

        ' Once the above checks are complete we can actually do the comparison. 
        If TypeOf x Is Style And TypeOf y Is Style Then
            Dim _proxyX As New StyleProxy(CType(x, Style))
            Dim _proxyY As New StyleProxy(CType(y, Style))

            If _proxyX.Type.IsSubclassOf(_proxyY.Type) Then
                Return 1
            ElseIf _proxyY.Type.IsSubclassOf(_proxyX.Type) Then
                Return -1
            Else
                Return 0
            End If
        End If
    End Function
End Class
#End Region