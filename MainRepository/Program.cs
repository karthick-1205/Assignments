// Program to find the given number is palindrome number or not
Console.Write("Enter the number: ");
int n = Convert.ToInt32(Console.ReadLine());
int reverse = 0, temp;
temp = n;
while (temp > 0)
{
    int rem = temp % 10;
    reverse = reverse * 10 + rem;
    temp /= 10;
}
if (n == reverse)
    Console.WriteLine($"{reverse} is Palindrome number");
else
    Console.WriteLine($"{reverse} is not a Palindrome number");