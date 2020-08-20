using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Add these two namespaces to the project
using System.Security;
using System.Security.Policy;

namespace AppDomainDemo
{
    //Add References to Assemblies for FileDemo and BasicCollection
    /* right click AppDomainPrivDemo to the right and add those assemblies */
    
    /* MUST ADD THE FOLLOWING XML CODE TO APP.CONFIG TO RUN LEGACY CODE
    <configuration>
        <runtime>
            <NetFx40_LegacySecurityPolicy enabled="true"/>
        </runtime>
    </configuration>

    //  CORRECT PROGRAM WILL GET SECURITY ERROR IF TRYING TO CREATE A FILE IN THE DOMAIN!!!! //
    // CH 8.2.1
    */

    class Program
    {
        static void Main(string[] args)
        {
            //AppDomain Setup (used in constructor that includes setup)
            AppDomainSetup setup = new AppDomainSetup();
            setup.ApplicationBase = "C:\\Users\\wkkah\\OneDrive\\Walter\\Programming Training\\C#\\Programs\\First Cs Project\\FILEDEMO\\FileDemo\\FileDemo\\bin\\Debug";
            //setup.ApplicationBase = "C:\\Users\\wkkah\\OneDrive\\Walter\\Programming Training\\C#\\Programs\\First Cs Project\\BASICCOLLECTION\\BasicCollection\\BasicCollection\\bin\\Debug";
            //setup.ConfigurationFile = "BasicCollection.exe";
            setup.ConfigurationFile = "FileDemo.exe";

            //Create a permission set to be used in appdomain creation
            PermissionSet perm = new PermissionSet(System.Security.Permissions.PermissionState.Unrestricted);

            //Use EvidenceBase[] Rather than object[] //
            EvidenceBase[] hostEvidence = { new Zone(SecurityZone.Internet) };
            Evidence e = new Evidence(hostEvidence,null);
            AppDomain dom = AppDomain.CreateDomain("SecuredDomain", e, setup);

            /* Allows programs to run */
            //AppDomain dom = AppDomain.CreateDomain("SecuredDomain",e,setup,perm,null);

            /*
            Console.WriteLine("Here is program BASICCOLLECTION created through AppDomain 2");
            Console.WriteLine("-----------------------------------------------------\n");
            dom.ExecuteAssemblyByName("BasicCollection");
            Console.WriteLine("");
            */

            //FILEDEMO
            Console.WriteLine("Here is program FILEDEMO createed through AppDomain 1");
            Console.WriteLine("-----------------------------------------------------\n");
            dom.ExecuteAssemblyByName("FileDemo");
            Console.WriteLine("");
            
        }
    }
}
