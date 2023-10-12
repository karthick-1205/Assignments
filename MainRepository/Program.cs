// Program to find the gcd and lcm of two numbers.
int n1 = GetNumber ("Enter the first number: ");
int n2 = GetNumber ("Enter the second number: ");
int x = n1, y = n2;
while (y > 0) {
   int temp = y;
   y = x % y;
   x = temp;
}
int gcd = x;
int lcm = (n1 * n2) / gcd;
Console.WriteLine ($"The GCD of two number is {gcd}");
Console.WriteLine ($"The LCM of two number is {lcm}");

static int GetNumber (string message) {
   Console.Write (message);
   string response = Console.ReadLine ();
   int number;
   while (!int.TryParse (response, out number) || number <= 0) {
      if (number < 0) Console.WriteLine ("Enter the valid input");
      Console.Write (message);
      response = Console.ReadLine ();
   }
   return number;
}