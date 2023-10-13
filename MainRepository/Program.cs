// Program to find the gcd and lcm of two numbers.
GetNumber ("Enter the first number: ", out int n1);
GetNumber ("Enter the second number: ", out int n2);
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

static void GetNumber (string message, out int number) {
   Console.Write (message);
   while (!int.TryParse (Console.ReadLine (), out number) || number <= 0) {
      if (number > 0) break;
      Console.WriteLine ("Enter the valid input");
      Console.Write (message);
   }
}