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
            //  Create a FileSystemWatcher to monitor all files on drive C.
            FileSystemWatcher watcher = new FileSystemWatcher("C:\\localhost"); //CHANGED PATH

            //  Look only at .ini files
            watcher.Filter = "*.ini";
            watcher.IncludeSubdirectories = true;

            //  Watch for changes in LastAccess and LastWrite times, and
            //  the renaming of files or directories. 
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Attributes | NotifyFilters.Size;

            //  Register a handler that gets called when a 
            //  file is created, changed, or deleted.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);

            //  Register a handler that gets called when a file is renamed.
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            //  Register a handler that gets called if the 
            //  FileSystemWatcher needs to report an error.
            watcher.Error += new ErrorEventHandler(OnError);

            //  Begin watching.
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press \'Enter\' to quit the sample.");
            Console.ReadLine();
        }

        //  These methods explain what to do if there is a change.

        //  This method is called when a file is created, changed, or deleted.
        private static void OnChanged(object source, FileSystemEventArgs e)
        {
            //  Show that a file has been created, changed, or deleted.
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {1}", e.FullPath, wct.ToString());
        }

        //  This method is called when a file is renamed.
        private static void OnRenamed(object source, RenamedEventArgs e)
        {
            //  Show that a file has been renamed.
            WatcherChangeTypes wct = e.ChangeType;
            Console.WriteLine("File {0} {2} to {1}", e.OldFullPath, e.FullPath, wct.ToString());
        }

        //  This method is called when the FileSystemWatcher detects an error.
        private static void OnError(object source, ErrorEventArgs e)
        {
            //  Show that an error has been detected.
            Console.WriteLine("The FileSystemWatcher has detected an error");
            //  Give more information if the error is due to an internal buffer overflow.
            if (e.GetException().GetType() == typeof(InternalBufferOverflowException))
            {
                //  This can happen if Windows is reporting many file system events quickly 
                //  and internal buffer of the  FileSystemWatcher is not large enough to handle this
                //  rate of events. The InternalBufferOverflowException error informs the application
                //  that some of the file system events are being lost.
                Console.WriteLine(("The file system watcher experienced an internal buffer overflow: " + e.GetException().Message));
            }
        }
    }
}
