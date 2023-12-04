
namespace _Triangle
{
    internal class Triangle
    {
        double _Side1;
        double _Side2;
        double _Side3;

        public double Side1
        {
            get
            {
                return _Side1;
            }
            set
            {
                if(value > 0)
                {
                    _Side1 = value;
                }
            }
        }
        public double Side2
        {
            get
            {
                return _Side2;
            }
            set
            {
                if (value > 0)
                {
                    _Side2 = value;
                }
            }
        }
        public double Side3
        {
            get
            {
                return _Side3;
            }
            set
            {
                if (value > 0 && _Side1 + _Side2 > value && _Side1 + value > _Side2 && _Side2 + value > _Side1)
                {
                    _Side3 = value;
                }
                else
                {
                    Console.WriteLine("It isn't valid Triangle");
                }
            }
        }
        public void CalculateArea()
        {
            if (_Side1 + _Side2 > _Side3 && _Side1 + _Side3 > _Side2 && _Side2 + _Side3 > _Side1)
            {
                double s = (_Side1 + _Side2 + _Side3) / 2;
                double area = Math.Sqrt(s * (s - _Side1) * (s - _Side2) * (s - _Side3));
                Console.WriteLine($"Area of the triangle is: {area}");
            }
        }
        public void CalculatePerimeter()
        {
            if (_Side1 + _Side2 > _Side3 && _Side1 + _Side3 > _Side2 && _Side2 + _Side3 > _Side1)
            {
                double perimeter = Side1 + Side2 + Side3;
                Console.WriteLine($"Perimeter of the triangle is: {perimeter}");
            }
        }
    }
}
