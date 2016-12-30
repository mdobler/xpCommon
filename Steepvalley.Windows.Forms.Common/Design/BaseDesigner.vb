Imports System.ComponentModel
Imports System.ComponentModel.Design
Imports Steepvalley.Windows.Forms.Common.Graphics

''' <summary>
''' Base Class for all control designers. This class will allow the display of design
''' time hints and graphics for all controls that use this (or an inherited) designer.
''' 
''' It will also allow the display of "Verbs". These verbs are displayed as link in the 
''' property dialog of VS and can be used to execute code.
''' </summary>
''' <remarks></remarks>
Public MustInherit Class BaseDesigner
    Inherits System.Windows.Forms.Design.ParentControlDesigner

    Private m_BorderPen As New Pen(SystemColors.ControlDark)
    Private m_WorkspacePen As New Pen(SystemColors.ControlLight)
    Private m_Font As New Font("Arial", 6, FontStyle.Regular)
    Private m_Format As New StringFormat(StringFormatFlags.LineLimit)
    Private m_Verbs As New DesignerVerbCollection
    Private m_mouseover As Boolean = False

    Private Const compName As String = "steepvalley.net"

    Protected Sub New()
        m_WorkspacePen.DashStyle = Drawing.Drawing2D.DashStyle.Dot
        m_BorderPen.DashStyle = Drawing.Drawing2D.DashStyle.Dash
        m_Format.Trimming = StringTrimming.EllipsisCharacter
        m_Verbs.Add(New DesignerVerb("About", New EventHandler(AddressOf AboutEvent)))
    End Sub

    Protected Overrides Sub OnMouseEnter()
        Me.m_mouseover = True
        Me.Control.Refresh()
    End Sub

    Protected Overrides Sub OnMouseLeave()
        Me.m_mouseover = False
        Me.Control.Refresh()
    End Sub

    Protected Overrides Sub OnPaintAdornments(ByVal pe As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaintAdornments(pe)
        pe.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

        'place the text in the left bottom 
        Dim _s As SizeF = pe.Graphics.MeasureString(compName, m_Font, Me.Control.Width, m_Format)
        If Me.MouseOver = True Then
            pe.Graphics.FillRectangle(New SolidBrush(Color.White), 0, Me.Control.Height - _s.Height, _s.Width, _s.Height)
            pe.Graphics.DrawRectangle(New Pen(Color.Black), 0, Me.Control.Height - _s.Height, _s.Width, _s.Height)
            pe.Graphics.DrawString("steepvalley.net", m_Font, New SolidBrush(Color.Black), Helpers.CheckedRectangleF(0, Me.Control.Height - _s.Height, _s.Width, _s.Height), m_Format)
        End If
    End Sub

#Region "protected properties"
    Protected Property BorderPen() As Pen
        Get
            Return m_BorderPen
        End Get
        Set(ByVal Value As Pen)
            m_BorderPen = Value
        End Set
    End Property

    Protected Property WorkspacePen() As Pen
        Get
            Return m_WorkspacePen
        End Get
        Set(ByVal Value As Pen)
            m_WorkspacePen = Value
        End Set
    End Property

    Protected Property Font() As Font
        Get
            Return m_Font
        End Get
        Set(ByVal Value As Font)
            m_Font = Value
        End Set
    End Property

    Protected Property MouseOver() As Boolean
        Get
            Return m_mouseover
        End Get
        Set(ByVal Value As Boolean)
            m_mouseover = Value
        End Set
    End Property

    Protected ReadOnly Property CompanyName() As String
        Get
            Return compName
        End Get
    End Property
#End Region

#Region "managing verbs"
    Public Overrides ReadOnly Property Verbs() As System.ComponentModel.Design.DesignerVerbCollection
        Get
            Return m_Verbs
        End Get
    End Property

    Protected Sub AboutEvent(ByVal sender As Object, ByVal e As EventArgs)
        Dim d As New About
        d.ShowDialog()
        d.Dispose()
    End Sub

    Protected Sub AddVerb(ByVal verb As DesignerVerb)
        m_Verbs.Add(verb)
    End Sub

    Protected Sub AddVerb(ByVal text As String, ByVal handler As System.EventHandler)
        m_Verbs.Add(New DesignerVerb(text, handler))
    End Sub
#End Region
End Class


