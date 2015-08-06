
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text

Namespace TrainsProblem
    Public NotInheritable Class GraphComputation
        Private Sub New()
        End Sub
        Public Shared Function FindAllPaths(from As Node, [to] As Node) As List(Of List(Of Node))
           
            Dim nodes = New Queue(Of Tuple(Of Node, List(Of Node)))()
            nodes.Enqueue(New Tuple(Of Node, List(Of Node))(from, New List(Of Node)()))
            Dim paths = New List(Of List(Of Node))()

            While nodes.Any()
                Dim current = nodes.Dequeue()
                Dim currentNode As Node = current.Item1

                If current.Item2.Contains(currentNode) Then
                    Continue While
                End If

                current.Item2.Add(currentNode)

                If currentNode.Equals([to]) Then
                    paths.Add(current.Item2)
                    Continue While
                End If

                For Each edge As Edge In current.Item1.Edges
                    nodes.Enqueue(New Tuple(Of Node, List(Of Node))(edge.NodeDestination, New List(Of Node)(current.Item2)))
                Next
            End While

            Return paths
        End Function

        Public Shared Function GetAllPathInfo(from As Node, [to] As Node) As GraphResult
            Dim result = New GraphResult() With { _
                .Start = from, _
                .[End] = [to] _
            }

            Dim allPaths = FindAllPaths(from, [to]).ToList()

            Dim pathInfo = New RouteInfo()
            For Each path As List(Of Node) In allPaths
                pathInfo = GetPathInfo(path)
                result.PossibleRoutes.Add(pathInfo)
            Next

            Return result
        End Function

        Public Shared Function GetPathInfo(paths As List(Of Node)) As RouteInfo
            'get the number of stops on each path
            Dim route = New StringBuilder()
            Dim totalDistance As Integer = 0
            Dim counter As Integer = 0
            Dim initialNode = New Node()

            For Each stopOver As Node In paths
                ' set route map
                route.AppendFormat("{0} ", stopOver.Name)

                'get distance between each other
                If counter < paths.Count Then
                    If counter > 0 Then
                        'check if first item
                        'compare
                        Dim endPoint As Edge = initialNode.Edges.FirstOrDefault(Function(e) e.NodeDestination.Name = stopOver.Name)

                        If endPoint Is Nothing Then
                            Return Nothing
                        End If

                        'get distance
                        totalDistance += endPoint.Distance
                    End If

                    'replace initial node; will be used to compare with the next node
                    initialNode = stopOver
                    counter += 1
                End If
            Next

            Dim result = New RouteInfo() With { _
                .Path = route.ToString(), _
                .NumberOfStops = paths.Count, _
                .TotalDistance = totalDistance _
            }

            Return result
        End Function
    End Class
End Namespace
