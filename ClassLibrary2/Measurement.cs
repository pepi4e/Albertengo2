using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Measurement
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
        public double Light { get; set; }
        public int Moisture { get; set; }

        public String getFormattedTemp()
        {
            if (Temperature > 9.9)
                return Temperature.ToString().Substring(0, 4) + " C";
            else
                return Temperature.ToString().Substring(0, 3) + " C";
        }

        public String getFormattedLight()
        {
            Light = Light * 100;

            if (Light > 9.9)
                return Light.ToString().Substring(0, 4) + " %";
            else
                return Light.ToString().Substring(0, 3) + " %";
        }

        public String getFormattedMois()
        {
            return (Moisture / 10) + " %";
        }
    }
}
