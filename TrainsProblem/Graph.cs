using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainsProblem
{
    public class Graph
    {
        public List<Node> Nodes { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
        }

        public Graph(List<Node> nodes)
        {
            Nodes = nodes;
        }

        public void AddNode(Node node)
        {
            Nodes.Add(node);
        }

        public List<List<Node>> FindAllPaths(Node from, Node to)
        {
            var nodes = new Queue<Tuple<Node, List<Node>>>();
            nodes.Enqueue(new Tuple<Node, List<Node>>(from, new List<Node>()));
            var paths = new List<List<Node>>();

            while (nodes.Any())
            {
                var current = nodes.Dequeue();
                Node currentNode = current.Item1;

                if (current.Item2.Contains(currentNode))
                {
                    continue;
                }

                current.Item2.Add(currentNode);

                if (currentNode == to)
                {
                    paths.Add(current.Item2);
                    continue;
                }

                foreach (var edge in current.Item1.Edges)
                {
                    nodes.Enqueue(new Tuple<Node, List<Node>>(edge.NodeDestination, new List<Node>(current.Item2)));
                }
            }

            return paths;
        }

        public GraphResult GetAllPaths(Node from, Node to)
        {
            var result = new GraphResult()
            {
                Start = from,
                End = to
            };

            var allPaths = FindAllPaths(from, to).ToList();

            var pathInfo = new RouteInfo();
            foreach (var path in allPaths)
            {
                pathInfo = GetPathInfo(path);
                result.PossiblePaths.Add(pathInfo);
            }

            return result;
        }

        public RouteInfo GetPathInfo(List<Node> paths)
        {
            //get the number of stops on each path
            var route = new StringBuilder();
            int totalDistance = 0;
            int counter = 0;
            var initialNode = new Node();

            foreach (Node stop in paths)
            {
                // set route map
                route.AppendFormat("{0} ", stop.Name);

                //get distance between each other
                if (counter < paths.Count)
                {
                    if (counter > 0) //check if first item
                    {
                        //compare
                        Edge endPoint = initialNode.Edges.FirstOrDefault(e => e.NodeDestination.Name == stop.Name);
                        //get distance
                        totalDistance += endPoint.Distance;
                    }

                    //replace initial node; will be used to compare with the next node
                    initialNode = stop;
                    counter++;
                }
            }

            var result = new RouteInfo
            {
                Path = route.ToString(),
                NumberOfStops = paths.Count,
                TotalDistance = totalDistance
            };

            return result;
        }
    }
}