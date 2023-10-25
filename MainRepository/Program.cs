using System.Text;
// Reduce string
var inputString = new List<string> { "a", "bb", "aabb", "aabcbbaa", "aabbcdddc", "aacbbcdbda" };
Dictionary<string, string> dictString = new () { { "a", "a" }, { "bb", "" }, { "aabb", "" }, { "aabcbbaa", "bc" }, { "aabbcdddc", "cdc" }, { "aacbbcdbda", "ccdbda" } };
var reduceStringList = new List<string> ();
foreach (string input in inputString) Reduce (input);
foreach (var value in dictString.Values) {
   if (reduceStringList.Contains (value)) Console.WriteLine ("Both string values are equal");
   else Console.WriteLine ("Both string values are not equal");
}

void Reduce (string s) {
   StringBuilder reduceString = new ();
   for (int i = 0; i < s.Length; i++) {
      if (i == s.Length - 1 || s[i] != s[i + 1]) reduceString.Append (s[i]);
      else i++;
   }
   reduceStringList.Add (reduceString.ToString ());
}