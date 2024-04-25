namespace Geography_Now_
{
    internal abstract class GeographicEntity
    {
        public string Name { get; set; }
        public int Popualtion { get; set; }
        public decimal Area { get; set; }
    }
    internal class City : GeographicEntity
    {
        public bool Capital { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
           
                return $"Name : {Name}, Area : {Area}, is capital city : {Capital},Country : {Country},  Popualtion : {Popualtion}";
           

        }

    }
    internal class Country : GeographicEntity
    {
        public Country(string name, List<City> cityes) 
        {
            Cityes = cityes;
            Name = name;
            Area = CalculateArea();
            Popualtion = CalculatePopulation();
        }
       // public string CapitalCity { get; set; }
       
        List<City> Cityes { get; set; }
        public decimal CalculateArea()
        {
            decimal countArea = 0; 
            if( Cityes != null && Cityes.Count > 0 )
            {
                foreach(City city in Cityes)
                {
                    countArea += city.Area;
                }
            }
            return countArea;
        }
        public int CalculatePopulation()
        {
            int countPopulation = 0;
            if(Cityes != null && Cityes.Count > 0)
            {
                foreach(City city in Cityes)
                {
                    countPopulation += city.Popualtion;
                }
            }
            return countPopulation; 
        }
        public override string ToString()
        {
            try
            {
                string cities = Cityes[0].Name;
                for (int i = 1; i < Cityes.Count; i++)
                {
                    cities += ", " + Cityes[i].Name;
                }
                return $"Name : {Name}, Area : {Area}, cities : {cities}, Popualtion : {Popualtion}";
            }
            catch
            {
                throw new  Exception("Your entered invalid country name!");
            }
        }

    }
}