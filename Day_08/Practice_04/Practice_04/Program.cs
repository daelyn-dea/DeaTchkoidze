Console.Write("Please enter number: ");
int num = Convert.ToInt32(Console.ReadLine());
Console.Write("Please enter degree: ");
int degree = Convert.ToInt32(Console.ReadLine());

Console.Write("Counted by recursion: ");
Console.WriteLine(DegreeByRecursion(num, degree));

Console.Write("Counted by tail recursion: ");
Console.WriteLine(DegreeByTailRecursion(num, degree, 1));

int DegreeByTailRecursion(int num, int degree, int first)
{
    if (degree == 0)
    {
        return first;
    }
    else
    {
        first *= num;
        return DegreeByTailRecursion(num, degree - 1, first);
    }
}

int DegreeByRecursion(int num, int degree)
{
    if (degree == 0)
    {
        return 1;
    }
    else if(degree == 1)
    {
        return num;
    }
    else
    {
        int a = num;
        num = DegreeByRecursion(num, degree - 1);
        return num * a;
    }
}