using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProblem
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            //Graph: AB5, BC4, CD8, DC8, DE6, AD5, CE2, EB3, AE7

            var a = new Node { Name = "A" };
            var b = new Node { Name = "B" };
            var c = new Node { Name = "C" };
            var d = new Node { Name = "D" };
            var e = new Node { Name = "E" };

            a.Edges.Add(new Edge { NodeDestination = b, Distance = 5 });
            a.Edges.Add(new Edge { NodeDestination = d, Distance = 5 });
            a.Edges.Add(new Edge { NodeDestination = e, Distance = 7 });

            b.Edges.Add(new Edge { NodeDestination = c, Distance = 4 });

            c.Edges.Add(new Edge { NodeDestination = d, Distance = 8 });
            c.Edges.Add(new Edge { NodeDestination = e, Distance = 2 });

            d.Edges.Add(new Edge { NodeDestination = c, Distance = 8 });
            d.Edges.Add(new Edge { NodeDestination = e, Distance = 6 });

            e.Edges.Add(new Edge { NodeDestination = b, Distance = 3 });

            var test1Result = GraphComputation.GetPathInfo(new List<Node>() { a, b, c });
            Console.WriteLine(string.Format("1. The distance of the route of A-B-C: {0}", test1Result.TotalDistance));

            var test2Result = GraphComputation.GetPathInfo(new List<Node>() { a, d});
            Console.WriteLine(string.Format("2. The distance of the route of A-D: {0}", test2Result.TotalDistance));

            var test3Result = GraphComputation.GetPathInfo(new List<Node>() { a, d, c });
            Console.WriteLine(string.Format("3. The distance of the route of A-D-C: {0}", test3Result.TotalDistance));

            var test4Result = GraphComputation.GetPathInfo(new List<Node>() { a, e, b, c, d });
            Console.WriteLine(string.Format("4. The distance of the route of A-E-B-C-D: {0}", test4Result.TotalDistance));

            var test5Result = GraphComputation.GetPathInfo(new List<Node>() { a, e, d });
            Console.WriteLine(string.Format("5. The distance of the route of A-E-D: {0}", test5Result == null ? "NO SUCH ROUTE" : test5Result.TotalDistance.ToString()));

            var test6ResultAll = GraphComputation.GetAllPathInfo(c, c);
            var test6ResultInitial = test6ResultAll.PossibleRoutes.Where(r => r.NumberOfStops <= 3);
            Console.WriteLine(string.Format("6. The number of trips starting at C and ending at C with 3 max stops: {0}", 
                test6ResultInitial.Count()));


            var test7ResultAll = GraphComputation.GetAllPathInfo(a, c);
            var test7ResultInitial = test6ResultAll.PossibleRoutes.Where(r => r.NumberOfStops == 4);
            Console.WriteLine(string.Format("7. The number of trips starting at A and ending at C with exactly 4 stops: {0}",
                test7ResultInitial.Count()));

            var test8Result = GraphComputation.GetAllPathInfo(a, c);
            Console.WriteLine(string.Format("8. The length of shortest route of A-C: {0} with route {1}", test8Result.ShortestPath.TotalDistance, test8Result.ShortestPath.Path ));

            var test9Result = GraphComputation.GetAllPathInfo(b, b);
            Console.WriteLine(string.Format("9. The length of shortest route of B-B: {0} with route {1}", test9Result.ShortestPath.TotalDistance, test9Result.ShortestPath.Path));


            var test10Result = GraphComputation.GetAllPathInfo(c, c);
            Console.WriteLine(string.Format("10. the number of different routes from C to C with distance of < 30: {0}", test10Result.PossibleRoutes.Count()));

            Console.ReadKey();
        }
    }
}
