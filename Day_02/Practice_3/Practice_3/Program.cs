using System.Text;
using System;

internal class Program
{
   
    private static void Main(string[] args)
    {
       
        bool inputForSquare = false;
        while (!inputForSquare)
        {
            Console.WriteLine("Enter  Number :");
            string sqrtNumber = Console.ReadLine();
            if (int.TryParse(sqrtNumber, out int numberSquare))
            {
                int result = (int)Math.Pow(numberSquare, 2);
                Console.WriteLine($"The pow of the entered Number is {result}");
                inputForSquare = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for  Num");
            }
            Console.ReadLine();
        }
       
    }

}




