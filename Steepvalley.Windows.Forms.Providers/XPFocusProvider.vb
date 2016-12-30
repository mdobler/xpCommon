''' <summary>
''' this class extends a form and displays focus hints. Every control that inherits from
''' Form.Control can receive a focus hint. You can select the color and type of the focus
''' hint to display (per control)
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	10.10.2004	Created
'''     [Mike]  02.11.2004  Changed the behaviour of the paint event. The paint event
''' of every parent of each control is now hooked to the painting which ensures that the
''' painting takes place on the current parent of the control and not the base form
''' </history>
<ProvideProperty("ShowFocus", GetType(Control)), _
 ProvideProperty("FocusType", GetType(Control)), _
 ProvideProperty("Color1", GetType(Control)), _
 ProvideProperty("Color2", GetType(Control)), _
 ProvideProperty("Weight", GetType(Control)), _
 ProvideProperty("Margin", GetType(Control))> _
Public Class XPFocusProvider
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

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' an interface method that returns true if a type can be extended by this
    ''' provider
    ''' </summary>
    ''' <param name="extendee"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is System.Windows.Forms.Control And Not TypeOf extendee Is System.Windows.Forms.Form Then
            addPropertyValue(CType(extendee, System.Windows.Forms.Control))
            Return True
        Else
            Return False
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this function adds a FocusExtendedProperties instance for every component of
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
    Private Function addPropertyValue(ByVal ctrl As System.Windows.Forms.Control) As FocusExtendedProperties
        If htCtrlProperties.Contains(ctrl) Then
            Return CType(htCtrlProperties(ctrl), FocusExtendedProperties)
        Else
            Dim props As New FocusExtendedProperties
            htCtrlProperties.Add(ctrl, props)

            AddHandler ctrl.GotFocus, AddressOf GotFocusHandler
            AddHandler ctrl.LostFocus, AddressOf LostFocusHandler
            AddHandler ctrl.ParentChanged, AddressOf ParentChangedHandler
            If Not ctrl.Parent Is Nothing Then
                AddHandler ctrl.Parent.Paint, AddressOf PaintHandler
            End If

            Return props
        End If
    End Function

#Region "Event Handlers"
    Public Sub GotFocusHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim p As Control = CType(sender, Control).Parent()
        If Not p Is Nothing Then p.Invalidate()
    End Sub

    Public Sub LostFocusHandler(ByVal sender As Object, ByVal e As EventArgs)
        Dim p As Control = CType(sender, Control).Parent()
        If Not p Is Nothing Then p.Invalidate()
    End Sub

    Private Sub ParentChangedHandler(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p As Control = CType(sender, Control).Parent
        If Not p Is Nothing Then
            AddHandler p.Paint, AddressOf PaintHandler
        End If
    End Sub
#End Region

#Region "GET/SET Functions for extended control"
    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the getter and setter functions for the ShowFocus Property. If this
    ''' value is true, the focus is rendered for the control
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("Show focus with this control?"), _
     Category("FocusProvider"), _
     DefaultValue(False), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetShowFocus(ByVal ctrl As Control) As Boolean
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).ShowFocus = False
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).ShowFocus
    End Function

    Sub SetShowFocus(ByVal ctrl As Control, ByVal value As Boolean)
        addPropertyValue(ctrl).ShowFocus = value
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the getter and setter functions for the FocusType Property.
    ''' You can select one of the predefined Focus types like underline,
    '''  mark, cirle, square and triangle
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("The Type to draw"), _
     Category("FocusProvider"), _
     DefaultValue(GetType(FocusType), "Underline"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetFocusType(ByVal ctrl As Control) As FocusType
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).FocusType = FocusType.Underline
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).FocusType
    End Function

    Sub SetFocusType(ByVal ctrl As Control, ByVal value As FocusType)
        addPropertyValue(ctrl).FocusType = value
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' The line weight of the marker. Depending on the type this value is the line thickness (underline)
    ''' the width of the marker (Mark), the circles, squares or triangles size.
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("line weight of the marker"), _
     Category("FocusProvider"), _
     DefaultValue(2), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetWeight(ByVal ctrl As Control) As Integer
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Weight = 2
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).Weight
    End Function

    Sub SetWeight(ByVal ctrl As Control, ByVal value As Integer)
        addPropertyValue(ctrl).Weight = value
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the margin from the control to the marker
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("the margin from the control to the marker"), _
     Category("FocusProvider"), _
     DefaultValue(2), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetMargin(ByVal ctrl As Control) As Integer
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Margin = 2
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).Margin
    End Function

    Sub SetMargin(ByVal ctrl As Control, ByVal value As Integer)
        addPropertyValue(ctrl).Margin = value
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the starting color of the focus marker. This Value is used to draw the marker
    ''' as a gradient filled object
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("starting color of the marker"), _
     Category("FocusProvider"), _
     DefaultValue(GetType(Color), "Orange"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetColor1(ByVal ctrl As Control) As Color
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Color1 = Color.Orange
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).Color1
    End Function

    Sub SetColor1(ByVal ctrl As Control, ByVal value As Color)
        addPropertyValue(ctrl).Color1 = value
    End Sub

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' the end color of the marker
    ''' </summary>
    ''' <param name="ctrl"></param>
    ''' <returns></returns>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    ''' -----------------------------------------------------------------------------
    <Description("end color of the marker"), _
     Category("FocusProvider"), _
     DefaultValue(GetType(Color), "DarkOrange"), _
     DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), _
     Browsable(True)> _
    Function GetColor2(ByVal ctrl As Control) As Color
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).Color2 = Color.Orange
        End If
        Return CType(htCtrlProperties(ctrl), FocusExtendedProperties).Color2
    End Function

    Sub SetColor2(ByVal ctrl As Control, ByVal value As Color)
        addPropertyValue(ctrl).Color2 = value
    End Sub
