#region class Wordle---------------------------------------------------------------------
/// <summary>Implementation of Wordle game</summary>
class Wordle {
   /// <summary>Public interface routine to run the game</summary>
   public void Run () {
      DisplayBoard ();
      while (!mGameOver) {
         ConsoleKeyInfo key = Console.ReadKey (true);
         UpdateGameState (key);
         DisplayBoard ();
      }
      PrintResult ();
   }

   #region Methods ------------------------------------------------
   /// <summary>Centers the cursor position</summary>
   void CenterCursor () => Console.CursorLeft = mHalfWidth - 13;

   /// <summary>Displays the current state of the board</summary>
   void DisplayBoard () {
      Console.CursorLeft = 0;
      Console.CursorTop = 0;
      Console.CursorVisible = false;
      Console.WriteLine ();
      Console.CursorLeft = mHalfWidth - 7;
      for (int i = 0; i < 6; i++) {
         for (int j = 0; j < 5; j++) {
            char ch = mWordle[i, j];
            if (i < mCount || mIsEnterPressed) {
               if (mSecretWord[j] == ch) AddList (mGreenList, ch, ConsoleColor.Green);
               else if (mSecretWord.Contains (ch)) AddList (mBlueList, ch, ConsoleColor.Blue);
               else if (!mSecretWord.Contains (ch) && char.IsLetter (ch)) AddList (mGrayList, ch, ConsoleColor.DarkGray);
               else AddList (mWhiteList, ch, ConsoleColor.White);
            }
            Console.Write (ch + "  ");
            Console.ResetColor ();
         }
         Console.WriteLine ();
         Console.WriteLine ();
         Console.CursorLeft = mHalfWidth - 7;
      }
      mIsEnterPressed = false;
      PrintAlphabet ();
      if (mGreenList.Count == 5) {
         mGameOver = true;
         mFoundWord = true;
      }
      mGreenList.Clear ();
      mBlueList.Clear ();
      mGrayList.Clear ();

      /// <summary>Adds each character to the list</summary>
      static void AddList (List<char> list, char c, ConsoleColor clr) {
         Console.ForegroundColor = clr;
         if (!list.Contains (c)) list.Add (c);
      }
   }

   /// <summary>Changes the foreground color for the alphabet</summary>
   void ForegroundClr (char ch) {
      if (mGreenList.Contains (ch)) Console.ForegroundColor = ConsoleColor.Green;
      else if (mBlueList.Contains (ch)) Console.ForegroundColor = ConsoleColor.Blue;
      else if (mGrayList.Contains (ch)) Console.ForegroundColor = ConsoleColor.DarkGray;
      else Console.ForegroundColor = ConsoleColor.Gray;
   }

   /// <summary>Prints the alphabet</summary>
   void PrintAlphabet () {
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

   /// <summary>Prints the error message</summary>
   void PrintErrorMessage (string msg) {
      mBadWord = string.Join ("", mList).ToUpper ();
      Console.SetCursorPosition (mHalfWidth - 1, Console.CursorTop);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine ($"{mBadWord} {msg}");
      Console.ResetColor ();
   }

   /// <summary>Prints the message</summary>
   void PrintMessage (ConsoleColor clr, string s1, string s2) {
      CenterCursor ();
      Console.ForegroundColor = clr;
      Console.WriteLine (s1);
      Console.WriteLine ();
      CenterCursor ();
      Console.WriteLine (s2);
      Console.ResetColor ();
   }

   /// <summary>Prints the final result</summary>
   void PrintResult () {
      CenterCursor ();
      Console.WriteLine (new string ('_', 25));
      if (mGameOver && mFoundWord) {
         string msg1 = "Congratulations you won it!";
         string msg2 = $"You found the word in {mCount} tries";
         PrintMessage (ConsoleColor.Green, msg1, msg2);
      } else {
         string msg1 = "You lost it!";
         string msg2 = $"Today's word is {mSecretWord}";
         PrintMessage (ConsoleColor.Yellow, msg1, msg2);
      }
      Console.WriteLine ();
      CenterCursor ();
      Console.WriteLine ("Press any key to quit");
      CenterCursor ();
      Console.ReadKey ();
      Console.WriteLine ();
   }

   /// <summary>Returns the random guess word</summary>
   static string SelectWord () {
      string[] lines = File.ReadAllLines (@"c:\etc\puzzle-5.txt");
      Random random = new ();
      return lines[random.Next (lines.Length)];
   }

   /// <summary>Update the game-state based on the key the user pressed</summary>
   void UpdateGameState (ConsoleKeyInfo key) {
      if (key.Key == ConsoleKey.Enter && mList.Count == 5) {
         if (ValidWord ()) {
            mGameOver = mRow == 5 && mCol == 5;
            mRow++; mCol = 0;
            mList.Clear ();
            if (mRow <= 5) mWordle[mRow, mCol] = mCircle;
            mIsEnterPressed = true;
            mCount++;
            Console.WriteLine (new string (' ', Console.WindowWidth));
         } else PrintErrorMessage ("is not a word");
      } else if (key.Key is ConsoleKey.Backspace or ConsoleKey.LeftArrow && mCol >= 0) {
         if (mCol > 0) {
            mList.RemoveAt (mCol - 1);
            if (mCol != 5) mWordle[mRow, mCol] = mDot;
            mCol--;
            mWordle[mRow, mCol] = mCircle;
            Console.WriteLine (new string (' ', Console.WindowWidth));
         }
      } else if (char.IsLetter (key.KeyChar)) {
         if (mCol <= 4) {
            char c = char.ToUpper (key.KeyChar);
            mList.Add (c);
            mWordle[mRow, mCol++] = c;
            if (mCol < 5) mWordle[mRow, mCol] = mCircle;
         }
      }
   }

   /// <summary>Returns true if the given word is valid</summary>
   bool ValidWord () {
      string input = string.Join ("", mList).ToUpper ();
      return mWords.Contains (input);
   }
   #endregion

   #region Private data ------------------------------------------
   readonly List<char> mList = new ();
   readonly List<char> mGreenList = new ();
   readonly List<char> mBlueList = new ();
   readonly List<char> mGrayList = new ();
   readonly List<char> mWhiteList = new ();
   static readonly char mCircle = '\u25cc';
   static readonly char mDot = '\u00b7';
   bool mGameOver = false;
   bool mFoundWord = false;
   int mRow, mCol;
   int mCount = 0;
   string? mBadWord;
   readonly string mSecretWord = SelectWord ();
   readonly int mHalfWidth = Console.WindowWidth / 2;
   static bool mIsEnterPressed = false;
   static readonly string[] mWords = File.ReadAllLines ("C:/etc/dict-5.txt");
   static readonly char[,] mWordle = { { mCircle, mDot, mDot, mDot,mDot },
                       { mDot, mDot, mDot, mDot, mDot },
                       { mDot, mDot, mDot, mDot, mDot },
                       { mDot, mDot, mDot, mDot, mDot },
                       { mDot, mDot, mDot, mDot, mDot },
                       { mDot, mDot, mDot, mDot, mDot } };
   #endregion
}

class Program {
   static void Main () {
      Console.OutputEncoding = System.Text.Encoding.UTF8;
      new Wordle ().Run ();
   }
}
#endregion