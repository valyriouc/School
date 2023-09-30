using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenTaskFive
{
    internal class Invoice
    {
        private Customer customer;
        List<Article> articlelist = new List<Article>();
        public Invoice(Customer p_customer)
        {
            this.customer = p_customer;
        }

        public double GetTotal_amount()
        {
            double total = 0.0;
            foreach (Article a in this.articlelist)
            {
                total += a.GetPrice();
            }
            return total;
        }
        public void SetArticle(Article article)
        {
            articlelist.Add(article);
        }
        public void Print()
        {
            //Ausgabe Kundendaten
            Console.WriteLine("Invoice: ");
            Console.WriteLine("Customer ID: " + customer.GetCustomerID());
            Console.WriteLine("Name: " + customer.GetCustomerName());
            Console.WriteLine("Road: " + customer.GetCustomerRoad());
            Console.WriteLine("PLZ, City: " + customer.Getplz() + ", " + customer.GetCustomerCity());

            
            foreach (Article a in this.articlelist)
            {
                Console.WriteLine("Number: " + a.GetNumber());
                Console.WriteLine("Designation: " + a.GetDesignation());
                Console.WriteLine("Price: " + a.GetPrice());
            }
            Console.WriteLine("Total price: " + this.GetTotal_amount());
        }
    }
}