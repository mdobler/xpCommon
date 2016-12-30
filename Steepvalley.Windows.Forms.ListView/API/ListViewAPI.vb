Imports System.Runtime.InteropServices
Imports SteepValley.Windows.Forms

''' <summary>
''' a wrapper class for all API calls to the list view
''' </summary>
''' <remarks></remarks>
Class ListViewAPI
    Inherits BaseAPI

#Region "LVS_EX enumeration"
    Public Enum LVS_EX
        LVS_EX_GRIDLINES = &H1
        LVS_EX_SUBITEMIMAGES = &H2
        LVS_EX_CHECKBOXES = &H4
        LVS_EX_TRACKSELECT = &H8
        LVS_EX_HEADERDRAGDROP = &H10
        LVS_EX_FULLROWSELECT = &H20
        LVS_EX_ONECLICKACTIVATE = &H40
        LVS_EX_TWOCLICKACTIVATE = &H80
        LVS_EX_FLATSB = &H100
        LVS_EX_REGIONAL = &H200
        LVS_EX_INFOTIP = &H400
        LVS_EX_UNDERLINEHOT = &H800
        LVS_EX_UNDERLINECOLD = &H1000
        LVS_EX_MULTIWORKAREAS = &H2000
        LVS_EX_LABELTIP = &H4000
        LVS_EX_BORDERSELECT = &H8000
        LVS_EX_DOUBLEBUFFER = &H10000
        LVS_EX_HIDELABELS = &H20000
        LVS_EX_SINGLEROW = &H40000
        LVS_EX_SNAPTOGRID = &H80000
        LVS_EX_SIMPLESELECT = &H100000
    End Enum 'LVS_EX
#End Region

#Region "Constants for Listview-Messages"
    Public Const LVM_FIRST As Integer = &H1000

    Public Const LVM_ARRANGE As Integer = (LVM_FIRST + 22)
    Public Const LVM_DELETEALLITEMS As Integer = (LVM_FIRST + 9)
    Public Const LVM_DELETECOLUMN As Integer = (LVM_FIRST + 28)
    Public Const LVM_DELETEITEM As Integer = (LVM_FIRST + 8)
    Public Const LVM_ENABLEGROUPVIEW As Integer = (LVM_FIRST + 157)
    Public Const LVM_GETCOLUMN As Integer = (LVM_FIRST + 25)
    Public Const LVM_GETCOLUMNW As Integer = (LVM_FIRST + 95)
    Public Const LVM_GETGROUPINFO As Integer = (LVM_FIRST + 149)
    Public Const LVM_GETGROUPMETRICS As Integer = (LVM_FIRST + 156)
    Public Const LVM_GETHEADER As Integer = (LVM_FIRST + 31)
    Public Const LVM_GETITEM As Integer = (LVM_FIRST + 5)
    Public Const LVM_GETTILEINFO As Integer = (LVM_FIRST + 165)
    Public Const LVM_GETTILEVIEWINFO As Integer = (LVM_FIRST + 163)
    Public Const LVM_GETTOOLTIPS As Integer = (LVM_FIRST + 78)
    Public Const LVM_GETVIEW As Integer = (LVM_FIRST + 143)
    Public Const LVM_HASGROUP As Integer = (LVM_FIRST + 161)
    Public Const LVM_INSERTCOLUMN As Integer = (LVM_FIRST + 27)
    Public Const LVM_INSERTGROUP As Integer = (LVM_FIRST + 145)
    Public Const LVM_INSERTGROUPSORTED As Integer = (LVM_FIRST + 159)
    Public Const LVM_INSERTITEM As Integer = (LVM_FIRST + 7)
    Public Const LVM_ISGROUPVIEWENABLED As Integer = (LVM_FIRST + 175)
    Public Const LVM_MOVEGROUP As Integer = (LVM_FIRST + 151)
    Public Const LVM_MOVEITEMTOGROUP As Integer = (LVM_FIRST + 154)
    Public Const LVM_REDRAWITEMS As Integer = (LVM_FIRST + 21)
    Public Const LVM_REMOVEALLGROUPS As Integer = (LVM_FIRST + 160)
    Public Const LVM_REMOVEGROUP As Integer = (LVM_FIRST + 150)
    Public Const LVM_SETCOLUMN As Integer = (LVM_FIRST + 26)
    Public Const LVM_SETEXTENDEDLISTVIEWSTYLE As Integer = (LVM_FIRST + 54)
    Public Const LVM_SETGROUPINFO As Integer = (LVM_FIRST + 147)
    Public Const LVM_SETGROUPMETRICS As Integer = (LVM_FIRST + 155)
    Public Const LVM_SETINFOTIP As Integer = (LVM_FIRST + 173)
    Public Const LVM_SETITEM As Integer = (LVM_FIRST + 6)
    Public Const LVM_SETTILEINFO As Integer = (LVM_FIRST + 164)
    Public Const LVM_SETTILEVIEWINFO As Integer = (LVM_FIRST + 162)
    Public Const LVM_SETTILEWIDTH As Integer = (LVM_FIRST + 141)
    Public Const LVM_SETTOOLTIPS As Integer = (LVM_FIRST + 74)
    Public Const LVM_SETVIEW As Integer = (LVM_FIRST + 142)
    Public Const LVM_SORTGROUPS As Integer = (LVM_FIRST + 158)
    Public Const LVM_SORTITEMS As Integer = (LVM_FIRST + 48)
    Public Const LVM_UPDATE As Integer = (LVM_FIRST + 42)


