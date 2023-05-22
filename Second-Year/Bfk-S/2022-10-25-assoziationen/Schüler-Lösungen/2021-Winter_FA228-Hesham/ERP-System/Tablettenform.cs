using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_System
{
    class Tablettenform : Medikamentenform
    {
        private double pulverKoernungInUm;

        public Tablettenform(double gewichtInG, double laengeInMm, double breiteInMm, long id, double pulverKoernungInUm) : base(gewichtInG, laengeInMm, breiteInMm, id)
        {
            this.pulverKoernungInUm = pulverKoernungInUm;
        }

        public override string wirkstofffreisetzung()
        {
            return "Freisetzung des Wirkstoffes durch Zersetzung der Tablette.\n" +
                "Pulverkoernung in Mikrometer: " + this.pulverKoernungInUm;
        }

        public double getPulverKoernungInUm()
        {
            return pulverKoernungInUm;
        }

        public void setPulverKoernungInUm(double pulverKoernungInUm)
        {
            this.pulverKoernungInUm = pulverKoernungInUm;
        }
    }
}
