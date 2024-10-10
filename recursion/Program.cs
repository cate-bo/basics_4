namespace recursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int test = Sum(3);
            Console.WriteLine(test);
        }

        static int Sum(int value)
        {
            if (value == 0)
            {
                return 0;
            }
            return value + Sum(value -1);
        }
    }
}
