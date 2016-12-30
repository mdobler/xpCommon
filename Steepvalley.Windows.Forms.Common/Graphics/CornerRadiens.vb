Namespace Graphics


    Public Structure CornerRadiens
        Public Sub New(ByVal topleft As Integer, ByVal topright As Integer, ByVal bottomleft As Integer, ByVal bottomright As Integer)
            Me.TopLeft = topleft
            Me.TopRight = topright
            Me.BottomLeft = bottomleft
            Me.BottomRight = bottomright
        End Sub

        Public Sub New(ByVal all As Integer)
            Me.All = all
        End Sub

        Private _topLeft As Integer
        Public Property TopLeft() As Integer
            Get
                Return _topLeft
            End Get
            Set(ByVal value As Integer)
                _topLeft = CInt(IIf(value < 0, 0, value))
            End Set
        End Property

        Private _topRight As Integer
        Public Property TopRight() As Integer
            Get
                Return _topRight
            End Get
            Set(ByVal value As Integer)
                _topRight = CInt(IIf(value < 0, 0, value))
            End Set
        End Property

        Private _bottomLeft As Integer
        Public Property BottomLeft() As Integer
            Get
                Return _bottomLeft
            End Get
            Set(ByVal value As Integer)
                _bottomLeft = CInt(IIf(value < 0, 0, value))
            End Set
        End Property

        Private _bottomRight As Integer
        Public Property BottomRight() As Integer
            Get
                Return _bottomRight
            End Get
            Set(ByVal value As Integer)
                _bottomRight = CInt(IIf(value < 0, 0, value))
            End Set
        End Property

        Public Property All() As Integer
            Get
                If _topLeft = _topRight And _topLeft = _bottomLeft And _topLeft = _bottomRight Then
                    Return _topLeft
                Else
                    Return -1
                End If
            End Get
            Set(ByVal value As Integer)
                If value >= 0 Then
                    _topLeft = value
                    _topRight = value
                    _bottomLeft = value
                    _bottomRight = value
                End If
            End Set
        End Property

    End Structure
End Namespace