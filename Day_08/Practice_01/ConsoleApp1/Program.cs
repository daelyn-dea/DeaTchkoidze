Console.Write("Please enter number: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.Write("Printed by recursion: ");
PrintNumbers(num);
Console.WriteLine();

Console.Write("Printed by tail recursion: ");
PrintNumbersTail(num, 1);
Console.Read();

void PrintNumbers(int num)
{
    if (num > 0)
    {
        PrintNumbers(num - 1);
        Console.Write($"{num} ");
    }
}
void PrintNumbersTail(int num, int one)
{
    if (one <= num)
    {
        Console.Write($"{one} ");
        PrintNumbersTail(num, one + 1);
    }
}