using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics; //must be added for the Event Log

namespace EventLogDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // **** Write EVENT LOG.  Program MUST BE RAN using Visual Studio as administrator.

            //if event log does not exist create one on Application level
            if (!EventLog.SourceExists("Chapter10DemoApplication","."))
            {
                EventLog.CreateEventSource("Chapter10DemoApplication","Application"); 
                //string source, log logname-Application, System, or Custom
            }

            EventLog DemoLog = new EventLog("Application", ".", "Chapter10DemoApplication");
            //logname, system, source
            DemoLog.WriteEntry("War, War never changes - Entry Written", EventLogEntryType.Information, 234, Convert.ToInt16(3));

            //Read From event log

            foreach (EventLogEntry DemoEntry in DemoLog.Entries)
            {
                Console.WriteLine(DemoEntry.Source + ":" + DemoEntry.Message);
            }
        }
    }
}
