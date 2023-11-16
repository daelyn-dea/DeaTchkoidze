// See https://aka.ms/new-console-template for more information
int year = Convert.ToInt32(Console.ReadLine());
if(year % 100 == 0)
{
    if(year % 400 == 0)
    {
        Console.WriteLine(true);
    }
    Console.WriteLine(false);
}
 else if (year % 4 == 0)
{
    Console.WriteLine(true);
}
else
{
    Console.WriteLine(false);
}