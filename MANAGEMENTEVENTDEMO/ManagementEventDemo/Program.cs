using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//need to add management and diagnostics
using System.Diagnostics;
using System.Management;

//also add assembly reference to System.Management

//Write Management event ot a log
namespace ManagementEventDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToEventLog();
            Console.ReadLine();
        }

        public static void WriteToEventLog()
        {
            //Wql is an EventQuery Object, represents a WMI event query in WQL format
            WqlEventQuery DemoQuery = new WqlEventQuery("__InstanceCreationEvent" //event class name (name to query)
                                                        , new TimeSpan(0, 0, 1) //within interval
                                                        , "TargetInstance isa \"Win32_Process\""); //condition to apply WMI code
            ManagementEventWatcher DemoWatcher = new ManagementEventWatcher();

            DemoWatcher.Query = DemoQuery;
            DemoWatcher.Options.Timeout = new TimeSpan(0, 0, 30);

            Console.WriteLine("Open an application to trigger an event.");

            ManagementBaseObject e = DemoWatcher.WaitForNextEvent();

            //Console.WriteLine("got through managementbaseobject initialization");

            EventLog DemoLog = new EventLog();
            DemoLog.Source = "Chap10.4 Demo";

            String EventName = ( (ManagementBaseObject) e["TargetInstance"] ) ["Name"].ToString();
            Console.WriteLine(EventName);

            DemoLog.WriteEntry(EventName, EventLogEntryType.Information);
        }
    }
}
