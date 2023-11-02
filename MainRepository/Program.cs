﻿// Program to find the possible combinations of queen in the n*n chess board
class PlaceNQueen {
   static int Count;
   // Function to check if two queens attack each other or not
   // Unicode of queen-\u2655
   static bool IsSafe (char[,] board, int r, int c) {
      // Checking the column 
      for (int i = 0; i < r; i++)
         if (board[i, c] == '\u2655') return false;
      // Checking the left diagonal 
      for (int i = r, j = c; i >= 0 && j >= 0; i--, j--)
         if (board[i, j] == '\u2655') return false;
      // Checking the right diagonal 
      for (int i = r, j = c; i >= 0 && j < board.GetLength (0); i--, j++)
         if (board[i, j] == '\u2655') return false;
      return true;
   }

   // Printing the queen in the chess board
   static void PrintSolution (char[,] board) {
      Console.WriteLine ("┌───┬───┬───┬───┬───┬───┬───┬───┐");
      for (int i = 0; i < board.GetLength (0); i++) {
         Console.Write ("\u2502");
         for (int j = 0; j < board.GetLength (1); j++)
            Console.Write (board[i, j] == '\u2655' ? " \u2655 \u2502" : "   \u2502");
         if (i == 7) {
            break;
         }
         Console.WriteLine ();
         Console.WriteLine ("├───┼───┼───┼───┼───┼───┼───┼───┤");
      }
      Console.WriteLine ();
      Console.WriteLine ("└───┴───┴───┴───┴───┴───┴───┴───┘");
   }

   static void NQueen (char[,] board, int r) {
      // if N queens are placed successfully,print the solution
      if (r == board.GetLength (0)) {
         Count++;
         Console.WriteLine ($"Solution {Count}");
         PrintSolution (board);
      }
      for (int i = 0; i < board.GetLength (0); i++) {
         if (IsSafe (board, r, i)) {
            // Place queen on the current square
            board[r, i] = '\u2655';
            // Recursion for the next row
            NQueen (board, r + 1);
            // Backtrack and remove the queen from the current square
            board[r, i] = '-';
         }
      }
   }

   static void Main () {
      // N*N Chessboard
      int n = 8;
      char[,] board = new char[n, n];
      Console.OutputEncoding = System.Text.Encoding.Unicode;
      NQueen (board, 0);
   }
}