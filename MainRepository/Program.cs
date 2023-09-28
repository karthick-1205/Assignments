// Reduce string
Console.Write ("Enter the string: ");
string s = Console.ReadLine ();
bool reduced;
do {
   reduced = false;
   for (int i = 0; i < s.Length - 1; i++) {
      if (s[i] == s[i + 1]) {
         s = s.Substring (0, i) + s.Substring (i + 2);
         reduced = true;
      }
   }
} while (reduced);
if (s.Length == 0)
   Console.WriteLine ("Empty String");
else
   Console.WriteLine ($"The reduced string is {s}");