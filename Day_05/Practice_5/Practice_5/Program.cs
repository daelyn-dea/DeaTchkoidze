Console.Write("Enter array size: ");
int size = Convert.ToInt32(Console.ReadLine());
int[] array = new int[size];

for (int i = 0; i < size; i++)
{
    Console.Write($"Enter number for index {i} : ");
    array[i] = Convert.ToInt32(Console.ReadLine());
}

Console.WriteLine("Unique elements in the array:");

for (int i = 0; i < size; i++)
{
    bool isUnique = true;

    for (int j = 0; j < size; j++)
    {
        if (i != j && array[i] == array[j])
        {
            isUnique = false;
            break;
        }
    }

    if (isUnique)
    {
        Console.WriteLine(array[i]);
    }
}
Console.Read();