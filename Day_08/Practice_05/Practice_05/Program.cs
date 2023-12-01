Console.Write("Please enter number: ");
string text = Console.ReadLine();

Console.Write("Counted by recursion: ");
Console.WriteLine(IsPalindromeRecursive(text));
Console.Write("Counted by tail recursion: ");
Console.WriteLine(IsPalindromeTailRecursive(text, 0, text.Length-1));

static bool IsPalindromeRecursive(string text)
{
    if (text.Length <= 1)
    {
        return true;
    }
    if (text[0] == text[text.Length - 1])
    {
        IsPalindromeRecursive(text.Substring(1, text.Length - 2));
        return true;
    }
    return false;
}
static bool IsPalindromeTailRecursive(string text, int start, int end)
{
    if (start >= end)
    {
        return true;
    }
    if (text[start] == text[end])
    {
        return IsPalindromeTailRecursive(text, start+1, end-1);
    }
    return false;
}