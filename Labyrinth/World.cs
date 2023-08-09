using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabyrinthTP
{
    class World
    {
        public void CreateGrid(string[,] mysStr)
        {
            for (int i = 0; i < mysStr.GetLength(0); i++)
            {
                for (int j = 0; j < mysStr.GetLength(1); j++)
                {
                    mysStr[i, j] = "X";
                }
                Console.Write("\n");
            }
        }

        public void PrintGrid(string[,] mysStr)
        {
            for (int i = 0; i < mysStr.GetLength(0); i++)
            {
                for (int j = 0; j < mysStr.GetLength(1); j++)
                {
                    Console.Write(mysStr[i, j]);
                }
                Console.Write("\n");
            }
            Console.Write("\n");
        }

        public bool IsPostitionAvailable(int x, int y, string[,] grid)
        {
            if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
            {
                //Console.WriteLine("Mauvaise coordonnée");
                return false;
            }

            return grid[x, y] == "X";
        }

        public bool IsNotAPath(int x, int y, string[,] grid)
        {
            if (x < 0 || y < 0 || x >= grid.GetLength(0) || y >= grid.GetLength(1))
            {
                return true;
            }

            return grid[x, y] == "X";
        }
    }
}
