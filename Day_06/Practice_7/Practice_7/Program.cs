Console.Write("Enter count of rows: ");
int rows = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter count of columns: ");
int columns = Convert.ToInt32(Console.ReadLine());

int[,] array = new int[rows, columns];

Console.WriteLine("===============================");

int[,] array1 = ArrayFunc(rows, columns);
int[,] array2 = ArrayFunc(rows, columns);
int[,] sumArray = ArrayFunc1(array1, array2);

ConsoleWriteSum(sumArray);
Console.Read();
static int[,] ArrayFunc(int rows, int columns)
{
    int[,] array = new int[rows, columns]; 

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"Enter element of index {i} , {j}:  ");
            array[i, j] = Convert.ToInt32(Console.ReadLine()); 
        }
    }
    Console.WriteLine("===============================");
    return array;
}
static int[,] ArrayFunc1(int[,] array1, int[,] array2)
{
    int rows = array1.GetLength(0);
    int columns = array1.GetLength(1);

    int[,] sumOfArray = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sumOfArray[i, j] = array1[i, j] + array2[i, j];
        }
    }
    return sumOfArray;
}
static void ConsoleWriteSum(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write(array[i, j] + " "); 
        }
        Console.WriteLine();
    }
}