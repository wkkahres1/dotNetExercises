using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*added these two for drawing graphics*/
using System.Drawing;
using System.Drawing.Drawing2D;


namespace GraphicsDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CenterToScreen(); //added to center the form
            SetStyle(ControlStyles.ResizeRedraw, true);
        }
    }
}
