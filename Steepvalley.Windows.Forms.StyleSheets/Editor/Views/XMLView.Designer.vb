<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class XMLView
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.wbXML = New System.Windows.Forms.WebBrowser
        Me.SuspendLayout()
        '
        'wbXML
        '
        Me.wbXML.Dock = System.Windows.Forms.DockStyle.Fill
        Me.wbXML.Location = New System.Drawing.Point(0, 0)
        Me.wbXML.MinimumSize = New System.Drawing.Size(20, 20)
        Me.wbXML.Name = "wbXML"
        Me.wbXML.Size = New System.Drawing.Size(317, 415)
        Me.wbXML.TabIndex = 0
        '
        'XMLView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.wbXML)
        Me.Name = "XMLView"
        Me.Size = New System.Drawing.Size(317, 415)
        Me.ResumeLayout(False)

    End Sub
    Private WithEvents wbXML As System.Windows.Forms.WebBrowser

End Class
