using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace EncodingTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //must update myPath and newPath to something on your computer. This is not universal */
            string myPath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\Clever Programming - Python 2020\lesson3_calendar.py - Copy.txt";
            string myNewPath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\Clever Programming - Python 2020\lesson3_calendar.py - Copy2.txt";
            StreamReader sr = new StreamReader(myPath);
            StreamWriter sw = new StreamWriter(myNewPath, false, Encoding.UTF7);
            sw.WriteLine(sr.ReadToEnd());
            sw.Close();
            sr.Close();           
        }
    }
}
