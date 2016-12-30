Imports System.Runtime.InteropServices

''' <summary>
''' this api will display the balloon tip with title, message and an icon
''' </summary>
''' <remarks>
''' </remarks>
Public Class BalloonTipAPI
    Inherits BaseAPI

    ''' <summary>
    ''' this enumeration controls the icon display of the balloon tip
    ''' </summary>
    Public Enum ToolTipIcon
        None
        Info
        Warning
        [Error]
    End Enum

#Region "constants"
    Private Const ECM_FIRST As Int32 = &H1500
    Private Const EM_SHOWBALLOONTIP As Int32 = ECM_FIRST + 3
    Private Const EM_HIDEBALLOONTIP As Int32 = ECM_FIRST + 4

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
    Private Structure EDITBALLOONTIP
        Public cbStruct As Int32
        Public pszTitle As String
        Public pszText As String
        Public ttiIcon As Int32
    End Structure
#End Region

#Region "Overloaded SendMessage-functions"
    ''' <summary>
    ''' Declare  overloaded SendMessage functions. The
    ''' difference is in the last parameter.
    ''' </summary>
    ''' <param name="hWnd">the window handle of the control to display the balloon tip on</param>
    ''' <param name="msg">the message to send to the control (EM_SHOWBALLOONTIP)</param>
    ''' <param name="wParam">always 0</param>
    ''' <param name="lParam">the EDITBALLOONTIP structure parameter</param>
    ''' <returns></returns>
    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Private Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
         ByVal wParam As Integer, _
         ByRef lParam As EDITBALLOONTIP) As IntPtr
    End Function
#End Region

#Region "methods"
    ''' <summary>
    ''' displays the balloon tip on the specified control
    ''' </summary>
    ''' <param name="ctrl">the control to display the balloon tip onto</param>
    ''' <param name="title">the title of the balloon tip</param>
    ''' <param name="text">the text of the balloon tip</param>
    ''' <param name="icon">the icon constant</param>
    Public Shared Sub ShowBalloonTip(ByVal ctrl As Control, ByVal title As String, ByVal text As String, ByVal icon As ToolTipIcon)
        Dim handle As IntPtr
        Dim tip As New EDITBALLOONTIP

        handle = _getHandle(ctrl)
        tip.cbStruct = Marshal.SizeOf(tip)
        tip.pszText = text
        tip.pszTitle = title
        tip.ttiIcon = CInt(icon)

        SendMessage(ctrl.Handle, EM_SHOWBALLOONTIP, 0, tip)
    End Sub

    ''' <summary>
    ''' overloaded method of ShowBalloonTip that uses the IntPtr of the control
    ''' </summary>
    ''' <param name="handle"></param>
    ''' <param name="title"></param>
    ''' <param name="text"></param>
    ''' <param name="icon"></param>
    Public Shared Sub ShowBalloonTip(ByVal handle As IntPtr, ByVal title As String, ByVal text As String, ByVal icon As ToolTipIcon)
        Dim tip As New EDITBALLOONTIP

        tip.cbStruct = Marshal.SizeOf(tip)
        tip.pszText = text
        tip.pszTitle = title
        tip.ttiIcon = CInt(icon)

        SendMessage(handle, EM_SHOWBALLOONTIP, 0, tip)
    End Sub

    ''' <summary>
    ''' this method hides the balloon tip again
    ''' </summary>
    ''' <param name="ctrl"></param>
    Public Shared Sub HideBalloonTip(ByVal ctrl As Control)
        Dim handle As IntPtr

        handle = _getHandle(ctrl)
        SendMessage(ctrl.Handle, EM_HIDEBALLOONTIP, 0, 0)
    End Sub
#End Region
End Class
