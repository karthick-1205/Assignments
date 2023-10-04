// Program to find the given word is palindrome or not.
Console.Write ("Enter the word or sentence: ");
string str = Console.ReadLine ().ToLower ().Replace (" ", "");
string rev = new (str.Reverse ().ToArray ());
if (rev == str)
   Console.Write ("Palindrome");
else
   Console.Write ("Not a palindrome");