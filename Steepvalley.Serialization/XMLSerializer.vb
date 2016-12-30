Imports System.Xml.Serialization
Imports System.IO

Namespace XML
    ''' <summary>
    ''' diese klasse ist Teil des Firmenframeworks und ist zuständig für die Serialisierung
    ''' und Deserialisierung von Klassen und Instanzen
    ''' </summary>
    ''' <remarks></remarks>
    Public Class Serializer
        Public Overloads Shared Function SerializeToXML(ByVal instance As Object, ByVal type As Type) As String
            Dim _serializer As XmlSerializer = Nothing
            Dim _stream As MemoryStream = Nothing
            Dim _reader As StreamReader = Nothing

            Try
                _serializer = New XmlSerializer(type)
                _stream = New MemoryStream
                _serializer.Serialize(_stream, instance)
                _stream.Position = 0
                _reader = New StreamReader(_stream)
                Return _reader.ReadToEnd

            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.SerializeToXMLException, type.FullName), ex)
            Finally
                If Not (_reader Is Nothing) Then
                    _reader.Close()
                End If
            End Try
        End Function

        Public Shared Function DeserializeFromXML(ByVal xml As String, ByVal type As Type) As Object
            Dim _serializer As XmlSerializer = Nothing
            Dim _writer As StreamWriter = Nothing
            Dim _stream As MemoryStream = Nothing

            Try
                _stream = New MemoryStream
                _writer = New StreamWriter(_stream)
                _writer.Write(xml)
                _writer.Close()
                _stream = New MemoryStream(_stream.ToArray)

                _serializer = New XmlSerializer(type)
                Return _serializer.Deserialize(_stream)

            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.DeserializeFromXMLException, type.FullName), ex)
            Finally
                If Not (_stream Is Nothing) Then
                    _stream.Close()
                End If

            End Try
        End Function
    End Class
End Namespace