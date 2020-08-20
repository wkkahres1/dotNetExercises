using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

//add these namsespaces
//--
using System.Timers;
using System.IO;
using System.Net;
//--

//!!!!-- Must right-click design view and then click Add Installer After Building --!!!!//
/* instructions are in the book CH 8.3 pages 461,462 
 * Instructions are laid out but difficult to follow without the website and information here.
 * 
 * You can right click for properties to update in design view.
 * Instructions for Setup Project for Windows Service is here
 * https://www.c-sharpcorner.com/UploadFile/b7531b/create-simple-window-service-and-setup-project-with-installa/
*/

namespace MonitorWebSite
{
    public partial class MonitorWebSite : ServiceBase
    {
        //Create Timer Object
        private Timer t = null;

        public MonitorWebSite(string[] args)
        {
            //--
            InitializeComponent();

            //Overwriting Constructor -- Add following --
            //--

            this.ServiceName = "MonitorWebSite";
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;

            //Configure Timer within constructor to call t_Elapsed method every 10 seconds
            t = new Timer(10000); //10,000 ms = 10 sec
            t.Elapsed += new ElapsedEventHandler(t_Elapsed);

            //--
        }

        

        protected override void OnStart(string[] args)
        {
            t.Start();
        }

        protected override void OnStop()
        {
            t.Stop();
        }

        //add these overrides also
        //--

        protected override void OnContinue()
        {
            t.Start();
        }

        protected override void OnPause()
        {
            t.Stop();
        }

        protected override void OnShutdown()
        {
            t.Stop();
        }

        //--

        //Add Elapsed Event Handler method to check the Web Site and write the current
        //time and status code to a text file. 
        //Add an event to the event log if you experience an exception, because services lacks a 
        //user interface to easily communicate the exception information to the user.

        void t_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                //Send the HTTP request
                string url = "http://www.microsoft.com";
                HttpWebRequest g = (HttpWebRequest)WebRequest.Create(url);
                HttpWebResponse r = (HttpWebResponse)g.GetResponse();

                //Log the response to a text file
                //string logPath = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\C#\Programs\First Cs Project\MONITORWEBSITE\log.txt";
                string path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "log.txt";
                TextWriter tw = new StreamWriter(path, true);
                tw.WriteLine(DateTime.Now.ToString() + " for " + url + 
                             ": " + r.StatusCode.ToString());
                tw.Close();

                //Close the HTTP response
                r.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.EventLog.WriteEntry("Application", "Exception: "
                             + ex.Message.ToString());
            }
        }
    }
}
