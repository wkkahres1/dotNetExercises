using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.RegularExpressions;

namespace RegExp_Ex
{
    class Program
    {
        static void Main(string[] args)
        {
            string testNumberString = ""; // = @"4048778977";
            string testAreaCodeString = ""; // = @"31021";
            bool phoneTest = false;

            Console.WriteLine("Hi, there! Please type in your phone number:  ");
            testNumberString = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Nice Job! Now please type in your area code:  ");
            testAreaCodeString = Console.ReadLine();
            Console.WriteLine("");

            PhoneNumber myNumber = new PhoneNumber(testNumberString);
            if (myNumber.isPhoneNumber() == true)
            {
                phoneTest = true;
                Console.WriteLine("The Phone Number as written, {0} is correct", testNumberString);
            }
            else
            {
                phoneTest = false;
                Console.WriteLine("The Phone Number as written, {0} is wrong", testNumberString);
            }

            Console.WriteLine("");

            AreaCode myAreaCode = new AreaCode(testAreaCodeString);
            if (myAreaCode.isAreaCode() == true)
            {
                Console.WriteLine("The Area Code as written, {0} is correct", testAreaCodeString);
            }
            else
            {
                Console.WriteLine("The Area Code as written, {0} is wrong", testAreaCodeString);
            }

            Console.WriteLine("");

            if (phoneTest == true)
            {
                string myFormatNumber = myNumber.reformatPhone();
                Console.WriteLine("The original number has been formatted: {0}", myFormatNumber);
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("The phone number was not accepted and has not been formatted.");
                Console.WriteLine("");
            }
            

        }
    }

    class PhoneNumber
    {
        /* DOCUMENT CLASS PhoneNumber 
        Class for storing, checking validity of, and reformatting a phone number string
        
        Constructor : PhoneNumber(string PhNm //INPUT phone number string to check and reformat )
                     sets INPUT phNmstring to attribute phoneNum   

        attributes - string phoneNum // stores phone number
                   - string const phoneExp // stores phone number expression for checking validity
                        valid expressions: 404-877-8977, (404)877-8977, (404) 877-8977
                   - string formatNum - stores formated phone Number
                        formatted phone numbers are in this format (###) ###-####

        methods    + bool isPhoneNumber - returns true if phone number is valid RETURN BOOL
                   + string reformatPhone - reformats input phone number to (###) ###-#### format RETURN formatNum
        */

        private string phoneNum;
        private const string phoneExp = @"^\(?(\d{3})\)?[\s\-]?(\d{3})[\s\-]?(\d{4})$";
        private string formatNum;

        public PhoneNumber(string phNm)
        {
            phoneNum = phNm;

        }

        public bool isPhoneNumber()
        {
            if (Regex.IsMatch(phoneNum, phoneExp)) //REGEX.IsMatch uses string, expression
            {
                Console.WriteLine("phoneExp: {0}, \nphoneNum: {1}", phoneExp, phoneNum);
                return true;
            }
            else
            {
                Console.WriteLine("phoneExp: {0}, \nphoneNum: {1}", phoneExp, phoneNum);
                return false;
            }
            //Regex.Replace();
        }

        public string reformatPhone()
        {
            Match m = Regex.Match(phoneNum, phoneExp); //phoneNum is grouping the digits with ( ) ex (\d{3})
            formatNum = String.Format("({0}) {1}-{2}", m.Groups[1], m.Groups[2], m.Groups[3]);
            return formatNum;
        }
    }

    class AreaCode
    {
        private string areaCd;
        private const string areaCdExp = @"^\d{5}(\-\d{4})?$";
        

        public AreaCode(string aC)
        {
            areaCd = aC;

        }

        public bool isAreaCode()
        {
            if (Regex.IsMatch(areaCd, areaCdExp))
            {
                Console.WriteLine("areaCdExp: {0}, \nareaCd: {1}", areaCdExp, areaCd);
                return true;
            }
            else
            {
                Console.WriteLine("areaCdExp: {0}, \nareaCd: {1}", areaCdExp, areaCd);
                return false;
            }
        }
    }
}
