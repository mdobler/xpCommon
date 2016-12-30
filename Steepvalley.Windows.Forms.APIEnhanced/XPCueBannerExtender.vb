Imports System.ComponentModel
Imports System.ComponentModel.Design

''' <summary>
''' this is an extender control for Textboxes and Comboboxes that allows a "cue text"
''' to be displayed. The cue text is a grayed out description text that is displayed in
''' the textbox before the user enters any information. 
''' After the textbox has content, the cue text won't be displayed.
''' </summary>
''' <remarks></remarks>
<ProvideProperty("CueBannerText", GetType(Control))> _
Public Class XPCueBannerExtender
    Inherits System.ComponentModel.Component
    Implements System.ComponentModel.IExtenderProvider

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

    'a hashtable that holds all contols for the extender
    Friend htCtrlProperties As New Hashtable
    Private _activeCtrl As Control

    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is System.Windows.Forms.TextBox Or _
            TypeOf extendee Is System.Windows.Forms.ComboBox Then
            Return True
            addPropertyValue(CType(extendee, System.Windows.Forms.Control))
        Else
            Return False
        End If
    End Function

    Private Function addPropertyValue(ByVal ctrl As System.Windows.Forms.Control) As CueBannerExtendedProperties
        If htCtrlProperties.Contains(ctrl) Then
            Return CType(htCtrlProperties(ctrl), CueBannerExtendedProperties)
        Else
            Dim props As New CueBannerExtendedProperties
            htCtrlProperties.Add(ctrl, props)

            AddHandler ctrl.HandleCreated, AddressOf HandleCreatedEventHandler

            Return props
        End If
    End Function

#Region "GET/SET Functions for extended control"
    <Description("Cue Banner Text to be displayed"), _
    Category("CueBannerProvider"), _
    DefaultValue(False), _
    DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
    Browsable(True)> _
    Function GetCueBannerText(ByVal ctrl As Control) As String
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Text = ""
        End If
        Return CType(htCtrlProperties(ctrl), CueBannerExtendedProperties).Text
    End Function

    Sub SetCueBannerText(ByVal ctrl As Control, ByVal value As String)
        addPropertyValue(ctrl).Text = value
    End Sub
#End Region

#Region "event handlers"
    Public Sub HandleCreatedEventHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim _ctrl As Control
        Dim _text As String

        _ctrl = CType(sender, Control)
        If Not _ctrl Is Nothing Then
            _text = addPropertyValue(_ctrl).Text
            If _text.Length > 0 Then
                Call CueBannerAPI.SetCueBanner(_ctrl, _text)
            End If
        End If
    End Sub
#End Region

#Region "Extender Property Class"
    Public Class CueBannerExtendedProperties
        Public Text As String = ""
    End Class
#End Region
End Class
