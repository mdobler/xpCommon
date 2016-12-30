Imports System.Reflection
Imports System.ComponentModel

''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.ConverterHelper
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class helps converting values from and to string
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	02.07.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class ConverterHelper
    ''' <summary>
    ''' returns a string from an object defined by assembly and type
    ''' </summary>
    ''' <param name="reference"></param>
    ''' <param name="typeName"></param>
    ''' <param name="propertyName"></param>
    ''' <param name="propertyValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertToString(ByVal reference As Reference, ByVal typeName As String, ByVal propertyName As String, ByVal propertyValue As Object) As String
        Try
            Dim _assembly As [Assembly] = AssemblyLoader.ProbeAssembly(reference)
            Dim _type As Type = _assembly.GetType(typeName)
            Dim _propType As Type = _type.GetProperty(propertyName).PropertyType

            Return TypeDescriptor.GetConverter(_propType).ConvertToString(propertyValue)
        Catch ex As NotSupportedException
            Return Nothing
        End Try
    End Function

    Public Shared Function ConvertToString(ByVal [type] As Type, ByVal propertyName As String, ByVal propertyValue As Object) As String
        Try
            Dim _propType As type = type.GetProperty(propertyName).PropertyType

            Return TypeDescriptor.GetConverter(_propType).ConvertToString(propertyValue)
        Catch ex As NotSupportedException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' returns an object of type from a string representation
    ''' </summary>
    ''' <param name="reference"></param>
    ''' <param name="typeName"></param>
    ''' <param name="propertyName"></param>
    ''' <param name="propertyValue"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function ConvertFromString(ByVal reference As Reference, ByVal typeName As String, ByVal propertyName As String, ByVal propertyValue As String) As Object
        Try
            Dim _assembly As [Assembly] = AssemblyLoader.ProbeAssembly(reference)
            Dim _type As Type = _assembly.GetType(typeName)
            Dim _propType As Type = _type.GetProperty(propertyName).PropertyType

            Return TypeDescriptor.GetConverter(_propType).ConvertFromString(propertyValue)
        Catch ex As NotSupportedException
            Return Nothing
        End Try
    End Function
End Class
