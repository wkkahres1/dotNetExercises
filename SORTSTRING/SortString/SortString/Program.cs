using System;

namespace SortString
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            string a = "Walter Kahres is a cool dude and a damn good programmer";
            string s = "Microsoft .NET Framework 2.0 Application Development Foundation";
            
            //breaks string into an array separated by ' '
            string[] sb = a.Split(' ');
            string[] sa = s.Split(' ');
            foreach(object o in sa)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine();

            //sorts string array (alphabetically)
            Array.Sort(sb);
            Array.Sort(sa);
            foreach (object o in sa)
            {
                Console.WriteLine(o);
            }

            Console.WriteLine();

            //Changes the array back into a string
            s = string.Join(" ", sa);
            a = string.Join(" ", sb);

            Console.WriteLine(s);
            Console.WriteLine(a);
        }
    }
}
