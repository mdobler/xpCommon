Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

<Serializable(), XmlRoot("WINFORM_STYLESHEET")> Public NotInheritable Class StyleSheet
    Implements ICloneable, INotifyPropertyChanged

    Private mFilename As String = ""
    Private mName As String = ""
    Private mDescription As String = ""
    Private mAuthor As String = ""
    Private mDate As Date = Date.Today
    Private mStyles As New StyleCollection

    Private Shared mSerializer As New Steepvalley.Serialization.XML.Generic.Serializer(Of StyleSheet)

#Region " Public Properties "
    ''' <summary>
    ''' the stylesheet's filename
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Stylesheet Info"), _
     Description("The Stylesheet's Filename"), _
     XmlIgnore()> _
    Public Property Filename() As String
        Get
            Return mFilename
        End Get
        Set(ByVal value As String)
            If Not value.Equals(mFilename) Then
                mFilename = value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Filename"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' the stylesheet's name (for display reasons)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Stylesheet Info"), _
     Description("The Stylesheet's name"), _
     XmlElement("NAME")> _
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            If Not Value.Equals(mName) Then
                mName = Value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Name"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' a description of this stylesheet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Stylesheet Info"), _
     Description("a description of the stylesheet"), _
     XmlElement("DESCRIPTION")> _
    Public Property Description() As String
        Get
            Return mDescription
        End Get
        Set(ByVal Value As String)
            If Not Value.Equals(mDescription) Then
                mDescription = Value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Description"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' the author's name of this stylesheet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Stylesheet Info"), _
     Description("the author of the stylesheet"), _
     XmlElement("AUTHOR")> _
    Public Property Author() As String
        Get
            Return mAuthor
        End Get
        Set(ByVal Value As String)
            If Not Value.Equals(mAuthor) Then
                mAuthor = Value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Author"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' last edited date
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
         Category("Stylesheet Info"), _
         Description("last edited date"), _
     XmlElement("LAST_EDITED")> _
    Public Property LastEdited() As Date
        Get
            Return mDate
        End Get
        Set(ByVal Value As Date)
            If Not Value.Equals(mDate) Then
                mDate = Value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Date"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' a collection of styles in this stylesheet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Styles"), _
     Description("The styles of this stylesheet"), _
     XmlArray("STYLES"), _
     XmlArrayItem("STYLE")> _
    Public Property Styles() As StyleCollection
        Get
            Return mStyles
        End Get
        Set(ByVal Value As StyleCollection)
            If Not Value.Equals(mStyles) Then
                mStyles = Value
                RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs("Styles"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' The references contained in this stylesheet
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("References"), _
     Description("The references contained in this stylesheet"), _
     XmlArray("REFERENCES"), _
     XmlArrayItem("REFERENCE")> _
   Public ReadOnly Property References() As ReferenceCollection
        Get
            Dim ref As New ReferenceCollection
            For Each s As Style In mStyles
                If Not ref.Contains(s.Reference) Then
                    ref.Add(s.Reference)
                End If
            Next

            Return ref
        End Get
    End Property
#End Region

#Region " functions to build up tree "
    Friend Function GetAssemblyNames() As Generic.Dictionary(Of String, String)
        Dim _retval As New Generic.Dictionary(Of String, String)

        For Each s As Style In mStyles
            If Not _retval.ContainsKey(s.Reference.AssemblyName) Then
                _retval.Add(s.Reference.AssemblyName, s.Reference.Name)
            End If
        Next

        Return _retval
    End Function

    Friend Function GetTypeNames(ByVal assembly As String) As Generic.Dictionary(Of String, String)
        Dim _retval As New Generic.Dictionary(Of String, String)

        For Each s As Style In mStyles
            If s.Reference.AssemblyName = assembly And s.ClassID = "" Then
                If Not _retval.ContainsKey(s.TypeName) Then
                    _retval.Add(s.TypeName, s.TypeNameShort)
                End If
            End If
        Next

        Return _retval
    End Function

    Friend Function GetTypeClassNames(ByVal assembly As String, ByVal type As String) As Generic.Dictionary(Of String, String)
        Dim _retval As New Generic.Dictionary(Of String, String)

        For Each s As Style In mStyles
            If s.Reference.AssemblyName = assembly And s.TypeName = type And s.ClassID.Length > 0 Then
                If Not _retval.ContainsKey(String.Format("{0}.{1}", s.TypeName, s.ClassID)) Then
                    _retval.Add(String.Format("{0}.{1}", s.TypeName, s.ClassID), s.ClassID)
                End If
            End If
        Next

        Return _retval
    End Function
#End Region

#Region " Serialization (XML) "
    Public Function ToXML() As String
        Return mSerializer.SerializeToXML(Me)
    End Function

    Public Function ToXML(ByVal filename As String) As Boolean
        Return mSerializer.SerializeToFile(Me, filename)
    End Function

    Public Shared Function ToXML(ByVal instance As StyleSheet) As String
        Return mSerializer.SerializeToXML(instance)
    End Function

    Public Shared Function ToXML(ByVal instance As StyleSheet, ByVal filename As String) As Boolean
        Return mSerializer.SerializeToFile(instance, filename)
    End Function

    Public Function ToXMLStream() As System.IO.Stream
        Return mSerializer.SerializeToStream(Me)
    End Function

    Public Shared Function ToXMLStream(ByVal instance As StyleSheet) As System.IO.Stream
        Return mSerializer.SerializeToStream(instance)
    End Function

    Public Shared Function FromXML(ByVal xml As String) As StyleSheet
        Return mSerializer.DeserializeFromXML(xml)
    End Function

    Public Shared Function FromXMLFile(ByVal filename As String) As StyleSheet
        Return mSerializer.DeserializeFromFile(filename)
    End Function
#End Region

#Region " ICloneable Interface Implementations "
    Public Function Clone() As Object Implements System.ICloneable.Clone
        Return Steepvalley.Serialization.ObjectCloner.Clone(Me)
    End Function
#End Region

#Region " INotifyPropertyChanged Interface Implementations "
    Public Event PropertyChanged(ByVal sender As Object, ByVal e As System.ComponentModel.PropertyChangedEventArgs) Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
#End Region
End Class
