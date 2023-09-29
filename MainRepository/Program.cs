// Program to convert the decimal number to binary and hexadecimal number.
Console.Write ("Enter the number: ");
string input = Console.ReadLine ();
List<int> binary = new ();
List<char> hexadecimal = new ();
if (int.TryParse (input, out int number) && number > 0) {
   while (number > 0) {
      binary.Add (number % 2);
      number /= 2;
   }
   number = int.Parse (input);
   while (number > 0) {
      int temp = number % 16;
      if (temp < 10) {
         // if temp value range from 0 to 9, then we have to add 48 to convert integer value to ascii character.  
         temp += 48;
         hexadecimal.Add ((char)temp);
      } else {
         // if temp value is above 9, then we have to add 55 to convert integer value to ascii character.  
         temp += 55;
         hexadecimal.Add ((char)temp);
      }
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

