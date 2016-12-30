Imports System.Runtime.InteropServices
Imports System.Text

    ''' <summary>
    ''' this native window class intercepts the the WM_THEMECHANGED message and then
    ''' tries to "retheme" any control on the parent window that supports the ITheme-interface.
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ThemeListener
        Inherits NativeWindow

#Region "Event Declarations"
        Public Delegate Sub ThemeChangedHandler(ByVal sender As Object, ByVal e As ThemeChangedEventArgs)
        Public Event ThemeChanged As ThemeChangedHandler
        Protected Sub OnThemeChanged(ByVal e As ThemeChangedEventArgs)
            RaiseEvent ThemeChanged(Me, e)
        End Sub
#End Region

        Private Const WM_THEMECHANGED As Integer = &H31A

        Private WithEvents mParent As Form
        Private mEnabled As Boolean = True
        Private mCurrentTheme As ThemeStyle = ThemeStyle.Unthemed

        Public Sub New(ByVal parent As Form)
            MyBase.AssignHandle(parent.Handle)
            mParent = parent
            Me.Enabled = True
        End Sub

        Public Sub New(ByVal parent As Form, ByVal enabled As Boolean)
            MyBase.AssignHandle(parent.Handle)
            mParent = parent
            Me.Enabled = enabled
        End Sub

        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub

        ''' <summary>
        ''' while this value is true, this class tries to retheme after receiving
        ''' a themechanged message
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("Turns the Listener on and off"), _
        Category("Behavior"), _
        DefaultValue(True)> _
        Public Property Enabled() As Boolean
            Get
                Return mEnabled
            End Get
            Set(ByVal value As Boolean)

                mEnabled = value
                If mEnabled = True Then
                    mCurrentTheme = _GetTheme()
                    Call _SetTheme(mParent, mCurrentTheme)
                End If
            End Set
        End Property


        <DllImport("UxTheme.dll", _
        CallingConvention:=CallingConvention.Winapi, _
        CharSet:=CharSet.Auto)> _
        Private Shared Function GetCurrentThemeName( _
            ByVal pszThemeFileName As StringBuilder, _
            ByVal dwMaxNameChars As Int32, _
            ByVal pszColorBuff As StringBuilder, _
            ByVal cchMaxColorChars As Int32, _
            ByVal pszSizeBuff As StringBuilder, _
            ByVal cchMaxSizeChars As Int32) As IntPtr
        End Function

        <DllImport("UxTheme.dll", _
        CallingConvention:=CallingConvention.Winapi, _
        CharSet:=CharSet.Auto)> _
        Private Shared Function IsThemeActive() As Boolean
        End Function

        ''' <summary>
        ''' application is insecure if you don't add the link demand to this sub
        ''' see FxCop for details: http://www.gotdotnet.com/team/fxcop/docs/rules/SecurityRules/VirtualMethodsAndOverrides.html
        ''' </summary>
        ''' <param name="m"></param>
        ''' <remarks></remarks>
        <System.Security.Permissions.PermissionSetAttribute(System.Security.Permissions.SecurityAction.Demand, Name:="FullTrust")> _
        Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
            Select Case m.Msg
                Case WM_THEMECHANGED
                    If mEnabled = True Then
                        mCurrentTheme = _GetTheme()
                        Call _SetTheme(mParent, mCurrentTheme)
                        OnThemeChanged(New ThemeChangedEventArgs(mCurrentTheme))
                    End If
            End Select
            MyBase.WndProc(m)
        End Sub

        ''' <summary>
        ''' gets the current theme of the desktop computer
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Private Function _GetTheme() As ThemeStyle
            Dim themeFile As New StringBuilder(255)  'String = Space(255)
            Dim colorBuffer As New StringBuilder(255) '= Space(255)
            Dim sizeBuffer As New StringBuilder(255) '= Space(255)
            Dim retval As IntPtr
            Dim thm As ThemeStyle

            Try
                If IsThemeActive() = True Then
                    retval = GetCurrentThemeName(themeFile, 255, colorBuffer, 255, sizeBuffer, 255)
                    thm = CType([Enum].Parse(GetType(ThemeStyle), colorBuffer.ToString), ThemeStyle)
                    Return thm
                Else
                    Return ThemeStyle.Unthemed
                End If
            Catch ex As Exception
                'Throw New System.Exception("An exception in ThemeListener._GetTheme occured: " & ex.Message)
                'cannot rethrow the exeption, since this error can be thrown on non-XP machines...
                Return ThemeStyle.Unthemed
            End Try
        End Function

        ''' <summary>
        ''' set the theme of all controls that implement Ithemed
        ''' </summary>
        ''' <param name="ctrl"></param>
        ''' <param name="theme"></param>
        ''' <remarks></remarks>
        Private Sub _SetTheme(ByVal ctrl As Control, ByVal theme As ThemeStyle)
            If TypeOf ctrl Is IThemed Then
                CType(ctrl, IThemed).Theme = theme
            End If

            For Each c As Control In ctrl.Controls
                _SetTheme(c, theme)
            Next
        End Sub

        ''' <summary>
        ''' assign the current theme to all controls that implement IThemed at startup
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks></remarks>
        Private Sub mParent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles mParent.Load
            If mEnabled = True Then
                mCurrentTheme = _GetTheme()
                Call _SetTheme(mParent, mCurrentTheme)
            End If
        End Sub

        ''' -----------------------------------------------------------------------------
        ''' <summary>
        ''' sets the theme of an added control if it implements the iThemed Interface.
        ''' This works only for controls that are added to the parent directly.
        ''' All other controls that are added to child controls of the parent do not
        ''' raise this event...
        ''' </summary>
        ''' <param name="sender"></param>
        ''' <param name="e"></param>
        ''' <remarks>
        ''' </remarks>
        ''' <history>
        ''' 	[Mike]	17.08.2004	Created
        ''' </history>
        ''' -----------------------------------------------------------------------------
        Private Sub mParent_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles mParent.ControlAdded
            If mEnabled = True AndAlso TypeOf e.Control Is IThemed Then
                CType(e.Control, IThemed).Theme = mCurrentTheme
            End If
        End Sub
    End Class

    ''' <summary>
    ''' event arguments for ThemeChanged Event
    ''' </summary>
    ''' <remarks></remarks>
    Public Class ThemeChangedEventArgs
        Inherits EventArgs

        Private mTheme As New ThemeStyle

        Public Property Theme() As ThemeStyle
            Get
                Return mTheme
            End Get
            Set(ByVal value As ThemeStyle)
                mTheme = value
            End Set
        End Property

        Public Sub New(ByVal theme As ThemeStyle)
            mTheme = theme
        End Sub
    End Class
