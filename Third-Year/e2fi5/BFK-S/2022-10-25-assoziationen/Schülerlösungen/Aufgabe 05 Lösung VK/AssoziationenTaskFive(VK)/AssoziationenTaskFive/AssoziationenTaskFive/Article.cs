using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenTaskFive
{
    internal class Article
    {
        private int number;
        private String designation; //Bezeichnung
        protected double price; //# == protected

        public Article(int number, String designation, double price)
        {
            this.number = number;
            this.designation = designation;
            this.price = price;
        }
        public int GetNumber()
        {
            return this.number;
        }
        public string GetDesignation()
        {
            return this.designation;
        }
        public double GetPrice()
        {
            return this.price;
        }
    }
}