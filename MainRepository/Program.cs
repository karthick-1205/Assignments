//Program to find computer is supposed to guess a number by user between 0 and 100
namespace Test2 {
   class Class1 {
      static void Main (string[] args) {
         Console.WriteLine ("Choose number between 1 and 100");
         Console.WriteLine ("Decide number");
         Console.WriteLine ("Lets start the game");
         int lower = 1;
         int upper = 100;
         int guessed_num = (lower + upper) / 2;
         int guess_count = 0;
         while (true) {
            guess_count++;
            Console.WriteLine ("Computer guessed number is " + guessed_num);
            Console.WriteLine ("Please enter 1: If computer guessed number is lower than what you have chosen!");
            Console.WriteLine ("Please enter 2: If computer guessed number is greater than what you have chosen!");
            Console.WriteLine ("Please enter 3: If computer guessed number is equal to what you have chosen!");
            int user_response = Convert.ToInt32 (Console.ReadLine ());
            if (user_response == 1) lower = guessed_num;
            else if (user_response == 2) upper = guessed_num;
            else if (user_response == 3) {
               Console.WriteLine ("I found it " + guess_count + " guesses");
               break;
            } else Console.WriteLine ("Invalid number");
            guessed_num = (lower + upper) / 2;
         }
      }
   }
}
