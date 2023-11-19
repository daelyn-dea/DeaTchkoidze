Console.Write("Enter a number : ");
int input = Convert.ToInt32(Console.ReadLine());

for (int i = 1; i <= input; i++)
{
   if ( input % i == 0)
    Console.Write(i + ", ");
}