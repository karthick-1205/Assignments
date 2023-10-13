GetNumber ("Enter the value of a: ", out int a);
GetNumber ("Enter the value of b: ", out int b);
Console.WriteLine ($"Before Swapping a= {a}, b = {b}");
SwapNumber (a, b);

static void SwapNumber (int a, int b) {
   (a, b) = (b, a);
   Console.WriteLine ($"After Swapping a= {a}, b = {b}");
}

static void GetNumber (string message, out int number) {
   Console.Write (message);
   while (!int.TryParse (Console.ReadLine (), out number) || number < 0) {
      if (number > 0) break;
      Console.WriteLine ("Enter the valid input");
      Console.Write (message);
   }
}