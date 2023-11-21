/// <summary>Implementation of Worlde game</summary>
class Wordle {
   /// <summary>Public interface routine to run the game</summary>
   public void Run () {
      string secretWord = SelectWord ();
      DisplayBoard (secretWord);
      while (!mGameOver) {
         UpdateGameState (secretWord);
         PrintResult (secretWord);
      }
   }

   /// <summary>Returns the random guess word</summary>
   public static string SelectWord () {
      string[] lines = File.ReadAllLines (@"c:\etc\puzzle-5.txt");
      Random random = new ();
      return lines[random.Next (lines.Length)];
   }

   /// <summary>Returns true if the given word is valid</summary>
   public bool ValidWord () {
      string givenString = string.Join ("", mList).ToUpper ();
      string[] validWord = File.ReadAllLines (@"c:\etc\dict-5.txt");
      return validWord.Contains (givenString);
   }

   /// <summary>Update the game-state based on the key the user pressed</summary>
   public void UpdateGameState (string word) {
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (mWordle[i, j] == mCircle) {
               mRow = i;
               ConsoleKeyInfo key = Console.ReadKey (true);
               if (key.Key is ConsoleKey.Backspace or ConsoleKey.LeftArrow) {
                  if (j == 0) j--;
                  else {
                     mWordle[i, j - 1] = mCircle;
                     mWordle[i, j] = mDot;
                     j -= 2;
                     mList.RemoveAt (mList.Count - 1);
                  }
               } else if (char.ToUpper (key.KeyChar) is >= 'A' and <= 'Z') {
                  if (j < 4) mWordle[i, j + 1] = mCircle;
                  char c = Convert.ToChar (key.KeyChar);
                  mWordle[i, j] = char.ToUpper (c);
                  if (mList.Count < 5) mList.Add (c);
               }
               if (i < 5 && j == 4) mWordle[i + 1, 0] = mCircle;
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
                        mWordle[i, 4] = mCircle;
                        mWordle[i + 1, 0] = mDot;
                        j--;
                        mList.RemoveAt (4);
                        break;
                     }
                  }
               }
               DisplayBoard (word);
               if (mList.Count == 5) {
                  DisplayBoard (word, true);
                  if (mGreenList.Count == 5) {
                     mGameOver = true;
                     mCount++;
                     return;
                  }
                  if (!ValidWord ()) j--;
                  else mList.Clear ();
               }
            }
         }
         mCount++;
      }
   }

   /// <summary>Set the foreground color for the list</summary>
   public char Color (char clr) {
      if (mGreenList.Contains (clr)) Console.ForegroundColor = ConsoleColor.Green;
      else if (mYellowList.Contains (clr))
         Console.ForegroundColor = ConsoleColor.Yellow;
      else Console.ForegroundColor = ConsoleColor.Gray;
      return clr;
   }

   /// <summary>Displays the current state of the board</summary>
   public void DisplayBoard (string word, bool isEntered = false) {
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.CursorVisible = false;
      Console.WriteLine ();
      Console.CursorLeft = (Console.WindowWidth / 2) - 5;
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (i < mRow || isEntered) {
               if (word[j] == mWordle[i, j]) {
                  Console.ForegroundColor = ConsoleColor.Green;
                  if (!mGreenList.Contains (mWordle[i, j]))
                     mGreenList.Add (mWordle[i, j]);
               } else if (word.Contains (mWordle[i, j])) {
                  Console.ForegroundColor = ConsoleColor.Yellow;
                  if (!mYellowList.Contains (mWordle[i, j]))
                     mYellowList.Add (mWordle[i, j]);
               } else {
                  Console.ForegroundColor = ConsoleColor.Gray;
                  if (!mGrayList.Contains (mWordle[i, j]))
                     mGrayList.Add (mWordle[i, j]);
               }
            }
            Console.Write (mWordle[i, j] + "  ");
            Console.ResetColor ();
         }
         Console.WriteLine ();
         Console.WriteLine ();
         Console.CursorLeft = (Console.WindowWidth / 2) - 5;
      }
      PrintAlphabet ();
   }

   /// <summary>Prints the alphabet</summary>
   public void PrintAlphabet () {
      Console.CursorLeft = (Console.WindowWidth / 2) - 13;
      Console.WriteLine (new string ('_', 25));
      Console.WriteLine ();
      Console.CursorLeft = (Console.WindowWidth / 2) - 13;
      for (int i = 0; i < 26; i++) {
         char ch = (char)('A' + i);
         Console.Write (Color (ch) + "   ");
         if ((ch - 64) % 7 == 0) {
            Console.SetCursorPosition ((Console.WindowWidth / 2) - 13, Console.CursorTop + 1);
         }
      }
      Console.WriteLine ();
      Console.CursorLeft = (Console.WindowWidth / 2) - 5;
   }

   /// <summary>Prints the final result</summary>
   public void PrintResult (string word) {
      Console.CursorLeft = (Console.WindowWidth / 2) - 13;
      Console.WriteLine (new string ('_', 25));
      if (mGameOver) {
         Console.CursorLeft = (Console.WindowWidth / 2) - 13;
         Console.WriteLine ("Congratulations you won it!");
         Console.CursorLeft = (Console.WindowWidth / 2) - 13;
         Console.WriteLine ($"You found the word in {mCount} tries");
         return;
      } else {
         Console.CursorLeft = (Console.WindowWidth / 2) - 13;
         Console.WriteLine ("You lose it!");
         Console.CursorLeft = (Console.WindowWidth / 2) - 13;
         Console.WriteLine ($"Today word is {word}");
         mGameOver = true;
      }
   }

   readonly List<char> mList = new ();
   readonly List<char> mGreenList = new ();
   readonly List<char> mYellowList = new ();
   readonly List<char> mGrayList = new ();
   readonly char mCircle = '\u25cc';
   readonly char mDot = '\u00b7';
   bool mGameOver = false;
   int mRow = 0;
   int mCount = 0;
   readonly char[,] mWordle = { { '\u25cc', '\u00b7', '\u00b7', '\u00b7','\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' }};
}

class Program {
   static void Main () {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      new Wordle ().Run ();
   }
}