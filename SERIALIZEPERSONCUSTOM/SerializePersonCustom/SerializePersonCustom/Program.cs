using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Serialization; //Must be added to serialize the class
using System.Runtime.Serialization.Formatters; //this is used in main program
using System.Runtime.Serialization.Formatters.Binary; //this is used for Binary formatter
using System.IO;//this is for filestream

namespace SerializePersonCustom
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileLocation1 = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\SERIALIZEPERSONCUSTOM\Person.DAT";
            string fileLocation2 = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\SERIALIZEPERSON\OptPerson.DAT";

            void Serialize(Person sp, string fL)
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

            Person Deserialize(Person dsp, string fL)
            {
                //string fileLocation = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\FILEDEMO\Person.DAT";
                //references file already in the system
                FileStream dfs = new FileStream(fL, FileMode.Open);

                //creates a BinaryFormatter object to perform the deserialization
                BinaryFormatter dbf = new BinaryFormatter();

                //Create the object to store deserialized date
                //Use BinaryFormtter to deserialize the data from the file
                dsp = (Person)dbf.Deserialize(dfs);

                //Close the file
                dfs.Close();

                return dsp;

            }

            //Creating Regular Person
            Person Walter = new Person("Walter", "Kahres", "male", 38);

            //test serialize
            Serialize(Walter, fileLocation1);

            Console.WriteLine("Creating a new blank Person and Deserializing the blank Person to create Walter again...");
            Person DeSerializeWalter = new Person("", "", "", 5);

            //test deserialize
            Console.WriteLine(Deserialize(DeSerializeWalter, fileLocation1).Sex.ToString());
            Console.WriteLine(Deserialize(DeSerializeWalter, fileLocation1).FirstName.ToString());
            Console.WriteLine(Deserialize(DeSerializeWalter, fileLocation1).LastName.ToString());
            Console.WriteLine(Deserialize(DeSerializeWalter, fileLocation1).Age.ToString());
            Console.WriteLine("This one will be incorrect because age in dog years was set to not serializable");
            Console.WriteLine(Deserialize(DeSerializeWalter, fileLocation1).getAgeInDogYears().ToString());
            Console.WriteLine(" ");
        }
    }

    //5.3.1 - Builld Custom Serializable Person class

    [Serializable]  // add this to make class serializable
    class Person : ISerializable 
        //added ISerializable to make this a Custom Serialization 
        //(must add GetObjectData(SerializationInfo, StreamingContext_
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
        private string height = " ' \""; //custom getter and setter needed
        public int Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Job { get; set; }
        [NonSerialized] private int ageInDogYears; //age * 7 is age in dog years

        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("First Name", FirstName);
            info.AddValue("Last Name", LastName);
            info.AddValue("Sex", Sex);
            info.AddValue("Age", Age);
        }
        //This must be added to custom serialized class

        public Person(SerializationInfo info, StreamingContext context)
        {
            FirstName = info.GetString("First Name");
            LastName = info.GetString("Last Name");
            Sex = info.GetString("Sex");
            Age = info.GetInt32("Age");
            ageInDogYears = Age * 7;

        }

        public Person(string fnm, string lnm, string sx, int g)
        {
            FirstName = fnm;
            LastName = lnm;
            Sex = sx;
            Age = g;
            ageInDogYears = Age * 7;
        }

        public int getAgeInDogYears()
        {
            return ageInDogYears;
        }
    }
}
