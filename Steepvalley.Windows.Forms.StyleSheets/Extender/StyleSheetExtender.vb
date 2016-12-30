Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports System.Windows.Forms
Imports System.Reflection


<Designer(GetType(Steepvalley.Windows.Forms.Styles.StyleSheetExtenderDesigner)), _
 ProvideProperty("Styleable", GetType(Control)), _
 ProvideProperty("ClassID", GetType(Control))> _
Public Class StyleSheetExtender
    Inherits System.ComponentModel.Component
    Implements IExtenderProvider

#Region "private vars"
    'a hashtable that holds all contols for the extender
    Friend htCtrlProperties As New Hashtable
    'the style sheet name for the style extender
    Private _StyleSheetName As String = ""
    'the style sheet object
    Private _StyleSheet As New StyleSheet
    'the current form the style sheet extender is located
    Private WithEvents _ParentForm As Form
    'a bit that tells if newly added controls are styleable by default
    Private _StyleableByDefault As Boolean = False
    'an object for the about dialog
    Private dlgAbout As New About
#End Region

#Region "Licensing"
    '    'Private _License As License = Nothing

    '    Private _lic As Licensing
    '    Private _licKey As String = ""
    '    Private _licensee As String = ""
    '    Private _isLicensed As Boolean = False
    '    Private _isDemoMode As Boolean = True

    '    <DesignOnly(True), _
    '     DefaultValue(""), _
    '     Category("Licensing"), _
    '     Description("the license code provided for the licensee")> _
    '    Public Property License() As String
    '        Get
    '            Return _licKey
    '        End Get
    '        Set(ByVal Value As String)
    '            _licKey = Value
    '        End Set
    '    End Property

    '    <DesignOnly(True), _
    '    DefaultValue(""), _
    '    Category("Licensing"), _
    '    Description("the licensee (user/company) that the control is licensed to")> _
    '    Public Property Licensee() As String
    '        Get
    '            Return _licensee
    '        End Get
    '        Set(ByVal Value As String)
    '            _licensee = Value
    '        End Set
    '    End Property

    '    Private Sub CheckLicense()

    '        _lic = New Licensing("fd99aug", New Licensing.LicenseInfo( _
    '            AssemblyAttributes.Title, _
    '            String.Format("{0}.{1}", AssemblyAttributes.VersionMajor, AssemblyAttributes.VersionMinor), _
    '            _licensee))

    '        If _licKey.Length = 0 And _licensee.Length = 0 Then
    '            _isLicensed = False
    '            _isDemoMode = True
    '        Else
    '            _isLicensed = _lic.IsValidLicense(_licKey)
    '            _isDemoMode = CBool(IIf(_licensee = "DEMOUser", True, False))
    '        End If

    '        If Me.DesignMode = True Or (Not Me.Site Is Nothing AndAlso Me.Site.DesignMode = True) Then
    '            If _isLicensed = False Then
    '                MessageBox.Show("Please provide the correct license information to run the component 'StyleSheetExtender' correctly!", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    '            End If
    '            If _isDemoMode = True Then
    '                Me.About()
    '            End If
    '        Else
    '            If _isLicensed = False Then
    '                Throw New LicenseException("Invalid License Information for component 'StyleSheetExtender'!")
    '            End If
    '            If _isDemoMode = True Then
    '                Me.About()
    '            End If
    '        End If
    '    End Sub

    'Private Sub tmrNagScreen_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrNagScreen.Tick
    '    tmrNagScreen.Enabled = False
    '    CheckLicense()
    '    If _isLicensed Then
    '        tmrNagScreen.Stop()
    '    Else
    '        tmrNagScreen.Enabled = True
    '    End If
    'End Sub
#End Region

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
        '_License = LicenseManager.Validate(Me.GetType, Me)

        'If LicenseManager.IsValid(Me.GetType, Me, _License) = False Then
        '    MessageBox.Show("No Valid License or License expired for the StyleSheetExtenderControl!", "License Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Me.Dispose()
        'End If

        'tmrNagScreen.Start()
    End Sub

    'Die Komponente überschreibt den Löschvorgang zum Bereinigen der Komponentenliste.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
            'If Not (_License Is Nothing) Then
            '    _License.Dispose()
            '    _License = Nothing
            'End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' Für Komponenten-Designer erforderlich
    Private components As System.ComponentModel.IContainer

    'HINWEIS: Die folgende Prozedur ist für den Komponenten-Designer erforderlich
    'Sie kann mit dem Komponenten-Designer modifiziert werden.
    'Verwenden Sie nicht den Code-Editor zur Bearbeitung.
    Private WithEvents tmrNagScreen As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        'Me.tmrNagScreen = New System.Windows.Forms.Timer(Me.components)
        '
        'tmrNagScreen
        '
        'Me.tmrNagScreen.Interval = 300000

    End Sub

#End Region

