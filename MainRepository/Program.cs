// Program to find the given number is palindrome number or not
Console.Write ("Enter the number: ");
if (int.TryParse (Console.ReadLine (), out int n) && n >= 0) {
   int reverse = 0, temp;
   temp = n;
   while (temp > 0) {
      int rem = temp % 10;
      reverse = reverse * 10 + rem;
      temp /= 10;
   }
   if (n == reverse) Console.WriteLine ($"{reverse} is Palindrome number");
   else Console.WriteLine ($"{reverse} is not a Palindrome number");
} else Console.WriteLine ("Enter the valid input");