// Program to find the gcd and lcm of two numbers.
Console.Write("Enter the first number: ");
int n1, n2, x, y, temp, gcd, lcm;
n1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter the second number: ");
n2 = Convert.ToInt32(Console.ReadLine());
x = n1;
y = n2;
while (y > 0)
{
    temp = y;
    y = x % y;
    x = temp;
}
gcd = x;
lcm = (n1 * n2) / gcd;
Console.WriteLine("The GCD of two number is " + gcd);
Console.WriteLine("The LCM of two number is " + lcm);