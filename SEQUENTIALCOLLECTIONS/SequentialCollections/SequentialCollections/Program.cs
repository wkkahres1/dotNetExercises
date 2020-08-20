using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;

namespace SequentialCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            //QUEUE EXAMPLE!!!
            Queue q = new Queue();
            q.Enqueue("First");
            q.Enqueue("Second");
            q.Enqueue("Third");
            q.Enqueue("Fourth");

            //q = {"First","Second","Third","Fourth"} all lined up

            if (q.Count == 0)
            {
                Console.WriteLine("The queue is empty");
            }
            else
            {
                Console.WriteLine("There are {0} items in the queue", q.Count);
            }
            

            while (q.Count>0)
            {
                Console.WriteLine(q.Dequeue());
            }

            Console.WriteLine("");
            if (q.Count == 0)
            {
                Console.WriteLine("The queue is empty");
            }
            Console.WriteLine("");

            //STACK EXAMPLE !!!
            Stack s = new Stack();
            s.Push("First");
            s.Push("Second");
            s.Push("Third");
            s.Push("Fourth");

            //s = {"Fourth","Third","Second","First"} all stacked up in order of placement

            if (s.Count == 0)
            {
                Console.WriteLine("The stack is empty");
            }
            else
            {
                Console.WriteLine("There are {0} items in the stack", s.Count);
            }

            while (s.Count > 0)
            {
                Console.WriteLine(s.Pop());
            }

            Console.WriteLine("");
            if (s.Count == 0)
            {
                Console.WriteLine("The stack is empty");
            }
        }
    }
}
