//შემოყვანილი რიცხვის ჩათვლით
int sum = 0;
Console.Write("Enter a number: ");
int input = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= input; i++)
{
    if (i % 2 == 1)
        sum += i;
}

Console.WriteLine($"Sum of odd number from 1 to {input} is {sum}");


//შემოყვანილი რიცხვამდე
 sum = 0;
 Console.Write("Enter a number: ");
 input = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i < input; i++)
{
    if (i % 2 == 1)
        sum += i;
}

Console.WriteLine($"Sum of odd number from 1 to {input} is {sum}");