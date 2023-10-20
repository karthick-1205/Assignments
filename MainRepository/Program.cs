using System.Text;
// Reduce string
var inputString = new List<string> { "a", "bb", "aabb", "aabcbbaa", "aabbcdddc", "aacbbcdbda" };
foreach (string input in inputString) Reduce (input);

static void Reduce (string s) {
   StringBuilder reduceString = new ();
   for (int i = 0; i < s.Length; i++) {
      if (i == s.Length - 1 || s[i] != s[i + 1]) reduceString.Append (s[i]);
      else i++;
   }
   if (reduceString.Length == 0)
      Console.WriteLine ("Empty String");
   else
      Console.WriteLine ($"The reduced string is {reduceString}");
}