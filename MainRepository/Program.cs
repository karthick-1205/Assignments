// Program to convert the decimal number to binary and hexadecimal number.
Console.Write ("Enter the number: ");
int number, num, num1;
number = Convert.ToInt32 (Console.ReadLine ());
num = num1 = number;
List<int> binary = new ();
List<char> hexadecimal = new ();
while (number > 0) {
   int temp = number % 2;
   binary.Add (temp);
   number /= 2;
}
while (num1 > 0) {
   int temp = num1 % 16;
   if (temp < 10) {
      temp += 48;
      hexadecimal.Add ((char)temp);
   } else {
      temp += 55;
      hexadecimal.Add ((char)temp);
   }
   num1 /= 16;
}
binary.Reverse ();
hexadecimal.Reverse ();
Console.Write ($"The binary number of {num} is ");
foreach (var result in binary)
   Console.Write (result);
Console.Write ($"\nThe hexadecimal number of {num} is ");
foreach (var result in hexadecimal)
   Console.Write (result);
