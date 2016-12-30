Imports System.Xml.Serialization
Imports System.IO

Public Class OscarLoader
    Public Shared Function LoadFromFile(ByVal fileName As String) As Oscars
        If Not System.IO.File.Exists(fileName) Then Return New Oscars

        Dim objSerializer As XmlSerializer = Nothing
        Dim objFileStream As FileStream = Nothing
        Dim objFileInfo As FileInfo = Nothing

        Try
            objSerializer = New XmlSerializer(GetType(Oscars))
            objFileInfo = New FileInfo(fileName)

            If objFileInfo.Exists Then
                objFileStream = objFileInfo.OpenRead
                Return objSerializer.Deserialize(objFileStream)
            Else
                Return New Oscars
            End If

        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(String.Format("Unable to load file [{0}]", fileName))
            Return New Oscars
        Finally
            If Not (objFileStream Is Nothing) Then
                objFileStream.Close()
            End If
        End Try
    End Function

    Public Shared Function SaveToFile(ByVal fileName As String, ByVal value As Oscars) As Boolean
        Dim objSerializer As XmlSerializer = Nothing
        Dim objFileStream As FileStream = Nothing
        Dim objFileInfo As FileInfo = Nothing

        Try
            objSerializer = New XmlSerializer(GetType(Oscars))
            objFileInfo = New FileInfo(fileName)

            If objFileInfo.Exists Then objFileInfo.Delete()
            objFileStream = objFileInfo.Create

            objSerializer.Serialize(objFileStream, value)
            Return True
        Catch ex As Exception
            System.Windows.Forms.MessageBox.Show(String.Format("Unable to save file [{0}]", fileName))
            Return False
        Finally
            If Not (objFileStream Is Nothing) Then
                objFileStream.Close()
            End If
        End Try
    End Function
End Class
