int sum = 0;
Console.Write("Enter a number: ");
int input = Convert.ToInt32(Console.ReadLine());
for (int i = 0; i <= input; i++)
{
    sum += i;
}
Console.WriteLine($"Sum from 0 to {input} is {sum}");