Imports System.Xml.Serialization
Imports System.IO

Namespace XML.Generic
    Public Class Serializer(Of T)

        Public Function SerializeToXML(ByVal instance As T) As String
            Dim _serializer As XmlSerializer = Nothing
            
            Try
                _serializer = New XmlSerializer(GetType(T))

                Using _stream As MemoryStream = New MemoryStream
                    _serializer.Serialize(_stream, instance)
                    _stream.Position = 0
                    Using _reader As StreamReader = New StreamReader(_stream)
                        Return _reader.ReadToEnd
                    End Using
                End Using
            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.SerializeToXMLException, GetType(T).FullName), ex)
            End Try
        End Function

        Public Function SerializeToFile(ByVal instance As T, ByVal filename As String) As Boolean
            Dim _serializer As XmlSerializer = Nothing
            Dim _fileinfo As FileInfo = Nothing

            Try
                _serializer = New XmlSerializer(GetType(T))
                _fileinfo = New FileInfo(filename)

                If _fileinfo.Exists Then _fileinfo.Delete()
                Using _filestream As FileStream = _fileinfo.Create
                    _serializer.Serialize(_filestream, instance)
                End Using

                Return True
            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.SerializeToXMLException, GetType(T).FullName), ex)
            End Try
        End Function

        Public Function SerializeToStream(ByVal instance As T) As Stream
            Dim _serializer As XmlSerializer = Nothing

            Try
                _serializer = New XmlSerializer(GetType(T))

                Using _stream As MemoryStream = New MemoryStream
                    _serializer.Serialize(_stream, instance)
                    _stream.Position = 0

                    Return New MemoryStream(_stream.ToArray)
                End Using
            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.SerializeToXMLException, GetType(T).FullName), ex)
            End Try
        End Function

        Public Function DeserializeFromXML(ByVal xml As String) As T
            Dim _serializer As XmlSerializer = Nothing

            Try
                Using _stream As MemoryStream = New MemoryStream
                    Using _writer As StreamWriter = New StreamWriter(_stream)
                        _writer.Write(xml)
                        _writer.Close()
                        Using _copy As MemoryStream = New MemoryStream(_stream.ToArray)
                            _serializer = New XmlSerializer(GetType(T))
                            Return DirectCast(_serializer.Deserialize(_copy), T)
                        End Using
                    End Using
                End Using

            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.DeserializeFromXMLException, GetType(T).FullName), ex)
            End Try
        End Function

        Public Function DeserializeFromFile(ByVal filename As String) As T
            Dim _serializer As XmlSerializer = Nothing
            Dim _fileinfo As FileInfo = Nothing

            Try
                _fileinfo = New FileInfo(filename)
                If _fileinfo.Exists Then
                    Using _stream As FileStream = _fileinfo.OpenRead
                        _serializer = New XmlSerializer(GetType(T))
                        Return DirectCast(_serializer.Deserialize(_stream), T)
                    End Using
                End If
            Catch ex As Exception
                Throw New SerializationException(String.Format(My.Resources.DeserializeFromXMLException, GetType(T).FullName), ex)
            End Try
        End Function
    End Class
End Namespace
