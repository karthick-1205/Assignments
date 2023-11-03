// Spell Bee Program
var words = File.ReadAllLines ("c:/etc/words.txt");
char[] seed = { 'U', 'X', 'L', 'T', 'A', 'E', 'N' };
List<string> valid = new ();
foreach (var word in words)
   if (IsValid (word)) valid.Add (word);
for (int i = 0; i < valid.Count - 1; i++) {
   for (int j = i + 1; j < valid.Count; j++) {
      if (!InOrder (valid[i], valid[j])) (valid[j], valid[i]) = (valid[i], valid[j]);
   }
}
int total = 0;
foreach (var w in valid) {
   if (IsPangram (w)) Console.ForegroundColor = ConsoleColor.Green;
   int score = GetScore (w);
   Console.WriteLine ($"{score,3}. {w}");
   Console.ResetColor ();
   total += score;
}
Console.WriteLine ($"----\n{total,3} total");

// Checking the given string is valid or not
bool IsValid (string word) {
   if ((word.Length >= 4) && (word.Contains (seed[0])) && (word.All (seed.Contains))) return true;
   return false;
}

// Checking the given string is pangram or not
bool IsPangram (string word) {
   return seed.All (word.Contains);
}

// Compute the score of given string
int GetScore (string word) {
   if (word.Length <= 4) return 1;
   if (IsPangram (word)) return word.Length + 7;
   return word.Length;
}

// Comparing the score of given string
bool InOrder (string a, string b) {
   int sa = GetScore (a), sb = GetScore (b);
   if (sa != sb) return sa > sb;
   return a.CompareTo (b) < 0;
}
