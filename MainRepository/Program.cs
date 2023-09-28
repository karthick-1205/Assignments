//LONGEST ABECEDARIAN WORD
string[] arr = { "almost", "bee", "apple", "school", "in" };
List<string> list = new ();
foreach (var res in arr) {
   if (!isAbecedarian (res)) continue;
   else list.Add (res);
}
if (list.Count == 0) Console.WriteLine ("");
string longWord = list.OrderByDescending (x => x.Length).First ();
Console.WriteLine ($"The given {longWord} is Longest Abecedarian word");
static bool isAbecedarian (string s) {
   for (int i = 0; i < s.Length - 1; i++) {
      if (s[i] > s[i + 1]) return false;
   }
   return true;
}