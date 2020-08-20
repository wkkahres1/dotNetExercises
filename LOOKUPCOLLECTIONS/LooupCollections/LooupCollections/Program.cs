using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.Specialized;
using System.Globalization;
using System.Collections;

namespace LooupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary list = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
            //ListDictionary specfiying caseInsensitive and culture invariant

            //adding lookups to the collection - studyspanish.com/typing-spanish-accents
            list["Estados Unidos"] = "United States of America";
            list["Canadá"] = "Canada";
            list["España"] = "Spain";

            //Show the results
            Console.WriteLine(list["Estados Unidos"]);
            Console.WriteLine(list["España"]);
            Console.WriteLine(list["CANADÁ"]);


            // Console.Read();
        }
    }
}
