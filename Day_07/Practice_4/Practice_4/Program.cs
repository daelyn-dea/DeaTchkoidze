string text = EnterText();
int countOfWord = SpaceInString(text);
PrintCount(countOfWord);
Console.Read();

void PrintCount(int num)
{
    Console.WriteLine(num);
}

int SpaceInString(string text)
{
    var splittedResult = text.Split(new char[] { ' ', ',', '\n', }, StringSplitOptions.RemoveEmptyEntries);
    return splittedResult.Length;
}
string EnterText()
{
    Console.Write("Please enter the text: ");
    string text = Console.ReadLine()!;
    return text!;
}