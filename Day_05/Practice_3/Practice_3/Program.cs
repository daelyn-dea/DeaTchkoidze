Console.Write("Enter array size: ");
int arraySize = Convert.ToInt32(Console.ReadLine());
int[] array = new int[arraySize];
int sum = 0;

for (int i = 0; i < arraySize; i++)
{
    Console.Write($"Enter number for index {i} : ");
    array[i] = Convert.ToInt32(Console.ReadLine());
    sum += array[i];
}
Console.Write($"Sum of array Elemnts is {sum}");