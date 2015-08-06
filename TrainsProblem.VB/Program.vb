
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace TrainsProblem
    Public NotInheritable Class Program
        Private Sub New()
        End Sub

        Public Shared Sub Main(args As String())
            'Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7

            Dim a = New Node()
            a.Name = "A"

            Dim b = New Node()
            b.Name = "B"

            Dim c = New Node()
            c.Name = "C"

			Dim d = New Node()
            d.Name = "D"

            Dim e = New Node()
            e.Name = "E"

            a.Edges = New List(Of Edge)
            a.Edges.Add(New Edge() With { _
                 .NodeDestination = b, _
                 .Distance = 5 _
            })
            a.Edges.Add(New Edge() With { _
                .NodeDestination = d, _
                .Distance = 5 _
            })
            a.Edges.Add(New Edge() With { _
                .NodeDestination = e, _
                .Distance = 7 _
            })

            b.Edges = New List(Of Edge)
            b.Edges.Add(New Edge() With { _
                .NodeDestination = c, _
                .Distance = 4 _
            })

            c.Edges = New List(Of Edge)
            c.Edges.Add(New Edge() With { _
                .NodeDestination = d, _
                .Distance = 8 _
            })
            c.Edges.Add(New Edge() With { _
                .NodeDestination = e, _
                .Distance = 2 _
            })

            d.Edges = New List(Of Edge)
            d.Edges.Add(New Edge() With { _
                .NodeDestination = c, _
                .Distance = 8 _
            })
            d.Edges.Add(New Edge() With { _
                .NodeDestination = e, _
                .Distance = 6 _
            })

            e.Edges = New List(Of Edge)
            e.Edges.Add(New Edge() With { _
                .NodeDestination = b, _
                .Distance = 3 _
            })

            Dim test1Result = GraphComputation.GetPathInfo(New List(Of Node)() From { _
                a, _
                b, _
                c _
            })
            Console.WriteLine(String.Format("1. The distance of the route of A-B-C: {0}", test1Result.TotalDistance))

            Dim test2Result = GraphComputation.GetPathInfo(New List(Of Node)() From { _
                a, _
                d _
            })
            Console.WriteLine(String.Format("2. The distance of the route of A-D: {0}", test2Result.TotalDistance))

            Dim test3Result = GraphComputation.GetPathInfo(New List(Of Node)() From { _
                a, _
                d, _
                c _
            })
            Console.WriteLine(String.Format("3. The distance of the route of A-D-C: {0}", test3Result.TotalDistance))

            Dim test4Result = GraphComputation.GetPathInfo(New List(Of Node)() From { _
                a, _
                e, _
                b, _
                c, _
                d _
            })
            Console.WriteLine(String.Format("4. The distance of the route of A-E-B-C-D: {0}", test4Result.TotalDistance))

            Dim test5Result = GraphComputation.GetPathInfo(New List(Of Node)() From { _
                a, _
                e, _
                d _
            })
            Console.WriteLine(String.Format("5. The distance of the route of A-E-D: {0}", If(test5Result Is Nothing, "NO SUCH ROUTE", test5Result.TotalDistance.ToString())))

            Dim test6ResultAll = GraphComputation.GetAllPathInfo(c, c)
            Dim test6ResultInitial = test6ResultAll.PossibleRoutes.Where(Function(r) r.NumberOfStops <= 3)
            Console.WriteLine(String.Format("6. The number of trips starting at C and ending at C with 3 max stops: {0}", test6ResultInitial.Count()))


            Dim test7ResultAll = GraphComputation.GetAllPathInfo(a, c)
            Dim test7ResultInitial = test6ResultAll.PossibleRoutes.Where(Function(r) r.NumberOfStops = 4)
            Console.WriteLine(String.Format("7. The number of trips starting at A and ending at C with exactly 4 stops: {0}", test7ResultInitial.Count()))

            Dim test8Result = GraphComputation.GetAllPathInfo(a, c)
            Console.WriteLine(String.Format("8. The length of shortest route of A-C: {0} with route {1}", test8Result.ShortestPath.TotalDistance, test8Result.ShortestPath.Path))

            Dim test9Result = GraphComputation.GetAllPathInfo(b, b)
            Console.WriteLine(String.Format("9. The length of shortest route of B-B: {0} with route {1}", test9Result.ShortestPath.TotalDistance, test9Result.ShortestPath.Path))


            Dim test10Result = GraphComputation.GetAllPathInfo(c, c)
            Console.WriteLine(String.Format("10. the number of different routes from C to C with distance of < 30: {0}", test10Result.PossibleRoutes.Count()))

            Console.ReadKey()
        End Sub
    End Class
End Namespace
