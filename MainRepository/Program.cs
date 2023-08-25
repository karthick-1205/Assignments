// Program to find the digital root of given number.
for (; ; )
{
    Console.Write("Enter the Number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    int.TryParse(input, out int n);
    int sum = 0;
    if (n < 0) Console.WriteLine("Enter the valid input");
    else
    {
        int temp = n;
        while (temp > 0)
        {
            int rem = temp % 10;
            sum += rem;
            temp /= 10;
            if (temp == 0)
            {
                if (sum > 9)
                {
                    temp = sum;
                    sum = 0;
                }
            }
        }
        Console.WriteLine($"The digital root number of {n} is {sum}");
    }
}