using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//add these for Read/Write configuration Settings
using System.Collections.Specialized;
using System.Collections;
using System.Configuration;

// must add System.Configuration assembly REFERENCE in Solution Explorer
// must go to Project => Addd New Item => Application Configuration File (needs configuration file)

//Chapter 9.4 Lab

namespace ConfigSettingsDemo
{
    public class LabSection : ConfigurationSection
    {
        public static void WriteSettings()
        {
            try
            {
                ConfigurationSection labSec;

                //Get the current configuration file
                System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

                if (config.Sections["LabSection"] == null)
                {
                    labSec = new LabSection();
                    config.Sections.Add("LabSection", labSec);
                    labSec.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
            catch (ApplicationException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LabSection.WriteSettings(); //static call in the main method
            
            //Code below can be used if WriteSettings is not Set to static
            /*LabSection _labSection = new LabSection();
            _labSection.WriteSettings();
            */
        }
    }
}
