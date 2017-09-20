using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace LendeskTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n------Problem 1-----\n");
            int[] oneToSix = {1,2,3,4,5,6};
            Problem1<int>(elements: oneToSix);

            Console.WriteLine("\n------Problem 2-----\n");
            Problem2("<a><b><c><d><e><f></f></e></d></c></b></a>");

            //Hack to keep the console program open for viewing after the logic has finished.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        static void Problem1<T>(IList<T> elements, string indent = "")
        {
            if(elements.Count > 0)
            {
                T first = elements[0];
                Console.WriteLine(indent + "<{0}>", first);

                if (elements.Count > 1)
                {
                    string increasedIndent = indent + "  "; //2 spaces to exactly match the question. Could use a tab instead.

                    IList<T> withoutFirst = elements.Skip(1).ToList<T>();
                    Problem1(elements: withoutFirst, indent: increasedIndent);
                }
         
                Console.WriteLine(indent + "</{0}>", first);
            }
        }

        static void Problem2(string xml)
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(xml);

                //Straight from msdn, because you might as well copy-paste from the official source
                //https://msdn.microsoft.com/en-us/library/system.xml.xmldocument.writeto(v=vs.110).aspx
                XmlTextWriter writer = new XmlTextWriter(Console.Out);
                writer.Formatting = Formatting.Indented;
                doc.WriteTo(writer);
                writer.Flush();
            }
            catch (XmlException exception)
            {
                Console.Error.WriteLine(exception);
            }
        }
    }
}
