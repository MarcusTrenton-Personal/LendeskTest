using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LendeskTest.Shapes
{
    public interface IShape
    {
        string Name
        {
            get;
        }

        double Perimeter
        {
            get;
        }

        double Area
        {
            get;
        }
    }
}