#End Region

#Region "Constants for LVCOLUMN.mask"
    Public Const LVCF_FMT As Integer = &H1
    Public Const LVCF_IMAGE As Integer = &H10
    Public Const LVCF_ORDER As Integer = &H20
    Public Const LVCF_SUBITEM As Integer = &H8
    Public Const LVCF_TEXT As Integer = &H4
    Public Const LVCF_WIDTH As Integer = &H2
#End Region

#Region "Konstanten fur LVCOLUMN.fmt"
    Public Const LVCFMT_BITMAP_ON_RIGHT As Integer = &H1000
    Public Const LVCFMT_CENTER As Integer = &H2
    Public Const LVCFMT_COL_HAS_IMAGES As Integer = &H8000
    Public Const LVCFMT_IMAGE As Integer = &H800
    Public Const LVCFMT_JUSTIFYMASK As Integer = &H3
    Public Const LVCFMT_LEFT As Integer = &H0
    Public Const LVCFMT_RIGHT As Integer = &H1
#End Region

#Region "Constants for LVGROUP.mask"
    Public Const LVGF_ALIGN As Integer = &H8
    Public Const LVGF_FOOTER As Integer = &H2
    Public Const LVGF_GROUPID As Integer = &H10
    Public Const LVGF_HEADER As Integer = &H1
    Public Const LVGF_NONE As Integer = &H0
    Public Const LVGF_STATE As Integer = &H4
#End Region

#Region "Constants for LVGROUP.uAlign"
    Public Const LVGA_FOOTER_CENTER As Integer = &H10
    Public Const LVGA_FOOTER_LEFT As Integer = &H8
    Public Const LVGA_FOOTER_RIGHT As Integer = &H20
    Public Const LVGA_HEADER_CENTER As Integer = &H2
    Public Const LVGA_HEADER_LEFT As Integer = &H1
    Public Const LVGA_HEADER_RIGHT As Integer = &H4
#End Region

#Region "Constants for LVGROUP.state"
    Public Const LVGS_COLLAPSED As Integer = &H1
    Public Const LVGS_HIDDEN As Integer = &H2
    Public Const LVGS_NORMAL As Integer = &H0
#End Region

#Region "Constants for LVTILEVIEWINFO.dwMask"
    Public Const LVTVIM_COLUMNS As Integer = &H2
    Public Const LVTVIM_TILESIZE As Integer = &H1
    Public Const LVTVIM_LABELMARGIN As Integer = &H4
#End Region

#Region "Constants for LVTILEVIEWINFO.dwFlags"
    Public Const LVTVIF_AUTOSIZE As Integer = &H0
    Public Const LVTVIF_FIXEDHEIGHT As Integer = &H2
    Public Const LVTVIF_FIXEDSIZE As Integer = &H3
    Public Const LVTVIF_FIXEDWIDTH As Integer = &H1
#End Region

