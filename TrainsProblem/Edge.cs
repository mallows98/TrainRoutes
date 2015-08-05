namespace TrainsProblem
{
    public class Edge
    {
        public Node NodeDestination { get; set; }
        public int Distance { get; set; }
        public string Destination {
            get {
                return (NodeDestination != null) ?  NodeDestination.Name : null;
            }
        }
    }
}