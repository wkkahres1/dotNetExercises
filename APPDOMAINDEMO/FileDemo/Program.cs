using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using System.Reflection;

//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!//
//
//Filedemo reference was added to AppDomainDemo 
//

namespace FileDemo
{
    //added to FileDemo to allow the domain
  //  [Serializable]
    class FileDemo
    {
        static void Main(string[] args)
        {
            //Exercise 2.2.1 and 2.2.2. - really easy basic read and write to a file
            //creating a writer
            StreamWriter writer = File.CreateText(@"C:\localhost\Powder.txt");
            /*NOTE:  My niece told me this to put in the file and incidently named the file.  It can be anything*/
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

