Public Class Form1

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            Dim o As New Oscars

            dlgOpen.Filter = "XML-File (*.XML)|*.XML"
            If dlgOpen.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                o = OscarLoader.LoadFromFile(dlgOpen.FileName)
                o.Filename = dlgOpen.FileName

                OscarCollectionBindingSource.DataSource = o.Items
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        ListView1.View = System.Windows.Forms.View.Tile
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        ListView1.View = System.Windows.Forms.View.LargeIcon
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        ListView1.View = System.Windows.Forms.View.SmallIcon
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        ListView1.View = System.Windows.Forms.View.List
    End Sub

    Private Sub ToolStripButton5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton5.Click
        ListView1.View = System.Windows.Forms.View.Details
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListViewDataExtender1.RetrieveColumnsFromDatasource(ListView1)
    End Sub
End Class