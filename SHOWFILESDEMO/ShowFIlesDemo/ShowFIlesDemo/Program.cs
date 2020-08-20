using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            //need to set directory to monitor
            string directory = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\Coding with Mosh";
            DirectoryInfo direct = new DirectoryInfo(directory);
            ShowDirectory(direct);

            void ShowDirectory(DirectoryInfo dir) //DirectoryInfo a class in System.IO
            {
                foreach (FileInfo file in dir.GetFiles()) //FileInfo a class, DirectoryInfo Getfiles() retrieves an array of
                                                          //FileInfo objects that represent all files in current directory
                {
                    Console.WriteLine("File: {0}", file.FullName); //each iteration Writes each fule filenamecd  in the directory
                }

                foreach (DirectoryInfo subdir in dir.GetDirectories()) //DirectoryInfo a class, DirectoryInfo GetDirectories()
                                                                       //retireves an array of DirectoryInfo objects that represent directories of the  
                                                                       //current directory
                {
                    ShowDirectory(subdir); // recursively callse
                }
            }
        }
    }
}
