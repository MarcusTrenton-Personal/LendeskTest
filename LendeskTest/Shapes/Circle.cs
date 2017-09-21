using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendeskTest.Shapes
{
    public struct Circle : IShape
    {
        public readonly double radius;

        public Circle(double radius)
        {
            if(radius < 0)
            {
                throw new ArgumentOutOfRangeException("Parameter cannot be negative", "radius");
            }
            this.radius = radius;
        }

        public string Name
        {
            get
            {
                return "circle";
            }
        }

        public double Perimeter
        {
            get
            {
                return 2 * Math.PI * radius;
            }
        }

        public double Area
        {
            get
            {
                return Math.PI * radius * radius;
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, with a radius of {1}, having a perimeter of {2}, and an area of {3} units square.", Name, radius, Math.Round(Perimeter, 2), Math.Round(Area, 2));
        }
    }
}
