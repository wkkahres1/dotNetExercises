using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Reflection;

namespace FileDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Exercise 2.2.1 and 2.2.2. - really easy basic read and write to a file
            //creating a writer
            StreamWriter writer = File.CreateText(@"C:\localhost\Powder.txt");
            writer.WriteLine("I forgot what weird thing Bre Said to put in this file");
            writer.WriteLine("Bre said its alright to just say something about \" Revenge of the Slimes \"");
            writer.Close();

            //creating a reader
            StreamReader reader = File.OpenText(@"C:\localhost\Powder.txt");
            string contents = reader.ReadToEnd();
            reader.Close();
            Console.WriteLine(contents);

            //Getting Assembly information (used in another program ;) )

            Console.WriteLine(Assembly.GetExecutingAssembly().GetName());
            //Console.WriteLine(a);
        
            
        }
    }
}
