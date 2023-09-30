using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssoziationenTaskFive
{
    internal class Customer
    {
        private  int customerID;
        private String customerName;
        private String customerRoad;
        private int plz;
        private String customerCity;
        public Customer(int customerID, String customerName, String customerRoad, int plz, String customerCity)
        {
            this.customerID = customerID;
            this.customerName = customerName;
            this.customerRoad = customerRoad;
            this.plz = plz;
            if(plz < 0 || plz > 100000)
            {
                plz = 99999;
                Console.WriteLine("plz changed to 99999. Plz wasnt between 0-100000");
            }
            this.customerCity = customerCity;
        }
        public int GetCustomerID()
        {
            return this.customerID;
        }
        public String GetCustomerName()
        {
            return this.customerName;
        }
        public String GetCustomerRoad()
        {
            return this.customerRoad;
        }
        public int Getplz() 
        {
            return this.plz;
        }
        public String GetCustomerCity()
        {
            return this.customerCity;
        }
    }
}