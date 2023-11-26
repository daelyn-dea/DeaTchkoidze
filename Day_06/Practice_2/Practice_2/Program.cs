int[] array = new int[] { 1, 123, 4, 15, 13, 23, 98 };
Console.WriteLine(Function(array, 1));
Console.ReadKey();

int Function(int[] numbers, int index)
{
    int sum = 0;
    while (numbers[index] % 10 >= 1)
    {  
        sum += numbers[index] % 10;
        numbers[index] /= 10;
    }
    return sum;
}