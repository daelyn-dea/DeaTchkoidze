using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_2
{
    internal static class CarsGenerator
    {
        private static Random random = new Random();
        public static List<ElectricCar> GenerateCars()
        {
            List<ElectricCar> carsList = new List<ElectricCar>();
            for(int i = 0; i < 20; i++)
            {
                int bateryLevel = random.Next(2,100);
                ModelType modelOfCars = (ModelType)random.Next(1, 4);
                int year = random.Next(2018, 2024);
                carsList.Add(new ElectricCar(bateryLevel, modelOfCars, year, i));
            }
            return carsList;
        }
    }
}
