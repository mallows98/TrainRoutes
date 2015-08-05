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
        public List<PathInfo> PossiblePaths { get; set; }

        public GraphResult()
        {
            PossiblePaths = new List<PathInfo>();
        }

    }
}