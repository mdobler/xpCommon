Imports System.Windows.Forms
Imports System.Drawing

Public Class Editor

#Region " events "
    Public Shared Event CurrentStyleChanged As EventHandler
    Public Shared Event CurrentSheetChanged As EventHandler
    Public Shared Event FileStateChanged As EventHandler
#End Region

#Region " event methods "
    Protected Shared Sub OnCurrentStyleChanged(ByVal e As EventArgs)
        RaiseEvent CurrentStyleChanged(Nothing, e)
    End Sub

    Protected Shared Sub OnCurrentSheetChanged(ByVal e As EventArgs)
        RaiseEvent CurrentSheetChanged(Nothing, e)
    End Sub

    Protected Shared Sub OnFileStateChanged(ByVal e As EventArgs)
        RaiseEvent FileStateChanged(Nothing, e)
    End Sub
#End Region

#Region " command classes "
    Public Class Commands
        Public Shared WithEvents OpenFile As New Command
        Public Shared WithEvents CloseFile As New Command
        Public Shared WithEvents SaveFile As New Command
        Public Shared WithEvents SaveFileAs As New Command
        Public Shared WithEvents Quit As New Command

        Public Shared WithEvents Print As New Command
        Public Shared WithEvents PrintPreview As New Command

        Public Shared WithEvents AddProperties As New Command
        Public Shared WithEvents RemoveProperties As New Command
        Public Shared WithEvents AddAssemblies As New Command
        Public Shared WithEvents RemoveAssemblies As New Command
        Public Shared WithEvents AddStyle As New Command
        Public Shared WithEvents RemoveStyle As New Command

#Region " handle command events "
        Private Shared Sub OpenFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles OpenFile.Click
            Editor.Load()
        End Sub

        Private Shared Sub CloseFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CloseFile.Click
            Editor.Close()
        End Sub

        Private Shared Sub SaveFile_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveFile.Click
            Editor.Save()
        End Sub

        Private Shared Sub SaveFileAs_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles SaveFileAs.Click
            Editor.SaveAs()
        End Sub

        Private Shared Sub Quit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Quit.Click
            Editor.Quit()
        End Sub

        Private Shared Sub AddAssemblies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddAssemblies.Click
            Editor.AddAssemblies()
        End Sub

        Private Shared Sub AddProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddProperties.Click
            Editor.AddProperties()
        End Sub

        Private Shared Sub AddStyle_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddStyle.Click
            Editor.AddStyle()
        End Sub

        Private Shared Sub RemoveAssemblies_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveAssemblies.Click
            Editor.RemoveAssemblies()
        End Sub

        Private Shared Sub RemoveProperties_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveProperties.Click
            Editor.RemoveProperties()
        End Sub

        Private Shared Sub RemoveType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RemoveStyle.Click
            Editor.RemoveStyle()
        End Sub

        Private Shared Sub Print_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Print.Click
            Editor.Print()
        End Sub

        Private Shared Sub PrintPreview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles PrintPreview.Click
            Editor.PrintPreview()
        End Sub

#End Region

    End Class
#End Region

#Region " showing the editor "
    Public Shared Sub ShowEditor()
        Dim dlg As New EditorDialog
        dlg.ShowDialog()
    End Sub

    Public Shared Sub ShowEditor(ByVal owner As System.Windows.Forms.IWin32Window)
        Dim dlg As New EditorDialog()
        dlg.ShowDialog(owner)
    End Sub

    Public Shared Sub ShowEditor(ByVal filename As String)
        Dim dlg As New EditorDialog()
        Load(filename)
        dlg.ShowDialog()
    End Sub

    Public Shared Sub ShowEditor(ByVal owner As System.Windows.Forms.IWin32Window, ByVal filename As String)
        Dim dlg As New EditorDialog()
        Load(filename)
        dlg.ShowDialog(owner)

    End Sub
#End Region

#Region " private fields "
    Private Shared WithEvents _currentSheet As StyleSheet
    Private Shared WithEvents _currentStyle As Style
    Private Shared _currentReference As Reference
    Private Shared _currentFile As String = ""
    Private Shared _isDirty As Boolean = False
    Private Shared _isNew As Boolean = False
    Private Shared _tempPrintFile As String = ""
#End Region

#Region " Public Properties "
    Public Shared ReadOnly Property CurrentSheet() As StyleSheet
        Get
            Return _currentSheet
        End Get
    End Property

    Public Shared Property CurrentStyle() As Style
        Get
            Return _currentStyle
        End Get
        Friend Set(ByVal value As Style)
            If _currentStyle Is Nothing OrElse Not _currentStyle.Equals(value) Then
                _currentStyle = value
                OnCurrentStyleChanged(New EventArgs)
            End If
        End Set
    End Property

    Public Shared ReadOnly Property CurrentFilename() As String
        Get
            Return _currentFile
        End Get
    End Property
#End Region

