using practice1;

Random r = new Random();
r.Next();

List<string> strings = new List<string>() { "dea", "lala"};  
int index = HangmanGameList.RandomMethod1(strings);
char enteredChar = HangmanGameList.ReadlineChar();
string output = HangmanGameList.printAnswer(index, enteredChar, strings);
int count = 1;
while (output != strings[index] | count != 6)
{
     enteredChar = HangmanGameList.ReadlineChar();
     output = HangmanGameList.printAnswer(index, enteredChar, strings);
    count++;
}
