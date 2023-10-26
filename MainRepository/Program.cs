using System.Text;
// Reduce string
Dictionary<string, string> dict = new () { { "a", "a" }, { "bb", "" }, { "aabb", "" }, { "aabcbbaa", "bc" }, { "aabbcdddc", "cdc" }, { "aacbbcdbda", "ccdbda" }, { "aabcb", "bc" } };
foreach (string input in dict.Keys) {
   var result = Reduce (input);
   if (result.Equals (dict[input])) {
      Console.WriteLine ($"The input string of '{result}'='{dict[input]}' dictionary values are equal");
   } else Console.WriteLine ($"The input string of '{result}'='{dict[input]}' dictionary values are not equal");
}

static string Reduce (string s) {
   StringBuilder reduceString = new ();
   for (int i = 0; i < s.Length; i++) {
      if (i == s.Length - 1 || s[i] != s[i + 1]) reduceString.Append (s[i]);
      else i++;
   }
   return reduceString.ToString ();
}