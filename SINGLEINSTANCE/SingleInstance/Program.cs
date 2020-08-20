using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

/*
 * A mutex class locks data across AppDomain and process boundries.
 * 
 * Using a MUTEX object, this program insures that only one instance of the application
 * can run at one time.
 * 
 * To test, run the program and then without exiting run the program again.
 * 
 * 
 */

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            //MUTEX MAIN TESTER

            //
            // A mutex class locks data across AppDomain and process boundries.
            // 
            // Using a MUTEX object, this program insures that only one instance of the 
            // application can run at one time.
            // 
            // To test, run the program and then without exiting run the program again.
            //

            /*
            //Create mutext variable;
            Mutex mutex = null;

            //string to hold the name of the shared Mutex
            string mutexString = "RUNMEONCE";

            //try catch
            try
            {
                mutex = Mutex.OpenExisting(mutexString);
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                //mutex cannot be opened because it doesn't exist.
            }

            //Create mutex if it doesn't exist
            {
                if (mutex == null)
                {
                    mutex = new Mutex(true, mutexString);
                }
                else
                {
                    //Close the mutex and exit the appplication 
                    //because we can only have one instance 
                    Console.WriteLine("The application is locked.");

                    mutex.Close();
                    return;
                }

                Console.WriteLine("The application is running correctly because its not locked");
                Console.Read();
            }

            //END MUTEX
            */

            // SEMAPHORE
            // A Semaphore class is used to throttle usage of some resources. It creates a kernel
            // object that allows a certain number of valid slots at once.
            // 
            // Using a SEMAPHORE object, this program insures that only the selected numnber  
            // instances of an application can run at one time.
            // 
            // !!!! To test, run the program and then without exiting run the program again. !!!
            //

            //Create semaphore variable;
             Semaphore semaphore = null;

            //string to hold the name of the shared Semaphore
            string semaphoreString = "THESEMAPHORE";

            //semaphore starts with 3 open and 3 slots total
            semaphore = new Semaphore(3, 3, semaphoreString);

            if(IsInstance(semaphore)==true)
            {
                Console.WriteLine("New Instance created");
            }
            else
            {
                Console.WriteLine("Instance already acquired");
            }
            Console.ReadLine();

            //if instance already exist after 5 seconds
            bool IsInstance(Semaphore check)
            {
                if (semaphore.WaitOne(5000, false) == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            //END SEMAPHORE


        }
    }
}
