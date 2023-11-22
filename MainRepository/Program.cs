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
      string input = string.Join ("", mList).ToUpper ();
      string[] validWords = File.ReadAllLines (@"c:\etc\dict-5.txt");
      return validWords.Contains (input);
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
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine ($"{mBadWord} is not a word");
                        Console.ResetColor ();
                     }
                     if (lastKey.Key == ConsoleKey.Backspace) {
                        mWordle[i, 4] = mCircle;
                        mWordle[i + 1, 0] = mDot;
                        j--;
                        mList.RemoveAt (4);
                        break;
                     }
                  }
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

   /// <summary>Sets the foreground color for the alphabet</summary>
   public char SetForegroundClr (char ch) {
      if (mGreenList.Contains (ch)) Console.ForegroundColor = ConsoleColor.Green;
      else if (mBlueList.Contains (ch))
         Console.ForegroundColor = ConsoleColor.Blue;
      else Console.ForegroundColor = ConsoleColor.Gray;
      return ch;
   }

   /// <summary>Displays the current state of the board</summary>
   public void DisplayBoard (string word, bool isEntered = false) {
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.CursorVisible = false;
      Console.WriteLine ();
      Console.CursorLeft = mHalfWidth - 5;
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            if (i < mRow || isEntered) {
               if (word[j] == mWordle[i, j]) {
                  Console.ForegroundColor = ConsoleColor.Green;
                  AddList (mGreenList, i, j);
               } else if (word.Contains (mWordle[i, j])) {
                  Console.ForegroundColor = ConsoleColor.Blue;
                  AddList (mBlueList, i, j);
               } else {
                  Console.ForegroundColor = ConsoleColor.Gray;
                  AddList (mGrayList, i, j);
               }
            }
            Console.Write (mWordle[i, j] + "  ");
            Console.ResetColor ();
         }
         Console.WriteLine ();
         Console.WriteLine ();
         Console.CursorLeft = mHalfWidth - 5;
      }
      PrintAlphabet ();
   }

   /// <summary>Prints the alphabet</summary>
   public void PrintAlphabet () {
      CursorCenter ();
      Console.WriteLine (new string ('_', 25));
      Console.WriteLine ();
      CursorCenter ();
      for (int i = 0; i < 26; i++) {
         char ch = (char)('A' + i);
         Console.Write (SetForegroundClr (ch) + "   ");
         if ((ch - 64) % 7 == 0) {
            Console.SetCursorPosition (mHalfWidth - 13, Console.CursorTop + 1);
         }
      }
      Console.WriteLine ();
      Console.CursorLeft = mHalfWidth - 5;
   }

   /// <summary>Centres the cursor position</summary>
   public void CursorCenter () => Console.CursorLeft = mHalfWidth - 13;

   /// <summary>Adds each character to the list</summary>
   public void AddList (List<char> list, int i, int j) {
      if (!list.Contains (mWordle[i, j])) list.Add (mWordle[i, j]);
   }

   /// <summary>Prints the final result</summary>
   public void PrintResult (string word) {
      CursorCenter ();
      Console.WriteLine (new string ('_', 25));
      if (mGameOver) {
         CursorCenter ();
         Console.ForegroundColor = ConsoleColor.Green;
         Console.WriteLine ("Congratulations you won it!");
         Console.WriteLine ();
         CursorCenter ();
         Console.WriteLine ($"You found the word in {mCount} tries");
         Console.ResetColor ();
      } else {
         CursorCenter ();
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine ("You lost it!");
         Console.WriteLine ();
         CursorCenter ();
         Console.WriteLine ($"Today's word is {word}");
         mGameOver = true;
         Console.ResetColor ();
      }
      Console.WriteLine ();
      CursorCenter ();
      Console.WriteLine ("Press any key to quit");
      CursorCenter ();
      Console.ReadKey ();
      Console.WriteLine ();
   }

   readonly List<char> mList = new ();
   readonly List<char> mGreenList = new ();
   readonly List<char> mBlueList = new ();
   readonly List<char> mGrayList = new ();
   readonly char mCircle = '\u25cc';
   readonly char mDot = '\u00b7';
   bool mGameOver = false;
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