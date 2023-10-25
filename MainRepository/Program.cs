while (true) {
   Console.Write ("Enter the number or press [e] to exit: ");
   string input = Console.ReadLine ();
   if (input.ToLower () == "e") break;
   if (int.TryParse (input, out int num) && num > 0 && num <= 3999) {
      Console.Write ("Is this number to be output in the 'r' for Roman or 'w' for Word format?");
      char outputFormat = Convert.ToChar (Console.ReadLine ().ToLower ());
      if (outputFormat == 'r') Console.WriteLine (NumberToRoman (num));
      else if (outputFormat == 'w') NumberToWord (num);
      else Console.WriteLine ("Enter the valid output format");
   } else if (num > 3999) Console.WriteLine ("Maximum limit is 3999");
   else Console.WriteLine ("Enter the number greater than zero");
}

static string NumberToRoman (int n) {
   string[] thousands = { "", "M", "MM", "MMM" };
   string[] hundreds = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
   string[] tens = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
   string[] units = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
   return thousands[n / 1000] + hundreds[n % 1000 / 100] + tens[n % 100 / 10] + units[n % 10];
}

static void NumberToWord (int n) {
   int one = n % 10;
   int ten = n % 100 / 10;
   int hundred = n % 1000 / 100;
   int thousand = n / 1000;
   string[] units = {"","One","Two","Three","Four","Five","Six","Seven","Eight","Nine","Ten",
                     "Eleven","Twelve","Thirteen","Fourteen","Fifteen","Sixteen","Seventeen","Eighteen","Nineteen"};
   string[] tens = { "", "Ten", "Twenty", "Thirty", "Fourty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
   string h = "Hundred";
   string th = "Thousand";
   if (n < 20) Console.WriteLine (units[n]);
   else if (n >= 20 && n < 100) Console.WriteLine (tens[ten] + " " + units[one]);
   else if (n >= 100 && n < 999) {
      if (ten == 1)
         Console.WriteLine (units[hundred] + " " + h + " " + units[10 + one]);
      else
         Console.WriteLine (units[hundred] + " " + h + " " + tens[ten] + " " + units[one]);
   } else {
      if (ten == 1)
         Console.WriteLine (units[thousand] + " " + th + " " + units[hundred] + " " + h + " " + units[10 + one]);
      else
         Console.WriteLine (units[thousand] + " " + th + " " + units[hundred] + " " + h + " " + tens[ten] + " " + units[one]);
   }
}

