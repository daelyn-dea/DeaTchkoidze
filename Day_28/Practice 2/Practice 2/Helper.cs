using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal  static class Helper
    {
        public static  void  Start()
        {
            List<ElectricCar> listOfCars = CarsGenerator.GenerateCars();

            foreach (var car in listOfCars)
            {
                Console.WriteLine(car);
            }

           Console.WriteLine($"\n Total second:  {ChargeCars.RunChargingTasks(listOfCars)} \n");

            foreach (var car in listOfCars)
            {
                Console.WriteLine(car);
            }
        }
    }
}
