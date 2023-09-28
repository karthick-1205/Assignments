// Program to find the given word is palindrome or not.
Console.Write ("Enter the word or sentence: ");
string str = Console.ReadLine ().ToLower ().Replace (" ", "");
string rev = "";
for (int i = str.Length - 1; i >= 0; i--)
   rev += str[i];
if (rev == str)
   Console.Write ("Palindrome");
else
   Console.Write ("Not a palindrome");