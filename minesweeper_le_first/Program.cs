namespace minesweeper_le_first
{
    internal class Program
    {

        struct Fieldstate
        {
            public byte adjacentMines = 0;
            public bool containsMine = false;
            public bool revealed = false;
            public bool flag = false;

            public Fieldstate()
            {
            }
        }

        static int areaWidth = 0;
        static int areaHeight = 0;
        static int mineCount = 0;
        static Fieldstate[,] playArea; //0-8 adjacent mines, 9 mine 
        static Random rand = new Random();
        static bool gameInProgress;
        static bool lose = false;
        static bool win = false;
        static void Main(string[] args)
        {

            bool playAgain = false;
            do
            {
                Console.Clear();
                gameInProgress = true;
                Console.WriteLine("enter area width");
                areaWidth = Validate_Input(2, int.MaxValue);

                Console.WriteLine("enter area height");
                areaHeight = Validate_Input(2, int.MaxValue);

                Console.WriteLine($"enter mine count (max {(areaWidth * areaHeight) / 2})");
                mineCount = Validate_Input(1, (areaWidth * areaHeight) / 2);

                playArea = new Fieldstate[areaWidth, areaHeight];
                // x and y coordinates correspond to lines and columns
                /*
                for (int y = 0; y < playArea.GetLength(1); y++)
                {
                    for (int x = 0; x < playArea.GetLength(0); x++)
                    {
                        playArea[x, y] = 0;
                    }
                }
                */
                win = false;
                lose = false;
                while (mineCount > 0)
                {
                    int x = rand.Next(0, playArea.GetLength(0));
                    int y = rand.Next(0, playArea.GetLength(1));
                    if (!playArea[x, y].containsMine)
                    {
                        playArea[x, y].containsMine = true;
                        mineCount--;
                    }
                }

                //DisplayPlayArea();
                CountAdjacentMines();
                Console.WriteLine();
                DisplayPlayArea();

                while (gameInProgress)
                {
                    Console.WriteLine("select column");
                    int inputX = Validate_Input(0, playArea.GetLength(0));
                    Console.WriteLine("select rank");
                    int inputY = Validate_Input(0, playArea.GetLength(1));
                    Console.WriteLine("select action reveal or flag (R/f)\n");
                    while (true)
                    {
                        ConsoleKey input = Console.ReadKey().Key;

                        if (input == ConsoleKey.R || input == ConsoleKey.Enter)
                        {
                            RevealField(inputX, inputY);
                            break;
                        }
                        else if (input == ConsoleKey.F)
                        {
                            PlaceFlag(inputX, inputY);
                            break;
                        }
                    }
                    Console.WriteLine("\n");

                    DisplayPlayArea();
                    CheckIfWon();
                    if (win || lose) break;





                }

                if (win)
                {
                    Console.WriteLine("you win\n");

                    RevealAllFields();
                    DisplayPlayArea();
                }
                else if (lose)
                {
                    Console.WriteLine("you lose\n");

                    RevealAllFields();
                    DisplayPlayArea();
                }
                else
                {
                    Console.WriteLine("program broke");
                }

                Console.WriteLine("play again?(Y/n)\n");
                while (true)
                {
                    ConsoleKey input = Console.ReadKey().Key;

                    if (input == ConsoleKey.Y || input == ConsoleKey.Enter)
                    {
                        playAgain = true;
                        break;
                    }
                    else if (input == ConsoleKey.N)
                    {
                        playAgain = false;
                        break;
                    }
                }

            } while (playAgain);
        }

        static void RevealAllFields()
        {
            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                for (int x = 0; x < playArea.GetLength(0); x++)
                {
                    playArea[x, y].revealed = true;
                }
            }
        }

        static void DisplayPlayArea()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" ");
            for (int width = 0; width < playArea.GetLength(0); width++)
            {
                Console.Write($"{width} ");
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine();

            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{y}");



                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                for (int x = 0; x < playArea.GetLength(0); x++)
                {
                    if (!playArea[x, y].revealed)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        if(playArea[x, y].flag)
                        {
                            Console.Write("f ");
                        }else
                        {
                            Console.Write("  ");
                        }
                        
                        Console.BackgroundColor = ConsoleColor.Gray;
                        continue;

                    }

                    if (playArea[x, y].containsMine)
                    {
                        Console.Write("X ");
                        continue;
                    }

                    if (playArea[x, y].adjacentMines == 0)
                    {
                        Console.Write("  ");
                    }
                    else if (!playArea[x, y].containsMine)
                    {
                        switch (playArea[x, y].adjacentMines)
                        {
                            case 0: break;
                            case 1: Console.ForegroundColor = ConsoleColor.Blue; break;
                            case 2: Console.ForegroundColor = ConsoleColor.Green; break;
                            case 3: Console.ForegroundColor = ConsoleColor.Red; break;
                            case 4: Console.ForegroundColor = ConsoleColor.Magenta; break;
                            case 5: Console.ForegroundColor = ConsoleColor.Yellow; break;
                            default: Console.ForegroundColor = ConsoleColor.Magenta; break;
                        }
                        Console.Write($"{playArea[x, y].adjacentMines} ");
                        Console.ForegroundColor = ConsoleColor.Black;

                    }

                    //Console.Write(playArea[x, y]);
                }
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
            }


            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }


        static void CheckIfWon()
        {
            win = true;
            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                for (int x = 0; x < playArea.GetLength(0); x++)
                {
                    if (!playArea[x, y].containsMine && !playArea[x, y].revealed)
                    {
                        win = false;
                    }
                }
            }
        }

        static int Validate_Input(int min_number, int max_number)
        {
            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input >= min_number && input <= max_number)
                    {
                        return input;
                    }
                    else
                    {
                        Console.WriteLine("invalid input");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("invalid input");
                }

            }
        }


        static void CountAdjacentMines()
        {

            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                for (int x = 0; x < playArea.GetLength(0); x++)
                {

                    if (playArea[x, y].containsMine) continue;


                    int upperOffset = 1;
                    int lowerOffset = 1;
                    int leftOffset = 1;
                    int rightOffset = 1;
                    byte adjacentMines = 0;
                    if (y == 0)
                    {
                        upperOffset = 0;
                    }
                    if (y == playArea.GetLength(1) - 1)
                    {
                        lowerOffset = 0;
                    }
                    if (x == 0)
                    {
                        leftOffset = 0;
                    }
                    if (x == playArea.GetLength(0) - 1)
                    {
                        rightOffset = 0;
                    }



                    for (int height = y - upperOffset; height <= y + lowerOffset; height++)
                    {
                        for (int width = x - leftOffset; width <= x + rightOffset; width++)
                        {
                            if (height == y && width == x) continue;
                            if (playArea[width, height].containsMine)
                            {
                                adjacentMines++;
                            }
                        }
                    }

                    playArea[x, y].adjacentMines = adjacentMines;

                }
            }

        }


        static void RevealField(int x, int y)
        {
            if (playArea[x, y].flag)
            {
                return;
            }

            playArea[x, y].revealed = true;



            if (playArea[x, y].containsMine)
            {
                lose = true;
                return;
            }
            if (playArea[x, y].adjacentMines > 0)
            {
                return;
            }


            int upperOffset = 1;
            int lowerOffset = 1;
            int leftOffset = 1;
            int rightOffset = 1;

            if (y == 0)
            {
                upperOffset = 0;
            }
            if (y == playArea.GetLength(1) - 1)
            {
                lowerOffset = 0;
            }
            if (x == 0)
            {
                leftOffset = 0;
            }
            if (x == playArea.GetLength(0) - 1)
            {
                rightOffset = 0;
            }



            for (int height = y - upperOffset; height <= y + lowerOffset; height++)
            {
                for (int width = x - leftOffset; width <= x + rightOffset; width++)
                {

                    if (!playArea[width, height].revealed && playArea[width, height].adjacentMines == 0)
                    {
                        RevealField(width, height);
                    }

                    playArea[width, height].revealed = true;
                }
            }
        }

        static void PlaceFlag(int x, int y)
        {
            if (playArea[x, y].revealed)
            {
                Console.WriteLine("cannot flag revealed field");
                return;
            }
            if (playArea[x, y].flag)
            {
                playArea[x, y].flag = false;
            }
            else
            {
                playArea[x, y].flag = true;
            }

        }
    }
}
