int[][] array1 = new int[8][];
int[][] array2 = new int[8][];
int row = 7;

for (int i = 0; i < 8; i++)
{
    array1[i] = new int[8];

    for (int j = 7; j > i; j--)
    {
        array1[i][j] = 1;
    }
}

for (int i = 0; i < 8; i++)
{
    for (int j = 0; j < 8; j++)
    {
        Console.Write(array1[i][j] + " ");
    }
    Console.WriteLine();
}

Console.WriteLine("\n");

for (int i = 0; i < 8; i++)
{
    array2[i] = new int[8];
    for (int j = 0; j < 8; j++)
    {
        array2[i][j] = array1[row][j];
        Console.Write(array2[i][j] + " ");
    }
    Console.WriteLine();
    row--;
}

Console.Read();
