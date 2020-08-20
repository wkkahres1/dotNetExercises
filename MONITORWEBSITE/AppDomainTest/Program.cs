using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//not needed for monitorWebSite.. this was made for debugging AppDomain only

namespace AppDomainTest
{
    class Program
    {
        static void Main(string[] args)
        {

            string logPath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\log.txt";
            string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt";

            //original call
            Console.WriteLine(@"Original Call without +:  " + AppDomain.CurrentDomain.SetupInformation.ApplicationBase);
            Console.WriteLine(@"Original Call from program:  " + AppDomain.CurrentDomain.SetupInformation.ApplicationBase + logPath);
            Console.WriteLine();

            //Application Domain Setup information
            AppDomainSetup domaininfo = new AppDomainSetup();
            domaininfo.ApplicationBase = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\MONITORWEBSITE";
            domaininfo.ConfigurationFile = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\MONITORWEBSITE\log.txt";
            
            //Creates the AppDomain
            AppDomain domain = AppDomain.CreateDomain("MyDomain", null, domaininfo);

            //Writes information to the Console
            Console.WriteLine(@"Host domain:  " + AppDomain.CurrentDomain.FriendlyName);
            Console.WriteLine(@"Child domain:  " + domain.FriendlyName);
            Console.WriteLine(@"Application Base:  " + domain.SetupInformation.ApplicationBase);
            Console.WriteLine(@"Configuration file is " + domain.SetupInformation.ConfigurationFile);
            Console.WriteLine(@"String Path:  " + path);
            Console.WriteLine(@"Original Path:  " + AppDomain.CurrentDomain.SetupInformation.ApplicationBase + logPath );
            


        }
    }
}
