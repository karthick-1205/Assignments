using System.Reflection;

//Strong password
using (var stm = Assembly.GetExecutingAssembly().GetManifestResourceStream("MainRepository.Data.passwords.txt"))
using (var sr = new StreamReader(stm))
{
    while (!sr.EndOfStream)
    {
        var result = sr.ReadLine();
        Console.WriteLine($"The given {result} password is " + (isValidPassword(result) ? "Strong" : "Weak"));
    }
}
static bool isValidPassword(string s)
{
    bool containsUpperCase = false;
    bool containsLowerCase = false;
    bool containsDigits = false;
    bool containsSpecialChar = false;
    if (s.Length < 6) return false;
    for (int i = 0; i < s.Length; i++)
    {
        char ch = s[i];
        if (Char.IsUpper(ch)) containsUpperCase = true;
        if (Char.IsLower(ch)) containsLowerCase = true;
        if (Char.IsDigit(ch)) containsDigits = true;
        if (!Char.IsLetter(ch) && !Char.IsDigit(ch) && !Char.IsWhiteSpace(ch)) containsSpecialChar = true;
    }
    return (containsUpperCase && containsLowerCase && containsDigits && containsSpecialChar);
}