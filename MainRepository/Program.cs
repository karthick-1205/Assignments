// Program to find the fibonacci series of the number
Console.Write ("Enter the Number: ");
string input = Console.ReadLine ();
int number, t1 = 0, t2 = 1, nextterm;
if (int.TryParse (input, out number) && number > 0) {
   Console.Write ($"Fibonacci series of number f({number}) is ");
   for (int i = 0; i < number; i++) {
      Console.Write ("{0} ", t1);
      nextterm = t1 + t2;
      (t1, t2) = (t2, nextterm);
   }
} else Console.WriteLine ("Enter the valid input");