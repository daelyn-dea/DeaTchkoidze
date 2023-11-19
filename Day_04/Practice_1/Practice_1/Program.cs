// See https://aka.ms/new-console-template for more information

int sum = 0;
for (int i = 0; i < 10; i++)
{
    sum += i;
}
Console.WriteLine($"Sum from 0 to 10 is {sum}"); // 10 მდე ჯამი 45-ია
sum = 0;
for (int i = 0; i <= 10; i++)
{
    sum += i;
}
Console.WriteLine($"Sum from 0 to 10 is {sum}");//10-ის ჩათვლით - 55