Console.Write("Enter array size: ");
int arraySize = Convert.ToInt32(Console.ReadLine());
int[] array = new int[arraySize];

for (int i = 0; i < arraySize; i++)
{
    Console.Write($"Enter number for index {i} : ");
    array[i] = Convert.ToInt32(Console.ReadLine());
}

for (int i = arraySize-1; i >= 0; i--)
{
    Console.WriteLine(array[i]);
}