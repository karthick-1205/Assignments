//Armstrong number
for (; ; )
{
    Console.Write("Enter the number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    if (int.TryParse(input, out int n) && n > 0)
    {
        bool result = ArmStrong(n);
        if (!result) Console.WriteLine($"The given {n} number is not a armstrong number");
        else Console.WriteLine($"The given {n} number is armstrong number");
    }
    else Console.WriteLine("Enter the valid input");
    static bool ArmStrong(int n)
    {
        int sum = 0, temp = n, digits = 0, temp1 = n;
        while (temp > 0)
        {
            temp /= 10;
            digits++;
        }
        while (temp1 > 0)
        {
            int rem = temp1 % 10;
            sum += (int)Math.Pow(rem, digits);
            temp1 /= 10;
        }
        if (n != sum) return false;
        return true;
    }
}