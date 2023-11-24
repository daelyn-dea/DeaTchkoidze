int a = EnterNumber();
Function(a);

void Function(int num)
{
    int number = num;
    int index = 0;
    string a = "";
    do
    {
        int num1 = number % 10;
        if (index == 0)
            a = $"{num1} * 10^{index}" + a;
        else
            a = $" {num1} * 10^{index} + " + a;
        index++;
        number /= 10;
    } while (number > 0);
    Console.WriteLine($"{num} = {a}");

}

int EnterNumber()
{
    Console.Write("Enter a positive number: ");
    int num = Convert.ToInt32(Console.ReadLine());
    return num;
}

