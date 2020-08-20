using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileWatchingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string dir = @"C:\localhost";
            FileSystemWatcher watcher = new FileSystemWatcher(Environment.SystemDirectory);

            watcher.Filter = "*.html"; //sets watcher to look for .ini files
            watcher.IncludeSubdirectories = true; //inscludes watching subdirectories for changes
            watcher.NotifyFilter = NotifyFilters.Attributes | NotifyFilters.Size;
            // sets NotifyFilter to watch Attributes and Size changes

            watcher.WaitForChanged(Changed,60000);

            // Wait for the user to quit the program.
            // Console.WriteLine("Press 'q' to quit the sample.");
            // while (Console.Read() != 'q') ;

            //handler for changed event of the watcher object
            watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            //watcher_changed is the method that will return this value

            void watcher_Changed(object sender, FileSystemEventArgs e)
            {
                Console.WriteLine("Changed: {0}", e.FullPath); //prints fullpath of the object changed from FileSystemEventArgs e
            }

            // watcher.EnableRaisingEvents = true;

            watcher.EnableRaisingEvents = true; //turns watcher on
            Console.WriteLine("Watcher is on!!");
            Console.WriteLine();



        }
    }
} 
