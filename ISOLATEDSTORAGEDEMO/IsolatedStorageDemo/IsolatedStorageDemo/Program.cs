using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.IsolatedStorage;

namespace IsolatedStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //writing to Isolated Storage
            //--------------------------------------------

            //create instance of IsolatedStorageFile class that is scoped to the CURRENT USER and ASSEMBLY
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            //Create instance of the IsolatedStorageFileStream object passing in UserSetting.set and the new store
            // (path, in the specified mode, and in the context of the Isolated Storage File)
            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Create, userStore);

            // Shows directories of Isolated Storage 
            Console.WriteLine(userStore.GetDirectoryNames());

            //Use Streamwriter to write data into the new Stream and close the stream when you are done.
            // Writes to the specified Stream in isolated storage above.
            StreamWriter userWriter = new StreamWriter(userStream);
            userWriter.WriteLine("User Prefs");
            userWriter.Close();

            Console.WriteLine("File has been updated");

            //this writes a file in a directory under C:\Users\<Username\AppData\Local\Isolated Storate
            //directory is a cache directory so may be giberrish machine-generated directory names here.. dig deeper into Assemfiles.

            //reading from Isolated Storage
            //-----------------------------------------------

            //check if file exists, if it exists write to console.
            string[] files = userStore.GetFileNames("UserSettings.set");
            if (files.Length == 0)
            {
                Console.WriteLine("No Data Saved for this User");
            }
            else
            {
                Console.WriteLine("File has been found!");
                //open file in the Isolated Storage FIle Stream object userstream in context of the Isolated Storage File
                userStream = new IsolatedStorageFileStream("UserSettings.set", FileMode.Open, userStore);

                //Use Streamreader to read all the text in the file into a local string variable.
                StreamReader userReader = new StreamReader(userStream);
                string contents = userReader.ReadToEnd();

                Console.WriteLine(contents);
            }



        }
    }
}
