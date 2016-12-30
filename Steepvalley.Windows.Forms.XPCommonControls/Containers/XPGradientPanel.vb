Imports System.ComponentModel
Imports System.Drawing.Imaging

Namespace Containers
    ''' <summary>
    ''' a panel with a linear gradient background
    ''' </summary>
    ''' <remarks></remarks>
    Public Class XPGradientPanel
        Inherits System.Windows.Forms.Panel

#Region "Designer Code"
        <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
            MyBase.New()

            'This call is required by the Component Designer.
            InitializeComponent()

            Me.DoubleBuffered = True
        End Sub

        'Component overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Component Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Component Designer
        'It can be modified using the Component Designer.
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            components = New System.ComponentModel.Container()
        End Sub

#End Region

#Region "Private Fields"
        Private mStartColor As Color = SystemColors.InactiveCaptionText
        Private mEndColor As Color = SystemColors.InactiveCaption
        Private mGradient As Drawing2D.LinearGradientMode = Drawing2D.LinearGradientMode.ForwardDiagonal

        Private mWatermark As Image = Nothing
        Private mWatermarkSize As Size = New Size(150, 150)
#End Region

#Region "Public Properties"
        ''' <summary>
        ''' the starting color of the gradient background
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("the starting color of the gradient background"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(Color), "InactiveCaptionText")> _
        Public Property StartColor() As Color
            Get
                Return mStartColor
            End Get
            Set(ByVal value As Color)
                mStartColor = value
            End Set
        End Property

        ''' <summary>
        ''' the end color of the gradient background
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("the end color of the gradient background"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(Color), "InactiveCaption")> _
        Public Property EndColor() As Color
            Get
                Return mEndColor
            End Get
            Set(ByVal value As Color)
                mEndColor = value
            End Set
        End Property

        ''' <summary>
        '''  the gradient direction of the gradient background
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("the gradient direction of the gradient background"), _
        Category("Appearance"), _
        Browsable(True), _
        DefaultValue(GetType(Drawing2D.LinearGradientMode), "ForwardDiagonal")> _
        Public Property Gradient() As Drawing2D.LinearGradientMode
            Get
                Return mGradient
            End Get
            Set(ByVal value As Drawing2D.LinearGradientMode)
                mGradient = value
            End Set
        End Property

        ''' <summary>
        ''' this property allows you to add a faded image to the 
        ''' right bottom corner of the control.
        ''' The code for this was supplied by Dave Wraight. 
        ''' It is automatically desaturated and faded as described in the 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("draws a watermark at the bottom of the control"), _
         Category("Appearance"), _
         Browsable(True), _
         Localizable(True), _
         DefaultValue(GetType(Image), "")> _
        Public Property Watermark() As Image
            Get
                Return mWatermark
            End Get
            Set(ByVal Value As Image)
                mWatermark = Value
                Me.Invalidate()
            End Set
        End Property

        ''' <summary>
        ''' sets the size of the watermark 
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        <Description("the size of the watermark"), _
        Category("Appearance"), _
        Browsable(True), _
        Localizable(True), _
        DefaultValue(GetType(Size), "150, 150")> _
        Public Property WatermarkSize() As Size
            Get
                Return mWatermarkSize
            End Get
            Set(ByVal Value As Size)
                mWatermarkSize = Value
                Me.Invalidate()
            End Set
        End Property
#End Region

#Region "Paint Methods"
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            If Me.Width > 0 Or Me.Height > 0 Then
                Dim rectPaint As RectangleF = Helpers.CheckedRectangleF(0, 0, Me.Width, Me.Height)
                Dim gradBrush As New System.Drawing.Drawing2D.LinearGradientBrush(rectPaint, mStartColor, mEndColor, mGradient)

                e.Graphics.FillRectangle(gradBrush, rectPaint)
                DrawWatermark(e.Graphics)
            End If
            MyBase.OnPaint(e)
        End Sub

        ''' <summary>
        ''' draws the watermark at the right bottom border
        ''' code provided by Dave Wraight
        ''' </summary>
        ''' <param name="g"></param>
        ''' <remarks></remarks>
        Protected Overridable Sub DrawWatermark(ByVal g As Drawing.Graphics)
            'draw watermark icon
            If Not mWatermark Is Nothing Then
                If mWatermarkSize.IsEmpty Then
                    mWatermarkSize = mWatermark.Size
                End If

                Dim lrectWatermark As Rectangle = Helpers.CheckedRectangle( _
                    Me.Width - mWatermarkSize.Width, _
                    Me.Height - mWatermarkSize.Height, _
                    mWatermarkSize.Width, _
                    mWatermarkSize.Height)

                Dim clrMatrix As ColorMatrix = New ColorMatrix
                clrMatrix.Matrix33 = 0.12F

                clrMatrix.Matrix00 = 1 / 3.0F
                clrMatrix.Matrix01 = 1 / 3.0F
                clrMatrix.Matrix02 = 1 / 3.0F
                clrMatrix.Matrix10 = 1 / 3.0F
                clrMatrix.Matrix11 = 1 / 3.0F
                clrMatrix.Matrix12 = 1 / 3.0F
                clrMatrix.Matrix20 = 1 / 3.0F
                clrMatrix.Matrix21 = 1 / 3.0F
                clrMatrix.Matrix22 = 1 / 3.0F

                Dim imgAttributes As ImageAttributes = New ImageAttributes
                imgAttributes.SetColorMatrix(clrMatrix, _
                       ColorMatrixFlag.Default, _
                       ColorAdjustType.Bitmap)

                g.DrawImage(mWatermark, _
                            lrectWatermark, _
                            0, 0, _
                            mWatermark.Width, _
                            mWatermark.Height, _
                            GraphicsUnit.Pixel, imgAttributes)

                lrectWatermark = Nothing
                clrMatrix = Nothing
                imgAttributes.Dispose()
            End If
        End Sub

        Protected Overrides Sub OnResize(ByVal eventargs As System.EventArgs)
            MyBase.OnResize(eventargs)
            Me.Invalidate()
        End Sub
#End Region
    End Class
End Namespace