#End Region

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' reacting on the form paint event
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks>
    ''' </remarks>
    ''' <history>
    ''' 	[Mike]	10.10.2004	Created
    ''' </history>
    Private Sub PaintHandler(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim gp As New GraphicsPath

        For Each ctrl As Control In CType(sender, Control).Controls
            If ctrl.Focused Then
                If htCtrlProperties.Contains(ctrl) Then

                    Dim ext As FocusExtendedProperties = CType(htCtrlProperties(ctrl), FocusExtendedProperties)
                    If ext.ShowFocus Then
                        If ext.Weight <= 0 Then ext.Weight = 1
                        Select Case ext.FocusType
                            Case FocusType.Underline
                                Dim rect As Rectangle = Helpers.CheckedRectangle(ctrl.Left, _
                                    ctrl.Top + ctrl.Height + ext.Margin, _
                                    ctrl.Width - 1, _
                                    ext.Weight)
                                e.Graphics.FillRectangle(New LinearGradientBrush(rect, ext.Color1, ext.Color2, LinearGradientMode.Horizontal), rect)

                            Case FocusType.Mark
                                Dim rect As Rectangle = Helpers.CheckedRectangle(ctrl.Left - ext.Margin - ext.Weight, _
                                    ctrl.Top, _
                                    ext.Weight, _
                                    ctrl.Height - 1)
                                e.Graphics.FillRectangle(New LinearGradientBrush(rect, ext.Color1, ext.Color2, LinearGradientMode.Vertical), rect)
                            Case FocusType.Circle
                                Dim rect As Rectangle = Helpers.CheckedRectangle(ctrl.Left - ext.Margin - ext.Weight, _
                                                            ctrl.Top + CInt((ctrl.Height - ext.Weight) / 2), _
                                                            ext.Weight, _
                                                            ext.Weight)
                                e.Graphics.FillEllipse(New LinearGradientBrush(rect, ext.Color1, ext.Color2, LinearGradientMode.ForwardDiagonal), rect)
                            Case FocusType.Square
                                Dim rect As Rectangle = Helpers.CheckedRectangle(ctrl.Left - ext.Margin - ext.Weight, _
                                    ctrl.Top + CInt((ctrl.Height - ext.Weight) / 2), _
                                    ext.Weight, _
                                    ext.Weight)
                                e.Graphics.FillRectangle(New LinearGradientBrush(rect, ext.Color1, ext.Color2, LinearGradientMode.ForwardDiagonal), rect)
                            Case FocusType.Triangle
                                Dim rect As Rectangle = Helpers.CheckedRectangle(ctrl.Left - ext.Margin - ext.Weight, _
                                    ctrl.Top, _
                                    ext.Weight, _
                                    ctrl.Height - 1)
                                Dim p As New GraphicsPath
                                p.StartFigure()
                                p.AddLine(ctrl.Left - ext.Margin - ext.Weight, ctrl.Top, ctrl.Left - ext.Margin, CInt(ctrl.Top + ctrl.Height / 2))
                                p.AddLine(ctrl.Left - ext.Margin, CInt(ctrl.Top + ctrl.Height / 2), ctrl.Left - ext.Margin - ext.Weight, ctrl.Top + ctrl.Height - 1)
                                p.CloseFigure()
                                e.Graphics.FillPath(New LinearGradientBrush(rect, ext.Color1, ext.Color2, LinearGradientMode.ForwardDiagonal), p)
                                p.Dispose()
                        End Select
                    End If
                End If
            End If
        Next

        gp.Dispose()
    End Sub

End Class

#Region "Extender Property Class"
Public Enum FocusType
    Underline
    Mark
    Circle
    Square
    Triangle
End Enum

''' -----------------------------------------------------------------------------
''' Project	 : XPCommonControls
''' Class	 : Windows.Forms.XPFocusProvider.FocusExtendedProperties
''' 
''' -----------------------------------------------------------------------------
''' <summary>
''' the class that holds all the extendable infos
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	10.10.2004	Created
''' </history>
''' -----------------------------------------------------------------------------
Public Class FocusExtendedProperties
    Public ShowFocus As Boolean = False
    Public FocusType As FocusType = FocusType.Underline
    Public Color1 As Color = Color.Orange
    Public Color2 As Color = Color.DarkOrange
    Public Weight As Integer = 2
    Public Margin As Integer = 2
End Class
#End Region