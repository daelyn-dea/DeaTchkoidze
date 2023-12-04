Console.Write("Please enter number: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.Write("Counted by recursion: ");
Console.WriteLine(CountByRecursion(num));

Console.Write("Counted by tail recursion: ");
Console.WriteLine(CountByTailRecursion(num, 0));
Console.Read();

int CountByRecursion(int num)
{
    if(num == 0)
    {
        return 0;
    }
    else
    {
        return 1 + CountByRecursion(num / 10);
    }
}

int CountByTailRecursion(int num, int firstDigit)
{
   if(num == 0)
    {
        return firstDigit;
    }
    else {
        return CountByTailRecursion(num / 10, firstDigit + 1);
    }
}