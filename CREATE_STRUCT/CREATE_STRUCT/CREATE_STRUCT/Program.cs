using System;

namespace CREATE_STRUCT
//CH 1.1 exercise 1 and 2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");
            Person me = new Person("Walter", "Kahres", 38, Person.Genders.Male);
            Person myWife = new Person("Marida", "Kahres", 39, Person.Genders.Female);
            Manager myManager = new Manager("Joe", "Exotic", 45, Manager.Genders.Male, "404-555-5555", "that Tiger Zoo");

            Console.WriteLine(me);
            Console.WriteLine(myWife);
            Console.WriteLine(myManager);
            //Console.WriteLine($"Hi, my name is {me} {me[1]}, and my wife's name is {mywife[0]} {mywife[1]}. I am {me[1]} years old and she is {mywife[1]}.");
        }
    }

    class APerson
    // Chapter 1.3.1 parent class to Manager
    {
        protected string firstName;
        protected string lastName;
        protected int age;
        protected Genders gender;

        //Constructor (return type void but blank in book)
        public APerson(string _firstName, string _lastName, int _age, Genders _gender)
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
            gender = _gender;

            Console.WriteLine("APerson Class Created");
        }

        public override string ToString()
        //function overrides the ToString method, All .NET classes have this method
        {
            // return base.ToString();) /*automatically placed in VS*/
            return firstName + " " + lastName + " (" + gender + "), age " + age;
        }

        public enum Genders : int { Male, Female };
    }

    //Chapter 1.3.1 Derived class from APerson
    class Manager : APerson
    {
        private string phoneNumber;
        private string officeLocation;

        //Constructor - how to build a constructor in a derived class
        public Manager(string _firstName, string _lastName, int _age, Genders _gender, string _phoneNumber, string _officeLocation) : base (_firstName, _lastName, _age, _gender)
        {
            phoneNumber = _phoneNumber;
            officeLocation = _officeLocation;

            Console.WriteLine("Manager class created");
        }

        public override string ToString()
        //function overrides the ToString method, All .NET classes have this method
        {
            return base.ToString() + ", " + phoneNumber + ", " + officeLocation;
        }

    }

    struct Person
    //1.1 Create a Structure with several public members
    {
        public string firstName;
        public string lastName;
        public int age;
        public Genders gender;

        //Constructor (return type void but blank in book)
        public Person(string _firstName, string _lastName, int _age, Genders _gender) 
        {
            firstName = _firstName;
            lastName = _lastName;
            age = _age;
            gender = _gender;

            Console.WriteLine("Person Struct Created");
        }

        public override string ToString()
        //function overrides the ToString method, All .NET classes have this method
        {
            // return base.ToString();) /*automatically placed in VS*/
            return firstName + " " + lastName + " (" + gender + "), age " + age;
        }

        public enum Genders : int { Male, Female };
    }
}
