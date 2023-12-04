using static System.Net.Mime.MediaTypeNames;

string enteredText = EnterText();
bool vowelOrConsonant = EnterVowelOrConsonant();
int count = VowelCounter(enteredText, vowelOrConsonant);
if (vowelOrConsonant)
{
    Console.WriteLine($"Vowel count : {count}");
}
else
{
    Console.WriteLine($"Consonant count : {count}");
}
PrintVowelsOrConsonant(enteredText, vowelOrConsonant);
Console.Read();


void PrintVowelsOrConsonant(string text, bool vowelOrConsonant)
{
    string vowels = "aeiouAEIOU";
    string insideVowels = " ";
    foreach (char c in text)
    {
        if (vowels.Contains(c) & vowelOrConsonant | !vowelOrConsonant & !vowels.Contains(c))
        {
            insideVowels += c + " ";
        }
    }
    if (vowelOrConsonant)
    {
        Console.WriteLine($"Vowel: {insideVowels}");
    }
    else
    {
        Console.WriteLine($"Consonant: {insideVowels}");
    }
}

int VowelCounter(string text, bool vowelOrConsonant)
{
    int count = 0;
    string vowels = "aeiouAEIOU";
    foreach (char c in text)
    {
        if (vowels.Contains(c) & vowelOrConsonant == true | vowelOrConsonant == false & !vowels.Contains(c))
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

bool EnterVowelOrConsonant()
{
    Console.WriteLine("Please enter which you want to count: Vowel or Consonant? "); 
    string value = Console.ReadLine()!;
    if(value == "Consonant" | value == "consonant")
    {
        return false;
    }
    return true!;
}
