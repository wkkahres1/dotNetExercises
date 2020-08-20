using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//App Config is added automatically

namespace ConnectionStringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Is this working?");
            // DemoConnectionStringHandler.GetAllConnectionStrings();\
            DemoConnectionStringHandler.GetSpecificConnectionString(RetrievalType.ByName, "AdventureWorksString");
            DemoConnectionStringHandler.GetSpecificConnectionString(RetrievalType.ByName, "MarsEnabledSqlServer2005String");

            Console.WriteLine("");
            DemoConnectionStringHandler.GetSpecificConnectionString(RetrievalType.ByProviderType, "System.Data.SqlClient");

            Console.ReadLine();
        }
    }
}
