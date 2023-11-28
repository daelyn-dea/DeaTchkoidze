string text = EnterText();
int numInString = NumInString(text);
int lettersInString = LettersInString(text);
PrintResult(numInString, lettersInString, text);
Console.Read();

void PrintResult(int numOfNums, int lettersInString, string text)
{
    Console.WriteLine($"\"{ text}\" -> Letters: {lettersInString}, Numbers: {numOfNums}, Others: {text.Length - lettersInString - numOfNums}  ");
}

int LettersInString(string text)
{
    int count = 0;
    string letters = "qwertyuiopasdfghjklzxcvbnmQWERTYUIOPASDFGHJKLZXCVBNM";
    foreach (char c in text)
    {
        if (letters.Contains(c))
        {
            count++;
        }
    }
    return count;
}

int NumInString(string text)
{
    int count = 0;
    string nums = "1234567890";
    foreach (char c in text)
    {
        if (nums.Contains(c))
        {
            count++;
        }
    }
    return count;
}
string EnterText()
{
    Console.Write("Please enter the text: ");
    string text = Console.ReadLine()!;
    return text!;
}