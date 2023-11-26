Console.WriteLine(Multilpy(1,2,3,4));

int Multilpy(params int[] numbers)
{
    int multiply = 1;
    foreach (int num in numbers)
    {
        multiply *= num;
    }
    return multiply;
}