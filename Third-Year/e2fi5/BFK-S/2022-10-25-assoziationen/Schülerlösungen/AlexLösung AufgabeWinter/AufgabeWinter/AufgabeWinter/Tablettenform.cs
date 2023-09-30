using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AufgabeWinter
{
    internal class Tablettenform : Medikamentenform
    {
        private double pulverKoernungInUm;

        public Tablettenform(double gewichtInG, double laengeInMm, double breiteInMm, long id, double pulverKoernungInUm) : base(gewichtInG, laengeInMm, breiteInMm, id)
        {
            this.pulverKoernungInUm = pulverKoernungInUm;
        }

        public override string wirkstofffreisetzung()
        {
            return "Freisetzung des Wirkstoffes durch Zersetzung der Tablette. Pulverkoernerung in Mikrometer: " + pulverKoernungInUm;
        }
    }
}
