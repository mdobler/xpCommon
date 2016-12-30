Imports System.Reflection
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.IO

''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.AssemblyLoader
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class tries to load an assembly by its global cache name, then by
''' its name in the application folder, in the bin folder or from the location
''' where it was first loaded from.
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	02.07.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public NotInheritable Class AssemblyLoader
    Public Shared Function ProbeAssembly(ByVal reference As Reference, Optional ByVal applicationPath As String = "") As [Assembly]
        'wenn kein pfad mitangegeben, dann versuchen, den pfad der calling assembly
        'festzustellen
        If applicationPath = "" Then
            applicationPath = AppDomain.CurrentDomain.BaseDirectory
        End If


        Try
            'suche im GAC
            Return [Assembly].Load(reference.AssemblyName)
        Catch fex As FileNotFoundException
            Try
                If File.Exists(Path.Combine(applicationPath, Path.GetFileName(reference.HintPath))) Then
                    Return [Assembly].LoadFrom(Path.Combine(Path.Combine(applicationPath, "bin"), Path.GetFileName(reference.HintPath)))
                ElseIf File.Exists(Path.Combine(Path.Combine(applicationPath, "bin"), Path.GetFileName(reference.HintPath))) Then
                    Return [Assembly].LoadFrom(Path.Combine(Path.Combine(applicationPath, "bin"), Path.GetFileName(reference.HintPath)))
                ElseIf File.Exists(reference.HintPath) Then
                    Return [Assembly].LoadFrom(reference.HintPath)
                Else
                    Throw New AssemblyLoaderException(String.Format("Assembly {0} not found", reference.AssemblyName))
                End If
            Catch biex As BadImageFormatException
                Throw New AssemblyLoaderException(String.Format("Could not load Assembly {0} because file is not a .net assembly", reference.AssemblyName), biex)
            Catch sex As System.Security.SecurityException
                Throw New AssemblyLoaderException(String.Format("Could not load Assembly {0} because of security problems", reference.AssemblyName), sex)
            End Try
        Catch biex As BadImageFormatException
            Throw New AssemblyLoaderException(String.Format("Could not load Assembly {0} because file is not a .net assembly", reference.AssemblyName), biex)
        Catch sex As System.Security.SecurityException
            Throw New AssemblyLoaderException(String.Format("Could not load Assembly {0} because of security problems", reference.AssemblyName), sex)
        End Try
    End Function
End Class

<Serializable()> _
Public NotInheritable Class AssemblyLoaderException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub

    Public Sub New(ByVal message As String, ByVal innerException As Exception)
        MyBase.New(message, innerException)
    End Sub

    Private Sub New(ByVal info As System.runtime.Serialization.SerializationInfo, ByVal context As System.Runtime.Serialization.StreamingContext)
        MyBase.New(info, context)
    End Sub
End Class
