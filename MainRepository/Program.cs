﻿// Print chessboard
int n = 8;
Console.OutputEncoding = System.Text.Encoding.Unicode;
string whiteCoins = " ♖ │ ♘ │ ♗ │ ♕ │ ♔ │ ♗ │ ♘ │ ♖ │";
string blackPawns = " ♟ │ ♟ │ ♟ │ ♟ │ ♟ │ ♟ │ ♟ │ ♟ │";
string whitePawns = " ♙ │ ♙ │ ♙ │ ♙ │ ♙ │ ♙ │ ♙ │ ♙ │";
string blackCoins = " ♜ │ ♞ │ ♝ │ ♛ │ ♚ │ ♝ │ ♞ │ ♜ │";
Console.WriteLine ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
for (int i = 0; i < n; i++) {
   Console.Write ("│");
   bool iEnd = i == n - 1;
   if (i == 0) Console.Write (whiteCoins);
   else if (i == 1) Console.Write (blackPawns);
   else if (i == n - 2) Console.Write (whitePawns);
   else if (iEnd) Console.Write (blackCoins);
   else for (int j = 0; j < n; j++) Console.Write ("   │");
   if (iEnd) break;
   Console.WriteLine ("\n├───┼───┼───┼───┼───┼───┼───┼───┤");
}
Console.WriteLine ("\n└───┴───┴───┴───┴───┴───┴───┴───┘");