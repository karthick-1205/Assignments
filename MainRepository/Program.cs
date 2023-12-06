using static State;
var testValues = new List<string> { "12", "1", "12.55667", "12.5", "..", ".3", "-12.0", "-4", "1e13", "3.4e+4", "3.15e-3", "abc", " 23.67 " , ".00341" ,"e+5",
  "89g2", "+-56", "21.+2", ".e08", "2E3", "1E+3"};

foreach (var val in testValues) {
   double.TryParse (val, out double value);
   double parseValue = DoubleParse (val);
   if (value == parseValue) PrintColor (val, value, parseValue, ConsoleColor.Green);
   else PrintColor (val, value, parseValue, ConsoleColor.Red);
}

/// <summary>Parses the given string into double value</summary>
static double DoubleParse (string input) {
   State s = A;
   foreach (char c in input.Trim () + '~') {
      s = (s, c) switch {
         (A, '+') => B,
         (A, '-') => B,
         (A or B or C, >= '0' and <= '9') => C,
         (C, '.') => D,
         (D or E, >= '0' and <= '9') => E,
         (C or E, 'e' or 'E') => F,
         (F, '+') => G,
         (F, '-') => G,
         (F or G or H, >= '0' and <= '9') => H,
         (C or E or H, '~') => I,
         _ => Z,
      };
   }
   if (s == I) return double.Parse (input);
   return double.NaN;
}

/// <summary>Prints color of the given string and value</summary>
static void PrintColor (string s, double d1, double d2, ConsoleColor clr) {
   Console.ForegroundColor = clr;
   Console.WriteLine ($"Actual Parse of the given string {s} : {d1}");
   Console.WriteLine ($"Custom Parse of the given string {s} : {d2}\n");
   Console.ResetColor ();
}

enum State { A, B, C, D, E, F, G, H, I, Z };