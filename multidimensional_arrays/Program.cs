namespace multidimensional_arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] things_2d = new int[4, 4];
            

            Random rand = new Random();

            for (int x = 0; x < things_2d.GetLength(0); x++)
            {
                for (int y = 0; y < things_2d.GetLength(1); y++)
                {
                    things_2d[x,y] = rand.Next(1, 100);
                }
            }

            Console.WriteLine();


            for (int x = 0; x < things_2d.GetLength(0); x++)
            {
                for (int y = 0; y < things_2d.GetLength(1); y++)
                {
                    Console.Write(things_2d[x, y] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
