// Program to print a diamond using an asterisk
Console.Write ("Enter the no of rows: ");
if (!int.TryParse (Console.ReadLine (), out int n) || n < 0) {
   Console.WriteLine ("Enter the valid input");
   return;
} else {
   for (int i = 0; i < n; i++) {
      for (int j = 0; j < n; j++) {
         if (i + j >= n - 1) Console.Write ("* ");
         else Console.Write ("  ");
      }
      for (int j = 0; j < n; j++) {
         if (i > j) Console.Write ("* ");
         else Console.Write ("  ");
      }
      Console.WriteLine ();
   }
   for (int i = 1; i < n; i++) {
      for (int j = 0; j < n; j++) {
         if (i <= j) Console.Write ("* ");
         else Console.Write ("  ");
      }
      for (int j = 0; j < n; j++) {
         if (i + j < n - 1) Console.Write ("* ");
         else Console.Write ("  ");
      }
      Console.WriteLine ();
   }
}
