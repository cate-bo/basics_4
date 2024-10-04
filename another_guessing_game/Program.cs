﻿namespace another_guessing_game
{
    internal class Program
    {
        static int[] nums = new int[1];
        static int lower;
        static int upper;
        static int lowest_contained_number;
        static int highest_contained_number;

        static void Main(string[] args)
        {
            
            Random random = new Random();
            bool another_one = false;
            do
            {

                Console.Clear();
                Console.WriteLine("enter amount of numbers");


                nums = new int[Validate_Input(int.MaxValue)];

                Console.WriteLine("enter range");
                int range = Validate_Input(int.MaxValue);
                lower = 0;
                upper = range+1;


                for (int index = 0; index < nums.Length; index++)
                {
                    nums[index] = random.Next(1, range+1);
                }

                int number_to_guess = nums[random.Next(nums.Length)];
                
                PrintNums();
                //Console.WriteLine(number_to_guess);

                bool game_over = false;

                while (!game_over)
                {
                    Console.WriteLine("guess a number");
                    int guess = Validate_Input(range);
                    

                    if (guess == number_to_guess)
                    {
                        Console.WriteLine("you win");
                        game_over = true;
                        for (int index = 0; index < nums.Length; index++)
                        {
                            lower = number_to_guess;
                            upper = lower;
                        }
                        PrintNums();
                        break;
                    }
                    else if (guess < number_to_guess)
                    {
                        lower = guess;
                    }
                    else
                    {
                        upper = guess;
                    }

                    
                    
                    bool only_number_to_guess_left = true;
                    foreach (int number in nums)
                    {
                        if ((number < number_to_guess && number > lower) || (number > number_to_guess && number < upper))
                        {
                            only_number_to_guess_left = false;
                        }
                    }

                    if (only_number_to_guess_left)
                    {
                        PrintNums();
                        game_over = true;
                        lower = number_to_guess;
                        upper = lower;
                        Console.WriteLine($"you lose\nnumber was {number_to_guess}");
                    }

                    //TODO stuff here

                    foreach(int number in nums)
                    {
                        if(number <= lower && number > lowest_contained_number)
                        {
                            lowest_contained_number = number;
                        }
                    }



                    PrintNums();

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

        static void PrintNums()
        {
            for (int index = 0; index < nums.Length; index++)
            {
                if (nums[index] <= lower || nums[index] >= upper)
                {
                    
                    Console.Write($"{nums[index]}");

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
