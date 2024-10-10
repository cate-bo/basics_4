namespace recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {


           Fibonacci(100);
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
    }
}
