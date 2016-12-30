''' <summary>
''' a component that wraps the BalloonTip API and implements a auto-hide function
''' </summary>
''' <remarks></remarks>
Public Class XPBalloonTip
    Inherits System.ComponentModel.Component

#Region " Vom Component Designer generierter Code "

    Public Sub New(ByVal Container As System.ComponentModel.IContainer)
        MyClass.New()

        'Für Support von Windows.Forms-Klassenkompositions-Designer
        Container.Add(Me)
    End Sub

    Public Sub New()
        MyBase.New()

        ' Dieser Aufruf ist für den Komponenten-Designer erforderlich.
        InitializeComponent()

        ' Initialisierungen nach dem Aufruf InitializeComponent() hinzufügen

    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Komponenten-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Komponenten-Designer erforderlich
    'Sie kann mit dem Komponenten-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
    End Sub

#End Region

    Private _hash As New Hashtable
    Private WithEvents _tmr As New Timer
    Private _currentCtrl As Control = Nothing
    Private _enabled As Boolean = True

    ''' <summary>
    ''' If the control's Enabled-Property is set to False, no balloon tip at all are displayed
    ''' Is used to show/hide balloon tips for all controls...
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public Property Enabled() As Boolean
        Get
            Return _enabled
        End Get
        Set(ByVal Value As Boolean)
            _enabled = Value
        End Set
    End Property

    ''' <summary>
    ''' displays the ballon tip for a defined period of time
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <param name="title"></param>
    ''' <param name="message"></param>
    ''' <param name="icon"></param>
    ''' <param name="Timeout"></param>
    ''' <remarks></remarks>
    Public Overridable Sub Show(ByVal ctrl As Control, ByVal title As String, ByVal message As String, ByVal icon As BalloonTipAPI.ToolTipIcon, ByVal Timeout As Integer)
        If _enabled = False Then Exit Sub

        If Timeout > 0 Then
            Me._tmr.Interval = 1000 * Timeout
            Me._tmr.Enabled = True
        End If

        _currentCtrl = ctrl

        Call BalloonTipAPI.ShowBalloonTip(ctrl, title, message, icon)
    End Sub

    Public Overridable Sub Show(ByVal ctrl As Control, ByVal title As String, ByVal message As String, ByVal icon As BalloonTipAPI.ToolTipIcon)
        Call Me.Show(ctrl, title, message, icon, 0)
    End Sub

    Public Overridable Sub Show(ByVal ctrl As Control, ByVal message As String, ByVal icon As BalloonTipAPI.ToolTipIcon)
        Call Me.Show(ctrl, "", message, icon, 0)
    End Sub

    Public Overridable Sub Show(ByVal ctrl As Control, ByVal message As String)
        Call Me.Show(ctrl, "", message, BalloonTipAPI.ToolTipIcon.None, 0)
    End Sub

    Public Overridable Sub Show(ByVal ctrl As Control, ByVal message As String, ByVal icon As BalloonTipAPI.ToolTipIcon, ByVal timeout As Integer)
        Call Me.Show(ctrl, "", message, icon, timeout)
    End Sub

    Public Overridable Sub Show(ByVal ctrl As Control, ByVal message As String, ByVal timeout As Integer)
        Call Me.Show(ctrl, "", message, BalloonTipAPI.ToolTipIcon.None, timeout)
    End Sub

    Public Sub Hide(ByVal ctrl As Control)
        Call BalloonTipAPI.HideBalloonTip(ctrl)
    End Sub

    Private Sub _tmr_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles _tmr.Tick
        Me.Hide(_currentCtrl)
        _tmr.Enabled = False
    End Sub
End Class
