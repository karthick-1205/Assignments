// Print Pascal's triangle
Console.Write ("Enter no of Lines: ");
int n = Convert.ToInt32 (Console.ReadLine ());
int spaces = n;
for (int i = 0; i < n; i++) {
   for (int s = 1; s <= spaces; s++)
      Console.Write (" ");
   int num = 1;
   for (int j = 0; j <= i; j++) {
      Console.Write (num + " ");
      num = num * (i - j) / (j + 1);
   }
   spaces--;
   Console.WriteLine ();
}