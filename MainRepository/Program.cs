//Display the individual digits of given number
while (true)
{
    Console.Write("Enter the number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    if (double.TryParse(input, out double d) && d > 0)
    {
        if (input.Contains("."))
        {
            string[] split = input.Split('.');
            string integral = string.Join(" ", split[0].ToCharArray());
            string factorial = string.Join(" ", split[1].ToCharArray());
            Console.WriteLine($"Integral part:{integral} ");
            Console.WriteLine($"Factorial part:{factorial}");

        }
        else Console.WriteLine($"Integral part:{string.Join(" ", input.ToCharArray())} ");
    }
    else Console.WriteLine("Enter the valid input");
}