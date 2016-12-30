Imports System.ComponentModel
Imports System.Windows.Forms


''' <summary>
''' this extender control provides databinding for list views and derived controls.
''' Data is bound to columns and items
''' </summary>
''' <remarks></remarks>
<ProvideProperty("DataSource", GetType(ListView)), _
 ProvideProperty("DataMember", GetType(ListView)), _
 Designer(GetType(DataExtenderDesigner))> _
Public Class ListViewDataExtender
    Inherits System.ComponentModel.Component
    Implements System.ComponentModel.IExtenderProvider

    'a hashtable that holds all contols for the extender
    Private _extendedProps As New System.Collections.Generic.Dictionary(Of ListView, DataExtendedProperties)

    Public ReadOnly Property ExtendedControls() As ListView()
        Get
            Dim _array(_extendedProps.Keys.Count - 1) As ListView
            _extendedProps.Keys.CopyTo(_array, 0)
            Return _array
        End Get
    End Property

#Region "Bindable Columns "
    Private _colsExtender As New ColumnHeaderDataExtender

    Public ReadOnly Property ColumnsExtender() As ColumnHeaderDataExtender
        Get
            Return _colsExtender
        End Get
    End Property
#End Region

#Region " IExtenderProvider Interface Implementation "
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is ListView Then
            addPropertyValue(CType(extendee, System.Windows.Forms.ListView))
            Return True
        Else
            Return False
        End If
    End Function
#End Region

#Region " Event Handling "
    Protected Sub DataSourceChanged(ByVal sender As Object, ByVal e As EventArgs)
        'add data columns
        If DirectCast(sender, ListView).Columns.Count = 0 Then
            RetrieveColumnsFromDatasource(DirectCast(sender, ListView))
        End If

    End Sub

    Protected Sub RetrieveColumns(ByVal sender As Object, ByVal e As EventArgs)
        'add data columns
        If DirectCast(sender, ListView).Columns.Count = 0 Then
            RetrieveColumnsFromDatasource(DirectCast(sender, ListView))
        End If

    End Sub

    ''' <summary>
    ''' handles the list changed event of the currency manager
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub ListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        If e.ListChangedType = ListChangedType.Reset Or e.ListChangedType = ListChangedType.ItemMoved Then
            UpdateAllData(sender, New EventArgs)
        ElseIf e.ListChangedType = ListChangedType.ItemAdded Then
            AddItem(DirectCast(sender, ListView), e.NewIndex)
        ElseIf e.ListChangedType = ListChangedType.ItemChanged Then
            UpdateItem(DirectCast(sender, ListView), e.NewIndex)
        ElseIf e.ListChangedType = ListChangedType.ItemDeleted Then
            DeleteItem(DirectCast(sender, ListView), e.NewIndex)
        Else
            'RetrieveColumnsFromDatasource()
            UpdateAllData(sender, New EventArgs)
        End If
    End Sub

    ''' <summary>
    ''' handles the position changed event of the binding source
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub PositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = DirectCast(sender, ListView)

        If lv.Items.Count > _extendedProps(lv).DataManager.Position Then
            lv.Items(_extendedProps(lv).DataManager.Position).Selected = True
            lv.EnsureVisible(_extendedProps(lv).DataManager.Position)
        End If
    End Sub

    ''' <summary>
    ''' handles the selectedindexchanged event from the list view
    ''' to keep the datasource in sync
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Protected Sub SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim lv As ListView = DirectCast(sender, ListView)

        Try
            If lv.SelectedIndices.Count > 0 And _extendedProps(lv).DataManager.Position <> lv.SelectedIndices(0) Then
                _extendedProps(lv).DataManager.Position = lv.SelectedIndices(0)
            End If
        Catch ex As Exception
            'do nothing....
        End Try
    End Sub

    Protected Sub BindingContextChanged(ByVal sender As Object, ByVal e As EventArgs)
        If TypeOf sender Is ListView Then
            If _extendedProps.ContainsKey(DirectCast(sender, ListView)) Then
                _extendedProps(DirectCast(sender, ListView)).TryDatabind()
            End If
        End If
    End Sub
#End Region

