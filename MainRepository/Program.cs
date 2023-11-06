// This program validates the file path
// BNF diagram of finding valid file path
// file://C:/WorkGIT/Assignments/MainRepository/Data/bnf-diagram.PNG
using static State;
var strs = new List<string> { @"C:\PROGRAMS\DATA\README.TXT", @"C:\PROGRAMS\README.TXT", @"C:\PROGRAMS\DATA\DIR\README.TXT", @"C:\README.TXT", "..", "", "C:", "C:\\PROGRAMS\\README..TXT" };
foreach (var str in strs) {
   if (IsValidFilePath (str)) {
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine ($"{str}");
      Console.ResetColor ();
      var (dir, folder, filename, ext) = Result (str);
      Console.WriteLine ($"{dir}, {folder}, {filename}, {ext}");
   } else {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine ($"{str}");
      Console.ResetColor ();
   }
}

// Extracts drive, directory, filename and extension from the given file path 
(string dir, string folder, string filename, string ext) Result (string input) {
   string drive = Path.GetPathRoot (input)!;
   drive = drive.Replace ("\\", "");
   string folders = Path.GetDirectoryName (input)!.Substring (drive.Length);
   string fileName = Path.GetFileNameWithoutExtension (input);
   string extension = Path.GetExtension (input).TrimStart ('.');
   return (drive, folders, fileName, extension);
}

// Checks if the given string is valid filepath or not
bool IsValidFilePath (string input) {
   State s = A;
   foreach (var ch in input.Trim ().ToUpper () + "~") {
      s = (s, ch) switch {
         (A, >= 'A' and <= 'Z') => B,
         (B, ':') => C,
         (C, '\\') => D,
         (D, >= 'A' and <= 'Z') => D,
         (D, '\\') => E,
         (E or F, >= 'A' and <= 'Z') => F,
         (F, '\\') => F,
         (F, '.') => G,
         (G or H, >= 'A' and <= 'Z') => H,
         (H, '~') => I,
         _ => Z,
      };
   }
   return (s == I);
}

enum State { A, B, C, D, E, F, G, H, I, Z };