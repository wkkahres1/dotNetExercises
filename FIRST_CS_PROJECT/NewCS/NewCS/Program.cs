using System;
using System.IO;

namespace NewCS
{
    class Program
    {
        static void Main(string[] args)
        {
            string myName = "    Walter Kahres";
            string myWifesName = myName.Replace("Walter", "Marida");
            Console.WriteLine($"Hello {myName}.");
            Console.WriteLine($"How is {myWifesName.Trim()}?");
            Console.WriteLine($"{myName.Trim()}, You are married to {myWifesName.Trim()}!");
            string firstLetter = myName.Trim();
            Console.WriteLine($"Here is your name trimmed:{firstLetter}");
            Console.WriteLine(myWifesName.Contains("Kahres"));
            Console.WriteLine(myWifesName.Contains("Marda"));


            int a = 18;
            int b = 6;
            int c = a + b;
            Console.WriteLine($"a + b = {c}");
            Console.WriteLine($"a * b = {a * b}");
            Console.WriteLine($"a % b = {a % b}");

            string txtline = " ";

            //Deletes previous instance of file
            File.Delete(@"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Streamtest.txt");

            //This will not write to a new line and will not delete prior text
            File.AppendAllText(@"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Streamtest.txt", "Hello World (File) - Changed this.");

            //This will create a new line to current text
            File.AppendAllText(@"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Streamtest.txt", Environment.NewLine + "New Line");

            string ft2 = "Testing the STREAM";
            string ntxt = Environment.NewLine +
                          "This is the First Line." + Environment.NewLine +
                          "and you also added this" + Environment.NewLine +
                          "<html></html>";
            FileWriter St2 = new FileWriter("streamtest3.txt", @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\", ft2);

            //These are done everytime a new St2 is created! That is why it cannot
            //append after the file has been created.

            //St2.createThisFile();
            //St2.appendTextToFile("\n add this shit everytime!!");
            St2.writeTextToFile();
            St2.appendTextToFile(ntxt);
            //St2.appendTextToFile("\n Is this gonna get added?");

            //Returning complete text to console
            Console.WriteLine();
            Console.WriteLine(St2.getFileText());
            Console.WriteLine();

            string streampath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Streamtest4.txt";
            FileWriter.SappendTextToFile(streampath, "Added this in ");
            FileWriter.SappendTextToFile(streampath, Environment.NewLine);
        }
    }

    class FileWriter
    //Non-Static filewriter.  Rewrites file every time program is ran
    {
        private string fileName { get; set; }
        private string fileLocation { get; set; }
        public static string fileText;
        private string filePath { get; set; }

        public FileWriter(string fN, string fL, string fT)
        {
            fileName = fN;
            fileLocation = fL;
            fileText = fT;
            filePath = fL + fN;

            Console.WriteLine("File To Create:  " + filePath);
            Console.Write("File Text To Add:  " + fileText);
        }

        public void createThisFile()
        {
            File.Create(filePath);
        }

        public void writeTextToFile()
        {
            File.WriteAllText(filePath, fileText);
        }

        public string getFileText()
        {
            return fileText;
        }

        public void appendTextToFile(string newText)
        {
            File.AppendAllText(filePath, newText);
            fileText = fileText + newText;

        }

        static public void SappendTextToFile(string Fp, string newText)
        {
            File.AppendAllText(Fp, newText);
            fileText = fileText + newText;
        }

        ~FileWriter()
        {
            Console.WriteLine("File is Deleted");
            File.Delete(filePath);
        }
    }
}