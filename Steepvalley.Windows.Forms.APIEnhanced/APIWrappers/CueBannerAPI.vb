Imports System.Runtime.InteropServices

''' <summary>
''' API calls for "cue banners". These are text hints on a text box or combobox that
''' disapear as soon as you type in text
''' </summary>
''' <remarks></remarks>
Public Class CueBannerAPI
    Inherits BaseAPI

#Region "constants for curebanner messages"
    Private Const EM_SETCUEBANNER As Int32 = (ECM_FIRST + 1)
    Private Const ECM_FIRST As Int32 = &H1500
#End Region

#Region "Overloaded SendMessage-functions"
    'Declare  overloaded SendMessage functions. The
    'difference is in the last parameter.
    <DllImport("User32", CharSet:=CharSet.Auto)> _
    Private Overloads Shared Function SendMessage _
        (ByVal hWnd As IntPtr, ByVal msg As Integer, _
         ByVal wParam As Integer, _
         <MarshalAs(UnmanagedType.LPWStr)> ByVal lParam As String) As IntPtr
    End Function
#End Region

#Region "methods"
    Public Shared Sub SetCueBanner(ByVal ctrl As Control, ByVal text As String)
        Dim handle As IntPtr
        handle = _getHandle(ctrl)
        SendMessage(handle, EM_SETCUEBANNER, 0, text)
    End Sub
#End Region
End Class
