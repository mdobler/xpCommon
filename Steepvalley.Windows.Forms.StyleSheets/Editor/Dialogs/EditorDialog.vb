Imports System.Windows.Forms

Friend Class EditorDialog

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        AttachCommands()
    End Sub

    Private Sub AttachCommands()
        Editor.Commands.OpenFile.Add(tbOpen)
        Editor.Commands.OpenFile.Add(mnuOpen)
        Editor.Commands.SaveFile.Add(tbSave)
        Editor.Commands.SaveFile.Add(mnuSave)
        Editor.Commands.SaveFileAs.Add(mnuSaveAs)

        Editor.Commands.Print.Add(mnuPrint)
        Editor.Commands.PrintPreview.Add(mnuPrintPreview)

        Editor.Commands.AddStyle.Add(mnuAddStyle)
        Editor.Commands.AddProperties.Add(mnuAddProperties)
        Editor.Commands.AddAssemblies.Add(mnuAddAssembly)

        Editor.Commands.RemoveAssemblies.Add(mnuRemoveAssembly)
        Editor.Commands.RemoveProperties.Add(mnuRemoveProperty)
        Editor.Commands.RemoveStyle.Add(mnuRemoveStyle)


    End Sub


End Class