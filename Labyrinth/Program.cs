using System;
using System.Collections;
using System.Collections.Generic;


namespace LabyrinthTP
{
    class Labyrinth
    {
        #region---Variables---
        public int x;
        public int y;
        public string[,] mysStr;
        public Stack<Tuple<int, int>> myStack = new Stack<Tuple<int, int>>();
        public Tuple<int, int> My_Tuple1 = new Tuple<int, int>(0, 0);

        public World world;
        #endregion

        #region---Constructor---
        public Labyrinth(int xPos, int yPos)
        {
            x = 0;
            y = 0;
            mysStr = new string[xPos, yPos];

            world = new World();

            world.CreateGrid(mysStr);
            Console.Clear();

            world.PrintGrid(mysStr);
            Console.Write("\n");
        }
        #endregion 

        #region---Movement---
        public bool MoveRight()
        {
            if (world.IsPostitionAvailable(x, y + 1, mysStr) && world.IsNotAPath(x, y + 2, mysStr) && world.IsNotAPath(x + 1, y + 1, mysStr) && world.IsNotAPath(x - 1, y + 1, mysStr))
            {
                mysStr[x, y] = "*";

                mysStr[x, y + 1] = "*";

                y++;

                return true;
            }
            return false;
        }

        public bool MoveLeft()
        {
            if (world.IsPostitionAvailable(x, y - 1, mysStr) && world.IsNotAPath(x, y - 2, mysStr) && world.IsNotAPath(x + 1, y - 1, mysStr) && world.IsNotAPath(x - 1, y - 1, mysStr))
            {
                mysStr[x, y] = "*";

                mysStr[x, y - 1] = "*";

                y--;

                return true;
            }
            return false;
        }

        public bool MoveDown()
        {
            if (world.IsPostitionAvailable(x + 1, y, mysStr) && world.IsNotAPath(x + 2, y, mysStr) && world.IsNotAPath(x + 1, y + 1, mysStr) && world.IsNotAPath(x + 1, y - 1, mysStr))
            {
                mysStr[x, y] = "*";

                mysStr[x + 1, y] = "*";

                x++;

                return true;
            }
            return false;
        }

        public bool MoveUp()
        {
            if (world.IsPostitionAvailable(x - 1, y, mysStr) && world.IsNotAPath(x - 2, y, mysStr) && world.IsNotAPath(x - 1, y + 1, mysStr) && world.IsNotAPath(x - 1, y - 1, mysStr))
            {
                mysStr[x, y] = "*";

                mysStr[x - 1, y] = "*";

                x--;

                return true;
            }
            return false;
        }
        #endregion

        #region---Displacement---
        public int RandomNumber()
        {
            int randomNum;
            Random rand = new Random();

            randomNum = rand.Next(0, 4);

            Console.WriteLine(randomNum);

            return randomNum;
        }

        public void Direction(int rand)
        {
            switch (rand)
            {
                case 0:
                    MoveRight();
                    break;
                case 1:
                    MoveLeft();
                    break;
                case 2:
                    MoveDown();
                    break;
                case 3:
                    MoveUp();
                    break;

                default:
                    break;
            }
        }


        public void KeepTrackOfPosition()
        {
            myStack.Push(My_Tuple1 = Tuple.Create(x, y));

            foreach (var item in myStack)
            {
                Console.WriteLine(item);
            }
        }

        public bool EndOfRoad()
        {
            if (!MoveRight() && !MoveLeft() && !MoveUp() && !MoveDown())
            {
                //Console.WriteLine("End of the road, please backtrack now !");
                return true;
            }

            KeepTrackOfPosition();
            world.PrintGrid(mysStr);

            return false;
        }
        #endregion

        #region---Build Labyrinth---
        public void BuildLabyrinth(Labyrinth labyrinth)
        {
            while (true)
            {
                int rand = labyrinth.RandomNumber();

                labyrinth.Direction(rand);

                labyrinth.KeepTrackOfPosition();

                labyrinth.world.PrintGrid(labyrinth.mysStr);

                while (labyrinth.EndOfRoad())
                {
                    Console.WriteLine("End of the road, please backtrack now !");
                    labyrinth.myStack.Pop();


                    labyrinth.x = labyrinth.My_Tuple1.Item1;
                    labyrinth.y = labyrinth.My_Tuple1.Item2;

                    if (labyrinth.myStack.Count != 0)
                    {
                        labyrinth.My_Tuple1 = labyrinth.myStack.Peek();

                    }
                    else
                    {
                        labyrinth.world.PrintGrid(labyrinth.mysStr);
                        return;
                    }

                    foreach (var item in labyrinth.myStack)
                    {
                        Console.WriteLine(item);
                    }

                    Console.Write(labyrinth.x + ",");
                    Console.WriteLine(labyrinth.y);

                    Console.ReadLine();

                }

                Console.ReadLine();
            }
        }

        public void BuildLabyrinthAutomatically(Labyrinth labyrinth)
        {
            while (true)
            {
                int rand = labyrinth.RandomNumber();

                labyrinth.Direction(rand);

                labyrinth.KeepTrackOfPosition();

                labyrinth.world.PrintGrid(labyrinth.mysStr);
                Console.Clear();

                while (labyrinth.EndOfRoad())
                {
                    labyrinth.myStack.Pop();

                    labyrinth.x = labyrinth.My_Tuple1.Item1;
                    labyrinth.y = labyrinth.My_Tuple1.Item2;

                    if (labyrinth.myStack.Count != 0)
                    {
                        labyrinth.My_Tuple1 = labyrinth.myStack.Peek();
                    }
                    else
                    {
                        labyrinth.world.PrintGrid(labyrinth.mysStr);
                        return;
                    }
                }
            }
        }
        #endregion
    }




    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, welcome to build a maze \nPlease enter the size of the maze you would like \n\n");
            int row;
            int col;
            int value;

            Console.WriteLine("Enter first the number of colones you would like : ");
            string input = Console.ReadLine();
            int.TryParse(input, out col);

            Console.WriteLine("Enter now the number of rows you would like : ");
            string input2 = Console.ReadLine();
            int.TryParse(input2, out row);


            Labyrinth labyrinth = new Labyrinth(col, row);


            Console.WriteLine("Plesse press 1 for automatic build or 2 for step by step build of the maze");
            string input3 = Console.ReadLine();
            int.TryParse(input3, out value);


            if (value == 1)
            {
                labyrinth.BuildLabyrinthAutomatically(labyrinth);
            }
            else if (value == 2)
            {
                labyrinth.BuildLabyrinth(labyrinth);
            }

        }
    }
}

