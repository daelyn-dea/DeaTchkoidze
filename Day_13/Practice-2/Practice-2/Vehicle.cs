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

        int SpeedKmH { get; set; }

        VehicleTypes VehicleTypes { get; set; }

        public Vehicle( )
        {
           
        }
        public virtual void PrintInfo()
        {

        }
    }

    public enum VehicleTypes
    {
        Combat,
        Consumer,
        Public,
        Sport
    }

}