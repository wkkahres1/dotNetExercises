using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, String> countryCodeName = new Dictionary<int, String>();
            countryCodeName[0] = "United States";
            countryCodeName[1] = "Canada";
            countryCodeName[2] = "Mexico";
            countryCodeName[3] = "United Kingdom";
            countryCodeName[4] = "France";
            countryCodeName[5] = "Germany";
            countryCodeName[6] = "Spain";
            countryCodeName[7] = "Italy";
            countryCodeName[8] = "India";
            countryCodeName[9] = "South Africa";
            countryCodeName[10] = "Brazil";
            // countryCodeName["11"] = "Egypt";

            Console.WriteLine("The code 4 refers to country {0}. ", countryCodeName[4]);
            Console.WriteLine(""); 

            foreach(KeyValuePair<int,String> item in countryCodeName)
            {
                Console.WriteLine("{0} = {1}", item.Key, item.Value);
            }
            Console.WriteLine("");
        }
    }
}
