Console.Write("Enter array size: ");
int arraySize = Convert.ToInt32(Console.ReadLine());
int[] array = new int[arraySize];
int multiplied = 1;

for (int i = 0; i < arraySize; i++)
{
    Console.Write($"Enter number for index {i} : ");
    array[i] = Convert.ToInt32(Console.ReadLine());
    multiplied *= array[i];
}
Console.Write($"Product of array Elemnts is {multiplied}");