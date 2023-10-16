//Isogram
Console.Write ("Enter the string: ");
string input = Console.ReadLine ();
if (!input.Any (char.IsLetter)) {
   Console.WriteLine ("Enter the valid input");
   return;
}
Console.WriteLine ($"The given {input} string is " + (Isogram (input) ? "isogram" : "not a isogram"));
static bool Isogram (string s) {
   HashSet<char> unique = new ();
   foreach (char c in s) unique.Add (c);
   return s.Length == unique.Count;
}