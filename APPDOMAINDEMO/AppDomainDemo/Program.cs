using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppDomainDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an app domain
            AppDomain d = AppDomain.CreateDomain("BY FILE APP DOMAIN 3");

            //Code to run assembly for FileDemo (previously created);
            //FileDemo.exe

            /* Use this code to run by Filename*/
            /*
            string fileDemoExe = "C:\\Users\\wkkah\\OneDrive\\Walter\\Programming Training\\C#\\Programs\\First Cs Project\\FILEDEMO\\FileDemo\\FileDemo\\bin\\Debug\\FileDemo.exe";
            d.ExecuteAssembly(fileDemoExe);
            */

            AppDomain dom1 = AppDomain.CreateDomain("BY ASSEMBLY APP DOMAIN 1");
            AppDomain dom2 = AppDomain.CreateDomain("BY ASSEMBLY APP DOMAIN 2");
            
            //YOU MUST ADD REFERENCE TO THE FILEDEMO THROUGH SOLUTION EXPLORER MENU FOR THIS TO WORK
            Console.WriteLine("Here is program FILEDEMO createed through AppDomain 1");
            Console.WriteLine("-----------------------------------------------------\n");
            dom1.ExecuteAssemblyByName("FileDemo");
            Console.WriteLine("");

            //YOU MUST ADD REFERENCE TO THE BASICCOLLECTION THROUGH SOLUTION EXPLORE MENU FOR THIS TO WORK
            //BROWSE BY FILE TO FIND FILE ELSEWHERE
            Console.WriteLine("Here is program BASICCOLLECTION created through AppDomain 2");
            Console.WriteLine("-----------------------------------------------------\n");
            dom2.ExecuteAssemblyByName("BasicCollection");
            Console.WriteLine("");

            



        }
    }
}
