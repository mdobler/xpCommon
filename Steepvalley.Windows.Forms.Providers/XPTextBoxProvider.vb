''' <summary>
''' this class is an extender for textbox controls. it paints their
''' outer border with smooth edges plus a "focus hint" when the textbox
''' receives the focus
''' </summary>
''' <remarks>
''' </remarks>
''' <history>
''' 	[Mike]	02.11.2004	Changed the painting event. the painting event is now
''' based on the parent control of each textbox which ensures that it is alyways
''' painted on the "correct surface"
''' 
''' In the previous version the extender always tried to paint on the base form 
''' which was problematic when the control was inside another component
''' </history>
<ProvideProperty("RenderTextbox", GetType(TextBox)), _
 ProvideProperty("BorderColor", GetType(TextBox))> _
Public Class XPTextBoxProvider
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
    'Private _activeCtrl As TextBox

    Public Function CanExtend(ByVal extendee As Object) As Boolean Implements System.ComponentModel.IExtenderProvider.CanExtend
        If TypeOf extendee Is System.Windows.Forms.TextBox Then
            Return True
            addPropertyValue(CType(extendee, TextBox))
        Else
            Return False
        End If
    End Function

    ''' -----------------------------------------------------------------------------
    ''' <summary>
    ''' this function adds a XPTextboxExtendedProperties instance for every component of
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
    Private Function addPropertyValue(ByVal ctrl As System.Windows.Forms.TextBox) As XPTextboxExtendedProperties
        If htCtrlProperties.Contains(ctrl) Then
            Return CType(htCtrlProperties(ctrl), XPTextboxExtendedProperties)
        Else
            Dim props As New XPTextboxExtendedProperties
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
    <Description("render this textbox as xpTextBox"), _
     Category("XPTextboxProvider"), _
     DefaultValue(False)> _
    Function GetRenderTextbox(ByVal ctrl As TextBox) As Boolean
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).RenderTextbox = False
        End If
        Return CType(htCtrlProperties(ctrl), XPTextboxExtendedProperties).RenderTextbox
    End Function

    Sub SetRenderTextbox(ByVal ctrl As TextBox, ByVal value As Boolean)
        addPropertyValue(ctrl).RenderTextbox = value
        If Not ctrl.Parent Is Nothing Then ctrl.Parent.Invalidate()
    End Sub

    <Description("The Border Color of the xpTextBox"), _
    Category("XPTextboxProvider"), _
    DefaultValue(GetType(Color), "ActiveBorder")> _
    Function GetBorderColor(ByVal ctrl As TextBox) As Color
        If Not htCtrlProperties.Contains(ctrl) Then
            addPropertyValue(ctrl).BorderColor = SystemColors.ActiveBorder
        End If
        Return CType(htCtrlProperties(ctrl), XPTextboxExtendedProperties).BorderColor
    End Function

    Sub SetBorderColor(ByVal ctrl As TextBox, ByVal value As Color)
        addPropertyValue(ctrl).BorderColor = value
        If Not ctrl.Parent Is Nothing Then ctrl.Parent.Invalidate()
    End Sub
#End Region

    Private Sub PaintHandler(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        'If Not _activeCtrl Is Nothing Then
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim lpenborder As New Pen(SystemColors.ActiveBorder, 1)
        Dim gp As New GraphicsPath
        lpenborder.Alignment = PenAlignment.Inset

        For Each ctrl As Control In CType(sender, Control).Controls
            If TypeOf (ctrl) Is TextBox AndAlso ctrl.Visible = True Then
                If htCtrlProperties.Contains(ctrl) Then
                    Dim tb As TextBox = CType(ctrl, TextBox)
                    Dim ext As XPTextboxExtendedProperties = CType(htCtrlProperties(ctrl), XPTextboxExtendedProperties)

                    If ext.RenderTextbox Then
                        If tb.BorderStyle <> BorderStyle.None Then tb.BorderStyle = BorderStyle.None

                        lpenborder.Color = ext.BorderColor
                        gp = Paths.RoundedRect(Helpers.CheckedRectangle(tb.Left - 5, tb.Top - 5, tb.Width + 10, tb.Height + 10), 3, 1, Corner.All)
                        If tb.Enabled Then
                            e.Graphics.FillPath(New SolidBrush(tb.BackColor), gp)
                            If tb.Focused Then
                                e.Graphics.DrawLine(New Pen(Color.Orange, 2), tb.Left - 4, tb.Top + tb.Height + 3, tb.Left + tb.Width + 3, tb.Top + tb.Height + 3)
                            End If
                            e.Graphics.DrawPath(lpenborder, gp)
                        Else
                            tb.BackColor = Helpers.GetNonTransparentBackColor(tb)
                            e.Graphics.FillPath(New SolidBrush(tb.Parent.BackColor), gp)
                            e.Graphics.DrawPath(lpenborder, gp)
                        End If
                    End If
                End If
            End If
        Next

        gp.Dispose()
        lpenborder.Dispose()

        'End If
    End Sub


End Class

#Region "Extender Property Class"
Public Class XPTextboxExtendedProperties
    Public RenderTextbox As Boolean = False
    Public BorderColor As Color = SystemColors.ActiveBorder
    Public HasFocus As Boolean = False
End Class
#End Region