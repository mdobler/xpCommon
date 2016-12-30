Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary

Public Class ObjectCloner
    ''' <summary>
    ''' Clones an object by using the
    ''' <see cref="BinaryFormatter" />.
    ''' </summary>
    ''' <param name="obj">The object to clone.</param>
    ''' <remarks>
    ''' The object to be cloned must be serializable.
    ''' [This code is copied from R. Lhotka's CSLA Project at http://www.lhotka.net]
    ''' </remarks>
    Public Shared Function Clone(ByVal obj As Object) As Object
        Using buffer As New MemoryStream()
            Dim formatter As New BinaryFormatter()

            formatter.Serialize(buffer, obj)
            buffer.Position = 0
            Dim temp As Object = formatter.Deserialize(buffer)
            Return temp
        End Using
    End Function
End Class
