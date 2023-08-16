//Program to find user is supposed to guess a number between 0 and 100 in a maximum of 8 attempts.
using System;
namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int rand = new Random().Next(1, 101);
            int tryCount = 0;
            while (tryCount < 8)
            {
                Console.WriteLine("Enter your guess(1-100): ");
                int number = Convert.ToInt32(Console.ReadLine());
                tryCount++;
                if (number == rand)
                {
                    Console.WriteLine("Correct you Win");
                    Console.WriteLine("No of tries:{0}", tryCount);
                    break;
                }
                else if (rand > number)
                {
                    Console.WriteLine("The number is higher and guess again");
                }
                else
                {
                    Console.WriteLine("The number is lesser and guess again");
                }

            }
            if (tryCount == 8)
            {
                Console.WriteLine("you lose game");
                Console.WriteLine("The guessed number is "+rand);
            }
        }
    }
}