int[] array1 = Function1(Function2());

Console.WriteLine($"The minimum number in the array is  {array1[1]}");
Console.WriteLine($"The maximum number in the array is  {array1[0]}");
Console.Read();

int[] Function2()
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

int[] Function1(int[] array)
{
    int[] array1 = new int[2];
    int max = array[0];
    int min = array[0];

   for (int i = 0; i < array.Length; i++)
    { 
        if (array[i] > max)
            max = array[i];
        if (array[i] < min)
            min = array[i];
    }
    array1[0] = max;
    array1[1] = min;
    return array1;
}