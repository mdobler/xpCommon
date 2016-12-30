Imports System.Runtime.InteropServices

''' <summary>
''' the base class of all API calls. includes base structs and sendmessage methods
''' </summary>
Public Class BaseAPI

#Region "Standard Structures fuer Interop"
    ''' <summary>
    ''' this is the basic SIZE structure for Windows API calls
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure INTEROP_SIZE
        Dim cx As Integer
        Dim cy As Integer
    End Structure

    ''' <summary>
    ''' this is the basic RECT structure for Windows API calls
    ''' </summary>
    ''' <remarks></remarks>
    Public Structure INTEROP_RECT
        Dim Left As Integer
        Dim Top As Integer
        Dim Right As Integer
        Dim Bottom As Integer
    End Structure

    ''' <summary>
    ''' returns a handle to a control as IntPtr. The ComboBox needs some special
    ''' handling
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Shared Function _getHandle(ByVal ctrl As Control) As IntPtr
        If TypeOf ctrl Is ComboBox Then
            Dim pcbi As New COMBOBOXINFO
            pcbi.cbSize = Marshal.SizeOf(pcbi)
            GetComboBoxInfo(CType(ctrl, ComboBox).Handle, pcbi)
            Return pcbi.hwndItem
        Else
            Return ctrl.Handle
        End If
    End Function
#End Region

#Region "structure for comboboxinfo"
    Public Declare Function GetComboBoxInfo Lib "user32.dll" (ByVal hwndCombo As IntPtr, ByRef pcbi As COMBOBOXINFO) As Int32

    <StructLayout(LayoutKind.Sequential)> _
    Public Structure COMBOBOXINFO
        Public cbSize As Int32
        Public rcItem As INTEROP_RECT
        Public rcButton As INTEROP_RECT
        Public stateButton As Int32
        Public hwndCombo As IntPtr
        Public hwndItem As IntPtr
        Public hwndList As IntPtr
    End Structure
#End Region

#Region "SendMessage Declaration"
    ''' <summary>
    ''' the basic sendmessage function, that is always used to communicate with the Windows API
    ''' </summary>
    ''' <param name="hWnd"></param>
    ''' <param name="Msg"></param>
    ''' <param name="wParam"></param>
    ''' <param name="lParam"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <DllImport("User32.dll")> _
        Public Overloads Shared Function SendMessage _
            (ByVal hWnd As IntPtr, ByVal Msg As Integer, _
             ByVal wParam As Integer, ByVal lParam As Integer) As IntPtr
    End Function
#End Region
End Class
