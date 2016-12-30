Public Interface IStyleSheetView
    Property StyleSheet() As StyleSheet
    Event StyleSheetChanged As EventHandler
    Event StyleSelected As EventHandler(Of StyleSelectedEventArgs)
End Interface
