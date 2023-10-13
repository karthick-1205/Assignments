//Program to find the frequency of alphabets in a dictionary.
namespace Test2 {
   class LetterFrequency {
      public static void Main (string[] args) {
         string[] words = File.ReadAllLines ("c:/etc/words.txt");
         List<char> Letters = new List<char> ();
         List<int> Count = new List<int> ();
         Dictionary<char, int> Occurence = new Dictionary<char, int> ();
         for (char c = 'A'; c <= 'Z'; c++) Letters.Add (c);
         foreach (char alphabets in Letters) {
            int count = 0;
            for (int i = 0; i < words.Length; i++) {
               if (words[i].Contains (alphabets)) count++;
            }
            Count.Add (count);
            Occurence.Add (alphabets, count);
         }
         var result1 = from result in Occurence orderby result.Value descending select result;
         foreach (KeyValuePair<char, int> ele1 in result1) Console.WriteLine ("{0} is {1}", ele1.Key, ele1.Value);
         Console.WriteLine ();
         List<char> keys = new List<char> ();
         foreach (KeyValuePair<char, int> ele2 in result1) keys.Add (ele2.Key);
         Console.Write ("The top 7 frequent letters are: ");
         for (int i = 0; i < 7; i++) Console.Write ("{0} ", keys[i]);
         Console.WriteLine ();
      }
   }
}