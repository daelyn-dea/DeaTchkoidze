using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    internal abstract class Shape
    {
        public virtual void Perimeter()
        {

        }
        public virtual void Area()
        {

        }
        protected static double Length(Point num, Point num2)
        {
            return Math.Sqrt(Math.Pow(num.x - num2.x, 2) + Math.Pow(num.y - num2.y, 2));
        }
    }
    internal  class Triangle : Shape
    {
        public Triangle(Point a, Point b, Point c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        Point a { get; set; }
        Point b { get; set; }
        Point c { get; set; }

        
        public override void Perimeter()
        {
            double perimeter = Length(a, b) + Length(b, c) + Length(c, a);
            Console.WriteLine($"traingle Perimeter is {perimeter}");
        }
        public override void Area()
        {
            double s = (Length(a, b) + Length(b, c) + Length(c, a)) / 2;
            double area = Math.Sqrt(s * (s - Length(a, b)) * (s - Length(b, c)) * (s - Length(c, a)));
            Console.WriteLine($"triangle Area is: {area}");
        }
    }
    internal class Square : Shape
    {
        public Square(Point a, Point b, Point c, Point d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        Point a { get; set; }
        Point b { get; set; }
        Point c { get; set; }
        Point d { get; set; }


        public override void Perimeter()
        {
            double perimeter = Length(a, b) + Length(b, c) * 2;
            Console.WriteLine($"Square Perimeter is {perimeter}");
        }
        public override void Area()
        {
            double area = Length(a, b) * Length(b, c);
            Console.WriteLine($"Square area is {area}");
        }
    }
    internal class Circle : Shape
    {
        public Circle(Point a, Point b)
        {
            this.a = a;
            this.b = b;
        }

        Point a { get; set; }
        Point b { get; set; }
        public override void Perimeter()
        {
            double perimeter = 2 * Math.PI * Length(a, b);
            Console.WriteLine($"circle Perimeter is {perimeter}");
        }
        public override void Area()
        {
            double area = Math.PI * Math.Pow(Length(a, b),2);
            Console.WriteLine($"circle area is {area}");
        }
    }

}
