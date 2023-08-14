//Program to find the prime number or not.
Console.Write("Enter the Number: ");
string number;
number = Console.ReadLine();
Prime(number);
static void Prime(string number)
{
    int result;
    if (int.TryParse(number, out result))
    {
        int divisors = 0;
        for (int i = 1; i <= result; i++)
        {
            if (result % i == 0)
                divisors++;
        }
        if (divisors == 2)
            Console.Write($"{result} is the prime number");
        else
            Console.Write($"{result} is the not a prime number");
    }
    else
    {
        Console.WriteLine("Enter the valid input");
        Console.Write("Enter the Number: ");
        number = Console.ReadLine();
        Prime(number);
    }
}