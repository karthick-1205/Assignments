/// <summary>This finds all anagrams and sorts them based on anagram count</summary>
string[] words = File.ReadAllLines ("c:/etc/words.txt");
Dictionary<string, List<string>> anagrams = new ();
foreach (string word in words) {
   string sortedWord = new (word.OrderBy (c => c).ToArray ());
   if (!anagrams.TryGetValue (sortedWord, out var list)) anagrams.Add (sortedWord, list = new ());
   list.Add (word);
}
foreach (KeyValuePair<string, List<string>> result in anagrams.Where (ab => ab.Value.Count > 1).OrderByDescending (a => a.Value.Count))
   Console.WriteLine ($"{result.Value.Count,2} {string.Join (' ', result.Value)}");