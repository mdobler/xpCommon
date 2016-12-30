Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable(), XmlRoot("OSCARS")> Public Class OscarCollection
    Inherits System.Collections.CollectionBase

    Public Delegate Sub CollectionChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event CollectionChanged As CollectionChangedHandler
    Protected Overridable Sub OnCollectionChanged(ByVal e As EventArgs)
        RaiseEvent CollectionChanged(Me, e)
    End Sub

    Default Public Property Item(ByVal index As Integer) As OscarItem
        Get
            Return CType(List(index), OscarItem)
        End Get
        Set(ByVal Value As OscarItem)
            List(index) = Value
        End Set
    End Property

    Public Function Add(ByVal value As OscarItem) As Integer
        AddHandler value.ItemChanged, AddressOf ItemChangedHandler

        Return List.Add(value)
        OnCollectionChanged(New EventArgs)
    End Function

    Public Function Add(ByVal movie As String, ByVal winner As String, ByVal category As String, ByVal year As String) As Integer
        Return Me.Add(New OscarItem(movie, winner, category, year))
    End Function

    Public Sub AddRange(ByVal ParamArray properties() As OscarItem)
        For Each itm As OscarItem In properties
            Me.Add(itm)
        Next
        OnCollectionChanged(New EventArgs)
    End Sub

    Public Function IndexOf(ByVal value As OscarItem) As Integer
        Return List.IndexOf(value)
    End Function

    Public Sub Insert(ByVal index As Integer, ByVal value As OscarItem)
        AddHandler value.ItemChanged, AddressOf ItemChangedHandler
        List.Insert(index, value)
        OnCollectionChanged(New EventArgs)
    End Sub

    Public Sub Remove(ByVal value As OscarItem)
        RemoveHandler value.ItemChanged, AddressOf ItemChangedHandler
        List.Remove(value)
        OnCollectionChanged(New EventArgs)
    End Sub

    Public Function Contains(ByVal value As OscarItem) As Boolean
        Return List.Contains(value)
    End Function

    Public Sub CopyTo(ByVal array() As OscarItem, ByVal index As Integer)
        Me.List.CopyTo(array, index)
    End Sub

    Private Sub ItemChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
        OnCollectionChanged(e)
    End Sub
End Class
