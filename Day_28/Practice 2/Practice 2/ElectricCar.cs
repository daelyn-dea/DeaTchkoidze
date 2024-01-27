using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal class ElectricCar
    {
        public ElectricCar(int batteryLevel, ModelType model, int year, int index)
        {
            BatteryLevel = batteryLevel;
            Model = model;
            Year = year;
            Index = index;
        }

        public int BatteryLevel { get; set; }
        public ModelType Model { get; set; }
        public int Year { get; set; }
        public int Index { get; set; }

        public async Task Charge()
        {
            while(BatteryLevel < 100)
            {
                await Task.Delay(10000);
                BatteryLevel += 5;

                if(BatteryLevel > 100)
                    BatteryLevel = 100;
            }
        }
        public override string ToString()
        {
            return $"Model : {Model,-10} Year : {Year,-8} Battery Level : { BatteryLevel, -6 }  index : {Index}";   
        }
    }
    enum ModelType
    {
        Tesla = 1,
        ModelX,
        ModelS
    }
}
