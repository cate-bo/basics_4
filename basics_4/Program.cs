namespace basics_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int testInt = 500;
            short testShort = 100;
            float testfloat = 3.5f;

            int targetInt = 0;
            short targetShort = 0;

            //implicit casting
            targetInt = testShort;

            //targetShort = testInt;



            //explicit cast
            targetShort = (short)testInt;






        }
    }
}
