using System.Reflection;

//Strong password
using (var stm = Assembly.GetExecutingAssembly ().GetManifestResourceStream ("MainRepository.Data.passwords.txt"))
using (var sr = new StreamReader (stm)) {
   while (!sr.EndOfStream) {
      var result = sr.ReadLine ();
      Console.WriteLine ($"The given {result} password is " + (isValidPassword (result) ? "Strong" : "Weak"));
      Console.WriteLine ();
   }
}

static bool isValidPassword (string s) {
   string specialChar = "!@#$%^&*()-+";
   if (s.Length < 6) {
      Console.WriteLine ("Length of the password must be atleast 6.");
      return false;
   }
   if (!s.Any (char.IsUpper)) {
      Console.WriteLine ("Password must contain atleast 1 upper case letter.");
      return false;
   }
   if (!s.Any (char.IsLower)) {
      Console.WriteLine ("Password must contain atleast 1 lower case letter.");
      return false;
   }
   if (!s.Any (char.IsDigit)) {
      Console.WriteLine ("Password must contain atleast 1 digit.");
      return false;
   }
   if (!s.Any (specialChar.Contains)) {
      Console.WriteLine ("Password must contain atleast 1 special case letter.");
      return false;
   }
   if (s.Any (c => !char.IsLetterOrDigit (c) && !specialChar.Contains (c))) {
      Console.WriteLine ("Special character contains only any one of this string !@#$%^&*()-+");
      return false;
   }
   return true;
}