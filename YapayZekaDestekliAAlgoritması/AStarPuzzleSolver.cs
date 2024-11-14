using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZekaDestekliAAlgoritması
{
    public class GridVisualizer
    {
        public static void Visualize(int[,] grid, List<Tuple<int, int>> path)
        {
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    if (path.Contains(new Tuple<int, int>(i, j)))
                        Console.Write(" * ");
                    else
                        Console.Write(grid[i, j] == 1 ? " X " : " . "); 
                }
                Console.WriteLine();
            }
        }
    }
}
