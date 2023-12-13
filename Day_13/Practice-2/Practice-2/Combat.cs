using Practice_02;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal class Combat : Vehicle
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }

        int PowerOfShot { get; set; }
        combatTypes CombatTypes { get; set; }
        public Combat()
        {

        }

        public override void PrintInfo()
        {
            Console.WriteLine($"You choose Combat, have to choose type of Combat");
        }

        
    }
    public enum combatTypes
    {
        Tank,
        Betteer,
        Info
    }
    internal class Tank : Combat 
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        int PowerOfShot { get; set; }
        int BarrelLength { get; set; }
        public Tank(int numOfWheel, int speedKmH, int powerOfShot, int barrelLength, VehicleTypes vehicleTypes, combatTypes combatTypes) 
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            PowerOfShot = powerOfShot;
            BarrelLength = barrelLength;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Numbers of Wheel of Tank is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Tank is: {SpeedKmH}");
            Console.WriteLine($"Colors of Tank is: {PowerOfShot}");
            Console.WriteLine($"Barrel Lentgh  of Tank is: {BarrelLength}");
        }
    }
    internal class Beteer : Combat
    {
        int NumOfWheel { get; set; }
        int SpeedKmH { get; set; }
        int PowerOfShot { get; set; }
        int NumOfRockets { get; set; }
        public Beteer(int numOfWheel, int speedKmH, int powerOfShot, int numOfRockets, VehicleTypes vehicleTypes, combatTypes combatTypes) 
        {
            NumOfWheel = numOfWheel;
            SpeedKmH = speedKmH;
            PowerOfShot = powerOfShot;
            NumOfRockets = numOfRockets;
        }

        public override void PrintInfo()
        {
            Console.WriteLine("----------Print Finally Info-----------");
            Console.WriteLine($"Numbers of Wheel of Beteer is: {NumOfWheel}");
            Console.WriteLine($"Speed in kilometer per houer of Beteer is: {SpeedKmH}");
            Console.WriteLine($"Colors of Beteer is: {PowerOfShot}");
            Console.WriteLine($"Number Of Rockets  of Beteer is: {NumOfRockets}");
        }
        
    }
}