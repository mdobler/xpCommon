Imports System.Reflection
Imports System.ComponentModel.Design
Imports System.ComponentModel
Imports System.IO

''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.ItemPropertyDescriptor
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class is used by the proxy class as property descriptor to fool 
''' the property grid. this class allows the property grid to set the values of
''' the properties defined in the style-class instead of the properties available
''' in the proxy class
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	02.07.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Friend NotInheritable Class ItemPropertyDescriptor
    Inherits PropertyDescriptor

    Private _style As Style
    Private _item As ItemProperty
    Private _proxy As StyleProxy
    Private _baseDescriptor As PropertyDescriptor

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' initialize the class with all the information of the current style and current 
    ''' item property to set
    ''' </summary>
    ''' <param name="style"></param>
    ''' <param name="item"></param>
    ''' <param name="attrs"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByRef style As Style, ByRef item As ItemProperty, ByVal attrs() As Attribute)
        MyBase.New(item.Name, attrs)

        _style = style
        _item = item
        _proxy = New StyleProxy(_style)

        _baseDescriptor = TypeDescriptor.GetProperties(_proxy.Type).Find(_item.Name, True)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' cannot reset a value
    ''' </summary>
    ''' <param name="component"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
        Return False
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the type defined in the style class (not the style type!)
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property ComponentType() As System.Type
        Get
            Return _proxy.Type
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the value of the defined property item
    ''' </summary>
    ''' <param name="component"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Function GetValue(ByVal component As Object) As Object
        Return _proxy.GetValue(_item)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the readonly flag of the underlying defined class of the property item
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property IsReadOnly() As Boolean
        Get
            Return _baseDescriptor.IsReadOnly
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the type of the current defined property of the style class
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property PropertyType() As System.Type
        Get
            Return _proxy.PropertyType(_item)
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' do nothing
    ''' </summary>
    ''' <param name="component"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub ResetValue(ByVal component As Object)

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the value of the defined property item in the style class
    ''' </summary>
    ''' <param name="component"></param>
    ''' <param name="value"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
        _proxy.SetValue(_item, value)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="component"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
        Return False
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying category of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property Category() As String
        Get
            Return _baseDescriptor.Category()
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying converter of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property Converter() As System.ComponentModel.TypeConverter
        Get
            Return _baseDescriptor.Converter
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying description of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property Description() As String
        Get
            Return _baseDescriptor.Description
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying design time flag of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property DesignTimeOnly() As Boolean
        Get
            Return _baseDescriptor.DesignTimeOnly
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying display name of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property DisplayName() As String
        Get
            Return _baseDescriptor.DisplayName
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying editor for the defined property type
    ''' </summary>
    ''' <param name="editorBaseType"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides Function GetEditor(ByVal editorBaseType As System.Type) As Object
        Return _baseDescriptor.GetEditor(editorBaseType)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying browsable flag of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property IsBrowsable() As Boolean
        Get
            Return _baseDescriptor.IsBrowsable
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying localizable-flag of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property IsLocalizable() As Boolean
        Get
            Return _baseDescriptor.IsLocalizable
        End Get
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying child properties of the defined property type
    ''' </summary>
    ''' <param name="instance"></param>
    ''' <param name="filter"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Overrides Function GetChildProperties(ByVal instance As Object, ByVal filter() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection
        Return _baseDescriptor.GetChildProperties(instance, filter)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns the underlying attributes of the defined property type
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.07.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overrides ReadOnly Property Attributes() As System.ComponentModel.AttributeCollection
        Get
            Return _baseDescriptor.Attributes
        End Get
    End Property
End Class