#Region "public properties"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the style sheet from where to get all the properties
    ''' </summary>
    ''' <value></value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	01.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Browsable(True), _
     DefaultValue(""), _
     Category("Styles"), _
     Description("the filename of the stylesheet"), _
     EditorAttribute(GetType(System.Windows.Forms.Design.FileNameEditor), GetType(System.Drawing.Design.UITypeEditor))> _
    Public Property StyleSheet() As String
        Get
            Return _StyleSheetName
        End Get
        Set(ByVal Value As String)
            Try
                Dim _retval As StyleSheet = Styles.StyleSheet.FromXMLFile(Value)
                If Not _retval Is Nothing AndAlso Not _retval Is New StyleSheet AndAlso Not _retval Is _StyleSheet Then
                    _StyleSheetName = Value
                    _StyleSheet = _retval
                    ApplyStyles()
                End If
            Catch ex As Exception

            End Try
        End Set
    End Property

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this sets the styleable property on freshly added controls
    ''' to this preset value
    ''' </summary>
    ''' <value>boolean</value>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	08.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Browsable(True), _
     DefaultValue(False), _
     Category("Styles"), _
     Description("this sets the styleable property on freshly added controls to this value")> _
    Public Property StyleableByDefault() As Boolean
        Get
            Return _StyleableByDefault
        End Get
        Set(ByVal Value As Boolean)
            _StyleableByDefault = Value
        End Set
    End Property

    <Browsable(False)> _
    Friend Property StyleObject() As StyleSheet
        Get
            Return _StyleSheet
        End Get
        Set(ByVal Value As StyleSheet)
            _StyleSheet = Value
        End Set
    End Property

    <Browsable(False)> Public Property Form() As Form
        Get
            If Me.Site.DesignMode Then
                Dim dh As IDesignerHost = _
                 DirectCast(Me.GetService( _
                 GetType(IDesignerHost)), IDesignerHost)
                If Not dh Is Nothing Then
                    Dim obj As Object = dh.RootComponent
                    If Not obj Is Nothing Then
                        Me.Form = DirectCast(obj, Form)
                    End If
                End If
            End If
            Return _ParentForm
        End Get

        Set(ByVal Value As Form)
            If Not Value Is Nothing Then
                _ParentForm = Value
            End If
        End Set
    End Property
#End Region

#Region "public methods"
    Public Sub LoadStyleSheet()
        Dim dlg As New OpenFileDialog
        With dlg
            .Filter = "StyleSheets|*.wfs|All Files|*.*"
            .DefaultExt = "wfs"
            .Title = "Open Stylesheet"

            If .ShowDialog = DialogResult.OK Then
                If .FileName <> "" Then
                    Me.StyleSheet = .FileName
                End If
            End If
        End With
    End Sub

    Public Sub About()
        dlgAbout.ShowDialog()
    End Sub

    Public Sub SaveCurrentStyle()
        Dim dlg As New SaveFileDialog
        Dim obj As New StyleSheet
        Dim stls As New StyleCollection

        With obj
            .Author = "StyleSheetExtender"
            .Description = "Current Styling"
            .LastEdited = Today
            .Name = "CurrentStyle"
            Call _getStyles(_ParentForm, stls)
            .Styles = stls
        End With

        'save the object
        With dlg
            .Filter = "StyleSheets|*.wfs"
            .DefaultExt = "wfs"
            .Title = "Save Current Styles"

            If .ShowDialog = DialogResult.OK Then
                If .FileName <> "" Then
                    obj.ToXML(.FileName)
                End If
            End If
        End With
    End Sub

    Private Sub _getStyles(ByVal parent As Control, ByRef styles As StyleCollection)
        For Each ctrl As Control In parent.Controls
            'add, only if styleable is set to true...
            If GetStyleable(ctrl) = True Then
                Dim _style As New Style
                Dim _value As String
                Dim _defaultAtt As DefaultValueAttribute

                With _style
                    .Reference = New Reference(ctrl.GetType.Assembly)
                    .TypeName = ctrl.GetType.FullName
                    .ClassID = GetClassID(ctrl)

                    For Each p As PropertyInfo In ctrl.GetType.GetProperties
                        'get the current value of the property
                        _value = TypeDescriptor.GetConverter(p.PropertyType).ConvertToString(p.GetValue(ctrl, Nothing))
                        'get the property's default value (from attribute)
                        _defaultAtt = CType(TypeDescriptor.GetProperties(ctrl).Item(p.Name).Attributes(GetType(DefaultValueAttribute)), DefaultValueAttribute)

                        'add only if default value and value are not equal
                        'AND a default value is defined!!!
                        If Not _defaultAtt Is Nothing _
                         AndAlso Not _defaultAtt.Value Is Nothing AndAlso _
                         _value <> _defaultAtt.Value.ToString Then
                            _style.Properties.Add(p.Name, _value)
                        End If
                    Next
                End With

                styles.Add(_style)
            End If

            'recursive call for the child elements of a control
            Call _getStyles(ctrl, styles)
        Next
    End Sub
#End Region

#Region "Styling methods"
    Public Sub ApplyStyles()

        If _StyleSheet Is Nothing Then Exit Sub

        'If _isLicensed = False Then Exit Sub

        'If _isDemoMode = True Then Me.About()


        Me.Form.SuspendLayout()

        'try to sort the styles
        _StyleSheet.Styles.Sort()

        'loop through all controls that are added to the extender
        For Each e As DictionaryEntry In htCtrlProperties
            Dim ctrl As Control = CType(e.Key, Control)
            Dim ext As StyleExtendedProperties = CType(e.Value, StyleExtendedProperties)

            If ext.Styleable = True Then
                ApplyStyleToControl(ctrl, ext.ClassID)
            End If
        Next

        Me.Form.ResumeLayout()
    End Sub

    Private Sub ApplyStyleToControl(ByVal ctrl As Control, ByVal classID As String)
        Try
            'apply the defined styles to the control
            'TODO: sort the stylesheet...
            For Each style As Steepvalley.Windows.Forms.Styles.Style In _StyleSheet.Styles
                Dim objAssembly As [Assembly] = AssemblyLoader.ProbeAssembly(style.Reference)
                Dim t As Type = objAssembly.GetType(style.TypeName)

                'apply style if control is an instance of the style type and
                'both class ids match OR the class id of the style is not set
                '--> style defintion for all instances of type
                If classID Is Nothing Then classID = ""
                If style.ClassID Is Nothing Then style.ClassID = ""

                If t.IsInstanceOfType(ctrl) And _
                    (classID.ToUpper = style.ClassID.ToUpper Or _
                     style.ClassID = "") _
                    Then

                    For Each entry As ItemProperty In style.Properties
                        Dim prop As PropertyInfo
                        prop = ctrl.GetType.GetProperty(entry.Name)
                        'found property
                        If Not prop Is Nothing Then
                            If prop.CanWrite Then
                                'this call creates an object value of property type from a string
                                prop.SetValue(ctrl, _
                                    TypeDescriptor.GetConverter( _
                                        prop.PropertyType).ConvertFromString( _
                                        entry.Value), _
                                    Nothing)
                            End If
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            'TODO: error handlers...
        End Try
    End Sub

    Private Sub _ParentForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles _ParentForm.Load
        ApplyStyles()
    End Sub
#End Region

#Region "GET/SET Functions for extended control"
    <Description("Can styles be applied to this control?"), _
     Category("WinForms Styling"), _
     DefaultValue(False)> _
    Function GetStyleable(ByVal ctrl As Control) As Boolean
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Styleable = _StyleableByDefault
            If _StyleableByDefault = True Then
                ApplyStyleToControl(ctrl, "")
            End If
        End If
        Return CType(htCtrlProperties(ctrl), StyleExtendedProperties).Styleable
    End Function

    Sub SetStyleable(ByVal ctrl As Control, ByVal value As Boolean)
        addPropertyValue(ctrl).Styleable = value
        If value = True Then
            ApplyStyleToControl(ctrl, CType(htCtrlProperties(ctrl), StyleExtendedProperties).ClassID)
        End If
    End Sub

    <Description("the class id of this specific control. Empty if no specific class id is applicable"), _
    Category("WinForms Styling"), _
    DefaultValue("")> _
    Function GetClassID(ByVal ctrl As Control) As String
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).ClassID = ""
        End If
        Return CType(htCtrlProperties(ctrl), StyleExtendedProperties).ClassID
    End Function

    Sub SetClassID(ByVal ctrl As Control, ByVal value As String)
        addPropertyValue(ctrl).ClassID = value
        If CType(htCtrlProperties(ctrl), StyleExtendedProperties).Styleable = True Then
            ApplyStyleToControl(ctrl, value)
        End If
    End Sub
#End Region

#Region "Extended Properties"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' returns true for any control that inherits from system.control
    ''' </summary>
    ''' <param name="extendee"></param>
    ''' <returns>true if type can be extended</returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	01.06.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is System.Windows.Forms.Control Then
            Return True
            addPropertyValue(DirectCast(extendee, Control))
        Else
            Return False
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this function adds a StyleExtendedProperties instance for every component of
    ''' the form
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Private Function addPropertyValue(ByVal ctrl As Control) As StyleExtendedProperties
        If htCtrlProperties.Contains(ctrl) Then
            Return CType(htCtrlProperties(ctrl), StyleExtendedProperties)
        Else
            Dim props As New StyleExtendedProperties
            htCtrlProperties.Add(ctrl, props)
            'TODO: add handler if needed
            Return props
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' Project	 : Steepvalley.Windows.Forms.Styles
    ''' Class	 : Windows.Forms.Styles.StyleSheetExtender.StyleExtendedProperties
    ''' 
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this class holds all the info of the extended components
    ''' </summary>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	02.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Class StyleExtendedProperties
        Public Styleable As Boolean
        Public ClassID As String
    End Class
#End Region
End Class


'TODO: add a application style sheet and a user style sheet...