using System;
using System.Drawing;  //add this for grahics
using System.Drawing.Drawing2D; //added to graphics designer
using System.Drawing.Imaging; //needed to save bm
using System.Windows.Forms;
using Microsoft.VisualBasic;

using ImagesAndTextDemo;

namespace ImagesAndTextDemo
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(97, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 256);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Images And Text Demo:  Authors - Walter Kahres and the kids";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Edit);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();

            /*
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bmp, pictureBox1.ClientRectangle);
            */

            this.ResumeLayout(false);
            this.PerformLayout();

        }

        //Draw in this space
        private void Form1_Edit(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            // Graphics g = this.CreateGraphics();
            Graphics g = e.Graphics;

            //background image
            Bitmap bm1 = new Bitmap(@"C:\Users\wkkah\OneDrive\Walter\Programming Training\c#\Programs\First cs Project\Imagesandtextdemo\download.jpg");
            Bitmap bm2 = new Bitmap(@"C:\Users\wkkah\OneDrive\Walter\Programming Training\c#\Programs\First cs Project\Imagesandtextdemo\images.jpg");
            //pictureBox1.BackgroundImage = bm1; //makes the background of the picture box the image
            //pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;  //Changes Size to size of the picture
            //pictureBox1.ClientSize = new Size(256,256);
            pictureBox1.Image = (Image)bm1; //draws the image one time in the box
            g.DrawImage(bm2, 1, 1, this.Width, this.Height); //puts a 

            //----- Drawer class made for kids --------//
            //sets current point, pen, and diretion for drawing functions
            Point curr = new Point(0, 0);
            Point next = new Point(0, 0);
            Pen r = new Pen(Color.Black, 5);
            string d = "right";

            LineDrawer drawer = new LineDrawer(g,curr,next,r,d);
            drawer.testdraw(g);
            
            for (int i = 0; i < 4; i++)
            {
                drawer.draw_forward(g);
                drawer.draw_forward(g);
                drawer.draw_forward(g);
                drawer.draw_forward(g);
                drawer.turn_right(g);
            }

            string bmSaveFile = @"C:\Users\wkkah\OneDrive\Walter\Programming Training\c#\Programs\First cs Project\Imagesandtextdemo\bm.jpg";

            /*
            Bitmap saveBitmap = new Bitmap(400,400,g);
            saveBitmap.MakeTransparent();
            saveBitmap.Save(bmSaveFile, ImageFormat.Jpeg);
            */

            //saving a bitmap to a file.
            Bitmap testmap = new Bitmap(600, 600);
            Graphics h = Graphics.FromImage(testmap);

            Brush b = new LinearGradientBrush(new Point(1, 1), new Point(600, 600), Color.White, Color.Red);
            Point[] points = new Point[] { new Point(10,10)
                                            ,new Point(77,500)
                                            ,new Point(590,100)
                                            ,new Point(250,590)
                                            ,new Point(300,410)
                                          };
            h.FillPolygon(b,points);
            testmap.Save(bmSaveFile, ImageFormat.Jpeg);

            //Draw Icons
            g.DrawIcon(SystemIcons.Exclamation, 40, 40);

            //page 351-353 - Adding Text Examples
            Font f = new Font("Arial", 20, FontStyle.Bold);
            g.DrawString("TEST TEST TEST TEST!", f, Brushes.CornflowerBlue, 200, 400);

            Rectangle rect = new Rectangle(new Point(300, 500), new Size(80, 150));
            StringFormat f1 = new StringFormat(StringFormatFlags.NoClip);

            f1.LineAlignment = StringAlignment.Far; //Bottom
            f1.Alignment = StringAlignment.Far; //right
            f1.FormatFlags = StringFormatFlags.DirectionVertical;
  
            g.DrawRectangle(Pens.Black, rect);
            g.DrawString("This should Align to the bottom right.", this.Font, Brushes.BlueViolet, (RectangleF)rect, f1);

            /*
            pictureBox1.BackgroundImage = testmap;
            pictureBox1.Image = (Image)testmap; //THIS COUD WORK IF IT FIT IN THE pictureBox1
            */



        }
        #endregion

        private PictureBox pictureBox1;
    }    
}

