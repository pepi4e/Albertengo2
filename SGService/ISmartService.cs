
using ClassLibrary3;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SGService
{
    [ServiceContract]
    public interface ISmartService
    {
        [OperationContract]
        [WebGet(UriTemplate = "/Measurements")]
        List<Measurement> GetMeasurements();

        [OperationContract]
        [WebInvoke(Method = "POST",
                   UriTemplate = "/Measurements/Create/{temperature}/{light}/{moisture}/")]
        Measurement CreateMeasurement(string temperature, string light, string moisture);

        [OperationContract]
        [WebInvoke(Method = "GET",
                   UriTemplate = "/Time/",
                   ResponseFormat = WebMessageFormat.Json)]
        string GetTime();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class MeasurementContract
    {
        [DataMember(IsRequired=true)]
        public double temperature;
        [DataMember(IsRequired = true)]
        public double light;
        [DataMember(IsRequired = true)]
        public int moisture;
    }

}
