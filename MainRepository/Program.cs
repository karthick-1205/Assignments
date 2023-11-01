// Program to find the frequency of alphabets in a dictionary.
namespace Training {
   class LetterFrequency {
      public static void Main () {
         string[] words = File.ReadAllLines ("c:/etc/words.txt");
         Dictionary<char, int> dict = new ();
         foreach (string word in words) {
            foreach (char ch in word) {
               dict[ch] = dict.TryGetValue (ch, out int value) ? value + 1 : 1;
            }
         }
         var result = dict.OrderByDescending (x => x.Value).Take (7);
         foreach (KeyValuePair<char, int> kv in result) {
            Console.WriteLine ("{0} is {1}", kv.Key, kv.Value);
         }
      }
   }
}