using Practice_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal class Sport : Vehicle
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        Sporttypes Types { get; set; }
        int SpeedFirst1second { get; set; }


        public Sport(int numOfWheel, int speedKmH, int speedFirst1second, Sporttypes types)
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            SpeedFirst1second = speedFirst1second;
            Types = types;
        }
        public Sport()
        {

        }

        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Type of Sport car is: {Types}");
            Console.WriteLine($"Numbers of Wheel of Public is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Public is: {SpeedKmH}");
            Console.WriteLine($"Numbers of Passenger of Public is: {SpeedFirst1second}");
        }
        public void sportMethod(string userInput1)
        {
            switch (userInput1)
            {
                case "F1":
                    Console.WriteLine("----------Create Object-----------");
                    Console.Write("Enter Num of Wheel: ");
                    int NumOfWheel = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Speed: ");
                    int SpeedKmH = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter num of passanger: ");
                    int km1sec = Convert.ToInt32(Console.ReadLine());
                    Sporttypes sporttypes = Sporttypes.F1;
                    Sport f1 = new Sport(NumOfWheel, SpeedKmH, km1sec, sporttypes);
                    f1.PrintInfo();
                    break;
                case "Offroad":
                    Console.WriteLine("----------Create Object-----------");
                    Console.Write("Enter Num of Wheel: ");
                    NumOfWheel = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Speed: ");
                    SpeedKmH = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter num of passanger: ");
                    km1sec = Convert.ToInt32(Console.ReadLine());
                    sporttypes = Sporttypes.Offroad;
                    Sport Offroad = new Sport(NumOfWheel, SpeedKmH, km1sec, sporttypes);
                    Offroad.PrintInfo();
                    break;
                case "Info":
                    Console.WriteLine("----------Print Info-----------");
                    Console.Write("You chooze Sport car: ");
                    break;
            }
        }
        public enum Sporttypes
        {
            F1,
            Offroad,
            Info
        }

    }
}