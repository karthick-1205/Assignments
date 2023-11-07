/// <summary>Implementation of Worlde game</summary>
class Wordle {
   public static void Main () {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      Wordle w = new ();
      w.Run ();
   }

   public void Run () {
      string secretWord = SelectWord ();
      DisplayBoard (secretWord);
      while (!mGameOver) UpdateGameState (secretWord);
      Console.WriteLine ($"Today word is {secretWord}");
   }

   /// <summary>Returns the random guess word</summary>
   public static string SelectWord () {
      string[] lines = File.ReadAllLines (@"c:\etc\puzzle-5.txt");
      Random random = new ();
      return lines[random.Next (lines.Length)];
   }

   /// <summary>Returns true if the given word is valid</summary>
   public bool ValidWord () {
      string givenString = string.Join ("", list).ToUpper ();
      string[] validWord = File.ReadAllLines (@"c:\etc\dict-5.txt");
      return validWord.Contains (givenString);
   }

   /// <summary>Update the game-state based on the key the user pressed</summary>
   public void UpdateGameState (string word) {
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (mList[i, j] == mCircle) {
               mRow = i;
               ConsoleKeyInfo key = Console.ReadKey (true);
               if ((key.Key is ConsoleKey.Backspace or ConsoleKey.LeftArrow)) {
                  if (j == 0) j--;
                  else {
                     mList[i, j - 1] = mCircle;
                     mList[i, j] = mDot;
                     j -= 2;
                     list.RemoveAt (list.Count - 1);
                  }
               } else if (char.ToUpper (key.KeyChar) is >= 'A' and <= 'Z') {
                  if (j < 4) mList[i, j + 1] = mCircle;
                  char c = Convert.ToChar (key.KeyChar);
                  mList[i, j] = char.ToUpper (c);
                  if (list.Count < 5) list.Add (c);
               }
               if (i < 5 && j == 4) mList[i + 1, 0] = mCircle;
               if (j == 4) {
                  DisplayBoard (word);
                  while (true) {
                     var lkey = Console.ReadKey (true);
                     if (lkey.Key == ConsoleKey.Enter && ValidWord ()) {
                        Console.WriteLine (new string (' ', Console.WindowWidth));
                        break;
                     }
                     if (lkey.Key == ConsoleKey.Enter && !ValidWord ()) Console.WriteLine ("Not a valid word");
                     if (lkey.Key == ConsoleKey.Backspace) {
                        mList[i, 4] = mCircle;
                        mList[i + 1, 0] = mDot;
                        j--;
                        list.RemoveAt (4);
                        break;
                     }
                  }
               }
               DisplayBoard (word);
               if (list.Count == 5) {
                  if (!ValidWord ()) j--;
                  else list.Clear ();
               }
            }
         }
      }
      mGameOver = true;
   }

   /// <summary>Set the foreground color for the list</summary>
   public char Color (char clr) {
      if (greenList.Contains (clr)) Console.ForegroundColor = ConsoleColor.Green;
      else if (yellowList.Contains (clr)) Console.ForegroundColor = ConsoleColor.Yellow;
      else Console.ForegroundColor = ConsoleColor.Gray;
      return clr;
   }

   /// <summary>Displays the current state of the board</summary>
   public void DisplayBoard (string word) {
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.CursorVisible = false;
      Console.CursorLeft = (Console.WindowWidth / 2) - 5;
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (i < mRow) {
               if (word[j] == mList[i, j]) {
                  Console.ForegroundColor = ConsoleColor.Green;
                  greenList.Add (mList[i, j]);
               } else if (word.Contains (mList[i, j])) {
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  yellowList.Add (mList[i, j]);
               } else {
                  Console.ForegroundColor = ConsoleColor.Gray;
                  grayList.Add (mList[i, j]);
               }
            }
            Console.Write (mList[i, j] + " ");
            Console.ResetColor ();
         }
         Console.WriteLine ();
         Console.CursorLeft = (Console.WindowWidth / 2) - 5;
      }
      Console.CursorLeft -= 2;
      Console.WriteLine (new string ('_', 13));
      Console.CursorLeft = (Console.WindowWidth / 2) - 7;
      foreach (char c in mAlpha) {
         Console.Write (Color (c) + " ");
         if ((c - 64) % 7 == 0) {
            Console.SetCursorPosition ((Console.WindowWidth / 2) - 7, Console.CursorTop + 1);
         }
      }
      Console.WriteLine ();
      Console.CursorLeft = (Console.WindowWidth / 2) - 5;
   }

   readonly List<char> list = new ();
   readonly List<char> greenList = new ();
   readonly List<char> yellowList = new ();
   readonly List<char> grayList = new ();
   readonly char mCircle = '\u25cc';
   readonly char mDot = '\u00b7';
   bool mGameOver = false;
   int mRow = 0;
   readonly char[,] mList = { { '\u25cc', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' }};
   readonly char[] mAlpha = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J'
                              ,'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S'
                              , 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
}