#Region " Public File Methods "
    Public Shared Sub Print()
        If _currentSheet Is Nothing Then Exit Sub

        Dim webBrowserForPrinting As New WebBrowser()

        AddHandler webBrowserForPrinting.DocumentCompleted, New _
            WebBrowserDocumentCompletedEventHandler(AddressOf PrintDocument)

        If System.IO.File.Exists(_tempPrintFile) Then System.IO.File.Delete(_tempPrintFile)

        _tempPrintFile = System.IO.Path.GetTempFileName
        _tempPrintFile = System.IO.Path.ChangeExtension(_tempPrintFile, ".xml")
        If _currentSheet.ToXML(_tempPrintFile) Then
            webBrowserForPrinting.Navigate(New System.Uri(_tempPrintFile))

        End If

    End Sub

    Public Shared Sub PrintPreview()
        If _currentSheet Is Nothing Then Exit Sub

        Dim webBrowserForPrinting As New WebBrowser()

        AddHandler webBrowserForPrinting.DocumentCompleted, New _
            WebBrowserDocumentCompletedEventHandler(AddressOf PrintPreviewDocument)

        If System.IO.File.Exists(_tempPrintFile) Then System.IO.File.Delete(_tempPrintFile)

        _tempPrintFile = System.IO.Path.GetTempFileName
        _tempPrintFile = System.IO.Path.ChangeExtension(_tempPrintFile, ".xml")
        If _currentSheet.ToXML(_tempPrintFile) Then
            webBrowserForPrinting.Navigate(New System.Uri(_tempPrintFile))

        End If

    End Sub

    Private Shared Sub PrintPreviewDocument(ByVal sender As Object, _
    ByVal e As WebBrowserDocumentCompletedEventArgs)

        Dim webBrowserForPrinting As WebBrowser = CType(sender, WebBrowser)

        ' Print the document now that it is fully loaded.
        webBrowserForPrinting.ShowPrintPreviewDialog()

        ' Dispose the WebBrowser now that the task is complete. 
        webBrowserForPrinting.Dispose()
        System.IO.File.Delete(_tempPrintFile)
    End Sub

    Private Shared Sub PrintDocument(ByVal sender As Object, _
    ByVal e As WebBrowserDocumentCompletedEventArgs)

        Dim webBrowserForPrinting As WebBrowser = CType(sender, WebBrowser)

        ' Print the document now that it is fully loaded.
        webBrowserForPrinting.Print()

        ' Dispose the WebBrowser now that the task is complete. 
        webBrowserForPrinting.Dispose()
        System.IO.File.Delete(_tempPrintFile)
    End Sub


    Public Shared Sub NewFile()
        _isNew = True
        _isDirty = True

        _currentFile = ""
        _currentSheet = New StyleSheet
        _currentStyle = New Style
        OnCurrentSheetChanged(New EventArgs)
    End Sub

    Public Shared Sub Load(ByVal filename As String)
        Try
            If System.IO.File.Exists(filename) Then
                _currentSheet = Styles.StyleSheet.FromXMLFile(filename)
                _currentFile = filename

                _isDirty = False
                _isNew = False
                OnCurrentSheetChanged(New EventArgs)
            Else
                MessageBox.Show(String.Format(My.Resources.FileNotFound, filename), My.Resources.ApplicationTitle, System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub Load()
        Dim dlg As New OpenFileDialog
        dlg.Title = My.Resources.OpenFile
        dlg.Filter = My.Resources.StyleSheetFileExtensions
        dlg.FilterIndex = 1
        dlg.Multiselect = False
        If dlg.ShowDialog = DialogResult.OK Then
            Load(dlg.FileName)
        End If
    End Sub

    Public Shared Sub Save()
        If _isNew Or _currentFile = "" Then
            SaveAs()
        Else
            SaveAs(_currentFile)
        End If
    End Sub

    Public Shared Sub SaveAs()
        Dim dlg As New SaveFileDialog
        dlg.Title = My.Resources.SaveFile
        dlg.Filter = My.Resources.StyleSheetFileExtensions
        dlg.FilterIndex = 1
        dlg.CheckFileExists = True
        dlg.CheckPathExists = True
        If dlg.ShowDialog = DialogResult.OK Then
            SaveAs(dlg.FileName)
        End If
    End Sub

    Public Shared Sub SaveAs(ByVal filename As String)
        Try
            _currentSheet.ToXML(filename)
            _isDirty = False
            _isNew = False
            _currentFile = filename
            OnFileStateChanged(New EventArgs)
        Catch ex As Exception
        End Try
    End Sub

    Public Shared Sub Quit()
        Application.Exit()
    End Sub

    Public Shared Sub Close()

    End Sub

    Private Shared Sub CheckDirty()

    End Sub
#End Region

#Region " Public Edit Methods "
    Public Shared Sub AddAssemblies()

    End Sub

    Public Shared Sub RemoveAssemblies()

    End Sub

    Public Shared Sub AddProperties()
        Dim dlg As New AddNewPropertiesDialog
        dlg.Style = _currentStyle
        If dlg.ShowDialog = DialogResult.OK Then
            _currentStyle.Properties.Clear()
            _currentStyle.Properties.AddRange(dlg.Properties)
            OnCurrentStyleChanged(New EventArgs)
        End If
    End Sub

    Public Shared Sub RemoveProperties()

    End Sub

    Public Shared Sub AddStyle()
        Dim dlg As New AddTypesDialog

        dlg.References = _currentSheet.References
        dlg.CurrentReference = _currentReference

        If dlg.ShowDialog = DialogResult.OK Then
            _currentSheet.Styles.AddRange(dlg.Styles)
            OnCurrentSheetChanged(New EventArgs)
        End If
    End Sub

    Public Shared Sub RemoveStyle()

    End Sub
#End Region

End Class
