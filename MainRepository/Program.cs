/// <summary>Implementation of Anagram</summary>
class Anagram {
   public static void Main () {
      Anagram a = new ();
      a.FindAnagrams ();
   }

   /// <summary>This finds all anagrams and sorts them based on anagram count</summary>
   public void FindAnagrams () {
      foreach (string word in mWords) {
         string sortedWord = new (word.OrderBy (c => c).ToArray ());
         if (!mAnagrams.ContainsKey (sortedWord)) mAnagrams[sortedWord] = new List<string> ();
         mAnagrams[sortedWord].Add (word);
      }
      foreach (KeyValuePair<string, List<string>> result in mAnagrams.Where (ab => ab.Value.Count > 1).OrderByDescending (a => a.Value.Count))
         Console.WriteLine ($"{result.Value.Count,2} {string.Join (' ', result.Value)}");
   }

   string[] mWords = File.ReadAllLines ("c:/etc/words.txt");
   Dictionary<string, List<string>> mAnagrams = new ();
}