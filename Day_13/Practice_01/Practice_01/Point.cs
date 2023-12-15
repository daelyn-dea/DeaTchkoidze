using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_01
{
    internal class Point
    {
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        internal int x { get; }
        internal int y { get; }
    }
}
