// Program to convert the decimal number to binary and hexadecimal number.
Console.Write ("Enter the number: ");
string input = Console.ReadLine ();
List<int> binary = new ();
List<char> hexadecimal = new ();
List<char> hexValues = new () { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
if (int.TryParse (input, out int number) && number > 0) {
   while (number > 0) {
      binary.Add (number % 2);
      number /= 2;
   }
   number = int.Parse (input);
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
} else Console.WriteLine ("Enter the valid input");

