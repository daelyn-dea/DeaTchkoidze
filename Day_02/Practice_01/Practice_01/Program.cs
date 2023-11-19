using System.Text;
using System;

internal class Program
{
    private static void Main(string[] args)
    {
        bool inputIsNumber = false;
        while (!inputIsNumber)
        {
            Console.WriteLine("Enter integer Number :");
            string inputNum = Console.ReadLine();
            if (int.TryParse(inputNum, out int number))
            {
                if (number % 2 == 0)
                {
                    Console.WriteLine($"Entered  Number {number} is even");
                }
                else
                {
                    Console.WriteLine($"Entered  Number {number} is odd");
                }
                inputIsNumber = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input");
            }
        }
    }

}




