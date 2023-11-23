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

   /// <summary>Centres the cursor position</summary>
   public void CenterCursor () => Console.CursorLeft = mHalfWidth - 13;

   /// <summary>Displays the current state of the board</summary>
   public void DisplayBoard (string word, bool isEntered = false) {
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.CursorVisible = false;
      Console.WriteLine ();
      Console.CursorLeft = mHalfWidth - 5;
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            char ch = mWordle[i, j];
            if (i < mRow || isEntered) {
               if (word[j] == ch) AddList (mGreenList, ch, ConsoleColor.Green);
               else if (word.Contains (ch)) AddList (mBlueList, ch, ConsoleColor.Blue);
               else AddList (mGrayList, ch, ConsoleColor.DarkGray);
            }
            Console.Write (ch + "  ");
            Console.ResetColor ();
         }
         Console.WriteLine ();
         Console.WriteLine ();
         Console.CursorLeft = mHalfWidth - 5;
      }
      PrintAlphabet ();

      /// <summary>Adds each character to the list</summary>
      static void AddList (List<char> list, char c, ConsoleColor clr) {
         Console.ForegroundColor = clr;
         if (!list.Contains (c)) list.Add (c);
      }
   }

   /// <summary>Changes the foreground color for the alphabet</summary>
   public void ForegroundClr (char ch) {
      if (mGreenList.Contains (ch)) Console.ForegroundColor = ConsoleColor.Green;
      else if (mBlueList.Contains (ch)) Console.ForegroundColor = ConsoleColor.Blue;
      else if (mGrayList.Contains (ch)) Console.ForegroundColor = ConsoleColor.DarkGray;
      else Console.ForegroundColor = ConsoleColor.Gray;
   }

   /// <summary>Prints the alphabet</summary>
   public void PrintAlphabet () {
      CenterCursor ();
      Console.WriteLine (new string ('_', 25));
      Console.WriteLine ();
      CenterCursor ();
      for (int i = 0; i < 26; i++) {
         char ch = (char)('A' + i);
         ForegroundClr (ch);
         Console.Write (ch + "   ");
         if ((ch - 64) % 7 == 0) Console.SetCursorPosition (mHalfWidth - 13, Console.CursorTop + 1);
      }
      Console.WriteLine ();
      Console.CursorLeft = mHalfWidth - 5;
   }

   /// <summary>Prints the message</summary>
   public void PrintMessage (ConsoleColor clr, string s1, string s2) {
      CenterCursor ();
      Console.ForegroundColor = clr;
      Console.WriteLine (s1);
      Console.WriteLine ();
      CenterCursor ();
      Console.WriteLine (s2);
      Console.ResetColor ();
   }

   /// <summary>Prints the final result</summary>
   public void PrintResult (string word) {
      CenterCursor ();
      Console.WriteLine (new string ('_', 25));
      if (mGameOver) {
         string msg1 = "Congratulations you won it!";
         string msg2 = $"You found the word in {mCount} tries";
         PrintMessage (ConsoleColor.Green, msg1, msg2);
      } else {
         string msg1 = "You lost it!";
         string msg2 = $"Today's word is {word}";
         PrintMessage (ConsoleColor.Yellow, msg1, msg2);
         mGameOver = true;
      }
      Console.WriteLine ();
      CenterCursor ();
      Console.WriteLine ("Press any key to quit");
      CenterCursor ();
      Console.ReadKey ();
      Console.WriteLine ();
   }

   /// <summary>Returns the random guess word</summary>
   public static string SelectWord () {
      string[] lines = File.ReadAllLines (@"c:\etc\puzzle-5.txt");
      Random random = new ();
      return lines[random.Next (lines.Length)];
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
               if (j == 4) {
                  DisplayBoard (word);
                  while (true) {
                     var lastKey = Console.ReadKey (true);
                     if (lastKey.Key == ConsoleKey.Enter && ValidWord ()) {
                        Console.WriteLine (new string (' ', Console.WindowWidth));
                        break;
                     }
                     if (lastKey.Key == ConsoleKey.Enter && !ValidWord ()) {
                        mBadWord = string.Join ("", mList).ToUpper ();
                        var cursorTop = mInvalid ? Console.CursorTop - 1 : Console.CursorTop;
                        Console.SetCursorPosition (mHalfWidth - 1, cursorTop);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine ($"{mBadWord} is not a word");
                        Console.ResetColor ();
                        mInvalid = true;
                     }
                     if (lastKey.Key == ConsoleKey.Backspace) {
                        mWordle[i, 4] = mCircle;
                        mWordle[i + 1, 0] = mDot;
                        j--;
                        mList.RemoveAt (4);
                        Console.SetCursorPosition (mHalfWidth - 1, Console.CursorTop - 1);
                        mInvalid = false;
                        Console.WriteLine (new string (' ', Console.WindowWidth));
                        break;
                     }
                  }
               } else if (key.Key is ConsoleKey.Enter && j < 4) {
                  j--;
                  continue;
               }
               if (i < 5 && j == 4) mWordle[i + 1, 0] = mCircle;
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

   /// <summary>Returns true if the given word is valid</summary>
   public bool ValidWord () {
      string input = string.Join ("", mList).ToUpper ();
      string[] validWords = File.ReadAllLines (@"c:\etc\dict-5.txt");
      return validWords.Contains (input);
   }

   readonly List<char> mList = new ();
   readonly List<char> mGreenList = new ();
   readonly List<char> mBlueList = new ();
   readonly List<char> mGrayList = new ();
   readonly char mCircle = '\u25cc';
   readonly char mDot = '\u00b7';
   bool mGameOver = false;
   bool mInvalid;
   int mRow = 0;
   int mCount = 0;
   string? mBadWord;
   readonly int mHalfWidth = Console.WindowWidth / 2;
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