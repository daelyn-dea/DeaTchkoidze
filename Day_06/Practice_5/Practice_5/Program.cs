int[] array = ArrayFunc();

Console.Write("Enter number in the array:");
int num = Convert.ToInt32(Console.ReadLine());

int arrayFunc1 = ArrayFunc1(array, num);

if(arrayFunc1 == -1)
{
    Console.WriteLine($"Number {num} wasn't found in the given array");
}
else
{
    Console.WriteLine($"Factorial of {num} is {arrayFunc1}");
}
Console.Read();

int[] ArrayFunc()
{
    Console.Write("Enter size of array: ");
    int size = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[size];
    for (int i = 0; i < size; i++){
        Console.Write($"Enter element of index {i}:  ");
        array[i] = Convert.ToInt32(Console.ReadLine());
    }
    return array;
}
int ArrayFunc1(int[] array, int num)
{
    foreach (int i in array)
    {
        if (num == i)
        {
            return Factorial(num);
        }
    }
    return -1;
}
int Factorial(int index)
{
    int factorial = 1;
    for (int i = index; i > 0; i--)
    {
        factorial *= i;
    }
    return factorial;
}