using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; //added for performance 
using System.Timers; //added for timer

namespace PerformanceCounterDemo
{
    //Class will display the number of Bytes in all heaps
    class Program
    {
        //private class members
        private static PerformanceCounter HeapCounter = null;
        private static PerformanceCounter ExceptionCounter = null;
        private static Timer DemoTimer;

        static void Main(string[] args)
        {
            DemoTimer = new Timer(3000);  //pass value 3000 (3 seconds) to overloaded Timer constructor

            //Add handler for elapsed event
            DemoTimer.Elapsed += new ElapsedEventHandler(OnTick);

            //Set DemoTimer object to true
            DemoTimer.Enabled = true;

            //Instantiate HeapCounter and ExceptionCounters
            HeapCounter = new PerformanceCounter(".NET CLR Memory", "# Bytes in all Heaps");
            HeapCounter.InstanceName = "_Global_";

            ExceptionCounter = new PerformanceCounter(".NET CLR Exceptions", "# of Exceps Thrown");
            ExceptionCounter.InstanceName = "_Global_";

            //allow application to run until Enter is pressed
            Console.WriteLine("Press [Enter] to Quit the Program");
            Console.ReadLine();
        }

        //EventHandler for the DemoTmer's elapsed event
        private static void OnTick(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("# of Bytes in all Heaps : " + HeapCounter.NextValue().ToString());
            Console.WriteLine("# of Framework Exceptions Thrown : " + ExceptionCounter.NextValue());
        }
    }
}
