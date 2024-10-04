namespace another_guessing_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            (int number, bool revealed)[] nums = new (int number, bool revealed)[10];
            Random random = new Random();

            for (int index = 0; index < nums.Length; index++)
            {
                nums[index] = (random.Next(1, 11), false);
            }

            int number_to_guess = nums[random.Next(nums.Length)].number;

            PrintNums(nums);
            //Console.WriteLine(number_to_guess);

            bool game_over = false;

            while (!game_over)
            {
                Console.WriteLine("guess");
                int guess = int.Parse(Console.ReadLine());
                bool smaller = false;
                if (guess == number_to_guess)
                {
                    Console.WriteLine("you win");
                    game_over = true;
                    for (int index = 0;index < nums.Length; index++)
                    {
                        nums[index].revealed = true;
                    }
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
                foreach((int number, bool revealed) in nums)
                {
                    if(number != number_to_guess && !revealed)
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
        }
    }
}