Imports System.ComponentModel
Imports System.Windows.Forms

Public Class DataExtendedProperties
    Private _dataSource As Object = Nothing
    Private _dataMember As String = ""
    Private _dataManager As CurrencyManager
    Private _control As Control

#Region "ctor"
    Private Sub New()
    End Sub

    Public Sub New(ByVal control As Control)
        _control = control
    End Sub
#End Region

#Region " Events "
    Public Event DataSourceChanged As EventHandler
    Public Event ListChanged As ListChangedEventHandler
    Public Event PositionChanged As EventHandler
    Public Event UpdateAllData As EventHandler
    Public Event RetrieveColumns As EventHandler

    Protected Sub OnDataSourceChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent DataSourceChanged(_control, e)
    End Sub

    Protected Sub OnListChanged(ByVal sender As Object, ByVal e As ListChangedEventArgs)
        RaiseEvent ListChanged(_control, e)
    End Sub

    Protected Sub OnPositionChanged(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent PositionChanged(_control, e)
    End Sub

    Protected Sub OnUpdateAllData(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent UpdateAllData(_control, e)
    End Sub

    Protected Sub OnRetrieveColumns(ByVal sender As Object, ByVal e As EventArgs)
        RaiseEvent RetrieveColumns(_control, e)
    End Sub
#End Region

#Region " Public Properties "
    ''' <summary>
    ''' provides a datasource property for this control. The Type Converter ensures
    ''' that all bindable resources are displayed
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter("System.Windows.Forms.Design.DataSourceConverter, System.Design"), _
     Category("Data")> _
    Public Property DataSource() As Object
        Get
            Return Me._dataSource
        End Get
        Set(ByVal value As Object)
            Try
                If _dataSource Is Nothing OrElse Not Object.Equals(_dataSource, value) Then
                    Me._dataSource = value
                    TryDatabind()
                    OnDataSourceChanged(_control, New EventArgs)
                End If
            Catch ex As Exception
                Throw New ApplicationException(String.Format("Fehler! {0}", ex.StackTrace), ex)
            End Try

        End Set
    End Property

    ''' <summary>
    ''' provides a data member property
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Category("Data"), _
     Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design", _
     "System.Drawing.Design.UITypeEditor, System.Drawing"), _
     DefaultValue("")> _
    Public Property DataMember() As String
        Get
            Return Me._dataMember
        End Get
        Set(ByVal value As String)
            If Not String.Equals(_dataMember, value) Then
                Me._dataMember = value
                TryDatabind()
                OnDataSourceChanged(_control, New EventArgs)
            End If
        End Set
    End Property

    Public ReadOnly Property DataManager() As CurrencyManager
        Get
            Return _dataManager
        End Get
    End Property
#End Region

#Region " Databinding "
    ''' <summary>
    ''' this method tries to unbind the current data source and bind to
    ''' the new datasource
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub TryDatabind()
        If _control Is Nothing Then Exit Sub

        If _dataSource Is Nothing Or _control.BindingContext Is Nothing Then Exit Sub

        Dim cm As CurrencyManager
        Try
            cm = DirectCast(_control.BindingContext(_dataSource, _dataMember), CurrencyManager)
        Catch ex As Exception
            'kein Curreny Manager gefunden
            Exit Sub
        End Try

        'alten currency manager abhaengen und neuen anhaengen
        If _dataManager Is Nothing OrElse Not _dataManager.Equals(cm) Then
            If _dataManager IsNot Nothing Then
                RemoveHandler _dataManager.ListChanged, AddressOf OnListChanged
                RemoveHandler _dataManager.PositionChanged, AddressOf OnPositionChanged
            End If

            _dataManager = cm
            If _dataManager IsNot Nothing Then
                AddHandler _dataManager.ListChanged, AddressOf OnListChanged
                AddHandler _dataManager.PositionChanged, AddressOf OnPositionChanged
            End If
        End If

        'do not retrieve cols automatically...
        OnRetrieveColumns(_control, New EventArgs)
        OnUpdateAllData(_control, New EventArgs)
    End Sub
#End Region
End Class
