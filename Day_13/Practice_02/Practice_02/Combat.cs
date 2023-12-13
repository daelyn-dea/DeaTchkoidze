using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_02
{
    internal  class Combat : Vehicle
    {
       

        public override void PrintInfo()
        {
            Console.WriteLine($"Numbers of Wheel is: {NumOfWheel}");
            Console.WriteLine($"Colors of Vehicle is: {ColorOfVehicle}");
            Console.WriteLine($"Speed in kilometer per houer of vehicle is: {speedKmH}");
        }
    }
}
