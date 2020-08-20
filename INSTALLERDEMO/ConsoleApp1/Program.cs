using System;
using System.Collections;
using System.ComponentModel;
using System.Configuration;
using System.Configuration.Install; //added this to get installer to work 

namespace CustomInstaller
{
    class Program
    {
        //args can be null, uninstall, or install
        string args;

        static void Main(string[] args)
        {

            IDictionary actions = new Hashtable();

            
            if(args[0] == "install" || args[0] == null)
            {
                try
                {
                    //program to install
                    string fullpath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\INSTALLERDEMO\ConsoleApp1\bin\Debug\ConsoleApp1.exe";
                    //Create an instance of the AssemblyInstaller class
                    AssemblyInstaller customAssemblyInstaller = new AssemblyInstaller(fullpath, args);
                    //Use new Install context
                    customAssemblyInstaller.UseNewContext = true;
                    //Install the CustomInstallerAssembly
                    customAssemblyInstaller.Install(actions);
                    //Commit the installation of the customInstaller assembly
                    customAssemblyInstaller.Commit(actions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else if (args[0] == "uninstall")
            {
                try
                {
                    //program to uninstall
                    string fullpath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\INSTALLERDEMO\ConsoleApp1\bin\Debug\ConsoleApp1.exe";
                    //Create an instance of the AssemblyInstaller class
                    AssemblyInstaller customAssemblyInstaller = new AssemblyInstaller(fullpath, args);
                    //Use new Install context
                    customAssemblyInstaller.UseNewContext = true;
                    //Install the CustomInstallerAssembly
                    customAssemblyInstaller.Uninstall(actions);
                    //Commit the uninstallation of the customInstaller assembly
                    customAssemblyInstaller.Commit(actions);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    // 1. Create a class that inherits from the installer class and is marked with the 
    // RunInstallerAttribute attribute, passing true for the runInstaller parameter

    [System.ComponentModel.RunInstaller(true)]
    public class CustomInstaller : Installer
    {
        //custom install code goes here

        //override each of the four main methods (Install, Commit, Rollback, and Uninstall)

        public CustomInstaller() : base()
        {
            //Wire up the Committed Event
            this.Committed += new InstallEventHandler(CustomInstaller_Committed);
            //Wire up the Committing Event
            this.Committing += new InstallEventHandler(CustomInstaller_Committing);
        }

        //Event Handler for the Committing Event
        private void CustomInstaller_Committing(object sender, InstallEventArgs e)
        {
            //Committing Event Occurred
        }

        //Event Handler for the Committed Event
        private void CustomInstaller_Committed(object sender, InstallEventArgs e)
        {
            //Committing Event Occurred
        }

        //Overide Install method
        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);
        }

        //Override Commit method
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);
        }

        //Override Rollback method
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }

        //Override Uninstall method
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }

    }


}
