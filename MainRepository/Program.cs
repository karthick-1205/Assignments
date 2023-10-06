// Sort and Swap characters
while (true) {
   Console.Write ("Enter the list of character: ");
   string input = Console.ReadLine ()!.ToLower ().Replace (" ", "");
   if (input == "") Console.WriteLine ("Enter the valid input");
   else {
      char[] charArray = input.Where (x => char.IsLetter (x)).Select (x => x).ToArray ();
      Console.WriteLine ("The list of characters: ");
      Console.Write ("[{0}]", string.Join (", ", charArray));
      Console.Write ("\nEnter the special character: ");
      char spChar = Convert.ToChar (Console.ReadLine ()!.ToLower ());
      Console.Write ("Is this array to be sorted ascending order type 'y' or 'n': ");
      char sortOrder = Convert.ToChar (Console.ReadLine ()!.ToLower ());
      SortCharacter (charArray, spChar, sortOrder);
   }
}

/// <summary> Displays a sorted character array with a special character in the last of the array. </summary>
void SortCharacter (char[] array, char c, char order) {
   var temp = array.Where (val => val == c).ToArray ();
   array = array.Where (val => val != c).ToArray ();
   if (order == 'y') array = array.OrderBy (d => d).ToArray ();
   else array = array.OrderByDescending (d => d).ToArray ();
   var newArray = array.Concat (temp);
   Console.WriteLine ("[{0}]", string.Join (", ", newArray));
}