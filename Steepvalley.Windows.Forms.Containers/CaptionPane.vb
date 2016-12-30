Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class CaptionPane
    Inherits Pane

#Region " Properties "

    Private _captionText As String = ""
    Public Property CaptionText() As String
        Get
            Return _captionText
        End Get
        Set(ByVal value As String)
            _captionText = value
            Me.Invalidate()
        End Set
    End Property

    Private _captionHeight As Integer = 25
    Public Property CaptionHeight() As Integer
        Get
            Return _captionHeight
        End Get
        Set(ByVal value As Integer)
            _captionHeight = value
            Me.Invalidate()
        End Set
    End Property

    Public Enum Positioning
        Top
        Bottom
    End Enum

    Private _captionPos As Positioning = Positioning.Top
    Public Property CaptionPosition() As Positioning
        Get
            Return _captionPos
        End Get
        Set(ByVal value As Positioning)
            _captionPos = value
            Me.Invalidate()
        End Set
    End Property

    Private _renderer As ICaptionPaneRenderer = New CaptionPaneSystemRenderer
    Public Overrides Property Renderer() As IRenderer
        Get
            Return _renderer
        End Get
        Set(ByVal value As IRenderer)
            _renderer = DirectCast(value, ICaptionPaneRenderer)
            Me.Invalidate()
        End Set
    End Property
#End Region

#Region " Paint Events "
    Protected Overrides Sub OnPaintBackground(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintBackground(e)

        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If TypeOf _renderer Is ICaptionPaneRenderer Then
            With CType(_renderer, ICaptionPaneRenderer)
                .RenderBackground(Me, e.Graphics)
                .RenderCaption(Me, e.Graphics)
                .RenderBorder(Me, e.Graphics)
            End With
        End If
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
    End Sub
#End Region
End Class
