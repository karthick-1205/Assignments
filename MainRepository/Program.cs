using System.Text;
// Reduce string
Console.Write ("Enter the string: ");
string s = Console.ReadLine ();
StringBuilder reduceString = new StringBuilder ();
for (int i = 0; i < s.Length; i++) {
   if (i == s.Length - 1 || s[i] != s[i + 1]) reduceString.Append (s[i]);
   else i++;
}
if (reduceString.Length == 0)
   Console.WriteLine ("Empty String");
else
   Console.WriteLine ($"The reduced string is {reduceString}");