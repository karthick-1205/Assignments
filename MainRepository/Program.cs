//Isogram
Console.Write ("Enter the string: ");
string input = Console.ReadLine ();
Console.WriteLine ($"The given {input} string is " + (Isogram (input) ? "isogram" : "not a isogram"));
static bool Isogram (string s) {
   HashSet<char> Unique = new ();
   foreach (char c in s) Unique.Add (c);
   return s.Length == Unique.Count;
}