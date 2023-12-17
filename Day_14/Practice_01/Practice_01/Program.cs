using Practice_01;
//1.
Console.WriteLine("Enter text which you want to reverced: ");
string input = Console.ReadLine();
Console.WriteLine($"Reversed text: {input.ReversecString()}");

//2.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter caracter, which you want to count: ");
char caracter = Convert.ToChar(Console.ReadLine());
Console.WriteLine($"the letter \"{caracter}\" in the text {input.CountCaracterInString(caracter)} - times");


//3.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter substring, to know start or end text by this: ");
string substrng = Console.ReadLine();
Console.WriteLine(input.StartOrEndString(substrng));

//4.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter number to know is it odd or even: ");
int number = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"number {number}  is {number.EvenOrOdd()}");

//5.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter number to know absolute value: ");
int number1 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"number {number1}'s absolute value is:  {number1.AbsoluteValue()}");

//6.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter number to rounds nearest multiple: ");
int number2 = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"number {number2}'s nearest multiple is:  {number2.RoundNearestMultiple()}");


//7.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter number for array length: ");
int arrayLength = Convert.ToInt32(Console.ReadLine());
int[] array = new int[arrayLength];

Console.WriteLine("Enter numbers for array : ");
for (int i = 0; i < arrayLength; i++)
{
    Console.Write($"array[{i}] : ");
    array[i]  = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Delete dublicate element from array : ");
int[] newarray = array.RemovesDublicate();
for (int i = 0; i < newarray.Length; i++)
{
    Console.Write($"{newarray[i]} ");
}

//8.
Console.WriteLine("---------------------");
Console.WriteLine();
Console.WriteLine("Enter numbers for search array : ");
int searchNumber = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(array.FindNumber
