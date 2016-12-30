Imports System.Reflection
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.IO


''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.StyleProxy
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' diese klasse dient als proxy fuer den style, d.h. es handelt alle typeninfos
''' propertyinfos usw... fuer den style ab. im style sind nur die definitionen ge-
''' speichert. der Zugriff erfolgt immer ueber die proxyklasse
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	02.07.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Friend NotInheritable Class StyleProxy
    Private _style As Style
    Private _assembly As [Assembly]
    Private _type As Type

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' erzeugt aus dem angegebenen style alle infos zu assembly und typ
    ''' </summary>
    ''' <param name="style"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByRef style As Style)
        _style = style

        Try
            _assembly = AssemblyLoader.ProbeAssembly(_style.Reference)
            _type = _assembly.GetType(_style.TypeName)
        Catch ex As AssemblyLoaderException
            'TODO: error handlers...
        End Try
    End Sub

#Region "type info"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' readonly zugriff auf das assembly des styles
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Friend ReadOnly Property [Assembly]() As [Assembly]
        Get
            Return _assembly
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' readonly zugriff auf den typ des styles
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Friend ReadOnly Property [Type]() As System.Type
        Get
                Return _type
        End Get
    End Property
#End Region

#Region "PropertyInfo"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns an object of "type" that represents the value of its
    ''' string representation in the itemproperty collection
    ''' </summary>
    ''' <param name="index">the index of the property</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetValue(ByVal index As Integer) As Object
        Dim _prop As ItemProperty

        Try
            _prop = _style.Properties(index)
            Return TypeDescriptor.GetConverter( _
                    _type.GetProperty(_prop.Name).PropertyType).ConvertFromString( _
                    _prop.Value)
        Catch ex As NotSupportedException
            Return Nothing
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns an object of "type" that represents the value of its
    ''' string representation in the itemproperty collection
    ''' </summary>
    ''' <param name="item">the itemproperty</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetValue(ByVal item As ItemProperty) As Object
        Return GetValue(_style.Properties.IndexOf(item))
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns an object of "type" that represents the value of its
    ''' string representation in the itemproperty collection
    ''' </summary>
    ''' <param name="name">the name of the property</param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function GetValue(ByVal name As String) As Object
        Return GetValue(_style.Properties.IndexOf(name))
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the object value (converted to string) for the item property
    ''' </summary>
    ''' <param name="index">the item property to set</param>
    ''' <param name="value">the object value to convert</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetValue(ByVal index As Integer, ByVal value As Object)
        Dim _prop As ItemProperty

        Try
            _prop = _style.Properties(index)
            _style.Properties.Item(index).Value = TypeDescriptor.GetConverter(Me.PropertyType(index)).ConvertToString(value)
        Catch ex As NotSupportedException

        End Try
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the objects value (converted to string) for the item property
    ''' </summary>
    ''' <param name="item">the item property to set</param>
    ''' <param name="value">the object value to convert</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetValue(ByVal item As ItemProperty, ByVal value As Object)
        Call SetValue(_style.Properties.IndexOf(item), value)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the objects value (converted to string) for the item property
    ''' </summary>
    ''' <param name="name">the name of the property to set</param>
    ''' <param name="value">the object value to convert</param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetValue(ByVal name As String, ByVal value As Object)
        Call SetValue(_style.Properties.IndexOf(name), value)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the system type of the requestet property item
    ''' </summary>
    ''' <param name="index"></param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property PropertyType(ByVal index As Integer) As System.Type
        Get
            Try
                If index >= _style.Properties.Count Or index < 0 Then Return Nothing

                Dim _info As PropertyInfo
                _info = _type.GetProperty(_style.Properties(index).Name)
                If Not _info Is Nothing Then
                    Return _info.PropertyType
                Else
                    Return Nothing
                End If
            Catch ex As AmbiguousMatchException
                Return Nothing
            End Try
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the system type of the requestet property item
    ''' 
    ''' </summary>
    ''' <param name="item"></param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property PropertyType(ByVal item As ItemProperty) As System.Type
        Get
            Return PropertyType(_style.Properties.IndexOf(item))
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the system type of the requestet property item
    ''' 
    ''' </summary>
    ''' <param name="name"></param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property PropertyType(ByVal name As String) As System.Type
        Get
            Return PropertyType(_style.Properties.IndexOf(name))
        End Get
    End Property
#End Region

#Region "PropertyDescriptors"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this returns an array of property descriptors not of the current class
    ''' but of the defined properties of the style - this fools the property
    ''' grid to display these instead of the real properties of the proxy class
    ''' </summary>
    ''' <param name="attributes"></param>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public ReadOnly Property PropertyDescriptors(ByVal attributes() As System.Attribute) As PropertyDescriptorCollection
        Get
            Dim _list As New ArrayList

            For Each item As ItemProperty In _style.Properties
                _list.Add(New ItemPropertyDescriptor(_style, item, attributes))
            Next

            Return New PropertyDescriptorCollection(CType( _
                        _list.ToArray(GetType(PropertyDescriptor)), _
                        PropertyDescriptor()))            
        End Get
    End Property
#End Region

End Class


