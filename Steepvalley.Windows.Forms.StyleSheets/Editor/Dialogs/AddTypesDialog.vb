Imports System.Windows.Forms
Imports System.Reflection

Public Class AddTypesDialog

    Private _attachedProps As ItemPropertyCollection
    Private _availableProps As ItemPropertyCollection


#Region " ctor "
    Public Sub New()
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
    End Sub

   
#End Region

#Region " UI events "
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub
#End Region

    Private _refs As ReferenceCollection
    Public WriteOnly Property References() As ReferenceCollection
        Set(ByVal value As ReferenceCollection)
            _refs = value
            PopulateCombobox()
        End Set
    End Property

    Private _currentRef As Reference
    Public Property CurrentReference() As Reference
        Get
            Return _currentRef
        End Get
        Set(ByVal value As Reference)
            If _currentRef Is Nothing Or Not _currentRef.Equals(value) Then
                _currentRef = value

                If _currentRef Is Nothing Or Not _refs.Contains(_currentRef) Then
                    cmbAssemly.SelectedIndex = 0
                Else
                    cmbAssemly.SelectedIndex = _refs.IndexOf(_currentRef)
                End If
            End If
        End Set
    End Property


    Public ReadOnly Property Styles() As StyleCollection
        Get
            Dim _col As New StyleCollection

            For Each itm As ListViewItem In lvTypes.CheckedItems
                _col.Add(CType(itm.Tag, Style))
            Next

            Return _col
        End Get
    End Property

    Private Sub PopulateCombobox()
        cmbAssemly.Items.Clear()
        If _refs Is Nothing OrElse _refs.Count = 0 Then Exit Sub

        For Each r As Reference In _refs
            cmbAssemly.Items.Add(r.Name)
        Next

        If _currentRef Is Nothing Or Not _refs.Contains(_currentRef) Then
            cmbAssemly.SelectedIndex = 0
        Else
            cmbAssemly.SelectedIndex = _refs.IndexOf(_currentRef)
        End If
    End Sub

    Private Sub PopulateList()
        lvTypes.Items.Clear()
        If _currentRef Is Nothing Then Exit Sub

        Dim _assembly As [Assembly]
        _assembly = AssemblyLoader.ProbeAssembly(_currentRef, Application.StartupPath)

        If Not _assembly Is Nothing Then

            For Each _type As Type In _assembly.GetTypes
                If _type.Name = GetType(Control).Name Or _
                    (_type.IsSubclassOf(GetType(Control)) AndAlso _
                    Not (_type.GetConstructor(Type.EmptyTypes) Is Nothing) AndAlso _
                    _type.IsAbstract = False) Then

                    Dim _item As New ListViewItem(_type.Name, 0)
                    _item.Tag = New Style(_currentRef, _type.FullName)

                    lvTypes.Items.Add(_item)
                End If
            Next
        End If
    End Sub

    Private Sub cmbAssemly_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAssemly.SelectedIndexChanged
        _currentRef = _refs(cmbAssemly.SelectedIndex)
        PopulateList()
    End Sub
End Class
