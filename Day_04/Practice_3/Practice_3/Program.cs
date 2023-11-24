Console.Write("Enter a number: ");
int input = Convert.ToInt32(Console.ReadLine());
for (int i = 1; i <= input; i++)
{
    Console.Write($"{i} cubed is {i*i*i}");
    Console.WriteLine();
}