// Program to find guess number from 1 to 127.
namespace Test2 {
   class GuessNumber {
      public static void GuessGame () {
         int[] bits = { 0, 0, 0, 0, 0, 0, 0 };
         int[] powers = { 64, 32, 16, 8, 4, 2, 1 };
         Console.Write ("Is your number is odd or even? (o/e): ");
         var firstDigit = Console.ReadKey ().Key;
         if (!(firstDigit is ConsoleKey.O or ConsoleKey.E)) {
            Console.WriteLine ("Enter valid input");
            return;
         }
         if (firstDigit is ConsoleKey.O) bits[6] = 1;
         Console.WriteLine ();
         int n = 2;
         for (int i = 5; i >= 0; i--) {
            Console.Write ($"If the number gets divided by {(Math.Pow (2, n))}, will it give a remainder of any number in the range [{(Math.Pow (2, n - 1))}, {(Math.Pow (2, n) - 1)}]? (y/n): ");
            string nthDigit = Console.ReadLine ()!;
            if (nthDigit == "y" || nthDigit == "Y") bits[i] = 1;
            n++;
         }
         for (int i = 0; i <= 6; i++) powers[i] = powers[i] * bits[i];
         Console.Write ($"I got the answer is 0b{string.Join ("", bits)} = {powers.Sum ()}.");
         Console.WriteLine ();
      }

      public static void Main (string[] args) {
         Console.WriteLine ("Choose number between 1 and 127");
         Console.WriteLine ("Decide number");
         Console.WriteLine ("Lets start the game");
         GuessGame ();
      }
   }
}