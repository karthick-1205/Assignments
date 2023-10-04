// Program to find the prime number or not.
while (true) {
   Console.Write ("Enter the Number: ");
   string number = Console.ReadLine ();
   if (int.TryParse (number, out int num) && num > 0) Prime (num);
   else Console.WriteLine ("Enter the valid input");
}
static void Prime (int result) {
   bool isPrime = true;
   for (int i = 2; i < result; i++) {
      if (result % i == 0) {
         isPrime = false;
         Console.WriteLine ($"{result} is the not a prime number");
         break;
      }
   }
   if (isPrime) Console.WriteLine ($"{result} is the prime number");
}
