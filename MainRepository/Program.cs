// Program to find user is supposed to guess a number between 0 and 100 in a maximum of 8 attempts.
using System.Diagnostics.Metrics;

namespace Test2 {
   class Program {
      static void Main (string[] args) {
         int rand = new Random ().Next (1, 101), tryCount = 0;
         while (tryCount < 8) {
            Console.WriteLine ("Enter your guess (1-100): ");
            if (!int.TryParse (Console.ReadLine (), out int number) || number < 0) {
               Console.WriteLine ("Enter the valid input");
            } else {
               tryCount++;
               switch (rand.CompareTo (number)) {
                  case 1:
                     Console.WriteLine ("The number is higher, guess again.");
                     break;
                  case -1:
                     Console.WriteLine ("The number is lesser, guess again.");
                     break;
                  default:
                     Console.WriteLine ("Correct, you Win!");
                     Console.WriteLine ("Number of tries: {0}", tryCount);
                     break;
               }
            }
         }
         if (tryCount == 8) {
            Console.WriteLine ("you lose game");
            Console.WriteLine ($"The guessed number is {rand}");
         }
      }
   }
}