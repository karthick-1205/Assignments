// Program to find user is supposed to guess a number between 0 and 100 in a maximum of 8 attempts.
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
               var x = (number - rand) switch {
                  > 0 => "The number is higher, guess again.",
                  < 0 => "The number is lesser, guess again.",
                  _ => "Correct, you Win!",
               };
               if (x == "Correct, you Win!") {
                  Console.WriteLine (x);
                  Console.WriteLine ("Number of tries: {0}", tryCount);
                  break;
               }
               Console.WriteLine (x);
               Console.WriteLine ("Number of tries: {0}", tryCount);
            }
         }
         if (tryCount == 8) {
            Console.WriteLine ("you lose game");
            Console.WriteLine ($"The guessed number is {rand}");
         }
      }
   }
}