string text = EnterText();
ReverseTextByMethod(text);//მეთოდის გამოყენებით
ReverseText(text);//ფორით
Console.Read();


void ReverseTextByMethod(string text)
{
    string reversed = new string(text.Reverse().ToArray());
    Console.WriteLine(reversed);
}

void ReverseText(string text)
{
    for (int i = text.Length - 1; i >= 0; i--)
    {
        Console.Write(text[i]);
    }
}

string EnterText()
{
    Console.Write("Please enter the text: ");
    string text = Console.ReadLine()!;
    return text!;
}