Imports System.CodeDom
Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.ComponentModel.Design.Serialization
Imports System.Windows.Forms
Imports System.Windows.Forms.Design

<TypeConverter(GetType(testConverter))> _
Public Class test
    Public Name As String
    Public Value As String

End Class


Public Class testCollection
    Inherits System.Collections.Generic.List(Of test)

End Class

Public Class testConverter
    Inherits ExpandableObjectConverter

    ''' <summary>
    ''' if the destination type is of Instance Descriptor, the designer is calling
    ''' to serialize this to code
    ''' </summary>
    Public Overloads Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
        If destinationType Is GetType(InstanceDescriptor) Then
            Return True
        End If
        Return MyBase.CanConvertTo(context, destinationType)
    End Function

    ''' <summary>
    ''' this function must return the constructor with the correct constructor signature
    ''' you wish to serialize
    ''' in my case i wish to serialze to the constructor:
    ''' Public Sub New(ByVal imageIndex As Integer)
    ''' of my BindableColumnHeader-object
    ''' </summary>
    ''' -----------------------------------------------------------------------------
    Public Overloads Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
        If destinationType Is GetType(InstanceDescriptor) Then
            ''parameter signature of my constructor
            'Dim signature As Type() = {GetType(Integer)}
            ''get the current objects values
            'Dim itm As BindableColumnHeader = CType(value, BindableColumnHeader)
            ''create an object array of the constructor parameter values
            'Dim args As Object() = {itm.ImageIndex} 'itm.Text, itm.DataPropertyName
            ''return an instance descriptor with signature and parameter values
            'Return New InstanceDescriptor(GetType(BindableColumnHeader).GetConstructor(signature), args, False)


            Return New InstanceDescriptor(GetType(test).GetConstructor(New Type() {}), Nothing, False)


        End If
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class


Public Class testCollectionEditor
    Inherits System.ComponentModel.Design.CollectionEditor

    Public Sub New()
        MyBase.New(GetType(testCollection))
    End Sub

    Protected Overrides Function CreateInstance(ByVal itemType As System.Type) As Object
        Return New test
    End Function

    Protected Overrides Function CreateCollectionItemType() As System.Type
        Return GetType(test)
    End Function
End Class