// Program to print a diamond using an asterisk
Console.Write("Enter the no of rows: ");
int n = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (i + j >= n - 1) Console.Write("* ");
        else Console.Write("  ");
    }
    for (int j = 0; j < n; j++)
    {
        if (i > j) Console.Write("* ");
        else Console.Write("  ");
    }
    Console.WriteLine();
}
for (int i = 1; i < n; i++)
{
    for (int j = 0; j < n; j++)
    {
        if (i <= j) Console.Write("* ");
        else Console.Write("  ");
    }
    for (int j = 0; j < n; j++)
    {
        if (i + j < n - 1) Console.Write("* ");
        else Console.Write("  ");
    }
    Console.WriteLine();
}