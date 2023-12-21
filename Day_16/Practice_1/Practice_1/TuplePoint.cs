using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_1
{
    public class TuplePoint
    {
        public TuplePoint(Tuple<double, double> pointA, Tuple<double, double> pointB)
        {
            PointA = pointA;
            PointB = pointB;
        }

        Tuple<double, double> PointA { get; set; }
        Tuple<double, double> PointB { get; set; }

        public double CalculateLength(Tuple<double, double> pointA, Tuple<double, double> pointB)
        {
            double deltaX = pointA.Item1 - pointB.Item1;
            double deltaY = pointA.Item2 - pointB.Item2;
            double distance = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
            return distance;
        }
    }
}