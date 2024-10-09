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
        static void Main(string[] args)
        {
            

            do
            {
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

                DisplayPlayArea();
                CountAdjacentMines();
                Console.WriteLine();
                DisplayPlayArea();


            } while (true);
        }

        static void DisplayPlayArea()
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("  ");
            for(int width = 0; width < playArea.GetLength(0); width++)
            {
                Console.Write($"{width} ");
            }
            Console.Write("  ");
            Console.WriteLine();
            Console.Write("  ");
            for (int width = 0; width < playArea.GetLength(0); width++)
            {
                Console.Write($"__");
            }
            Console.Write("  ");
            Console.WriteLine();

            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                Console.Write($"{y}|");
                for (int x = 0; x < playArea.GetLength(0); x++)
                {
                    if(!playArea[x, y].revealed)
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.Write("  ");
                        Console.BackgroundColor = ConsoleColor.Gray;
                        continue;
                    } 

                    if (!playArea[x, y].containsMine)
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
                    if (playArea[x, y].containsMine)
                    {
                        Console.Write("X ");
                    }

                    //Console.Write(playArea[x, y]);
                }
                Console.WriteLine("|");
            }
            Console.Write(" |");
            for (int width = 0; width < playArea.GetLength(0); width++)
            {
                Console.Write($"__");
            }
            Console.WriteLine("|");

            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
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
    }
}
