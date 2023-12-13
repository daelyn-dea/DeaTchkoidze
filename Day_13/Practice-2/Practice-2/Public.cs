using Practice_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal class Public : Vehicle
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        publictypes Types { get; set; }
        int Passenger { get; set; }

 
        public Public(int numOfWheel, int speedKmH,  int pessegner, publictypes publictypes) 
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            Passenger = pessegner;
            Types = publictypes;
        }
        public Public()
        {
            
        }
        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Type of Public car is: {Types}");
            Console.WriteLine($"Numbers of Wheel of Public is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Public is: {SpeedKmH}");
            Console.WriteLine($"Numbers of Passenger of Public is: {Passenger}");
        }
        public void publicMethod(string userInput1)
        {
            switch (userInput1)
            {
                case "Bus":
                    Console.WriteLine("----------Create Object-----------");
                    Console.Write("Enter Num of Wheel: ");
                    int NumOfWheel = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Speed: ");
                    int SpeedKmH = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter num of passanger: ");
                    int passanger = Convert.ToInt32(Console.ReadLine());
                    publictypes publicTypes = publictypes.Bus;
                    Public bus = new Public(NumOfWheel, SpeedKmH, passanger, publicTypes);
                    bus.PrintInfo();
                    break;
                case "Tram":
                    Console.WriteLine("----------Create Object-----------");
                    Console.Write("Enter Num of Wheel: ");
                    NumOfWheel = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter Speed: ");
                    SpeedKmH = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter num of passanger: ");
                    passanger = Convert.ToInt32(Console.ReadLine());
                    publicTypes = publictypes.Tram;
                    Public tram = new Public(NumOfWheel, SpeedKmH, passanger, publicTypes);
                    tram.PrintInfo();
                    break;
                case "Info":
                    Console.WriteLine("----------Print Info-----------");
                    Console.Write("You choose Public car: ");
                    break;
            }
        }

    }
    public enum publictypes
    {
        Bus,
        Tram,
        Info
    }
}