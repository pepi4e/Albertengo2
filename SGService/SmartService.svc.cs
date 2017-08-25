using ClassLibrary3;
using SGService.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace SGService
{
    public class SmartService : ISmartService
    {
        MeasurementsController controller = new MeasurementsController();

        public List<Measurement> GetMeasurements()
        {
            return controller.GetMeasurements().ToList();
        }

        public Measurement CreateMeasurement(string temperature, string light, string moisture)
        {
            Measurement m = new Measurement();
            m.Light = Double.Parse(light);
            m.Moisture = Int32.Parse(moisture);
            m.Time = DateTime.Now;
            m.Temperature = double.Parse(temperature);

            controller.PostMeasurement(m);
            return m;
        }

    }
}
