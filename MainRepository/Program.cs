// Implementation of string is valid file path or not into tuple format.
using static State;
var strs = new List<string> { @"C:\PROGRAMS\DATA\README.TXT", @"C:\PROGRAMS\README.TXT", @"C:\PROGRAMS\DATA\DIR\README.TXT", @"C:\README.TXT", "..", "", "C:", "C:\\PROGRAMS\\README..TXT" };
foreach (var str in strs) {
   if (ParseFile (str)) {
      Console.WriteLine ($"{str} is a Valid filepath.");
      var res = Result (str);
      Console.WriteLine ($"{res.dir}, {res.folder}, {res.filename}, {res.ext}");
   } else { Console.WriteLine ($"{str} is Not a Valid filepath."); }
}

// Convert valid filepath into tuple format
(string dir, string folder, string filename, string ext) Result (string input) {
   string[] splits = input.Split ('\\'); // C: programs data readme.txt
   string drive = splits[0];
   string folders = "";
   for (int i = 1; i < splits.Length - 1; i++) folders += splits[i] + "\\";
   splits = splits[splits.Length - 1].Split ('.'); // readme txt
   string filename = splits[0];
   string extension = splits[1];
   return (drive, folders, filename, extension);
}

// Check string is valid filepath or not
bool ParseFile (string input) {
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