char[] array = ArrayFunc();
Console.Write("Enter char in the array:");
char symbol = Convert.ToChar(Console.ReadLine());
ConsoleWriteFunc(symbol, ArrayFunc1(array, symbol));
Console.Read();

char[] ArrayFunc()
{
    Console.Write("Enter size of array: ");
    int size = Convert.ToInt32(Console.ReadLine());
    char[] array = new char[size];
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Enter element of index {i}:  ");
        array[i] = Convert.ToChar(Console.ReadLine());
    }
    return array;
}

int ArrayFunc1(char[] array, char symbol)
{
    int sumOfChar = 0;
    for (int i = 0; i < array.Length; i++)
    {
        if (symbol == array[i])
        {
            sumOfChar++;
        }
    }
    return  sumOfChar; ;
}

void ConsoleWriteFunc(char a, int sumOfChars)
{
    Console.WriteLine($" {a} shegvxda {sumOfChars}-jer");
}