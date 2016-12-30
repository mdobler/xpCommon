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
<ProvideProperty("RenderTextbox", GetType(TextBox))> _
Public Class XPTextBoxProvider2
    Inherits System.ComponentModel.Component
    Implements System.ComponentModel.IExtenderProvider

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
    Private Function addPropertyValue(ByVal ctrl As System.Windows.Forms.TextBox) As XPTextbox2ExtendedProperties
        If htCtrlProperties.Contains(ctrl) Then
            Return CType(htCtrlProperties(ctrl), XPTextbox2ExtendedProperties)
        Else
            Dim props As New XPTextbox2ExtendedProperties
            htCtrlProperties.Add(ctrl, props)

            AddHandler ctrl.ParentChanged, AddressOf ParentChangedHandler
            If Not ctrl.Parent Is Nothing Then
                AddHandler ctrl.Parent.Paint, AddressOf PaintHandler
            End If
            Return props
        End If
    End Function

#Region "Event Handlers"
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
        Return CType(htCtrlProperties(ctrl), XPTextbox2ExtendedProperties).RenderTextbox
    End Function

    Sub SetRenderTextbox(ByVal ctrl As TextBox, ByVal value As Boolean)
        addPropertyValue(ctrl).RenderTextbox = value
        If Not ctrl.Parent Is Nothing Then ctrl.Parent.Invalidate()
    End Sub
#End Region

    Private Sub PaintHandler(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        Dim gp As New GraphicsPath

        For Each ctrl As Control In CType(sender, Control).Controls
            If TypeOf (ctrl) Is TextBox AndAlso ctrl.Visible = True Then
                If htCtrlProperties.Contains(ctrl) Then
                    Dim tb As TextBox = CType(ctrl, TextBox)
                    Dim ext As XPTextbox2ExtendedProperties = CType(htCtrlProperties(ctrl), XPTextbox2ExtendedProperties)

                    If ext.RenderTextbox Then
                        If tb.BorderStyle <> BorderStyle.None Then tb.BorderStyle = BorderStyle.None

                        'draw shadow
                        gp = Paths.RoundedRect(Helpers.CheckedRectangle(tb.Left - 4, tb.Top - 4, tb.Width + 11, tb.Height + 11), 3, 1, Corner.All)
                        e.Graphics.FillPath(New SolidBrush(Color.FromArgb(50, Color.Black)), gp)

                        'draw textbox
                        gp = Paths.RoundedRect(Helpers.CheckedRectangle(tb.Left - 5, tb.Top - 5, tb.Width + 10, tb.Height + 10), 3, 1, Corner.All)
                        If tb.Enabled Then
                            e.Graphics.FillPath(New SolidBrush(tb.BackColor), gp)
                        Else
                            tb.BackColor = Helpers.GetNonTransparentBackColor(tb)
                            e.Graphics.FillPath(New SolidBrush(tb.Parent.BackColor), gp)
                        End If
                    End If
                End If
            End If
        Next

        gp.Dispose()
    End Sub


End Class

#Region "Extender Property Class"
Public Class XPTextbox2ExtendedProperties
    Public RenderTextbox As Boolean = False
End Class
#End Region