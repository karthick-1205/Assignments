// Program to find the fibonacci series of the number
Console.Write ("Enter the Number: ");
int number, t1 = 0, t2 = 1, nextterm;
number = Convert.ToInt32 (Console.ReadLine ());
Console.Write ($"Fibonacci series of number f({number}) is ");
for (int i = 0; i < number; i++) {
   Console.Write ("{0} ", t1);
   nextterm = t1 + t2;
   (t1, t2) = (t2, nextterm);
}