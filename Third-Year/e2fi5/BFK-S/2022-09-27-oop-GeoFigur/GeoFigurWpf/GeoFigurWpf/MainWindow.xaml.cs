using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using GeoFigurGUI2;

namespace GeoFigurWpf
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<GeoFigur> figurenListe = new List<GeoFigur>();
        private DispatcherTimer timer = new DispatcherTimer();
        private int top = 150;
        private int left = 0;

        public MainWindow()
        {
            InitializeComponent();

            timer.Interval = TimeSpan.FromMilliseconds(40);
            timer.Tick += timer_Tick;
            timer.Start();

        }

        public void timer_Tick(object sender, EventArgs e)
        {
            lblTime.Content = DateTime.Now.ToString("HH:mm:ss");
            geoCanvas.Children.Clear();
            zeichneAufCanvas(geoCanvas);
        }

        public void zeichneAufCanvas(Canvas geoCanvas)
        {
            Rectangle r1 = new Rectangle();
            r1.Height = 20;
            r1.Width = 20;
            
            
            r1.Fill = Brushes.Red;
            geoCanvas.Children.Add(r1);

            Random rand = new Random();

            if(left < geoCanvas.Width - 20)
            {
                left += 10;

            }
            else
            {
                left = 0;
            }
            //An beliebige Stelle setzen
            //int left = rand.Next(0,(int)geoCanvas.Width-20);
            //int top = rand.Next(0, (int)geoCanvas.Height-20);
            Canvas.SetLeft(r1,left);
            Canvas.SetTop(r1, top);
            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //geoCanvas.Children.Clear();
            if (timer.IsEnabled)
            {
                timer.Stop();
            }
            else
            {
                timer.Start();
            }

        }
    }
}
