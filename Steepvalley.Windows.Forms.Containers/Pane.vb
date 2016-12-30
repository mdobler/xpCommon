Imports System.Drawing
Imports System.Drawing.Drawing2D

''' <summary>
''' a simple Panel that supports Renderers...
''' </summary>
''' <remarks>please check the designer code for the SetStyle(...) calls</remarks>
Public Class Pane
    Implements IRenderableControl


#Region " IRenderableControl Interface Implementation "
    Private _renderer As IPaneRenderer = New PaneSystemRenderer
    Public Overridable Property Renderer() As IRenderer Implements IRenderableControl.Renderer
        Get
            Return _renderer
        End Get
        Set(ByVal value As IRenderer)
            _renderer = DirectCast(value, IPaneRenderer)
            Me.Invalidate()
        End Set
    End Property

    Private _renderMode As RenderModes = RenderModes.System
    Public Overridable Property RenderMode() As RenderModes Implements IRenderableControl.RenderMode
        Get
            Return _renderMode
        End Get
        Set(ByVal value As RenderModes)
            If Not value.Equals(_renderMode) Then
                _renderMode = value
                Me.Invalidate()
            End If
        End Set
    End Property
#End Region

#Region " Paint Events "
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If TypeOf _renderer Is IPaneRenderer Then
            With CType(_renderer, IPaneRenderer)
                .RenderBackground(Me, e.Graphics)
                .RenderBorder(Me, e.Graphics)
            End With
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub
#End Region
End Class
