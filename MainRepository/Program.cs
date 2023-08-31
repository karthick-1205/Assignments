//Factorial program
for (; ; )
{
    Console.Write("Enter the number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    int.TryParse(input, out int n);
    if (n < 0) Console.WriteLine("Enter the valid input");
    else
    {
        Console.WriteLine("The factorial of {0} is {1}", n, factorial(n));
        static int factorial(int n)
        {
            if (n == 0) return 1;
            return n * factorial(n - 1);
        }
    }
}