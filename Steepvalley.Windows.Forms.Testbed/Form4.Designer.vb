<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim CaptionPaneSystemRenderer1 As Steepvalley.Windows.Forms.Containers.CaptionPaneSystemRenderer = New Steepvalley.Windows.Forms.Containers.CaptionPaneSystemRenderer
        Me.Button1 = New System.Windows.Forms.Button
        Me.trackMargin = New System.Windows.Forms.TrackBar
        Me.trackRadius = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Border = New System.Windows.Forms.Label
        Me.TrackBorder = New System.Windows.Forms.TrackBar
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.CaptionPane1 = New Steepvalley.Windows.Forms.Containers.CaptionPane
        CType(Me.trackMargin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.trackRadius, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBorder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(12, 362)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Custom"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'trackMargin
        '
        Me.trackMargin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackMargin.Location = New System.Drawing.Point(91, 210)
        Me.trackMargin.Maximum = 20
        Me.trackMargin.Name = "trackMargin"
        Me.trackMargin.Size = New System.Drawing.Size(177, 45)
        Me.trackMargin.TabIndex = 2
        '
        'trackRadius
        '
        Me.trackRadius.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trackRadius.Location = New System.Drawing.Point(91, 261)
        Me.trackRadius.Maximum = 20
        Me.trackRadius.Name = "trackRadius"
        Me.trackRadius.Size = New System.Drawing.Size(177, 45)
        Me.trackRadius.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 214)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Padding"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Radius"
        '
        'Border
        '
        Me.Border.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Border.AutoSize = True
        Me.Border.Location = New System.Drawing.Point(12, 318)
        Me.Border.Name = "Border"
        Me.Border.Size = New System.Drawing.Size(38, 13)
        Me.Border.TabIndex = 8
        Me.Border.Text = "Border"
        '
        'TrackBorder
        '
        Me.TrackBorder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TrackBorder.Location = New System.Drawing.Point(91, 312)
        Me.TrackBorder.Maximum = 20
        Me.TrackBorder.Name = "TrackBorder"
        Me.TrackBorder.Size = New System.Drawing.Size(177, 45)
        Me.TrackBorder.TabIndex = 7
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button2.Location = New System.Drawing.Point(102, 362)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Professional"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(193, 362)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 10
        Me.Button3.Text = "System"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'CaptionPane1
        '
        Me.CaptionPane1.CaptionHeight = 15
        Me.CaptionPane1.CaptionPosition = Steepvalley.Windows.Forms.Containers.CaptionPane.Positioning.Bottom
        Me.CaptionPane1.CaptionText = "Hello World"
        Me.CaptionPane1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CaptionPane1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CaptionPane1.Location = New System.Drawing.Point(12, 12)
        Me.CaptionPane1.Name = "CaptionPane1"
        Me.CaptionPane1.Renderer = CaptionPaneSystemRenderer1
        Me.CaptionPane1.RenderMode = Steepvalley.Windows.Forms.Containers.RenderModes.System
        Me.CaptionPane1.Size = New System.Drawing.Size(255, 182)
        Me.CaptionPane1.TabIndex = 11
        '
        'Form4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(280, 397)
        Me.Controls.Add(Me.CaptionPane1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Border)
        Me.Controls.Add(Me.TrackBorder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.trackRadius)
        Me.Controls.Add(Me.trackMargin)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form4"
        Me.Text = "Form4"
        CType(Me.trackMargin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.trackRadius, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBorder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents trackMargin As System.Windows.Forms.TrackBar
    Friend WithEvents trackRadius As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Border As System.Windows.Forms.Label
    Friend WithEvents TrackBorder As System.Windows.Forms.TrackBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents CaptionPane1 As Steepvalley.Windows.Forms.Containers.CaptionPane
End Class
