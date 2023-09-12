internal class Program {
   private static void Main (string[] args) {
      try {
         if (int.TryParse (args[0], out int n) && n > 0 && n <= 25)
            Console.WriteLine ($"The {n}th armstrong number is {Armstrong (n)}");
         else Console.WriteLine ("Maximum input is 25");
      } catch { Console.WriteLine ("Provide the input"); }
   }

   static int Armstrong (int n) {
      int count = 0, maxValue = int.MaxValue;
      for (int l = 1; l <= maxValue; l++) {
         int digits, sum = 0, temp = l, rem;
         digits = l.ToString ().Length;
         while (temp > 0) {
            rem = temp % 10;
            sum += (int)Math.Pow (rem, digits);
            temp /= 10;
         }
         if (l == sum) count++;
         if (count == n) return l;
      }
      return n;
   }
}