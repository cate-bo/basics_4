using System.Net.Http.Headers;

namespace recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {


            //Fibonacci(100);

            /*
            Console.WriteLine(NumberOfUniquePaths(1, 1));
            Console.WriteLine(NumberOfUniquePaths(3, 4));
            Console.WriteLine(NumberOfUniquePaths(2, 2));
            Console.WriteLine(NumberOfUniquePaths(1, 2));
            Console.WriteLine(NumberOfUniquePaths(2, 1));
            */
            Console.WriteLine(PartitionSets(3, 3));
            Console.WriteLine(PartitionSets(9, 5));
            Console.WriteLine(PartitionSets(7, 4));
            Console.WriteLine(PartitionSets(1, 1));
            Console.WriteLine(PartitionSets(2, 2));
            Console.WriteLine(PartitionSets(4, 2));
            Console.WriteLine(PartitionSets(4, 3));
        }

        static int Sum(int value)
        {
            if (value == 0)
            {
                return 0;
            }
            return value + Sum(value -1);
        }


        static int Fibonacci(int max, int former = 0, int current = 1)
        {
            Console.WriteLine(current);
            if(former + current > max)
            { 
                return current;
            }
            return Fibonacci(max, current,former + current);
        }

        static int NumberOfUniquePaths(int x, int y)
        {
            if (x == 1 || y == 1) return 1;
            return NumberOfUniquePaths(x -1, y) + NumberOfUniquePaths(x, y -1);
        }



        static int PartitionSets(int set, int partitionMaxSize)
        {
            if(partitionMaxSize == 0) return 0;
            if(partitionMaxSize == 1) return 1;
            if (set <= 1) return 1;
            return PartitionSets(set - partitionMaxSize, partitionMaxSize) + PartitionSets(set, partitionMaxSize - 1);
        }
    }
}
