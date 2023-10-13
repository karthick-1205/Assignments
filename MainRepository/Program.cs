// Implementation of Anagram
class Anagram {

   public static void Main (string[] args) {
      Anagram a = new Anagram ();
      a.test ();
   }

   // Function to find given two strings are anagram or not
   bool IsAnagram (string str1, string str2) {
      if (str1.Length != str2.Length) return false;
      if (str1 == str2) return true;
      Dictionary<char, int> word = new Dictionary<char, int> ();
      foreach (char element in str1.ToCharArray ()) {
         if (word.ContainsKey (element)) word[element]++;
         else word.Add (element, 1);
      }
      foreach (char element in str2.ToCharArray ()) {
         if (!word.ContainsKey (element)) return false;
         if (--word[element] == 0) word.Remove (element);
      }
      return word.Count == 0;
   }

   public void test () {
      for (int i = 0; i < words.Length; i++) {
         if (words[i].StartsWith (";")) continue;
         temp.Add (words[i], new () { words[i] });
         for (int j = i + 1; j < words.Length; j++) {
            if (IsAnagram (words[i], words[j])) {
               if (temp.ContainsKey (words[i])) {
                  temp[words[i]].Add (words[j]);
                  words[j] = ";" + words[j];
               }
            }
         }
      }

      foreach (KeyValuePair<string, List<string>> result in temp.Where (ab => ab.Value.Count > 1).OrderByDescending (a => a.Value.Count))
         Console.WriteLine ($"{result.Value.Count,2} {string.Join (' ', result.Value)}");
   }
   string[] words = File.ReadAllLines ("c:/etc/words.txt");
   Dictionary<string, List<string>> temp = new Dictionary<string, List<string>> ();
}