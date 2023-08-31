Console.Write("Enter the value of a: ");
int a = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the value of b: ");
int b = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Before Swapping a= {a}, b = {b}");
swapNumber(a, b);
static void swapNumber(int a, int b)
{
    int temp = a;
    a = b;
    b = temp;
    Console.WriteLine($"After Swapping a= {a}, b = {b}");
}