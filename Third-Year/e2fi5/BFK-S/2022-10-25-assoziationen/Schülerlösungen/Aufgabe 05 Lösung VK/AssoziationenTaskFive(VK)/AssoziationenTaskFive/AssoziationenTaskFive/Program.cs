using System;

namespace AssoziationenTaskFive
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Customer
            Customer first_customer = new Customer(1234567, "Hans Peter", "Peterweg 23", 76788, "Stadt");

            //Single license
            Single_license e1 = new Single_license(123, "Product 1", 100.00);

            //Volum license
            Volum_license v1 = new Volum_license(1, 234, "Product 2", 100.00);
            
            //Invoice (Rechnung) erzeugen
            Invoice r = new Invoice(first_customer);
            r.SetArticle(e1);
            r.SetArticle(v1);

            //Invoice (Rechnung) drucken
            r.Print();
        }
    }
}