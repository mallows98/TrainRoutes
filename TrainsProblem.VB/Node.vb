Namespace TrainsProblem
    Public Class Node

        Public Property Name() As String
            Get
                Return m_Name
            End Get
            Set(value As String)
                m_Name = value
            End Set
        End Property
        Private m_Name As String

        Public Property Edges As List(Of Edge)
            Get
                Return m_Edges
            End Get
            Set(value As List(Of Edge))
                m_Edges = value
            End Set
        End Property
        Private m_Edges As List(Of Edge)

        Public Sub Node()
            Edges = New List(Of Edge)
        End Sub
        Public Sub Node(neighbours As List(Of Edge))
            Edges = neighbours
        End Sub
    End Class
End Namespace