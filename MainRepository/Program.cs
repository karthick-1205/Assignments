// Program to find the possible combination of queen in the n*n chess board
class NQueen
{
    static int Count;
    //Function to check if two queens attack each other or not
    // Unicode of queen-\u2655
    static bool IsSafe(char[,] board, int r, int c)
    {
        // Checking the column 
        for (int i = 0; i < r; i++)
        {
            if (board[i, c] == '\u2655')
                return false;
        }
        // Checking the left diagonal 
        for (int i = r, j = c; i >= 0 && j >= 0; i--, j--)
        {
            if (board[i, j] == '\u2655')
                return false;
        }
        // Checking the right diagonal 
        for (int i = r, j = c; i >= 0 && j < board.GetLength(0); i--, j++)
        {
            if (board[i, j] == '\u2655')
                return false;
        }
        return true;
    }
    // Printing the queen in the chess board
    static void PrintSolution(char[,] board)
    {
        Console.WriteLine("\u250C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u252C\u2500\u2500\u2500\u2510");
        for (int i = 0; i < board.GetLength(0); i++)
        {
            Console.Write("\u2502");
            for (int j = 0; j < board.GetLength(1); j++)
                Console.Write(board[i, j] == '\u2655' ? " \u2655 \u2502" : "   \u2502");
            if (i == 7)
            {
                break;
            }
            Console.WriteLine();
            Console.WriteLine("\u251C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u253C\u2500\u2500\u2500\u2524");
        }
        Console.WriteLine();
        Console.WriteLine("\u2514\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2534\u2500\u2500\u2500\u2518");
    }
    static void Nqueen(char[,] board, int r)
    {
        // if N queesn are placed successfully,print the solution
        if (r == board.GetLength(0))
        {
            PrintSolution(board);
            Count++;
            Console.WriteLine($"the solutions number are {Count}");
        }
        for (int i = 0; i < board.GetLength(0); i++)
        {
            if (IsSafe(board, r, i))
            {
                // Place queen on the current square
                board[r, i] = '\u2655';
                // Recursion for the next row
                Nqueen(board, r + 1);
                // Backtrack and remove the queen from the current square
                board[r, i] = '-';
            }
        }
    }
    static void Main(string[] args)
    {
        // N*N Chessboard
        int n = 8;
        char[,] board = new char[n, n];
        Console.OutputEncoding = System.Text.Encoding.Unicode;
        Nqueen(board, 0);
    }

}