Imports System.Reflection
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


''' <summary>
''' this control extends the standard list view with a tiled view and grouping
''' functionalities.
''' </summary>
''' <remarks>
''' the control's added functionality works only in a Windows XP environment with the
''' visual styles enabled. Use the TileMode for displaying the items with a large icon
''' and multiple lines (one per subitem).
''' Use the grouping to display groups of items in the list view. Groups and items can be 
''' defined manually or the listview can be grouped automatically by the values of a 
''' defined subitem.
''' For details see the methods and properties
''' </remarks>
<Designer(GetType(Design.ListViewDesigner))> _
Public Class ListView
    Private _tileCols() As Integer = {1}
    Private _borderSelect As Boolean = False
    Private m_apiRetVal As IntPtr

#Region "Extended Properties"
    <Editor(GetType(System.ComponentModel.Design.ArrayEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property TileColumns() As Integer()
        Get
            Return _tileCols
        End Get
        Set(ByVal Value() As Integer)
            _tileCols = Value

            If _tileCols Is Nothing OrElse _tileCols.Length = 0 Then Exit Property
            ShowTiles(_tileCols)
        End Set
    End Property

    <Category("Appearance"), _
     Description("If this style is set, when an item is selected the border color of the item changes rather than the item being highlighted"), _
     DefaultValue(False), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)> _
    Public Property BorderSelect() As Boolean
        Get
            Return _borderSelect
        End Get
        Set(ByVal value As Boolean)
            _borderSelect = value
            ListViewAPI.SetBorderSelect(Me, value)
        End Set
    End Property
#End Region

#Region "Display Functions"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' switches to the tile-view
    ''' </summary>
    ''' <param name="columns">an array of column ids that are displayed as text lines</param>
    ''' <remarks>
    ''' this method switches to the tiles-view and uses the array of column ids to display
    ''' the text of each corresponding subitem on the right hand side of the icon
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub ShowTiles(ByVal ParamArray columns() As Integer)

        If Not Me.View = System.Windows.Forms.View.Tile Then Exit Sub

        Me.BeginUpdate()

        'if paramarray is empty then show all columns
        'without the first column - it is always displayed
        If columns.Length = 0 Then
            ReDim columns(Me.Columns.Count - 1)
            For i As Integer = 1 To Me.Columns.Count
                columns(i) = i
            Next
        End If

        Dim apiTile As ListViewAPI.LVTILEINFO

        Dim lpcol As IntPtr = Marshal.AllocHGlobal(columns.Length * 4)
        Marshal.Copy(columns, 0, lpcol, columns.Length)

        'define the tile info for each item
        For Each itm As ListViewItem In Me.Items

            apiTile = New ListViewAPI.LVTILEINFO
            With apiTile
                .cbSize = Marshal.SizeOf(GetType(ListViewAPI.LVTILEINFO))
                m_apiRetVal = ListViewAPI.SendMessage(Me.Handle, ListViewAPI.LVM_GETTILEINFO, 0, apiTile)
                .iItem = itm.Index
                .cColumns = columns.Length
                .puColumns = lpcol.ToInt32
                m_apiRetVal = ListViewAPI.SendMessage(Me.Handle, ListViewAPI.LVM_SETTILEINFO, 0, apiTile)
            End With

        Next

        Erase columns
        Marshal.FreeHGlobal(lpcol)

        Me.EndUpdate()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' groups the listview by the value of the specified subitems
    ''' </summary>
    ''' <param name="columnID">Integer. The column id for autogrouping</param>
    ''' <returns>Boolean. true, if grouping is correct</returns>
    ''' <remarks>
    ''' use this method to group all items by the value of the subitem specified
    ''' by the column id. The function loops through all subitems and creates a
    ''' group for each distinct value of these subitems. When the EmtpyAutoGroup-property
    ''' is set, empty strings are displayed with the value from EmtpyAutoGroup.
    ''' The auto groups are also sorted before display.
    ''' New items of the listview will not be grouped automatically. You have to call 
    ''' the method again to group the complete list.
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function AutoGroup(ByVal columnID As Integer, Optional ByVal emptyValue As String = "") As Boolean
        If columnID >= Me.Columns.Count Or columnID < 0 Then
            Me.ShowGroups = False
            Return False
        End If

        Try
            'get the different entries in the subitem...
            For Each itm As ListViewItem In Me.Items
                Dim grpText As String = CStr(IIf(itm.SubItems(columnID).Text = "", _
                       emptyValue, _
                       itm.SubItems(columnID).Text))

                Dim grp As ListViewGroup = Me.Groups.Item(grpText)
                If grp Is Nothing Then
                    grp = New ListViewGroup(grpText, grpText)
                    Me.Groups.Add(grp)
                End If

                itm.Group = grp
            Next

            Me.ShowGroups = True
            Return True
        Catch ex As Exception
            Throw New SystemException("Error in XPListView.AutoGroupByColumn: " + ex.Message)
            Return False
        End Try
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the Font, Forecolor and Backcolor for an entire column
    ''' </summary>
    ''' <param name="column">column id of the subitems to change</param>
    ''' <param name="font">the font to apply</param>
    ''' <param name="foreColor">the forecolor to apply</param>
    ''' <param name="backColor">the backcolor to apply</param>
    ''' <remarks>
    ''' sets the Font, Forecolor and Backcolor for all subitems of a specified columns
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.04.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetColumnStyle(ByVal column As Integer, ByVal font As Font, ByVal foreColor As Color, ByVal backColor As Color)
        Me.SuspendLayout()

        For Each itm As ListViewItem In Me.Items
            If itm.SubItems.Count > column Then
                With itm.SubItems(column)
                    .Font = font
                    .BackColor = backColor
                    .ForeColor = foreColor

                End With
            End If
        Next

        Me.ResumeLayout()
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the font and forecolor of an entire column
    ''' </summary>
    ''' <param name="column">the column id of the subitems to change</param>
    ''' <param name="font">the font to apply</param>
    ''' <param name="foreColor">the forecolor to apply</param>
    ''' <remarks>
    ''' overloads the SetColumnStyle and sets the font and forecolor of all
    ''' subitems of the column
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.04.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetColumnStyle(ByVal column As Integer, ByVal font As Font, ByVal foreColor As Color)
        Call SetColumnStyle(column, font, foreColor, Me.BackColor)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' sets the font of an entire column
    ''' </summary>
    ''' <param name="column">the column id of the subitems to change</param>
    ''' <param name="font">the font to apply</param>
    ''' <remarks>
    ''' overloads the SetColumnstyle and sets the font of all subitems of the column
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.04.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub SetColumnStyle(ByVal column As Integer, ByVal font As Font)
        Call SetColumnStyle(column, font, Me.ForeColor, Me.BackColor)
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' resets the column to the standard font and colors
    ''' </summary>
    ''' <param name="column">the column id of the subitems to reset</param>
    ''' <remarks>
    ''' resets all subitems of the column to the values specified for the control
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	28.04.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Sub ResetColumnStyle(ByVal column As Integer)
        Me.SuspendLayout()

        For Each itm As ListViewItem In Me.Items
            If itm.SubItems.Count > column Then
                itm.SubItems(column).ResetStyle()
            End If
        Next

        Me.ResumeLayout()
    End Sub
#End Region

End Class
