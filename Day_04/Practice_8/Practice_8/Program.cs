Console.Write("Enter a number : ");
int input = Convert.ToInt32(Console.ReadLine());
string output = " ";
for (int i = 0; i <= input; i++)
{
    for(int j = 0; j <= input; j++) 
    {
        int binary = input % 2;
        output = binary + output;
        input /= 2;
    }
}
Console.WriteLine(output);
Console.ReadLine();