﻿//Armstrong number
for (; ; )
{
    Console.Write("Enter the number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    if (int.TryParse(input, out int n) && n > 0)
    {
        bool result = Armstrong(n);
        if (result) Console.WriteLine($"The given {n} number is armstrong number");
        else Console.WriteLine($"The given {n} number is not a armstrong number");
    }
    else Console.WriteLine("Enter the valid input");

    static bool Armstrong(int n)
    {
        int sum = 0, temp = n;
        int digits = n.ToString().Length;
        while (temp > 0)
        {
            int rem = temp % 10;
            sum += (int)Math.Pow(rem, digits);
            temp /= 10;
        }
        if (n != sum) return false;
        return true;
    }
}