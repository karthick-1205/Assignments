//String permutation
Console.Write ("Enter the string: ");
string str = Console.ReadLine ();
HashSet<string> result = GetPermutations (str);
Console.WriteLine ($"Permutation of {str} are " + string.Join (" ", result));
static HashSet<string> GetPermutations (string str) {
   HashSet<string> permutations = new ();
   if (str.Length == 0) {
      permutations.Add ("");
      return permutations;
   }
   char first = str[0];
   string sub = str.Substring (1);
   HashSet<string> words = GetPermutations (sub);
   foreach (string word in words) {
      for (int i = 0; i <= word.Length; i++)
         permutations.Add (word.Substring (0, i) + first + word.Substring (i));
   }
   return permutations;
}