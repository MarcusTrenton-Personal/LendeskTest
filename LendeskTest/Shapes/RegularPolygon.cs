using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendeskTest.Shapes
{
    public struct RegularPolygon : IShape
    {
        public readonly int sideCount;
        public readonly double sideLength;

        public RegularPolygon(int sideCount, double sideLength)
        {
            if (sideLength < 0)
            {
                throw new ArgumentException("Parameter cannot be negative", "sideLength");
            }
            if (sideCount < 3)
            {
                throw new ArgumentException("Parameter must be at least 3", "sideCount");
            }

            this.sideLength = sideLength;
            this.sideCount = sideCount;
        }

        public string Name
        {
            get
            {
                string name = String.Empty;
                switch(sideCount)
                {
                    case 3: name = "triangle";  break;
                    case 4: name = "square";    break;
                    case 5: name = "pentagon";  break;
                    case 6: name = "hexagon";   break;
                    case 7: name = "heptagon";  break;
                    case 8: name = "octagon";   break;
                    case 9: name = "nonagon";   break;
                    case 10: name = "decagon";  break;

                    default:
                        name = String.Format("{0}-gon", sideCount);
                        break;
                }
                return name;
            }
        }

        public double Perimeter
        {
            get
            {
                return sideLength * sideCount;
            }
        }

        public double Area
        {
            get
            {
                return sideLength * sideLength * sideCount / (4 * Math.Tan(Math.PI / sideCount));
            }
        }

        public override string ToString()
        {
            return String.Format("{0}, with a side length of {1}, having a perimeter of {2}, and an area of {3} units square.", Name, sideLength, Math.Round(Perimeter, 2), Math.Round(Area, 2));
        }
    }
}
