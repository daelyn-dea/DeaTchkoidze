

internal class Program
{
  
    private static void Main(string[] args)
    {
        
        Console.ReadLine();
        bool inputIsNumber1 = false;
        bool inputIsNumber2 = false;
        bool inputIsNumber3 = false;
        int number1 = 0;
        int number2 = 0;
        int number3 = 0;
        while (!inputIsNumber1)
        {
            Console.WriteLine("Enter first Number :");
            string firstNumst = Console.ReadLine();
            if (int.TryParse(firstNumst, out number1))
            {
                inputIsNumber1 = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for first Num");
            }
        }
        while (!inputIsNumber2)
        {
            Console.WriteLine("Enter second Number :");
            string secondNumst = Console.ReadLine();
            if (int.TryParse(secondNumst, out number2))
            {
                inputIsNumber2 = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for second Num");
            }
        }
        while (!inputIsNumber3)
        {
            Console.WriteLine("Enter third Number :");
            string thirdNumst = Console.ReadLine();
            if (int.TryParse(thirdNumst, out number3))
            {
                inputIsNumber3 = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for third Num");
            }
        }
        if ((number1 + number2) > number3 && (number2 + number3) > number1 && (number1 + number3) > number2)
        {
            Console.WriteLine("this should be a triangle");
            inputIsNumber1 = true;
        }
        else
        {
            Console.WriteLine("this shouldn't be a triangle");
            inputIsNumber1 = true;
        }
        Console.ReadLine();
       
    }

}




