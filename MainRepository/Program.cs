//Isogram
Console.Write("Enter the string: ");
string input = Console.ReadLine();
Console.WriteLine($"The given {input} string is " + (isIsogram(input) ? "isogram" : "not a isogram"));
static bool isIsogram(string s)
{
    Dictionary<char, int> Unique = new();
    foreach (char c in s)
    {
        if (Unique.ContainsKey(c)) return false;
        else Unique[c] = 1;
    }
    return true;
}