#Region "Constants for LVITEM.mask"
    Public Const LVIF_COLUMNS As Integer = &H200
    Public Const LVIF_DI_SETITEM As Integer = &H1000
    Public Const LVIF_GROUPID As Integer = &H100
    Public Const LVIF_IMAGE As Integer = &H2
    Public Const LVIF_INDENT As Integer = &H10
    Public Const LVIF_NORECOMPUTE As Integer = &H800
    Public Const LVIF_PARAM As Integer = &H4
    Public Const LVIF_STATE As Integer = &H8
    Public Const LVIF_TEXT As Integer = &H1
#End Region

    Public Const HDM_SETIMAGELIST As Integer = 4616

#Region "Structures for ListView (API)"
    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Public Structure LVITEM
        Dim mask As Integer
        Dim iItem As Integer
        Dim iSubItem As Integer
        Dim state As Integer
        Dim stateMask As Integer
        <MarshalAs(UnmanagedType.LPTStr)> Dim pszText As String
        Dim cchTextMax As Integer
        Dim iImage As Integer
        Dim lParam As Integer
        Dim iIndent As Integer
        Dim iGroupId As Integer
        Dim cColumns As Integer
        Dim puColumns As Integer
    End Structure

    'Define the LVCOLUMN for use with Interop.
    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Structure LVCOLUMN
        Dim mask As Integer
        Dim fmt As Integer
        Dim cx As Integer
        <MarshalAs(UnmanagedType.LPTStr)> Dim pszText As String
        Dim cchTextMax As Integer
        Dim iSubItem As Integer
        Dim iImage As Integer
        Dim iOrder As Integer
    End Structure

    'Define LVGROUP
    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Public Structure LVGROUP
        Dim cbSize As Integer
        Dim mask As Integer
        <MarshalAs(UnmanagedType.LPWStr)> Dim pszHeader As String
        Dim cchHeader As Integer
        <MarshalAs(UnmanagedType.LPWStr)> Dim pszFooter As String
        Dim cchFooter As Integer
        Dim iGroupId As Integer
        Dim stateMask As Integer
        Dim state As Integer
        Dim uAlign As Integer
    End Structure

    'define LVTILEVIEWINFO
    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Public Structure LVTILEVIEWINFO
        Dim cbSize As Integer
        Dim dwMask As Integer
        Dim dwFlags As Integer
        Dim sizeTile As INTEROP_SIZE
        Dim cLines As Integer
        Dim rcLabelMargin As INTEROP_RECT
    End Structure

    'define LVTILEINFO
    <StructLayout(LayoutKind.Sequential, pack:=8, CharSet:=CharSet.Auto)> _
    Public Structure LVTILEINFO
        Dim cbSize As Integer
        Dim iItem As Integer
        Dim cColumns As Integer
        Dim puColumns As Integer
    End Structure
#End Region

#Region "Overloaded SendMessage-functions"
    'Declare  overloaded SendMessage functions. The
    'difference is in the last parameter.
    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
         ByVal wParam As Integer, ByRef lParam As LVCOLUMN) As IntPtr
    End Function

    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
        ByVal wParam As Integer, ByRef lParam As LVTILEINFO) As IntPtr
    End Function

    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
        ByVal wParam As Integer, ByRef lParam As LVTILEVIEWINFO) As IntPtr
    End Function

    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
        ByVal wParam As Integer, ByRef lParam As LVGROUP) As IntPtr
    End Function

    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Public Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
        ByVal wParam As Integer, ByRef lParam As LVITEM) As IntPtr
    End Function
#End Region

#Region "methods to call"
    Public Shared Sub SetBorderSelect(ByVal lst As ListView, Optional ByVal flag As Boolean = False)
        Dim ptrRetVal As IntPtr

        Try
            If lst Is Nothing Then Exit Sub
            If flag Then
                ptrRetVal = SendMessage(lst.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX.LVS_EX_BORDERSELECT, LVS_EX.LVS_EX_BORDERSELECT)
            Else
                ptrRetVal = SendMessage(lst.Handle, LVM_SETEXTENDEDLISTVIEWSTYLE, LVS_EX.LVS_EX_BORDERSELECT, 0)
            End If
        Catch ex As Exception
            'to comply with FxCop, the error must be rethrown
            Throw New System.Exception("An exception in ListViewAPI.SetDoubleBuffer occured: " & ex.Message)
        End Try
    End Sub
#End Region
End Class