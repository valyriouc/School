using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    //------------------------------------------------------------------------------------------------
    //Dies ist nur zur Übung. Diese Klasse muss aber laut Aufgabenstellung nicht implementiert werden!
    //------------------------------------------------------------------------------------------------
    class Kapselform : Medikamentenform
    {
        private double gelMengeInG;

        public Kapselform(double gewichtInG, double laengeInMm, double breiteInMm, long id, double gelMengeInG) : base(gewichtInG, laengeInMm, breiteInMm, id)
        {
            this.gelMengeInG = gelMengeInG;
        }

        public override string wirkstofffreisetzung()
        {
            return "";
        }
    }
}
