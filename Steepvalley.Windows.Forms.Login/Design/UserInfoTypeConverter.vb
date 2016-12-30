Imports System.ComponentModel.Design.Serialization
Imports System.Reflection

Public Class UserInfoTypeConverter
    Inherits TypeConverter

    Public Overrides Function CanConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal destinationType As System.Type) As Boolean
        If destinationType.Equals(GetType(InstanceDescriptor)) Then
            Return True
        End If

        Return MyBase.CanConvertTo(context, destinationType)
    End Function

    Public Overrides Function ConvertTo(ByVal context As System.ComponentModel.ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destinationType As System.Type) As Object
        If destinationType.Equals(GetType(InstanceDescriptor)) And TypeOf value Is LoginUserInfo Then
            Dim l As LoginUserInfo = CType(value, LoginUserInfo)
            Dim ctor As ConstructorInfo = GetType(LoginUserInfo).GetConstructor(New System.Type() {GetType(String), GetType(String), GetType(String), GetType(Image), GetType(Boolean)})
            Return New InstanceDescriptor(ctor, New Object() {l.Username, l.Password, l.Message, l.UserImage, l.HasPassword})
        End If

        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class
