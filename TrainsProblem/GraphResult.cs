using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProblem
{
    public class GraphResult
    {
        public Node Start { get; set; }
        public Node End { get; set; }
        public List<RouteInfo> PossibleRoutes { get; set; }
        public RouteInfo ShortestPath {
            get {
                var shortPath = PossibleRoutes.Min(r => r.TotalDistance);
                return PossibleRoutes.FirstOrDefault(r => r.TotalDistance == shortPath);
            }
        }

        public GraphResult()
        {
            PossibleRoutes = new List<RouteInfo>();
        }
    }
}