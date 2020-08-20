using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;  //add this for grahics
using System.Drawing.Drawing2D; //added to graphics designer
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ImagesAndTextDemo
{
    class LineDrawer
    {
        // public Graphics graphics;
        private Point nextPoint;
        public Point CurrPoint { get; set; }
        public Pen DrawPen { get; }
        public string Direction { get; set; }
        //public string color { get; set; }


        //Constructor
        public LineDrawer(Graphics g, Point curr, Point next, Pen pen, string dir)
        {
            CurrPoint = curr;
            nextPoint = next;
            DrawPen = pen;
            Direction = dir;
        }
        
        public void testdraw(Graphics g)
        {
            nextPoint.Offset(0, -100);
            g.DrawLine(DrawPen, CurrPoint, nextPoint);
            //g.DrawLine(DrawPen, 1,1, 100, 100);
        }
        
        public void draw_forward(Graphics g)
        {
            if (Direction == "right")
            {
                nextPoint.Offset(100, 0);
            }
            else if (Direction == "left")
            {
                nextPoint.Offset(-100, 0);
            }
            else if (Direction == "down")
            {
                nextPoint.Offset(0, 100);
            }
            else if (Direction == "up")
            {
                nextPoint.Offset(0, -100);
            }
            else
            {
                Console.WriteLine("Error, direction is not set correctly");
            }
            g.DrawLine(DrawPen, CurrPoint, nextPoint);
            this.CurrPoint = nextPoint;
        }

        public void turn_right(Graphics g)
        {
            if (this.Direction == "up")
            {
                this.Direction = "right";
            }
            else if (this.Direction == "right")
            {
                this.Direction = "down";
            }
            else if (this.Direction == "down") 
            {
                this.Direction = "left";
            }
            else if (this.Direction == "left")
            {
                this.Direction = "up";
            }
        }

        public void turn_left(Graphics g)
        {
            if (this.Direction == "up")
            {
                this.Direction = "left";
            }
            else if (this.Direction == "left")
            {
                this.Direction = "down";
            }
            else if (this.Direction == "down")
            {
                this.Direction = "right";
            }
            else if (this.Direction == "right")
            {
                this.Direction = "up";
            }
        }


    }
}
/*
        //draw_forward function
        private static Point draw_forward(Graphics g, Point myCurrPosition, Pen myPen, string myDirection)
        {
            if (myDirection == "right")
            {
                nextPoint.Offset(100, 0);
            }
            else if (myDirection == "left")
            {
                nextPoint.Offset(-100, 0);
            }
            else if (myDirection == "down")
            {
                nextPoint.Offset(0, -100);
            }
            else if (myDirection == "up")
            {
                nextPoint.Offset(0, 100);
            }
            else
            {
                Console.WriteLine("Error, direction is not set correctly");
            }

            g.DrawLine(myPen, myCurrPosition, nextPoint);
            myCurrPosition = nextPoint;
            return myCurrPosition;
        }
    }
}
*/