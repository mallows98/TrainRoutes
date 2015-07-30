using System.Collections.Generic;
using System;


namespace TrainsProblem
{
    public class Node
    {
        public string Name { get; set; }
        public List<Edge> Edges { get; set; }

        public Node() {
            Edges  = new List<Edge>();
        }

        public Node(List<Edge> neighbours) {
            Edges = neighbours;
        }
    }
}