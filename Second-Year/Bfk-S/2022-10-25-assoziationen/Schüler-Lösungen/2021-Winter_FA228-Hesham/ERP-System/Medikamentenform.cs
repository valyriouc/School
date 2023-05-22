using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    abstract class Medikamentenform
    {
        private double gewichtInG;
        private double laengeInMm;
        private double breiteInMm;
        private long id;

        public Medikamentenform(double gewichtInG, double laengeInMm, double breiteInMm,long id)
        {
            this.gewichtInG = gewichtInG;
            this.laengeInMm = laengeInMm;
            this.breiteInMm = breiteInMm;
            this.id = id;
        }

        public abstract string wirkstofffreisetzung();
    }
}
