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

        public GraphResult ProcessGraph(Node from, Node to){
            var result = new GraphResult()
            {
                Start = from,
                End = to
            };

            var allPaths = FindAllPaths(from, to).ToList();

            foreach (var path in allPaths)
            {
                ProcessGraph(path);
            }

            return result;
        }

        public GraphResult ProcessGraph(List<Node> paths) { 
            //determine start and end path
            var result = new GraphResult()
            {
                Start = paths.FirstOrDefault(),
                End = paths.LastOrDefault()
            };


            //get the number of stops on each path
            foreach (var path in paths)
            {
                var stops = new StringBuilder();
                int totalDistance = 0;
                int counter = 0;
                var initialNode = new Node();

                foreach (Node stop in path)
                {
                    //get name
                    stops.AppendFormat("{0} ", stop.Name);

                    //get distance between each other
                    if (counter < path.Count)
                    {
                        if (counter == 0)
                        {
                            initialNode = stop;
                        }
                        else
                        {
                            //compare
                            Edge endPoint = initialNode.Edges.FirstOrDefault(e => e.NodeDestination.Name == stop.Name);
                            //get distance
                            totalDistance += endPoint.Distance;
                            //set startNode
                            initialNode = stop;
                        }
                        counter++;
                    }
                }

                result.PossiblePaths.Add(new PathInfo
                {
                    Path = stops.ToString(),
                    NumberOfStops = path.Count,
                    TotalDistance = totalDistance
                });
            }

            return result;
        
        }

    }
}