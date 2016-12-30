Public Class XPTaskBoxSpecial
    Inherits XPTaskBox


#Region " Vom Windows Form Designer generierter Code "

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Windows Form-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen
        Me.mThemeFormat = Theming.GetTaskBoxThemeSpecial(mTheme)
    End Sub

    ' Die Form überschreibt den Löschvorgang der Basisklasse, um Komponenten zu bereinigen.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Windows Form-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Windows Form-Designer erforderlich
    'Sie kann mit dem Windows Form-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

#Region "overriden fields and properties of the base (generic) taskbox"

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' Sets the theming of the control
    ''' </summary>
    ''' <value>ThemeStyle</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	14.03.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Sets the theming of the control"), _
     Category("Appearance"), _
     Browsable(True), _
     DefaultValue(GetType(ThemeStyle), "NormalColor")> _
    Public Overrides Property Theme() As ThemeStyle
        Get
            Return mTheme
        End Get
        Set(ByVal value As ThemeStyle)
            mTheme = value
            mThemeFormat = Theming.GetTaskBoxThemeSpecial(mTheme)
            Me.Invalidate()
        End Set
    End Property
#End Region

End Class

