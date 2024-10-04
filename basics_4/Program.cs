namespace basics_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testInt = 500;
            short testShort = 100;
            float testfloat = 3.5f;
            long testLong = long.MaxValue;

            int targetInt = 0;
            short targetShort = 0;

            //implicit casting
            targetInt = testShort;

            //targetShort = testInt;



            //explicit cast
            targetShort = (short)testInt;


            string thing = "10";

            
            targetInt = int.Parse(thing);



            float targetFloat = testLong + 1;

            Console.WriteLine(long.MaxValue + "       " + targetFloat);


        }
    }
}
