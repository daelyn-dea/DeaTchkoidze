Console.Write("Enter array row size: ");
int arrayRowSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter array column size: ");
int arrayColumnSize = Convert.ToInt32(Console.ReadLine());

int[,] array1 = new int[arrayRowSize, arrayColumnSize];
int[,] array2 = new int[arrayRowSize, arrayColumnSize];
int[,] array3 = new int[arrayRowSize, arrayColumnSize];


Console.WriteLine("Fill first matrix: ");

for (int i = 0; i < arrayRowSize; i++)
{
    for (int j = 0; j < arrayColumnSize; j++)
    {
        Console.Write($"Enter number for index {i}, {j} : ");
        array1[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}

Console.WriteLine();
Console.WriteLine("Fill second matrix: ");
for (int i = 0; i < arrayRowSize; i++)
{
    for (int j = 0; j < arrayColumnSize; j++)
    {
        Console.Write($"Enter number for index {i}, {j} : ");
        array2[i, j] = Convert.ToInt32(Console.ReadLine());
    }
}

for (int i = 0; i < arrayRowSize; i++)
{
    for (int j = 0; j < arrayColumnSize; j++)
    {
        array3[i, j] = array1[i, j] + array2[i, j];
        Console.Write(array3[i, j] + ", ");
    }
    Console.WriteLine();
}