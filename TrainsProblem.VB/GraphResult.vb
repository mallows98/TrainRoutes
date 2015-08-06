
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace TrainsProblem
	Public Class GraphResult
		Public Property Start() As Node
			Get
				Return m_Start
			End Get
			Set
				m_Start = Value
			End Set
		End Property
		Private m_Start As Node
		Public Property [End]() As Node
			Get
				Return m_End
			End Get
			Set
				m_End = Value
			End Set
		End Property
		Private m_End As Node
		Public Property PossibleRoutes() As List(Of RouteInfo)
			Get
				Return m_PossibleRoutes
			End Get
			Set
				m_PossibleRoutes = Value
			End Set
		End Property
		Private m_PossibleRoutes As List(Of RouteInfo)
		Public ReadOnly Property ShortestPath() As RouteInfo
			Get
				Dim shortPath = PossibleRoutes.Min(Function(r) r.TotalDistance)
				Return PossibleRoutes.FirstOrDefault(Function(r) r.TotalDistance = shortPath)
			End Get
		End Property

		Public Sub New()
			PossibleRoutes = New List(Of RouteInfo)()
		End Sub
	End Class
End Namespace
