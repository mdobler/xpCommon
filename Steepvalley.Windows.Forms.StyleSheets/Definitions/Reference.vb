Imports System.ComponentModel
Imports System.Xml.Serialization
Imports System.Reflection
Imports System.IO

''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.AssemblyInfo
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' diese klasse speichert die notwendigen infos zum assembly ab, um
''' es wieder instanzieren zu koennen
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	01.07.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
<Serializable()> Public NotInheritable Class Reference
    Private mName As String = ""
    Private mAssemblyName As String = ""
    Private mHintPath As String = ""

#Region "ctor"
    Public Sub New()
        '...
    End Sub

    Public Sub New(ByVal name As String, ByVal assemblyName As String, ByVal hintPath As String)
        mName = name
        mAssemblyName = assemblyName
        mHintPath = hintPath
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' erzeugt ein objekt ueber die infos aus dem assembly
    ''' </summary>
    ''' <param name="a"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal a As [Assembly])
        Me.New(a.GetName.Name, a.GetName.FullName, a.Location)
    End Sub
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' der einfache name des assemblies ("System.Windows.Forms")
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	01.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <XmlAttributeAttribute("name")> _
    Public Property Name() As String
        Get
            Return mName
        End Get
        Set(ByVal Value As String)
            mName = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' der volle Name (inkl. Version, ...) wie von AssemblyName.AssemblyName
    ''' zurueckgegeben wird
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	01.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <XmlElement("AssemblyName")> _
    Public Property AssemblyName() As String
        Get
            Return mAssemblyName
        End Get
        Set(ByVal Value As String)
            mAssemblyName = Value
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' der volle pfad zur assemblydatei ("c:\programme\...\myassembly.dll")
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	01.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <XmlElement("HintPath")> _
    Public Property HintPath() As String
        Get
            Return mHintPath
        End Get
        Set(ByVal Value As String)
            mHintPath = Value
        End Set
    End Property
End Class

