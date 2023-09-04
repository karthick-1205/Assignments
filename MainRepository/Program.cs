//Display the individual digits of given number
for (; ; )
{
    Console.Write("Enter the number or press [e] to exit: ");
    string input = Console.ReadLine();
    if (input.ToLower() == "e") break;
    if (double.TryParse(input, out double n) && n > 0)
    {
        if (input.Contains("."))
        {
            string[] result = input.Split('.');
            char[] int_part_array = result[0].ToCharArray();
            char[] fract_part_array = result[1].ToCharArray();
            string resultString = String.Join(" ", int_part_array);
            string resultString1 = String.Join(" ", fract_part_array);
            if (resultString.Length > 0 && resultString1.Length == 0) Console.Write($"Integral part:{resultString}\n");
            if (resultString1.Length > 0 && resultString.Length == 0) Console.Write($"Factorial part:{resultString1}\n");
            if (resultString.Length > 0 && resultString1.Length > 0)
            {
                Console.Write($"Integral part:{resultString} ");
                Console.WriteLine($"Factorial part:{resultString1}");
            }


        }
        else Console.WriteLine("Enter the valid input");
    }
    else Console.WriteLine("Enter the valid input");
}