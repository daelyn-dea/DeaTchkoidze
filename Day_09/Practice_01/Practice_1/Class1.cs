
namespace _Cat
{
    class Cat
    {
        string _Name;
        int _Grams = 10;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }
        public string Breed { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }

        public void Eating(int grams)
        {
            Console.WriteLine("Tom start eating");
            int bites = grams / _Grams;
            if (grams % _Grams > 0)
            {
                bites++;
            }
            for (int i = 0; i < bites; i++)
            {
                Console.WriteLine("Eating...");
            }
            Console.WriteLine("Tom finished eating");
        }
        public void Meowing(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("Meowing...");
            }
        }
    }

}

