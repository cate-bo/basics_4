namespace arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] myArray = new int[10];
            Random rand = new Random();

            // fill array with random and print
            for (int index = 0; index < myArray.Length; index++)
            {
                myArray[index] = rand.Next(1,1001);
            }

            for (int index = 0;index < myArray.Length; index++)
            {
                Console.Write($"{myArray[index]}-");
            }
            Console.WriteLine("\n\n\n");


            //initialize array with values and access specifically
            int fibnum = 5;
            int[] fibo = new int[] { 1, 2, 3, 5, 8, 13, 21, 34, 55 };

            Console.WriteLine($"no. {fibnum} is {fibo[fibnum-1]}");


            //array mistakes

            int[] errorArray = new int[3];

            errorArray[0] = 5;
            errorArray[1] = 6;
            errorArray[2] = 7;
            //errorArray[3] = 8;
            Console.WriteLine(errorArray[2]);


            //foreach

            foreach(int num in fibo)
            {
                Console.Write(num + " ");
            }

        }
    }
}
