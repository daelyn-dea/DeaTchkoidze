Console.Write("Enter a number of rows of Floyd's triangle to be printed: ");
int input = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= input; i++)
{
    for (int j = 1; j <= i; j++)
    {
        if (i % 2 == 0)
            Console.Write((j + 1) % 2 + " ");
        else
            Console.Write(j % 2 + " ");
    }
    Console.WriteLine();
}
Console.ReadLine();