Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Reflection


''' -----------------------------------------------------------------------------
''' Project	 : Steepvalley.Windows.Forms.StyleSheets
''' Class	 : Windows.Forms.StyleSheets.StyleProxy
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' this class is used as proxy for all properties that were added to the
''' style class. this class can then be used to display these properties in
''' the property grid
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	21.06.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Friend NotInheritable Class StyleTypeDescriptor
    Implements ICustomTypeDescriptor

    Private mStyleProxy As StyleProxy

    Public Sub New()

    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' class must be instantiated with a style definition!
    ''' </summary>
    ''' <param name="style"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	21.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub New(ByVal style As StyleProxy)
        Me.Style = style
    End Sub

    Public Property Style() As StyleProxy
        Get
            Return mStyleProxy
        End Get
        Set(ByVal Value As StyleProxy)
            mStyleProxy = Value
        End Set
    End Property

#Region "Interface ICustomTypeDescriptor"
    Public Function GetAttributes() As System.ComponentModel.AttributeCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetAttributes
        Return TypeDescriptor.GetAttributes(Me, True)
    End Function

    Public Function GetClassName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetClassName
        Return TypeDescriptor.GetClassName(Me, True)
    End Function

    Public Function GetComponentName() As String Implements System.ComponentModel.ICustomTypeDescriptor.GetComponentName
        Return TypeDescriptor.GetComponentName(Me, True)
    End Function

    Public Function GetConverter() As System.ComponentModel.TypeConverter Implements System.ComponentModel.ICustomTypeDescriptor.GetConverter
        Return TypeDescriptor.GetConverter(Me, True)
    End Function

    Public Function GetDefaultEvent() As System.ComponentModel.EventDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultEvent
        Return TypeDescriptor.GetDefaultEvent(Me, True)
    End Function

    Public Function GetDefaultProperty() As System.ComponentModel.PropertyDescriptor Implements System.ComponentModel.ICustomTypeDescriptor.GetDefaultProperty
        Return Nothing
    End Function

    Public Function GetEditor(ByVal editorBaseType As System.Type) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetEditor
        Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
    End Function

    Public Overloads Function GetEvents() As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, True)
    End Function

    Public Overloads Function GetEvents(ByVal attributes() As System.Attribute) As System.ComponentModel.EventDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetEvents
        Return TypeDescriptor.GetEvents(Me, attributes, True)
    End Function

    Public Overloads Function GetProperties() As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        Dim a(0) As System.Attribute
        Return CType(Me, ICustomTypeDescriptor).GetProperties(a)
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this function must return a collection of the defined "styled" properties
    ''' </summary>
    ''' <param name="attributes"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	21.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Overloads Function GetProperties(ByVal attributes() As System.Attribute) As System.ComponentModel.PropertyDescriptorCollection Implements System.ComponentModel.ICustomTypeDescriptor.GetProperties
        'check if style is set
        If mStyleProxy Is Nothing Then Return Nothing

        'get the properties for the current defined type
        Return mStyleProxy.PropertyDescriptors(attributes)
    End Function

    Public Function GetPropertyOwner(ByVal pd As System.ComponentModel.PropertyDescriptor) As Object Implements System.ComponentModel.ICustomTypeDescriptor.GetPropertyOwner
        Return Me
    End Function
#End Region

End Class
