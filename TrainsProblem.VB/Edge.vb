
Namespace TrainsProblem
    Public Class Edge
        Public Property NodeDestination() As Node
            Get
                Return m_NodeDestination
            End Get
            Set(value As Node)
                m_NodeDestination = Value
            End Set
        End Property
        Private m_NodeDestination As Node
        Public Property Distance() As Integer
            Get
                Return m_Distance
            End Get
            Set(value As Integer)
                m_Distance = Value
            End Set
        End Property
        Private m_Distance As Integer
        Public ReadOnly Property Destination() As String
            Get
                Return If((NodeDestination IsNot Nothing), NodeDestination.Name, Nothing)
            End Get
        End Property
    End Class
End Namespace