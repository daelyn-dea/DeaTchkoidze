Console.WriteLine($"Aritmethic average of arrya is: {Average(CreateArray())}");
Console.Read();

int[] CreateArray()
{
    Console.Write("Enter array size: ");
    int arraySize = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[arraySize];

    for (int i = 0; i < arraySize; i++)
    {
        Console.Write($"Enter number for index {i} : ");
        array[i] = Convert.ToInt32(Console.ReadLine());
    }
    return array;
}
int Average(int[] array)
{
    int count = 0;
    for(int i = 0; i < array.Length; i++)
    {
        count += array[i];
    }

    return count / array.Length; ;
}