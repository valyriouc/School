using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsGeoFigur {
    public partial class Form1 : Form {

        private int xRect = 30, yRect = 30;

        List<GeoFigur> objekte = new List<GeoFigur>();

        public Form1() {
            InitializeComponent();
            this.Text = "GeoFigur";
                                     // x,   y  w   h   color
            Rechteck r1 = new Rechteck(10, 20, 50, 80, Brushes.Red);
            Kreis k1 = new Kreis(0, 0, 40, Brushes.Green); // x, y, radius, color
            objekte.Add(r1);
            objekte.Add(k1);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }

        private void panelCanvas_Paint(object sender, PaintEventArgs e) {
            e.Graphics.Clear(Color.White);

            foreach (GeoFigur objekt in objekte) {
                objekt.Paint(e.Graphics);
            }


            /*
            Console.WriteLine("Canvas Size: {0}, {1}", 
                panelCanvas.ClientSize.Width, 
                panelCanvas.ClientSize.Height);
            */
            

            //Recheck zeichen
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(xRect, yRect, 300, 150));

            // Linien zeichnen
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 20), new Point(330, 170));
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 170), new Point(330, 20));
        }
        
        private void button1_Click(object sender, EventArgs e) {
            Console.WriteLine($"Button Start {xRect} {yRect}");
            Graphics g = this.panelCanvas.CreateGraphics();
            xRect+=10;
            yRect+=10;
            this.panelCanvas.Invalidate(); //male mich wieder neu
            /*
            Random rand = new Random();
            g.FillRectangle(Brushes.Blue, new Rectangle(rand.Next(0,300), rand.Next(0, 300), 30, 30));
            */      
    }
    }
}
