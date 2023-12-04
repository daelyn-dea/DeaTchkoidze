Console.Write("Please text number: ");
string text = Console.ReadLine();

Console.Write("Counted by recursion: ");
Console.WriteLine(IsPalindromeRecursive(text));
Console.Write("Counted by tail recursion: ");
Console.WriteLine(IsPalindromeTailRecursive(text, 0, text.Length-1));
Console.Read();

static bool IsPalindromeRecursive(string text)
{
    if (text.Length <= 1)
    {
        return true;
    }
    if (text[0] == text[text.Length - 1])
    {
        return IsPalindromeRecursive(text.Substring(1, text.Length - 2)); ;
    }
    return false;
}
static bool IsPalindromeTailRecursive(string text, int start, int end)
{
    if (start >= end)
    {
        return true;
    }
    if (text[start] != text[end])
    {
        return false;
    }
    return IsPalindromeTailRecursive(text, ++start , --end);
}