using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainsProblem
{
    public class Graph
    {   
        Queue<Node> queue;

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

        public int GetDistance(string startNode, string endNode)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> FindAllPaths(Node from, Node to)
        {
            var nodes = new Queue<Tuple<Node, List<Node>>>();
            nodes.Enqueue(new Tuple<Node, List<Node>>(from, new List<Node>()));
            var paths = new List<dynamic>();

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

        public List<dynamic> Process(Node from, Node to){
            var allPaths= FindAllPaths(from, to).ToArray();

            List<dynamic> result = new List<dynamic>();

            for (int ctr = 0; ctr < allPaths.Length; ctr++ )
            {
                var item = allPaths[ctr];

                result.Add()
                
                result
            }
            return null;

        }

    }
   
    public class Routes {
        public Node Start { get; set; }
        public Node End { get; set; }

        public List<Node> Path { get; set; }
        public string PathToString {
            get {
                var path = new StringBuilder();
                foreach (var item in Path)
                {
                    path.Append(item.Name + " ");
                }

                return path.TrimEnd();
            }
        }
        public int Distance { get; set; }
        public int NumberOfStops { get; set; }
    }
}