using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_02
{
    internal abstract class Vehicle
    {
       int NumOfWheel { get; set; }
       string ColorOfVehicle { get; set; }
       int SpeedKmH { get; set; }

        public Vehicle( int numOfWheel, string colorOfVehicle, int speedKmH)
        {
            NumOfWheel = numOfWheel;
            ColorOfVehicle = colorOfVehicle;
            SpeedKmH = speedKmH;
        }
        public virtual void PrintInfo()
        {
            
        }
    }
}
