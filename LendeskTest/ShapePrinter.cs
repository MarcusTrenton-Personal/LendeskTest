using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using LendeskTest.Shapes;

namespace LendeskTest
{
    public class ShapePrinter
    {
        readonly IList<IShape> shapes;

        public ShapePrinter(string filePath)
        {
            if(filePath == null)
            {
                throw new ArgumentException("Parameter cannot be null", "filePath");
            }

            shapes = new List<IShape>();

            string line;
            using (StreamReader file = new StreamReader(filePath))
            {
                while ((line = file.ReadLine()) != null)
                {
                    IShape shape = ParseShape(line);
                    shapes.Add(shape);
                }

                file.Close();
            }
        }

        private IShape ParseShape(string text)
        {
            string[] strings = text.Split(',');
            if(strings.Length != 2)
            {
                throw new ArgumentException("Parameter must be a csv line with 2 values", "text");
            }

            string name = strings[0];
            double measurement = Double.Parse(strings[1]);
            IShape shape = null;
            switch(name)
            {
                case "circle":      shape = new Circle(radius: measurement); break;
                case "triangle":    shape = new RegularPolygon(sideCount: 3, sideLength: measurement); break;
                case "square":      shape = new RegularPolygon(sideCount: 4, sideLength: measurement); break;
                case "pentagon":    shape = new RegularPolygon(sideCount: 5, sideLength: measurement); break;
                case "hexagon":     shape = new RegularPolygon(sideCount: 6, sideLength: measurement); break;
                case "heptagon":    shape = new RegularPolygon(sideCount: 7, sideLength: measurement); break;
                case "octagon":     shape = new RegularPolygon(sideCount: 8, sideLength: measurement); break;
                case "nonagon":     shape = new RegularPolygon(sideCount: 9, sideLength: measurement); break;
                case "decagon":     shape = new RegularPolygon(sideCount: 10, sideLength: measurement); break;

                default:
                    throw new ArgumentException("Text contains unrecongnized shape name: " + name);
            }

            return shape;
        }

        public void Print(TextWriter writer)
        {
            int count = 1;
            foreach (IShape shape in shapes)
            {
                writer.WriteLine("Shape {0} is a " + shape.ToString(), count);
                ++count;
            } 
        }
    }
}
