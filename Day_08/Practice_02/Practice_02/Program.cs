Console.Write("Please enter number: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.Write("Sum by recursion: ");
Console.WriteLine(SumRecursion(num));

Console.Write("Sum by tail recursion: ");
Console.WriteLine(SumbyTialRecursion(num, 0));
Console.Read();

int SumRecursion(int num)
{
    if (num > 0)
    {
        int prevSum = SumRecursion(num - 1);
        return num + prevSum;
    }
    return num;
}
int SumbyTialRecursion(int num, int sum)
{
    if (num == 1)
    {
        return sum += num;
    }
    else
    {
        sum += num;
        return SumbyTialRecursion(num - 1, sum);
    }
}