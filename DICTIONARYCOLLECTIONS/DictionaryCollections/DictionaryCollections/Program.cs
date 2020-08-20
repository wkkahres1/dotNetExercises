using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace DictionaryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable testHash = new Hashtable();

            testHash.Add("0", "Zero");
            testHash.Add("1", "One");
            testHash.Add("2", "Two");
            testHash.Add("3", "Three");
            testHash.Add("4", "Four");
            testHash.Add("5", "Five");
            testHash.Add("6", "Six");
            testHash.Add("7", "Seven");
            testHash.Add("8", "Eight");
            testHash.Add("9", "Nine");

            
            foreach(DictionaryEntry entry in testHash)
            {
                Console.WriteLine("Key: {0}, Value: {1}", entry.Key, entry.Value);
            }
            

            Console.WriteLine("Please type in a phone number and press 'ENTER':  ");
            string numbers = Console.ReadLine();
            Console.WriteLine("Thanks, ya did great!!");
            
            Console.WriteLine("");

            //string numbers = "478-455-4763";

            Console.Write("The number you wrote is ");
            foreach (char num in numbers)
            {
                string digit = num.ToString(); //need this to turn char into equivalent string representation
                if (testHash.ContainsKey(digit))
                {
                    Console.Write(testHash[digit] + " ");
                }
                /*else
                {
                    Console.Write("{0} not found!!", num);
                }*/
            }
            Console.WriteLine("");

        }
    }
}
