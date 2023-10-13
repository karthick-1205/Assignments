// Program to find guess number from 1 to 127.
namespace Test2 {
   class GuessNumber {
      public static void GuessGame () {
         int n = 2;
         List<int> BitList = new List<int> () { 0, 0, 0, 0, 0, 0, 0 };
         List<int> Powers = new List<int> () { 64, 32, 16, 8, 4, 2, 1 };
         Console.Write ("Is your number is odd or even? (o/e): ");
         string firstDigit = Console.ReadLine ();
         if (firstDigit == "o" || firstDigit == "O") BitList[6] = 1;
         for (int i = 5; i >= 0; i--) {
            Console.Write ($"If the number gets divided by {(Math.Pow (2, n))}, will it give a remainder of any number in the range [{(Math.Pow (2, n - 1))}, {(Math.Pow (2, n) - 1)}]? (y/n): ");
            string nthDigit = Console.ReadLine ();
            if (nthDigit == "y" || nthDigit == "Y") BitList[i] = 1;
            n++;
         }
         for (int i = 0; i <= 6; i++) {
            Powers[i] = Powers[i] * BitList[i];
         }
         Console.Write ($"I got the answer is 0b{String.Join ("", BitList)} = {Powers.Sum ()}.");
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