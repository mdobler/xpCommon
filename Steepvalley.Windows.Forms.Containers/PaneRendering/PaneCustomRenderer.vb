Imports Steepvalley.Windows.Forms.Common.Graphics

Public Class PaneCustomRenderer
    Implements IPaneRenderer

#Region " IXPPanelRenderer Interface Implementation "
    Public Sub RenderBackground(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBackground
        If _bgBrush Is Nothing Then Exit Sub

        Dim _lineWidth As Integer = CInt(IIf(_linePen Is Nothing OrElse _linePen.Width = 0, 0, _linePen.Width - 1))
        Dim _inner As New Rectangle(ctrl.Padding.Left + CInt(_lineWidth / 2), ctrl.Padding.Top + CInt(_lineWidth / 2), ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - _lineWidth - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - _lineWidth - 1)

        g.FillPath(_bgBrush, Paths.RoundedRect(_inner, _radiens, _margin))

    End Sub

    Public Sub RenderBorder(ByVal ctrl As Pane, ByVal g As System.Drawing.Graphics) Implements IPaneRenderer.RenderBorder
        If _linePen Is Nothing Then Exit Sub

        Dim _lineWidth As Integer = CInt(IIf(_linePen Is Nothing OrElse _linePen.Width = 0, 0, _linePen.Width - 1))
        Dim _inner As New Rectangle(ctrl.Padding.Left + CInt(_lineWidth / 2), ctrl.Padding.Top + CInt(_lineWidth / 2), ctrl.Width - ctrl.Padding.Left - ctrl.Padding.Right - _lineWidth - 1, ctrl.Height - ctrl.Padding.Top - ctrl.Padding.Bottom - _lineWidth - 1)

        g.DrawPath(_linePen, Paths.RoundedRect(_inner, _radiens, _margin))

    End Sub
#End Region

#Region " Public Custom Properties "
    Private _bgBrush As Brush = SystemBrushes.ControlLight
    Private _linePen As Pen = SystemPens.ControlLightLight
    Private _margin As Padding = New Padding(0)
    Private _radiens As CornerRadiens = New CornerRadiens(0)

    ''' <summary>
    ''' the background brush with which the renderer draws the background part
    ''' you can set this property to a simple Brush or a gradient brush
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BackgroundBrush() As Brush
        Get
            Return _bgBrush
        End Get
        Set(ByVal value As Brush)
            _bgBrush = value
        End Set
    End Property

    ''' <summary>
    ''' the pen with which the border around the control is drawn. 
    ''' Using a pen will allow you to set the border's width, dotted lines
    ''' and other properties
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property BorderPen() As Pen
        Get
            Return _linePen
        End Get
        Set(ByVal value As Pen)
            _linePen = value
        End Set
    End Property

    ''' <summary>
    ''' defines the margin between the outer bounds of the control and the border/background
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Margin() As Padding
        Get
            Return _margin
        End Get
        Set(ByVal value As Padding)
            _margin = value
        End Set
    End Property

    ''' <summary>
    ''' defines the radius for each corner of the control separately
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Radiens() As CornerRadiens
        Get
            Return _radiens
        End Get
        Set(ByVal value As CornerRadiens)
            _radiens = value
        End Set
    End Property

#End Region
End Class
