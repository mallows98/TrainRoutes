namespace TrainsProblem
{
    public class Edge
    {
        public Node NodeDestination { get; set; }
        public int Distance { get; set; }
        public string Destination
        {
            get
            {
                //this is a test
                return (NodeDestination != null) ? NodeDestination.Name : null;
            }
        }
    }
}
