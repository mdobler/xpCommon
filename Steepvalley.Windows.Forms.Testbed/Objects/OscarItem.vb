Imports System.Xml.Serialization

<Serializable()> Public Class OscarItem
    Private mMovie As String
    Private mWinner As String
    Private mCategory As String
    Private mYear As String

    Public Delegate Sub ItemChangedHandler(ByVal sender As Object, ByVal e As EventArgs)
    Public Event ItemChanged As ItemChangedHandler
    Protected Overridable Sub OnItemChanged(ByVal e As EventArgs)
        RaiseEvent ItemChanged(Me, e)
    End Sub

    Public Sub New()

    End Sub

    Public Sub New(ByVal movie As String, ByVal winner As String, ByVal category As String, ByVal year As String)
        Me.mMovie = movie
        Me.mWinner = winner
        Me.mCategory = category
        Me.mYear = year
    End Sub

    <XmlElement("MOVIE")> _
    Public Property Movie() As String
        Get
            Return mMovie
        End Get
        Set(ByVal Value As String)
            mMovie = Value
            OnItemChanged(New EventArgs)
        End Set
    End Property

    <XmlElement("WINNER")> _
    Public Property Winner() As String
        Get
            Return mWinner
        End Get
        Set(ByVal Value As String)
            mWinner = Value
            OnItemChanged(New EventArgs)
        End Set
    End Property

    <XmlElement("CATEGORY")> _
    Public Property Category() As String
        Get
            Return mCategory
        End Get
        Set(ByVal Value As String)
            mCategory = Value
            OnItemChanged(New EventArgs)
        End Set
    End Property

    <XmlElement("YEAR")> _
    Public Property Year() As String
        Get
            Return mYear
        End Get
        Set(ByVal Value As String)
            mYear = Value
            OnItemChanged(New EventArgs)
        End Set
    End Property

    Public Shadows Function ToString() As String
        Return mWinner
    End Function

    Public Function ToStringArray() As String()
        Return New String() {mMovie, mWinner, mCategory, mYear}
    End Function
End Class
