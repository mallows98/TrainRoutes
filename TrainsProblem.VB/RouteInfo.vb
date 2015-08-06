
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace TrainsProblem
    Public Class RouteInfo
        Public Property Path() As String
            Get
                Return m_Path
            End Get
            Set(value As String)
                m_Path = Value
            End Set
        End Property
        Private m_Path As String
        Public Property NumberOfStops() As Integer
            Get
                Return m_NumberOfStops
            End Get
            Set(value As Integer)
                m_NumberOfStops = Value
            End Set
        End Property
        Private m_NumberOfStops As Integer
        Public Property TotalDistance() As Integer
            Get
                Return m_TotalDistance
            End Get
            Set(value As Integer)
                m_TotalDistance = Value
            End Set
        End Property
        Private m_TotalDistance As Integer
    End Class
End Namespace
