// Implementation of Worlde game.
class Wordle
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Wordle w = new Wordle();
        w.Run();
    }

    public void Run()
    {
        DisplayBoard();
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                UpdateGameState();
            }
        }
        Console.WriteLine(SelectWord());
    }

    // Function give guessing word
    public string SelectWord()
    {
        string[] lines = File.ReadAllLines(@"C:\etc1\puzzle-5.txt");
        Random random = new Random();
        return lines[random.Next(lines.Length)];
    }

    // Getting user input of character like online worlde game
    public void UpdateGameState()
    {
        bool isFound = false;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                if (mList[i, j] == '\u25cc')
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    char result = Convert.ToChar(key.KeyChar);
                    mList[i, j] = Char.ToUpper(result);
                    if (j < 4) mList[i, j + 1] = '\u25cc';
                    if (i < 5 && j == 4) mList[i + 1, 0] = '\u25cc';
                    isFound = true;
                    DisplayBoard();
                    break;
                }
            }
            if (isFound) break;
        }
    }

    // Displaying the user input of character like online worlde game
    public void DisplayBoard()
    {
        Console.CursorLeft = 0;
        Console.CursorTop = 0;
        Console.CursorVisible = false;
        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                Console.Write(mList[i, j] + " ");
            }
            Console.WriteLine();
            Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        }
        for (int i = 0; i < 3; i++)
            Console.Write("\u2500\u2500\u2500\u2500");
        Console.WriteLine();
        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        Console.WriteLine("A B C D E F G");
        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        Console.WriteLine("H I J K L M N");
        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        Console.WriteLine("O P Q R S T U");
        Console.CursorLeft = (Console.WindowWidth / 2) - 5;
        Console.WriteLine("V W X Y Z");
    }
    char[,] mList = { { '\u25cc', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' },
                       { '\u00b7', '\u00b7', '\u00b7', '\u00b7', '\u00b7' }};
}