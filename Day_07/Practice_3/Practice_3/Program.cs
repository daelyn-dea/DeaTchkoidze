string spaceText = EnterText();
SpaceInString(spaceText);
Console.Read();

void SpaceInString(string text)
{
    char[] textInCharArray = text.ToCharArray();
    string spaceText = String.Join(" ", textInCharArray);
    string upperString = spaceText.ToUpper();
    Console.WriteLine(upperString);
}

string EnterText()
{
    Console.Write("Please enter the text: ");
    string text = Console.ReadLine()!;
    return text!;
}