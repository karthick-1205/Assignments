// Program to print the multiplication table of the given number
Console.Write("Enter the Number: ");
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= 10; i++)
    Console.WriteLine($"{n} * {i} = {n * i}");