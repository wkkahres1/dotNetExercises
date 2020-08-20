using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization; //Must be added to serialize the class NOT NEEDED FOR XML
using System.Runtime.Serialization.Formatters; //this is used in main program
using System.Runtime.Serialization.Formatters.Binary; //this is used for Binary formatter
using System.IO;//this is for filestream

using System.Xml.Serialization; //needed for XML Serialization

namespace SerializePerson
{
    class Program
    {
        static void Main(string[] args)
        {
            void XmlSerialize(Person sp)
            {

                string fileLocation1 = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\SERIALIZEPERSONXML\Person.XML";
                //string fileLocation = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\FILEDEMO\Person.DAT";
                //creates file to save the stream
                FileStream fs = new FileStream(fileLocation1, FileMode.Create);

                //creates an XmlSerializer object to perform the serialization
                XmlSerializer xs = new XmlSerializer(typeof(Person)); //need to add type here

                //Use the XmlSerializer object to serialize the data to the file.
                xs.Serialize(fs, sp); //serializes the Person object;

                //Close the file
                fs.Close();
            }

            Person XmlDeserialize()
            {
                Person dsp = new Person(); //Xml class CANNOT take arguments
                //Creates person to put deserialized data into

                /*NEED TO SET A FILE LOCATION THAT WORKS ON YOUR COMPUTER*/
                string fileLocation1 = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\SERIALIZEPERSONXML\Person.XML";
                //references file already in the system
                FileStream dfs = new FileStream(fileLocation1, FileMode.Open);

                //creates a XmlSerializer object to perform the deserialization
                XmlSerializer dxs = new XmlSerializer(typeof(Person));

                //Create the object to store deserialized date
                //Use XmlSerializer to deserialize the data from the file
                dsp = (Person)dxs.Deserialize(dfs);

                //Close the file
                dfs.Close();

                return dsp;

            }

            /* previous code using optomized Binary Serialization 
            void SerializeOpt(OptimizedPerson sp, string fL)
            {
                //string fileLocation = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\FILEDEMO\Person.DAT";
                //creates file to save the stream
                FileStream fs = new FileStream(fL, FileMode.Create);

                //creates a BinaryFormatter object to perform the serialization
                BinaryFormatter bf = new BinaryFormatter();

                //Use the BinaryFormatter object to serialize the data to the file.
                bf.Serialize(fs, sp); //serializes the Person object;

                //Close the file
                fs.Close();
            }

            OptimizedPerson DeserializeOpt(OptimizedPerson dsp, string fL)
            {
                //string fileLocation = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\FILEDEMO\Person.DAT";
                //references file already in the system
                FileStream dfs = new FileStream(fL, FileMode.Open);

                //creates a BinaryFormatter object to perform the deserialization
                BinaryFormatter dbf = new BinaryFormatter();

                //Create the object to store deserialized date
                //Use BinaryFormtter to deserialize the data from the file
                dsp = (OptimizedPerson)dbf.Deserialize(dfs);

                //Close the file
                dfs.Close();

                return dsp;
            }
            
            */

            //Creating Regular Person
            Person Walter = new Person(); // MUST USE PARAMETERLESS STRUCTURE
            Walter.Job = "Programmer";
            Walter.FirstName = "Walter";
            Walter.LastName = "Kahres";
            Walter.Age = 38;
            Walter.Sex = "Male";

            Console.WriteLine("Walter's age in dog years BEFORE serialization:  " + Walter.getAgeInDogYears());

            //test serialize
            XmlSerialize(Walter);
            Console.WriteLine("Serialized Person 'Walter'");
            Console.WriteLine("");

            /* -- Blank person is created within Deserialize function */
            Console.WriteLine("Last Name:  " + XmlDeserialize().LastName);
            // Console.WriteLine("Age in Dog Years " + XmlDeserialize().AgeinDogYears);  WILL THROW AN ERROR BECAUSE IT CAN NOT BE ACCESSED
            Console.WriteLine("Walter's Age in Dog Years AFter Serialization:  " + XmlDeserialize().getAgeInDogYears()); //Will now show zero
 
            



            //test deserialize
        }
    }

    //5.3.2 - Builld Serializable Person class

    // DOES NOT NEED [Serializable] add this to make class serializable
    public class Person // <-- MUST MUST mark class as public
    {
        public string FirstName { get; set; }
        /* is the same as the following
         * private string _firstName;
         * public string FirstName {
         *      get { return _firstName; }
         *      set { _firstName = value; }
         */
        public string LastName { get; set; }
        public string Sex { get; set; }
        private string height = " ' \""; //custom getter and setter needed <-- Will not be serialized
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Job { get; set; }
        private int ageInDogYears = 2; //age * 7 is age in dog years 
        //DOES NOT NEED [NonSerialized], it will not use anything marked as private


        public Person()
        {
            ageInDogYears = Age * 7;
        }

        public int getAgeInDogYears()
        {
            this.ageInDogYears = Age * 7; 
            return ageInDogYears;
        }
    }
}

