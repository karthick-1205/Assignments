// Program to find the given word is palindrome or not.
Console.Write ("Enter the word or sentence: ");
string str = Console.ReadLine ()!.ToLower ().Replace (" ", "");
bool isPalindrome = true;
for (int i = 0; i < str.Length; i++) {
   if (str[i] != str[str.Length - 1 - i]) {
      isPalindrome = false;
      break;
   }
}
if (isPalindrome) Console.Write ("Palindrome");
else Console.Write ("Not a palindrome");