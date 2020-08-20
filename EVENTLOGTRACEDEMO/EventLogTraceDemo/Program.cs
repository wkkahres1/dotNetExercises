using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; // neeed this and System for this Demo, diagnostics is for debugging

namespace EventLogTraceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Clear(); //clears all the listeners from the Trace List

            Trace.AutoFlush = true; //Trace.Flush called on Listener after every write

            //Add a listener
            Trace.Listeners.Add(new EventLogTraceListener("Chap10Demo - The Cake is A Lie"));

            //Trace.Listeners.Add(MyListener);

            Trace.WriteLine("This is a test");
        }
    }
}