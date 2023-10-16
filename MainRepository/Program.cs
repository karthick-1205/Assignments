//Factorial program
for (; ; ) {
   Console.Write ("Enter the number: ");
   if (!int.TryParse (Console.ReadLine (), out int n) || n < 0) {
      Console.WriteLine ("Enter the valid input");
      return;
   }
   Console.WriteLine ("The factorial of {0} is {1}", n, Factorial (n));

   static int Factorial (int n) {
      if (n == 0) return 1;
      return n * Factorial (n - 1);
   }
}