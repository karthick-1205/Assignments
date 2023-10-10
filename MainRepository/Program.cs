// Print Pascal's triangle
Console.Write ("Enter no of Lines: ");
if (int.TryParse (Console.ReadLine (), out int n) && n > 0) {
   int spaces = n;
   for (int i = 0; i < n; i++) {
      for (int s = 0; s < spaces; s++)
         Console.Write (" ");
      int num = 1;
      for (int j = 0; j <= i; j++) {
         Console.Write (num + " ");
         num = num * (i - j) / (j + 1);
      }
      spaces--;
      Console.WriteLine ();
   }
} else Console.WriteLine ("Enter the valid input");
