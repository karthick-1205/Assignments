using System.Reflection;

//Strong password
using (var stm = Assembly.GetExecutingAssembly ().GetManifestResourceStream ("MainRepository.Data.passwords.txt"))
using (var sr = new StreamReader (stm)) {
   while (!sr.EndOfStream) {
      var result = sr.ReadLine ();
      Console.WriteLine ($"The given {result} password is " + (IsValidPassword (result) ? "Strong" : "Weak"));
      Console.WriteLine ();
   }
}

/// <summary>Returns whether the given password is strong or weak.</summary>
static bool IsValidPassword (string s) {
   string specialChar = "!@#$%^&*()-+";
   bool isUpper, isLower, isDigits, isSpecialChar, isInvalid;
   isUpper = isLower = isDigits = false;
   isSpecialChar = isInvalid = false;
   if (s.Length < 6) {
      Console.WriteLine ("Length of the password must be atleast 6.");
      return false;
   }
   foreach (char c in s) {
      if (c >= 'A' && c <= 'Z') isUpper = true;
      else if (c >= 'a' && c <= 'z') isLower = true;
      else if (c >= '0' && c <= '9') isDigits = true;
      else if (specialChar.Contains (c)) isSpecialChar = true;
      else {
         isInvalid = true;
         break;
      }
   }
   if (!isUpper) {
      Console.WriteLine ("Password must contain atleast 1 upper case letter.");
      return false;
   }
   if (!isLower) {
      Console.WriteLine ("Password must contain atleast 1 lower case letter.");
      return false;
   }
   if (!isDigits) {
      Console.WriteLine ("Password must contain atleast 1 digit.");
      return false;
   }
   if (!isSpecialChar) {
      Console.WriteLine ("Password must contain atleast 1 special case letter.");
      return false;
   }
   if (isInvalid) {
      Console.WriteLine ("Special character contains only any one of this string !@#$%^&*()-+");
      return false;
   }
   return true;
}