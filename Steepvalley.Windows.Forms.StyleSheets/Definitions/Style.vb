Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

''' <summary>
''' 
''' </summary>
''' <remarks></remarks>
<Serializable()> Public NotInheritable Class Style
    Implements IComparable

    'Private mAssemblyName As String
    Private _assembly As Reference
    Private _typeName As String = ""
    Private _properties As New ItemPropertyCollection
    Private _classID As String = ""

#Region "ctor"
    Public Sub New()
        'nothing to do
    End Sub

    Public Sub New(ByVal reference As Reference, ByVal typeName As String, Optional ByVal classID As String = "")
        _assembly = reference
        _typeName = typeName
        _classID = classID
    End Sub

    Public Sub New(ByVal reference As Reference, ByVal typeName As String, ByVal propertyCollection As ItemPropertyCollection)
        _assembly = reference
        _typeName = typeName
        _properties = propertyCollection
    End Sub

    Public Sub New(ByVal reference As Reference, ByVal typeName As String, ByVal classID As String, ByVal propertyCollection As ItemPropertyCollection)
        _assembly = reference
        _typeName = typeName
        _classID = classID
        _properties = propertyCollection
    End Sub

    Public Sub New(ByVal reference As Reference, ByVal typeName As String, ByVal ParamArray properties() As ItemProperty)
        _assembly = reference
        _typeName = typeName
        _properties.AddRange(properties)
    End Sub

    Public Sub New(ByVal reference As Reference, ByVal typeName As String, ByVal classID As String, ByVal ParamArray properties() As ItemProperty)
        _assembly = reference
        _typeName = typeName
        _classID = classID
        _properties.AddRange(properties)
    End Sub
#End Region


    ''' <summary>
    ''' the name of the containing assembly. this is needed for the 
    ''' reflection of the properties and values of the control
    ''' </summary>
    ''' <value>String</value>
    ''' <remarks>
    ''' </remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Class Information"), _
     Description("The assembly name containing the class"), _
     XmlElement("REFERENCE")> _
    Public Property Reference() As Reference
        Get
            Return _assembly
        End Get
        Set(ByVal Value As Reference)
            _assembly = Value
        End Set
    End Property

    ''' <summary>
    ''' the classes type name for reflection
    ''' </summary>
    ''' <value>the classes type name</value>
    ''' <remarks>
    ''' </remarks>
    <Browsable(True), _
     DefaultValue(""), _
     Category("Class Information"), _
     Description("The type name of the class"), _
     XmlAttribute("type")> _
    Public Property TypeName() As String
        Get
            Return _typeName
        End Get
        Set(ByVal Value As String)
            _typeName = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the classID for distinction between different formats for the same
    ''' type. Class ID = "" means that it applies to all instances of a type.
    ''' The base definition.
    ''' </summary>
    ''' <value>the classes type name</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	08.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Browsable(True), _
     DefaultValue(""), _
     Category("Class ID"), _
     Description("The Class ID (empty if base defintion"), _
     XmlAttributeAttribute("classID")> _
    Public Property ClassID() As String
        Get
            Return _classID
        End Get
        Set(ByVal Value As String)
            _classID = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' a hashtable with all the defined property-value pairs
    ''' </summary>
    ''' <value>Hashtable</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	08.06.2004	Created
    ''' </history>
    '''     ''' -----------------------------------------------------------------------------
    <Browsable(True), _
     Category("Properties"), _
     Description("The definded properties of this type"), _
     XmlArray("PROPERTIES"), _
     XmlArrayItem("PROPERTY")> _
    Public Property Properties() As ItemPropertyCollection
        Get
            Return _properties
        End Get
        Set(ByVal Value As ItemPropertyCollection)
            _properties = Value
        End Set
    End Property

    <Browsable(False), _
     XmlIgnore()> _
    Public ReadOnly Property TypeNameShort() As String
        Get
            Dim _a As String() = _typeName.Split(CChar("."))
            Return _a(_a.Length - 1)
        End Get
    End Property

    Public Overrides Function ToString() As String
        If _classID.Length = 0 Then
            Return _typeName
        Else
            Return String.Format("{0}.{1}", _typeName, _classID)
        End If
    End Function

#Region "IComparable Interface Implementations"
    Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        If TypeOf obj Is Style Then
            Return _typeName.CompareTo(CType(obj, Style).TypeName)
        End If

        Throw New ArgumentException("object is not a Style")
    End Function

    Public Overloads Function Equals(ByVal obj As Object) As Boolean
        If Not TypeOf obj Is Style Then
            Return False
        End If

        Return Me.CompareTo(obj) = 0
    End Function

    Public Overloads Function GetHashCode() As Integer
        Return _typeName.GetHashCode
    End Function
#End Region

#Region " helper functions "
    Public Function GetAvailablePropertyItems() As ItemPropertyCollection
        Return GetPropertyItemsFromType(Me, True)
    End Function

    Public Shared Function GetAvailablePropertyItems(ByVal style As Style) As ItemPropertyCollection
        Return GetPropertyItemsFromType(style, True)
    End Function

    Public Function GetAllPropertyItems() As ItemPropertyCollection
        Return GetPropertyItemsFromType(Me, False)
    End Function

    Public Shared Function GetlAllPropertyItems(ByVal style As Style) As ItemPropertyCollection
        Return GetPropertyItemsFromType(style, False)
    End Function

    Private Shared Function GetPropertyItemsFromType(ByVal style As Style, ByVal unattachedTypesOnly As Boolean) As ItemPropertyCollection
        Dim _type As Type
        Dim _assembly As Assembly
        Dim _value As String

        Dim _retval As New ItemPropertyCollection

        _assembly = AssemblyLoader.ProbeAssembly(style.Reference)
        _type = _assembly.GetType(style.TypeName)

        For Each p As PropertyInfo In _type.GetProperties
            If p.CanRead And p.CanWrite Then
                If unattachedTypesOnly = False OrElse Not style.Properties.Contains(p.Name) Then
                    Try
                        _value = ConverterHelper.ConvertToString( _
                                _type, _
                                p.Name, _
                                p.GetValue(_type.Assembly.CreateInstance(_type.FullName), Nothing))

                        _retval.Add(p.Name, _value)
                    Catch ex As Exception

                    End Try
                End If
            End If
        Next
        Return _retval
    End Function
#End Region

End Class
