// Program to find the digital root of given number.
int sum = 0, temp;
for (; ; ) {
   Console.Write ("Enter the Number: ");
   if (!int.TryParse (Console.ReadLine (), out int n) || n < 0) {
      Console.WriteLine ("Enter the valid input");
      return;
   }
   temp = n;
   while (temp > 0) {
      int rem = temp % 10;
      sum += rem;
      temp /= 10;
      if (temp == 0 && sum > 9) {
         temp = sum;
         sum = 0;
      }
   }
   Console.WriteLine ($"The digital root number of {n} is {sum}");
}