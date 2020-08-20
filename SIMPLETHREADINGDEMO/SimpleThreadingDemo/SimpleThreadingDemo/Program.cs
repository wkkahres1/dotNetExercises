using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; //added to this program

/*Creating Threads
 * 1)Create method that takes no arguments and does not return data (void)
 * 2)Create a new ThreadStart delegate
 * 3)Create a new Thread object specifying the ThreadStart object
 * 4)Call Thread.Start to begin execution of new thread
*/

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //2 Create ThreadStart delegate
            ThreadStart operation = new ThreadStart(CountingOne); //thread function goes here

            //added this to orinal program
            ThreadStart operation2 = new ThreadStart(ReadTheArray);

            //3 Create Thread 
            Thread firstThread = new Thread(operation); //threadstart goes here
            Thread secondThread = new Thread(operation); //creating a second thread
            Thread thirdThread = new Thread(operation2); //third operation

            //4 Start Threads
            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();

            //5 Join Threads to make sure both must complete
            firstThread.Join();
            secondThread.Join();
            thirdThread.Join();

        }

        //1. Creat method to call
        static void CountingOne()
        {
            for(int i = 0; i<10; i++)
            {
                Console.WriteLine("Count: {0}, - Thread {1}", i + 1, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(1000); //Sleep current thread for 10 seconds
            }
            
        }

        //added this to original
        static void ReadTheArray()
        {
            String[] FruitsArr = { "Orange", "Apple", "Kiwi", "Banana", "Grapes", "Mango", "Pear", "Peach", "Dragonfruit", "Watermelon", "Honeydew Melon" };
            foreach(string fruit in FruitsArr)
            {
                Console.WriteLine("Fruit: {0}, - Thread {1}", fruit, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(3000);
                
            }
        }

    }
}
