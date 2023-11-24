Console.Write("Enter array row size: ");
int arrayRowSize = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter array column size: ");
int arrayColumnSize = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[arrayRowSize,arrayColumnSize];

for (int i = 0; i < arrayRowSize; i++)
{
    for (int j = 0; j < arrayColumnSize; j++)
    {
        Console.Write($"Enter number for index {i}, {j} : ");
        array[i,j] = Convert.ToInt32(Console.ReadLine());
    }
}

Console.WriteLine("Here is Matrix view of Multidimensional array: ");
for (int i = 0; i < arrayRowSize; i++)
{
    for (int j = 0; j < arrayColumnSize; j++)
    {
        Console.Write(array[i,j] + ", ");
    }
    Console.WriteLine();
}