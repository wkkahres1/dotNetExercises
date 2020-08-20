using System;
using System.Drawing; //add these to graphics designer
using System.Drawing.Drawing2D; //added to graphics designer
using System.Windows.Forms;
using Microsoft.VisualBasic;


namespace GraphicsDemo
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Fun With Graphics!"; //Added Text Tile for Window
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint); //added this function
        }
        
        //Draw in this space
        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Graphics g = this.CreateGraphics();
            // Make a big red pen.
            Pen r = new Pen(Color.Red, 5); //Pen Color, width
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.DrawLine(r, 1, 1, 50, 100); // Draw line using pen from x1,y1 to x2,y2)
            

            //Make a pie piece
            Pen b = new Pen(Color.Blue,5);
            g.DrawPie(b, 100, 100, 200, 200, -30, 60);

            //testing DrawLines
            Pen o = new Pen(Color.Orange, 9);
            //line array
            Point[] points = { new Point(400,200),
                               new Point(400,300),
                               new Point(600,300),
                               new Point(600,200),
                               new Point(400,200)
            };
            Brush mb = new SolidBrush(Color.Maroon);
            g.DrawLines(o, points);
            g.FillPolygon(mb, points);

            //GDI+ Graphical Device Interface (library) rendering operations, Bezier curves
            Pen bk = new Pen(Color.Black);
            bk.Width = 5;
            bk.DashStyle = DashStyle.Dash;
            bk.StartCap = LineCap.RoundAnchor;
            bk.EndCap = LineCap.ArrowAnchor;
            g.DrawBezier(bk, new Point(500, 380), new Point(100, 450), new Point(200,100), new Point(70,100));

            //pie chart using created DrawPieChart function
            // Take Total Five Values and Draw Chart using these
            int[] myPiePercent = { 20, 25, 20, 30, 5 };
            // Take colors to dispaly Pie in that colors of taken five values
            Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };
            using (Graphics myPieGraphic = this.CreateGraphics())

            {
                Point myPieLocation = new Point(600,600);
                Size myPieSize = new Size(150, 150);
                DrawPieChart(myPiePercent, myPieColors, myPieGraphic, myPieLocation, myPieSize);
            }
            
            // buttons
            Button button1 = new Button();
            button1.Location = new Point(200, 400);
            button1.Size = new Size(600,50); //width,height
            button1.BackColor = Color.FromArgb(10, 200, 200);
            button1.Text = "Yo I'm a creepy random button";

            button1.Click += new EventHandler(Button1_Click);

            this.Controls.Add(button1);


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show ("AND THE CREEPY TEXT CHANGED!");
            
        }
        
        private void DrawPieChart(int[] myPiePercents, Color[] myPieColors, Graphics myPieGraphic,Point myPieLocation,Size myPieSize)
        {
            //Check if sections add up to 100
            int sum = 0;
            foreach( int percent_loopVariable in myPiePercents)
            {
                sum += percent_loopVariable;
            }
            if (sum > 100)
            {
                MessageBox.Show("Sum does not add to 100");
            }
            //Check here number of values and Colors are same or not (must be the same)
            if (myPiePercents.Length != myPieColors.Length)
            {
                MessageBox.Show("There must be the same number of percents and colors");
            }
            int PiePercentTotal = 0;
            for (int PiePercents = 0; PiePercents < myPiePercents.Length; PiePercents++)
            {
                myPieGraphic.SmoothingMode = SmoothingMode.HighQuality; //antialiasing
                using (SolidBrush brush = new SolidBrush(myPieColors[PiePercents]))
                {
                    // here it will convert each value into 360, so total into 360 and then draw a full pie
                    myPieGraphic.FillPie(brush, new Rectangle(new Point(10, 10), myPieSize), Convert.ToSingle(PiePercentTotal * 360 / 100), Convert.ToSingle(myPiePercents[PiePercents] * 360 / 100));
                }
                PiePercentTotal += myPiePercents[PiePercents];
            }
            return;
        }
        /*
        private void DrawPieChartonForm()
        {
            // Take Total Five Values and Draw Chart using these
            int[] myPiePercent = { 10, 20, 25, 5, 40 };

            // Take colors to dispaly Pie in that colors of taken five values
            Color[] myPieColors = { Color.Red, Color.Black, Color.Blue, Color.Green, Color.Maroon };

            using (Graphics myPieGraphic = this.CreateGraphics)
            {

            }
            
        
        }
        */

        #endregion
    }
}

