using System.Globalization;

namespace Geography_Now_
{
    internal static class FileRead
    {
        internal static List<City> fileReadMethod()
        {
            List<City> cityList = new List<City>();

            string path = @"C:\Users\dchko\Desktop\visual studio\.NET\Day_20\Cities.txt";
            
                using (StreamReader sr = new StreamReader(path))
                {

                    var line = sr.ReadLine();
                    if (line != null)
                    {
                    string[] array1 = line.Split('|');
                    while (line != null && array1.Length > 1)
                        {
                                City cities = new City()
                                {
                                    Name = array1[0],
                                    Area = Convert.ToDecimal(array1[1], new CultureInfo("fr-FR")),
                                    Popualtion = Convert.ToInt32(array1[2]),
                                    Capital = Convert.ToBoolean(array1[3]),
                                    Country = array1[4]
                                };

                                cityList.Add(cities);

                                line = sr.ReadLine();
                                array1 = line.Split('|');
                        }
                    }
                    else
                    {
                        throw new Exception($"File is empty");
                    }
                }
                return cityList;
         }     
     }
 }