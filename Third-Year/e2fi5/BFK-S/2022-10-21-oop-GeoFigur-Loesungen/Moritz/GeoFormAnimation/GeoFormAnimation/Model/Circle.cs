using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows;
using GeoFormAnimation.ViewModel;

namespace GeoFormAnimation.Model
{
    public class Circle : INotifyPropertyChanged
    {
        
        private int scope;
        private int area;

        public int RadiusToDiameter(int radius)
        {
            diameter = radius * 2;
            return diameter;
        }

        public int DiameterToRadius(int diameter)
        {
            radius = diameter / 2;
            return radius;
        }

        private int radius;

        public int Radius
        {

            get { return radius; }
            set 
            {
                diameter = radius / 2;
                radius = value;
                OnPropertyChanged("Radius");
                OnPropertyChanged("Diameter");
            }
        }

        private int diameter;

        public int Diameter
        {
            get { return diameter; }
            set 
            {
                diameter = radius * 2;
                diameter = value;
                OnPropertyChanged("Diameter");
                OnPropertyChanged("Radius");
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