#Region "Get/Set Functions for extended controls "

    ''' <summary>
    ''' adds the control to the extended controls list
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function addPropertyValue(ByVal ctrl As ListView) As DataExtendedProperties
        If Not _extendedProps.ContainsKey(ctrl) Then

            Dim props As New DataExtendedProperties(ctrl)

            AddHandler props.DataSourceChanged, AddressOf DataSourceChanged
            AddHandler props.ListChanged, AddressOf ListChanged
            AddHandler props.PositionChanged, AddressOf PositionChanged
            AddHandler props.UpdateAllData, AddressOf UpdateAllData
            AddHandler ctrl.BindingContextChanged, AddressOf BindingContextChanged
            AddHandler props.RetrieveColumns, AddressOf RetrieveColumns

            _extendedProps(ctrl) = props
        End If
        Return _extendedProps(ctrl)
    End Function

    <Description("Data Source for this Listview"), _
     TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design"), _
     Category("Data"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetDataSource(ByVal ctrl As ListView) As Object
        If Not _extendedProps.ContainsKey(ctrl) Then
            addPropertyValue(ctrl).DataSource = Nothing
        End If
        Return _extendedProps(ctrl).DataSource
    End Function

    Sub SetDataSource(ByVal ctrl As ListView, ByVal value As Object)
        addPropertyValue(ctrl).DataSource = value
    End Sub

    <Description("Data Source for this Listview"), _
     TypeConverter("System.Windows.Forms.Design.DataMemberConverter, System.Design"), _
     Category("Data"), _
     DefaultValue(""), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetDataMember(ByVal ctrl As ListView) As String
        If Not _extendedProps.ContainsKey(ctrl) Then
            addPropertyValue(ctrl).DataMember = ""
        End If
        Return _extendedProps(ctrl).DataMember
    End Function

    Sub SetDataMember(ByVal ctrl As ListView, ByVal value As String)
        addPropertyValue(ctrl).DataMember = value
    End Sub
#End Region

#Region " Data Binding "
    ''' <summary>
    ''' retrieves the column information of the datasource and displays it 
    ''' in the view
    ''' </summary>
    ''' <param name="control"></param>
    ''' <remarks></remarks>
    Public Sub RetrieveColumnsFromDatasource(ByVal control As Control)
        If Not TypeOf control Is ListView Then Exit Sub

        Dim lv As ListView = DirectCast(control, ListView)
        If _extendedProps.ContainsKey(lv) Then
            lv.Columns.Clear()

            If _extendedProps(lv).DataManager Is Nothing Then Exit Sub

            For Each prop As PropertyDescriptor In _extendedProps(lv).DataManager.GetItemProperties
                Dim col As New ColumnHeader
                col.Text = prop.Name
                col.Tag = prop.Name
                lv.Columns.Add(col)
                ColumnsExtender.SetDataPropertyName(col, prop.Name)
            Next
        End If
    End Sub

    ''' <summary>
    ''' retrieves all data into the list view
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub UpdateAllData(ByVal sender As Object, ByVal e As EventArgs)
        Dim lv As ListView = DirectCast(sender, ListView)

        lv.Items.Clear()
        If _extendedProps(lv).DataManager Is Nothing Then Exit Sub

        lv.BeginUpdate()
        For i As Integer = 0 To _extendedProps(lv).DataManager.Count - 1
            AddItem(lv, i)
        Next
        lv.EndUpdate()
    End Sub

    ''' <summary>
    ''' retrieves data from a specific position of the datasource
    ''' and adds it to the view items
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal control As ListView, ByVal index As Integer)
        Dim item As ListViewItem = GetListViewItem(control, index)
        control.Items.Insert(index, item)
    End Sub

    ''' <summary>
    ''' this functions moves through all columns of the view and all
    ''' properties of the object and adds the string represenation of that
    ''' value to the listviewitem, which is then returned
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="index"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetListViewItem(ByVal control As ListView, ByVal index As Integer) As ListViewItem
        Dim row As Object = _extendedProps(control).DataManager.List(index)
        Dim propColl As PropertyDescriptorCollection = _extendedProps(control).DataManager.GetItemProperties
        Dim items As New Collections.Generic.List(Of String)

        For Each column As ColumnHeader In control.Columns
            Dim prop As PropertyDescriptor = Nothing
            prop = propColl.Find(column.Tag.ToString, False)
            If prop IsNot Nothing Then
                items.Add(prop.GetValue(row).ToString)
            End If
        Next

        Return New ListViewItem(items.ToArray)
    End Function

    ''' <summary>
    ''' updates an item from the data source
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Private Sub UpdateItem(ByVal control As ListView, ByVal index As Integer)
        If index >= 0 And index < control.Items.Count Then
            Dim item As ListViewItem = GetListViewItem(control, index)
            control.Items(index) = item
        End If
    End Sub

    ''' <summary>
    ''' removes an item from the view
    ''' </summary>
    ''' <param name="control"></param>
    ''' <param name="index"></param>
    ''' <remarks></remarks>
    Private Sub DeleteItem(ByVal control As ListView, ByVal index As Integer)
        If index >= 0 And index < control.Items.Count Then
            control.Items.RemoveAt(index)
        End If
    End Sub
#End Region
End Class
