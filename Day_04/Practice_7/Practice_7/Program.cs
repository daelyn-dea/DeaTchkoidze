Console.Write("Enter a number : ");
int input = Convert.ToInt32(Console.ReadLine());

int num1 = 0, num2 = 1;

for (int i = 0; i <= input; i++)
{
    Console.WriteLine(num1);
    int num3 = num1 + num2;
    num1 = num2;
    num2 = num3;
}