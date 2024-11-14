using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YapayZekaDestekliAAlgoritması
{
    public class Program
    {
        static void Main()
        {
            int[,] grid = new int[10, 10]
            {
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                {0, 1, 1, 1, 0, 0, 0, 0, 0, 0},
                {0, 0, 0, 1, 0, 0, 0, 1, 1, 0},
                {0, 1, 0, 0, 0, 1, 0, 0, 0, 0},
                {0, 1, 0, 1, 0, 1, 0, 0, 1, 0},
                {0, 1, 0, 0, 0, 0, 1, 0, 0, 0},
                {0, 1, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 0, 1, 1, 0, 0, 0, 1, 0},
                {0, 1, 0, 0, 1, 0, 1, 0, 0, 0},
                {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
            };

            var start = new Tuple<int, int>(0, 0); 
            var end = new Tuple<int, int>(9, 9);  

            var solver = new AStarSolver();
            var path = solver.FindPath(grid, start, end);

            if (path != null)
            {
                Console.WriteLine("Yol bulundu!");
                foreach (var point in path)
                {
                    Console.WriteLine($"({point.Item1}, {point.Item2})");
                }
            }
            else
            {
                Console.WriteLine("Yol bulunamadı.");
            }

            Console.ReadKey();
        }
    }
}
