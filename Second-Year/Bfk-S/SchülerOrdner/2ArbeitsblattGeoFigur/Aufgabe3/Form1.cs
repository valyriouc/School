namespace Aufgabe3
{
    public partial class Form1 : Form
    {
        int xRect = 30, yRect = 20;
        public Form1()
        {
            InitializeComponent();
            this.Text = "GeoFigur";
                            //x y w h color
            Rechteck r1 = new(12, 21);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PanelCanvas_Paint(object sender, PaintEventArgs e)
        {
            // Rechteck zeichnen
            e.Graphics.FillRectangle(Brushes.Red, new Rectangle(xRect, yRect, 300, 150));
            
            // Linien zeichnen
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 20), new Point(330, 170));
            e.Graphics.DrawLine(new Pen(Brushes.Blue), new Point(30, 170), new Point(330, 20));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button Start");
            Graphics g = this.PanelCanvas.CreateGraphics();
            xRect+=10;
            yRect+=10;
            this.PanelCanvas.Invalidate(); // male mich wieder neu

            /*
            Random rand = new();
            g.FillRectangle(Brushes.Blue, new Rectangle(rand.Next(0, 600), rand.Next(0, 150), 80, 50));
            */

            foreach (GeometricObject geoObject in objekte)
            {

            }
        }
    }
}