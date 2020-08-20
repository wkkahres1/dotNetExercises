using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace BasicCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            //CREATE Arraylist coll
            ArrayList coll = new ArrayList();
            coll.Add("First");
            coll.Add("Second");
            coll.Add("Third");
            coll.Add("Fourth");

            //ITERATE and print array using IEnumerator
            Console.WriteLine("Here is the array printed using an IEnumerator to iterate the ArrayList");
            IEnumerator enumerator = coll.GetEnumerator();
            while (enumerator.MoveNext())
            {
                Console.WriteLine(enumerator.Current);
            }
            Console.WriteLine("");

            //Sort the array alphabetically
            coll.Sort();

            //ITERATE using foreach
            Console.WriteLine("Here is the array printed after sorting alphabetically using 'foreach' to iterate");
            foreach(string ListItem in coll)
            {
                Console.WriteLine(ListItem);
            }
            Console.WriteLine("");

            //doing someother stuff to it and reprinting 
            coll.Add("Marida");
            coll.RemoveRange(0, 2);
            coll.Add("Walter");
            coll.Add("Georgie");
            coll.Add("Z, do we have four?");
            coll.Insert(3, "Number 3");

            //ITERATE using count property
            Console.WriteLine("Here is the array printed after updates are made using .count to iterate");
            for (int x=0; x<coll.Count; ++x)
            {
                Console.WriteLine(coll[x]);
            }
            Console.WriteLine("");
        }
    }
}
