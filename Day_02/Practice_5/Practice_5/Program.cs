using System.Text;
using System;

internal class Program
{
    
    private static void Main(string[] args)
    {
      
        bool inputDay = false;
        bool inputMonth = false;
        string birthMonth = "January";
        uint numBirthDay = 1;
        

        while (!inputDay)
        {
            Console.WriteLine("Enter your day of birth:");
            string birthDay = Console.ReadLine();
            if (uint.TryParse(birthDay, out numBirthDay) && numBirthDay > 0 && numBirthDay <= 31)
            {
                inputDay = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for day");
            }
        }

        while (!inputMonth)
        {
            Console.WriteLine("Enter your month of birth:");
            birthMonth = Console.ReadLine();
            if (birthMonth == "January" || birthMonth == "February" || birthMonth == "March" || birthMonth == "April" || birthMonth ==  "June" || birthMonth == "July" || birthMonth == "August" || birthMonth == "September" || birthMonth == "October" || birthMonth == "November" || birthMonth == "December")
            {
                inputMonth = true;
            }
            else
            {
                Console.WriteLine("Please enter valid input for month : \"January\", \"February\", \"March\", \"April\", \"June\", \"July\", \"August\", \"September\", \"October\", \"November\", \"December\" ");
            }
        }

        if ((birthMonth == "March" && numBirthDay >= 21 && numBirthDay <= 31) || (birthMonth == "April" && numBirthDay <= 20))
            Console.WriteLine($"Your Zodiac is Aries");
        else if ((birthMonth == "April" && numBirthDay >= 21 && numBirthDay <= 30) || (birthMonth == "May" && numBirthDay <= 20))
            Console.WriteLine($"Your Zodiac is Taurus");
        else if ((birthMonth == "May" && numBirthDay >= 21 && numBirthDay <= 31) || (birthMonth == "June" && numBirthDay <= 20))
            Console.WriteLine($"Your Zodiac is Gemini");
        else if ((birthMonth == "June" && numBirthDay >= 21 && numBirthDay <= 30) || (birthMonth == "July" && numBirthDay <= 22))
            Console.WriteLine($"Your Zodiac is Cancer");
        else if ((birthMonth == "July" && numBirthDay >= 23 && numBirthDay <= 31) || (   birthMonth == "August" && numBirthDay <= 22))
            Console.WriteLine($"Your Zodiac is Leo");
        else if ((birthMonth == "August" && numBirthDay >= 23 && numBirthDay <= 31) || (birthMonth == "September" && numBirthDay <= 22))
            Console.WriteLine($"Your Zodiac is Virgo");
        else if ((birthMonth == "September" && numBirthDay >= 23 && numBirthDay <= 30) || (birthMonth == "October" && numBirthDay <= 22))
            Console.WriteLine($"Your Zodiac is Libra");
        else if ((birthMonth == "October" && numBirthDay >= 23 && numBirthDay <= 31) || (birthMonth == "November" && numBirthDay <= 21))
            Console.WriteLine($"Your Zodiac is Scorpio");
        else if ((birthMonth == "November" && numBirthDay >= 22 && numBirthDay <= 30) || (birthMonth == "December" && numBirthDay <= 21))
            Console.WriteLine($"Your Zodiac is Sagittarius");
        else if ((birthMonth == "December" && numBirthDay >= 22 && numBirthDay <= 31) || (birthMonth == "January" && numBirthDay <= 19))
            Console.WriteLine($"Your Zodiac is Capricorn");
        else if ((birthMonth == "January" && numBirthDay >= 20 && numBirthDay <= 31) || (birthMonth == "February" && numBirthDay <= 18))
            Console.WriteLine($"Your Zodiac is Aquarius");
        else if ((birthMonth == "February" && numBirthDay >= 19 && numBirthDay <= 29) || (birthMonth == "March" && numBirthDay <= 20))
            Console.WriteLine($"Your Zodiac is Pisces");
        else
            Console.WriteLine($"Your Zodiac is Unknown");
        Console.ReadLine();
    }
   
    
        
 

}




