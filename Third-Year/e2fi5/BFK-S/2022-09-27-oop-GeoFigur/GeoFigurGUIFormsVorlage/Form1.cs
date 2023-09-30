using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoFigurGUI1 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            this.Name = "GeoFigur";
            this.Text = "GeoFigur";
        }

        private void canvas_Paint(object sender, PaintEventArgs e) {
            // Linien zeichnen
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 20), new Point(330, 170));
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 170), new Point(330, 20));

            //Recheck zeichen
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(30, 20, 300, 150));

            //Kreis zeichnen
            DrawCircle(e.Graphics, Brushes.Green, 200, 300, 70);
            FillCircle(e.Graphics, Brushes.Yellow, 500, 200, 100);
        }

        public void DrawCircle(Graphics g, Brush brush,
                               float centerX, float centerY, float radius) {
            g.DrawEllipse(new Pen(brush), centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        public void FillCircle(Graphics g, Brush brush,
                                      float centerX, float centerY, float radius) {
            g.FillEllipse(brush, centerX - radius, centerY - radius,
                          radius + radius, radius + radius);
        }

        private void Form1_Load(object sender, EventArgs e) {

        }
    }
}
