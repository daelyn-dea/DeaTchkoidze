using System.Text;
using System;

internal class Program
{
   
    private static void Main(string[] args)
    {
        bool inputYear = false;
        while (!inputYear)
        {
            Console.WriteLine("Enter your birth year: :");
            string birthYear = Console.ReadLine();
            if (uint.TryParse(birthYear, out uint numBirthYear))
            {
                switch (numBirthYear % 12)
                {
                    case 0:
                        Console.WriteLine($"{numBirthYear} was Monkey year");
                        break;
                    case 1:
                        Console.WriteLine($"{numBirthYear} was Rooster year");
                        break;
                    case 2:
                        Console.WriteLine($"{numBirthYear} was Dog year");
                        break;
                    case 3:
                        Console.WriteLine($"{numBirthYear} was Pig year");
                        break;
                    case 4:
                        Console.WriteLine($"{numBirthYear} was Rat year");
                        break;
                    case 5:
                        Console.WriteLine($"{numBirthYear} was Ox year");
                        break;
                    case 6:
                        Console.WriteLine($"{numBirthYear} was Tiger year");
                        break;
                    case 7:
                        Console.WriteLine($"{numBirthYear} was Rabbit year");
                        break;
                    case 8:
                        Console.WriteLine($"{numBirthYear} was Dragon year");
                        break;
                    case 9:
                        Console.WriteLine($"{numBirthYear} was Snake year");
                        break;
                    case 10:
                        Console.WriteLine($"{numBirthYear} was Horse year");
                        break;
                    case 11:
                        Console.WriteLine($"{numBirthYear} was Goat year");
                        break;

                }
                inputYear = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for  year");
            }
        }
        Console.ReadLine();
       
    }

}




