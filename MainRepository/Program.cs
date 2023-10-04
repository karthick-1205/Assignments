// Program to convert the decimal number to binary and hexadecimal number.
Console.Write ("Enter the number: ");
if (!int.TryParse (Console.ReadLine (), out int input)) { Console.WriteLine ("Enter the valid input"); return; }
int number = input;
List<int> binary = new ();
while (number > 0) {
   binary.Add (number % 2);
   number /= 2;
}
number = input;
List<char> hexadecimal = new ();
string hexValues = "0123456789ABCDEF";
while (number > 0) {
   hexadecimal.Add (hexValues[number % 16]);
   number /= 16;
}
binary.Reverse ();
hexadecimal.Reverse ();
Console.Write ($"The binary number of {input} is ");
foreach (var result in binary)
   Console.Write (result);
Console.WriteLine ();
Console.Write ($"The hexadecimal number of {input} is ");
foreach (var result in hexadecimal)
   Console.Write (result);

