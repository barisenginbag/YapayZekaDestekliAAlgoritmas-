using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZekaDestekliAAlgoritması
{
    public class AStarSolver
    {
        private static readonly Tuple<int, int>[] Directions = new Tuple<int, int>[]
        {
            new Tuple<int, int>(0, 1),  
            new Tuple<int, int>(1, 0),  
            new Tuple<int, int>(0, -1), 
            new Tuple<int, int>(-1, 0)  
        };

        public List<Tuple<int, int>> FindPath(int[,] grid, Tuple<int, int> start, Tuple<int, int> end)
        {
            var openList = new List<Node> { new Node(start, 0, Heuristic(start, end)) };
            var closedList = new HashSet<Tuple<int, int>>();

            while (openList.Count > 0)
            {
                openList.Sort((a, b) => a.F.CompareTo(b.F)); 
                var current = openList[0];
                openList.RemoveAt(0);

                if (current.Position.Equals(end))
                {
                    var path = new List<Tuple<int, int>>();
                    while (current.Parent != null)
                    {
                        path.Add(current.Position);
                        current = current.Parent;
                    }
                    path.Reverse();
                    return path;
                }

                closedList.Add(current.Position);

                foreach (var direction in Directions)
                {
                    var neighbor = new Tuple<int, int>(current.Position.Item1 + direction.Item1, current.Position.Item2 + direction.Item2);

                    if (IsValid(grid, neighbor, closedList))
                    {
                        var gCost = current.G + 1;
                        var hCost = Heuristic(neighbor, end);
                        var neighborNode = new Node(neighbor, gCost, hCost) { Parent = current };
                        openList.Add(neighborNode);
                    }
                }
            }

            return null; 
        }

        private bool IsValid(int[,] grid, Tuple<int, int> position, HashSet<Tuple<int, int>> closedList)
        {
            return position.Item1 >= 0 && position.Item1 < grid.GetLength(0) &&
                   position.Item2 >= 0 && position.Item2 < grid.GetLength(1) &&
                   grid[position.Item1, position.Item2] == 0 && !closedList.Contains(position);
        }

        private int Heuristic(Tuple<int, int> a, Tuple<int, int> b)
        {
            return Math.Abs(a.Item1 - b.Item1) + Math.Abs(a.Item2 - b.Item2); 
        }

        private class Node
        {
            public Tuple<int, int> Position { get; }
            public int G { get; }
            public int H { get; }
            public int F => G + H;
            public Node Parent { get; set; }

            public Node(Tuple<int, int> position, int g, int h)
            {
                Position = position;
                G = g;
                H = h;
                Parent = null;
            }
        }
    }
}
