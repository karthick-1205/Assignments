// Program to print the multiplication table of the given number
Console.Write ("Enter the Number: ");
if (int.TryParse (Console.ReadLine (), out int n) && n > 0) {
   for (int i = 1; i <= 10; i++)
      Console.WriteLine ($"{n} * {i,2} = {n * i}");
} else Console.WriteLine ("Enter the valid input");