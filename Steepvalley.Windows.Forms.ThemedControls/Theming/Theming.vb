Imports System.Resources
Imports System.Reflection

''' -----------------------------------------------------------------------------
''' <summary>
''' the available theme styles in windows XP
''' </summary>
''' <remarks>
''' if a new theme is added, the theming must be changed...
''' </remarks>
''' <history>
''' 	[Mike]	14.03.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Enum ThemeStyle
    NormalColor
    HomeStead
    Metallic
    Unthemed
End Enum

''' <summary>
''' this class themes the controls manually! There is no need for UxTheme or WinXP.
''' The good side: you do not need WinXP to get the themed look.
''' The down side: if a new theme is added to WinXP it has to be hardcoded here.
''' </summary>
''' <remarks></remarks>
Public Class Theming

    Public Shared Function GetTaskBoxThemeGeneric(ByVal theme As ThemeStyle) As TaskBoxFormat
        Dim fmt As New TaskBoxFormat

        Select Case theme
            Case ThemeStyle.NormalColor
                fmt = New TaskBoxFormat( _
                    Color.White, _
                    Color.FromArgb(197, 210, 240), _
                    Color.FromArgb(197, 210, 240), _
                    Color.White, _
                    Color.FromArgb(33, 93, 198), _
                    Color.FromArgb(66, 142, 255), _
                    Color.FromArgb(33, 93, 198), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_NormalColor_Generic_up, _
                    My.Resources.ThemedControls_NormalColor_Generic_up_over, _
                    My.Resources.ThemedControls_NormalColor_Generic_down, _
                    My.Resources.ThemedControls_NormalColor_Generic_down_over)
            Case ThemeStyle.HomeStead
                fmt = New TaskBoxFormat( _
                    Color.FromArgb(255, 252, 236), _
                    Color.FromArgb(224, 231, 187), _
                    Color.FromArgb(246, 246, 236), _
                    Color.White, _
                    Color.FromArgb(86, 102, 45), _
                    Color.FromArgb(114, 146, 29), _
                    Color.FromArgb(150, 168, 103), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_HomeStead_Generic_up, _
                    My.Resources.ThemedControls_HomeStead_Generic_up_over, _
                    My.Resources.ThemedControls_HomeStead_Generic_down, _
                    My.Resources.ThemedControls_HomeStead_Generic_down_over)
            Case ThemeStyle.Metallic
                fmt = New TaskBoxFormat( _
                    Color.White, _
                    Color.FromArgb(216, 217, 226), _
                    Color.FromArgb(240, 241, 245), _
                    Color.White, _
                    Color.FromArgb(63, 61, 61), _
                    Color.FromArgb(126, 124, 124), _
                    Color.FromArgb(104, 104, 127), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_Metallic_Generic_up, _
                    My.Resources.ThemedControls_Metallic_Generic_up_over, _
                    My.Resources.ThemedControls_Metallic_Generic_down, _
                    My.Resources.ThemedControls_Metallic_Generic_down_over)
            Case ThemeStyle.Unthemed
                fmt = New TaskBoxFormat( _
                    SystemColors.InactiveCaption, _
                    SystemColors.InactiveCaption, _
                    SystemColors.ControlLightLight, _
                    Color.White, _
                    SystemColors.InactiveCaptionText, _
                    SystemColors.ActiveCaptionText, _
                    SystemColors.WindowText, _
                    SystemInformation.MenuFont, _
                    SystemInformation.MenuFont, _
                    My.Resources.ThemedControls_Unthemed_Generic_up, _
                    My.Resources.ThemedControls_Unthemed_Generic_up_over, _
                    My.Resources.ThemedControls_Unthemed_Generic_down, _
                    My.Resources.ThemedControls_Unthemed_Generic_down_over)
        End Select

        Return fmt
    End Function

    Public Shared Function GetTaskBoxThemeSpecial(ByVal theme As ThemeStyle) As TaskBoxFormat
        Dim fmt As New TaskBoxFormat

        Select Case theme
            Case ThemeStyle.NormalColor

                fmt = New TaskBoxFormat( _
                    Color.FromArgb(1, 72, 178), _
                    Color.FromArgb(40, 91, 197), _
                    Color.FromArgb(239, 243, 255), _
                    Color.White, _
                    Color.White, _
                    Color.FromArgb(66, 142, 255), _
                    Color.FromArgb(33, 93, 198), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_NormalColor_Special_up, _
                    My.Resources.ThemedControls_NormalColor_Special_up_over, _
                    My.Resources.ThemedControls_NormalColor_Special_down, _
                    My.Resources.ThemedControls_NormalColor_Special_down_over)

            Case ThemeStyle.HomeStead
                fmt = New TaskBoxFormat( _
                    Color.FromArgb(122, 142, 67), _
                    Color.FromArgb(150, 168, 103), _
                    Color.FromArgb(246, 246, 236), _
                    Color.White, _
                    Color.White, _
                    Color.FromArgb(224, 231, 184), _
                    Color.FromArgb(150, 168, 103), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_HomeStead_Special_up, _
                    My.Resources.ThemedControls_HomeStead_Special_up_over, _
                    My.Resources.ThemedControls_HomeStead_Special_down, _
                    My.Resources.ThemedControls_HomeStead_Special_down_over)
            Case ThemeStyle.Metallic
                fmt = New TaskBoxFormat( _
                    Color.FromArgb(119, 119, 146), _
                    Color.FromArgb(179, 181, 199), _
                    Color.FromArgb(240, 241, 245), _
                    Color.White, _
                    Color.White, _
                    Color.FromArgb(230, 230, 230), _
                    Color.FromArgb(104, 104, 127), _
                    New Font("Tahoma", 8, FontStyle.Bold), _
                    New Font("Tahoma", 8, FontStyle.Regular), _
                    My.Resources.ThemedControls_Metallic_Special_up, _
                    My.Resources.ThemedControls_Metallic_Special_up_over, _
                    My.Resources.ThemedControls_Metallic_Special_down, _
                    My.Resources.ThemedControls_Metallic_Special_down_over)
            Case ThemeStyle.Unthemed
                fmt = New TaskBoxFormat( _
                    SystemColors.ActiveCaption, _
                    SystemColors.ActiveCaption, _
                    SystemColors.ControlLightLight, _
                    Color.White, _
                    SystemColors.InactiveCaptionText, _
                    SystemColors.ActiveCaptionText, _
                    SystemColors.WindowText, _
                    SystemInformation.MenuFont, _
                    SystemInformation.MenuFont, _
                    My.Resources.ThemedControls_Unthemed_Special_down, _
                    My.Resources.ThemedControls_Unthemed_Special_down_over, _
                    My.Resources.ThemedControls_Unthemed_Special_up, _
                    My.Resources.ThemedControls_Unthemed_Special_up_over)
        End Select

        Return fmt
    End Function

    Public Shared Function GetTaskPanelTheme(ByVal theme As ThemeStyle) As TaskPanelFormat
        Dim fmt As New TaskPanelFormat

        Select Case theme
            Case ThemeStyle.NormalColor
                fmt = New TaskPanelFormat(Color.FromArgb(82, 130, 210), Color.FromArgb(40, 91, 197))
            Case ThemeStyle.HomeStead
                fmt = New TaskPanelFormat(Color.FromArgb(203, 216, 172), Color.FromArgb(165, 189, 132))
            Case ThemeStyle.Metallic
                fmt = New TaskPanelFormat(Color.FromArgb(195, 199, 211), Color.FromArgb(177, 179, 200))
            Case ThemeStyle.Unthemed
                fmt = New TaskPanelFormat(SystemColors.ControlLight, SystemColors.ControlLight)

        End Select
        Return fmt
    End Function

    Public Shared Function GetSoftBarrierTheme(ByVal theme As ThemeStyle) As SoftBarrierFormat
        Dim fmt As New SoftBarrierFormat

        Select Case theme
            Case ThemeStyle.NormalColor
                fmt = New SoftBarrierFormat(Color.FromArgb(0, 51, 153), _
                    Color.FromArgb(40, 91, 197), _
                    Color.FromArgb(85, 130, 210), _
                    Color.FromArgb(90, 126, 220), _
                    Color.FromArgb(214, 223, 245), _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold), _
                    48)
            Case ThemeStyle.HomeStead
                fmt = New SoftBarrierFormat(Color.FromArgb(150, 168, 103), _
                    Color.FromArgb(164, 168, 103), _
                    Color.FromArgb(165, 189, 132), _
                    Color.FromArgb(165, 189, 132), _
                    Color.FromArgb(224, 231, 184), _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold), _
                    48)
            Case ThemeStyle.Metallic
                fmt = New SoftBarrierFormat(Color.FromArgb(119, 119, 146), _
                    Color.FromArgb(176, 178, 199), _
                    Color.FromArgb(177, 179, 200), _
                    Color.FromArgb(177, 179, 200), _
                    Color.White, _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold), _
                    48)
            Case ThemeStyle.Unthemed
                fmt = New SoftBarrierFormat(SystemColors.ActiveCaption, _
                    SystemColors.InactiveCaption, _
                    SystemColors.ControlLight, _
                    SystemColors.ControlLightLight, _
                    SystemColors.ActiveCaptionText, _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold), _
                    48)
        End Select

        Return fmt
    End Function

    Public Shared Function GetLetterboxTheme(ByVal theme As ThemeStyle) As LetterBoxFormat
        Dim fmt As New LetterBoxFormat

        Select Case theme
            Case ThemeStyle.NormalColor
                fmt = New LetterBoxFormat( _
                    Color.FromArgb(0, 51, 153), _
                    Color.FromArgb(0, 51, 153), _
                    Color.FromArgb(85, 130, 210), _
                    Color.FromArgb(90, 126, 220), _
                    Color.FromArgb(214, 223, 245), _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold))
            Case ThemeStyle.HomeStead
                fmt = New LetterBoxFormat( _
                    Color.FromArgb(150, 168, 103), _
                    Color.FromArgb(150, 168, 103), _
                    Color.FromArgb(165, 189, 132), _
                    Color.FromArgb(165, 189, 132), _
                    Color.FromArgb(224, 231, 184), _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold))
            Case ThemeStyle.Metallic
                fmt = New LetterBoxFormat( _
                    Color.FromArgb(119, 119, 146), _
                    Color.FromArgb(119, 119, 146), _
                    Color.FromArgb(177, 179, 200), _
                    Color.FromArgb(177, 179, 200), _
                    Color.White, _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold))
            Case ThemeStyle.Unthemed
                fmt = New LetterBoxFormat( _
                    SystemColors.ActiveCaption, _
                    SystemColors.ActiveCaption, _
                    SystemColors.InactiveCaption, _
                    SystemColors.InactiveCaption, _
                    Color.White, _
                    New Font("Franklin Gothic Medium", 14, FontStyle.Bold))
        End Select

        Return fmt
    End Function

End Class
