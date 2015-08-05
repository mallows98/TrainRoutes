using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainsProblem
{
    public class Routes
    {
        public Node Start { get; set; }
        public Node End { get; set; }

        public List<Node> Path { get; set; }
        public string PathToString
        {
            get
            {
                var path = new StringBuilder();
                foreach (var item in Path)
                {
                    path.Append(item.Name + " ");
                }

                return path.ToString().TrimEnd();
            }
        }
        public int Distance { get; set; }
        public int NumberOfStops { get; set; }
    }
}
