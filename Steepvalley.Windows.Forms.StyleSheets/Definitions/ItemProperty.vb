Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable()> Public NotInheritable Class ItemProperty
    
    Private mName As String
    Private mValue As String

    <XmlAttributeAttribute("name")> _
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
                mName = Value
            
        End Set
    End Property

    <XmlAttributeAttribute("value")> _
    Public Property Value() As String
        Get
            Return mValue
        End Get
        Set(ByVal Value As String)
                mValue = Value

        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal name As String, ByVal value As String)
        mName = name
        mValue = value
    End Sub
End Class
