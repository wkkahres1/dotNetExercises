using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace ThreadPoolDemo
{
    /* This program will use a Threadpool to synchronously run different Items.  
     * They will show in random orders when the program is ran because they are all running 
     * basically at the same time and print when it is complete
     */


    class Program
    {
        static void Main(string[] args)
        {
            //created show my Text method within Main (could also make it static outside the main)
            void ShowMyText(object state)
            {
                //create a string variable using the object state
                string myText = (string)state;

                //Write the managed thread Id and the new string to the console
                Console.WriteLine($"Thread: {Thread.CurrentThread.ManagedThreadId} - {myText} \n");
            }

            //create instance of WaitCallBack delegate that would refer to the showMyText method
            WaitCallback callback = new WaitCallback(ShowMyText); //parameter is object target

            //Queue up several calls to the WaitCallback delegate using different strings as the 
            //object state

            ThreadPool.QueueUserWorkItem(callback, "This is the first one");
            ThreadPool.QueueUserWorkItem(callback, "Walter, you wrote this one second, bro.");
            ThreadPool.QueueUserWorkItem(callback, "3:  Next");
            ThreadPool.QueueUserWorkItem(callback, "What's Marida doing?");
            ThreadPool.QueueUserWorkItem(callback, "Probably watching TV");
            ThreadPool.QueueUserWorkItem(callback, "Hey, gotta go.  Peace!");

            //wait
            Console.Read();


        }
    }
}
