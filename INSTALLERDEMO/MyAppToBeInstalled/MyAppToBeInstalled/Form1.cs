using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyAppToBeInstalled
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e) //do something on load

        {
            labelHello.Text = "Hello World";
        }

        private void buttonSet_Click(object sender, EventArgs e)
        {
            labelHello.Text = "You pressed the \"Set\" Button, Dog.";
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            labelHello.Text = "You pressed the \"Cancel\" button, G.";
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            labelHello.Text = "Log Out.... no I don't think so.";
        }
    }
}
