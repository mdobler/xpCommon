Public Interface IPaneRenderer
    Inherits IRenderer

    Sub RenderBackground(ByVal ctrl As Pane, ByVal g As Graphics)
    Sub RenderBorder(ByVal ctrl As Pane, ByVal g As Graphics)
End Interface
