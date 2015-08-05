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

            var trainRoutes = new Graph();

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


            trainRoutes.AddNode(a);
            trainRoutes.AddNode(b);
            trainRoutes.AddNode(c);
            trainRoutes.AddNode(d);
            trainRoutes.AddNode(e);


            var result1 = trainRoutes.GetAllPaths(a, c);
            var result2 = trainRoutes.GetPathInfo(new List<Node>() { a, b, c });

        }
    }
}
