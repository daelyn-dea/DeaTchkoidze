using Practice_01;
using static Practice_01.ENUMS;

Console.Write("Enter number: ");
int num = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter number for pow: ");
int pow = Convert.ToInt32(Console.ReadLine());
Status resultStatus;
int result = MATH.Pow(num, pow, out resultStatus);

if (resultStatus == Status.Success)
{
    Console.WriteLine($"{num} ^ {pow} = {result}");
}
else
{
    Console.WriteLine("Pow must be positive or zero.");
}

Console.Write("Enter number for num1 for max func: ");
int num1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter number for num2 for max func: ");
int num2 = Convert.ToInt32(Console.ReadLine());

result = MATH.Max(num1, num2, out resultStatus);
if (resultStatus == Status.Success)
{
    Console.WriteLine($"max num is {result}");
}
else
{
    Console.WriteLine("nums is equals");
}


Console.Write("Enter number for num1 for min func: ");
num1 = Convert.ToInt32(Console.ReadLine());
Console.Write("Enter number for num2 for min func: ");
num2 = Convert.ToInt32(Console.ReadLine());


result = MATH.Min(num1, num2, out resultStatus);
if (resultStatus == Status.Success)
{
    Console.WriteLine($"min num is {result}");
}
else
{
    Console.WriteLine("nums is equals");
}