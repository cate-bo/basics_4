namespace minesweeper_le_first
{
    internal class Program
    {

        static int areaWidth = 0;
        static int areaHeight = 0;
        static int mineCount = 0;
        static int[,] playArea; //0-8 adjacent mines, 9 mine 
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
                mineCount = Validate_Input(1,(areaWidth * areaHeight) / 2);

                playArea = new int[areaWidth, areaHeight];
                // x and y coordinates correspond to lines and columns
                for (int y = 0; y < playArea.GetLength(1); y++)
                {
                    for (int x = 0; x < playArea.GetLength(0); x++)
                    {
                        playArea[x, y] = 0;
                    }
                }

                while(mineCount > 0)
                {
                    int x = rand.Next(0, playArea.GetLength(0));
                    int y = rand.Next(0, playArea.GetLength(1));
                    if (playArea[x,y] == 0)
                    {
                        playArea[x, y] = 9;
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
            for (int y = 0; y < playArea.GetLength(1); y++)
            {
                for (int x = 0; x < playArea.GetLength(0); x++)
                {

                    if (playArea[x, y] <= 8)
                    {
                        Console.Write(playArea[x, y]);
                    }else if (playArea[x, y] == 9)
                    {
                        Console.Write("X");
                    }
                    
                    //Console.Write(playArea[x, y]);
                }
                Console.WriteLine();
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

                    if(playArea[x, y] == 9) break;


                    int upperOffset = 1;
                    int lowerOffset = 1;
                    int leftOffset = 1;
                    int rightOffset = 1;
                    int adjacentMines = 0;
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
                


                    for (int height = y-upperOffset; height <= y+lowerOffset; height++)
                    {
                        for(int width = x-leftOffset; width <= x+rightOffset; width++)
                        {
                            //if (height == y && width == x) break;
                            if (playArea[width, height] == 9)
                            {
                                adjacentMines++;
                            }
                        }
                    }
                    
                    playArea[x, y] = adjacentMines;
                    
                }
            }

        }
    }
}
