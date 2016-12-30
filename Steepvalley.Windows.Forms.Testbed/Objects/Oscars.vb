Imports System.Xml.Serialization

<Serializable(), XmlRoot("OSCARS")> Public Class Oscars
    Private WithEvents mOscarCollection As New OscarCollection
    Private mFilename As String = ""
    Private mDirtyFlag As Boolean = False

    Public Delegate Sub ContentChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ContentChanged As ContentChangedHandler
    Protected Overridable Sub OnContentChanged(ByVal e As EventArgs)
        RaiseEvent ContentChanged(Me, e)
    End Sub

    <XmlIgnore()> Public Property Filename() As String
        Get
            Return mFilename
        End Get
        Set(ByVal Value As String)
            mFilename = Value
            OnContentChanged(New EventArgs)
        End Set
    End Property

    <XmlIgnore()> Public Property DirtyFlag() As Boolean
        Get
            Return mDirtyFlag
        End Get
        Set(ByVal Value As Boolean)
            mDirtyFlag = Value
            OnContentChanged(New EventArgs)
        End Set
    End Property

    <XmlArray("ITEMS"), XmlArrayItem("ITEM")> Public Property Items() As OscarCollection
        Get
            Return mOscarCollection
        End Get
        Set(ByVal Value As OscarCollection)
            mOscarCollection = Value
            OnContentChanged(New EventArgs)
        End Set
    End Property

    Private Sub mOscarCollection_CollectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mOscarCollection.CollectionChanged
        Me.DirtyFlag = True
    End Sub
End Class
