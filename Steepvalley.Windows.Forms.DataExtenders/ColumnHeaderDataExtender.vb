Imports System.ComponentModel
Imports System.Windows.Forms

''' <summary>
''' this extender control provides databinding for list views and derived controls.
''' Data is bound to columns and items
''' </summary>
''' <remarks></remarks>
<ProvideProperty("DataPropertyName", GetType(ColumnHeader))> _
Public Class ColumnHeaderDataExtender
    Inherits System.ComponentModel.Component
    Implements System.ComponentModel.IExtenderProvider

    'a hashtable that holds all contols for the extender
    Private _extendedProps As New System.Collections.Generic.Dictionary(Of ColumnHeader, String)

#Region " IExtenderProvider Interface Implementation "
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is ColumnHeader Then
            Return True
        End If
        Return False
    End Function
#End Region

#Region " Extender Properties "

    <Description("Binding Name"), _
     Category("Data"), _
     DefaultValue(""), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetDataPropertyName(ByVal ctrl As ColumnHeader) As String
        If _extendedProps.ContainsKey(ctrl) Then
            Return _extendedProps(ctrl)
        End If
        Return String.Empty
    End Function

    Sub SetDataPropertyName(ByVal ctrl As ColumnHeader, ByVal value As String)
        If value Is Nothing Then value = String.Empty

        If value = String.Empty Then
            _extendedProps.Remove(ctrl)
        Else
            _extendedProps(ctrl) = value
        End If

    End Sub
#End Region
End Class
