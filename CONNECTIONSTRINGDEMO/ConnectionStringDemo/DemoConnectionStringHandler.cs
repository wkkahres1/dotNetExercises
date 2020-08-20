using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add all these
using System.Data;

using System.Configuration;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Data.OleDb;
//using System.Data.OracleClient;
using System.Data.Odbc;
using System.Web;

/*NOTES 
 * add all libraries
 * add a reference to System.Configuration
 * CHECK AND DOUBLE CHECK SPELLINGS IN App.Config, lots of issues there
*/

namespace ConnectionStringDemo
{
    public enum RetrievalType
    {
        ByName = 0,
        ByProviderType = 1
    }

    class DemoConnectionStringHandler
    {
        private String _MyValue;
        public String MyValue
        {
            get { return this._MyValue; }
            set { this._MyValue = value; }
        }

        public static void GetSpecificConnectionString(RetrievalType type, String typeOrName)
        {
            if (typeOrName == string.Empty || typeOrName == null)
            {
                throw new ArgumentException("Name cannot be empty");
            }
            switch (type)
            {
                case RetrievalType.ByName:
                    ConnectionStringSettings MySettings =
                        ConfigurationManager.ConnectionStrings[typeOrName];
                    Debug.Assert(MySettings != null, "The name does not appear to exist.  Verify it in the configuration file");
                    if (MySettings != null)
                    {
                        Console.WriteLine(MySettings.ConnectionString);
                    }
                    break;

                case RetrievalType.ByProviderType:
                    ConnectionStringSettingsCollection MyTypeSettings = ConfigurationManager.ConnectionStrings;
                    //DEBUG //Console.WriteLine("Created My Type settings");

                    Debug.Assert(MyTypeSettings != null, "Type does not appear to present.");

                    //DEBUG //int i = 0;
                    if (MyTypeSettings != null)
                    {
                        foreach (ConnectionStringSettings typeSettings in MyTypeSettings)
                        {
                            if (typeSettings.ProviderName == typeOrName)
                            {
                                SqlConnection MyConnection = new SqlConnection(typeSettings.ConnectionString);
                                Console.WriteLine("Connection String" + typeSettings.ConnectionString);
                            }
                            //DEBUG
                            //i++;
                            //Console.WriteLine($"went through foreach loop{i} times");
                            //Console.WriteLine(MyTypeSettings[i - 1]);
                        }
                    }
                    break;
            }
        }

        public static void GetAllConnectionStrings()
        {
            
            ConnectionStringSettingsCollection MySettings = ConfigurationManager.ConnectionStrings;
            //DEBUG //Console.WriteLine("Made it here");

            if (MySettings == null)
            {
                Console.WriteLine("MySettings was not created properly");
            }
            else
            {
                Console.WriteLine("My settings is NOT null");
            }

            Debug.Assert(MySettings != null);
            //Should fail if no values are present
            if (MySettings != null)
            {
                StringBuilder sb = new StringBuilder();
                foreach (ConnectionStringSettings individualSettings in MySettings)
                {
                    sb.Append("Full Connection String: " + individualSettings.ConnectionString + "\r\n");
                    sb.Append("Provider Name: " + individualSettings.ProviderName + "\r\n");
                    sb.Append("Section Name: " + individualSettings.Name + "\r\n");
       
                }
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
