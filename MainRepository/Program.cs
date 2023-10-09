/// <summary>This program takes a string as input and converts it into a character array A, 
/// along with a special character S and sort order O (the default order is ascending).
/// It then prints the sorted array by keeping the elements matching S to the last of the array.</summary>
while (true) {
   Console.Write ("Enter the list of character: ");
   string input = Console.ReadLine ()!.ToLower ();// .Replace (" ", "");
   if (input == "") Console.WriteLine ("Enter the valid input");
   else {
      char[] charArray = input.Where (x => char.IsLetter (x)).ToArray ();
      Console.WriteLine ("The list of characters: ");
      Console.Write ("[{0}]", string.Join (", ", charArray));
      Console.Write ("\nEnter the special character: ");
      char spChar = Convert.ToChar (Console.ReadLine ()!.ToLower ());
      Console.Write ("Is this array to be sorted ascending order type 'y' or 'n': ");
      char sortOrder = Convert.ToChar (Console.ReadLine ()!.ToLower ());
      if (sortOrder == 'y') SortCharacter (charArray, spChar);
      else SortCharacter (charArray, spChar, sortOrder);
   }
}

/// <summary>Displays a sorted character array with a special character in the last of the array.</summary>
void SortCharacter (char[] array, char spChar, char order = 'y') {
   var arr = array.Where (val => val != spChar);
   if (order == 'y') arr = arr.OrderBy (d => d);
   else arr = arr.OrderByDescending (d => d);
   var newArray = arr.Concat (Enumerable.Repeat (spChar, array.Length - arr.Count ()));
   Console.WriteLine ("[{0}]", string.Join (", ", newArray));
}