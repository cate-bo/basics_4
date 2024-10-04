namespace another_guessing_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Random random = new Random();
            bool another_one = false;
            do
            {

                Console.Clear();
                Console.WriteLine("enter amount of numbers");


                (int number, bool revealed)[] nums = new (int number, bool revealed)[Validate_Input(int.MaxValue)];

                Console.WriteLine("enter range");
                int range = Validate_Input(int.MaxValue);


                for (int index = 0; index < nums.Length; index++)
                {
                    nums[index] = (random.Next(1, range+1), false);
                }

                int number_to_guess = nums[random.Next(nums.Length)].number;
                
                PrintNums(nums);
                //Console.WriteLine(number_to_guess);

                bool game_over = false;

                while (!game_over)
                {
                    Console.WriteLine("guess a number");
                    int guess = Validate_Input(range);
                    bool smaller = false;
                    if (guess == number_to_guess)
                    {
                        Console.WriteLine("you win");
                        game_over = true;
                        for (int index = 0; index < nums.Length; index++)
                        {
                            nums[index].revealed = true;
                        }
                        PrintNums(nums);
                        break;
                    }
                    else if (guess < number_to_guess)
                    {
                        smaller = true;
                    }
                    else
                    {
                        smaller = false;
                    }

                    if (smaller)
                    {
                        for (int index = 0; index < nums.Length; index++)
                        {
                            if (nums[index].number <= guess)
                            {
                                nums[index].revealed = true;
                            }
                        }
                    }
                    else
                    {
                        for (int index = 0; index < nums.Length; index++)
                        {
                            if (nums[index].number >= guess)
                            {
                                nums[index].revealed = true;
                            }
                        }
                    }
                    bool only_number_to_guess_left = true;
                    foreach ((int number, bool revealed) in nums)
                    {
                        if (number != number_to_guess && !revealed)
                        {
                            only_number_to_guess_left = false;
                        }
                    }

                    if (only_number_to_guess_left)
                    {
                        PrintNums(nums);
                        game_over = true;
                        for (int index = 0; index < nums.Length; index++)
                        {
                            nums[index].revealed = true;
                        }
                        Console.WriteLine($"you lose\nnumber was {number_to_guess}");
                    }



                    PrintNums(nums);

                }

                Console.WriteLine("play again?(Y/n)\n");
                while (true)
                {
                    ConsoleKey input = Console.ReadKey().Key;

                    if (input == ConsoleKey.Y || input == ConsoleKey.Enter)
                    {
                        another_one = true;
                        break;
                    }
                    else if (input == ConsoleKey.N)
                    {
                        another_one = false;
                        break;
                    }
                }

            } while (another_one);
        }

        static void PrintNums((int number, bool revealed)[] nums)
        {
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index].revealed)
                {
                    Console.Write($"{nums[index].number}");

                }
                else
                {
                    Console.Write("X");
                }
                if (index != nums.Length - 1)
                {
                    Console.Write(" - ");
                }
            }
            Console.WriteLine("\n");
        }

        static int Validate_Input(int max_number)
        {
            while (true)
            {
                try
                {
                    int input = int.Parse(Console.ReadLine());
                    if (input > 0 && input <= max_number)
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
    }
}
