
namespace _Triangle
{
    internal class Triangle
    {
        int _Side1;
        int _Side2;
        int _Side3;

        public int Side1
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
        public int Side2
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
        public int Side3
        {
            get
            {
                return _Side3;
            }
            set
            {
                if (value > 0)
                {
                    _Side3 = value;
                }
            }
        }
        public double CalculateArea()
        {
            double s = (_Side1 + _Side2 + _Side3) / 2;
            return Math.Sqrt(s * (s - _Side1) * (s - _Side2) * (s - _Side3));
        }
        public double CalculatePerimeter()
        {
            return Side1 + Side2 + Side3;
        }
        public bool ValidateTriangle()
        {
            if(_Side1+_Side2>_Side3 && _Side1+_Side3>_Side2 && _Side2 + _Side3 > _Side1)
            {
                return true;
            }
            return false;
        }
    }
}
