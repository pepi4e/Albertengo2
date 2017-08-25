//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     .NET Micro Framework MFSvcUtil.Exe
//     Runtime Version:2.0.00001.0001
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Xml;
using System.Ext;
using System.Ext.Xml;
using Ws.ServiceModel;
using Ws.Services.Mtom;
using Ws.Services.Serialization;
using XmlElement = Ws.Services.Xml.WsXmlNode;
using XmlAttribute = Ws.Services.Xml.WsXmlAttribute;
using XmlConvert = Ws.Services.Serialization.WsXmlConvert;

namespace tempuri.org
{
    
    
    [DataContract(Namespace="http://tempuri.org/")]
    public class GetMeasurements
    {
    }
    
    public class GetMeasurementsDataContractSerializer : DataContractSerializer
    {
        
        public GetMeasurementsDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public GetMeasurementsDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            GetMeasurements GetMeasurementsField = null;
            if (IsParentStartElement(reader, false, true))
            {
                GetMeasurementsField = new GetMeasurements();
                reader.Read();
                reader.ReadEndElement();
            }
            return GetMeasurementsField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            GetMeasurements GetMeasurementsField = ((GetMeasurements)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [DataContract(Namespace="http://tempuri.org/")]
    public class GetMeasurementsResponse
    {
        
        [DataMember(Order=0, IsNillable=true, IsRequired=false)]
        public schemas.datacontract.org.ClassLibrary.ArrayOfMeasurement GetMeasurementsResult;
    }
    
    public class GetMeasurementsResponseDataContractSerializer : DataContractSerializer
    {
        
        public GetMeasurementsResponseDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public GetMeasurementsResponseDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            GetMeasurementsResponse GetMeasurementsResponseField = null;
            if (IsParentStartElement(reader, false, true))
            {
                GetMeasurementsResponseField = new GetMeasurementsResponse();
                reader.Read();
                schemas.datacontract.org.ClassLibrary.ArrayOfMeasurementDataContractSerializer GetMeasurementsResultDCS = new schemas.datacontract.org.ClassLibrary.ArrayOfMeasurementDataContractSerializer("GetMeasurementsResult", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                GetMeasurementsResultDCS.BodyParts = this.BodyParts;
                GetMeasurementsResponseField.GetMeasurementsResult = ((schemas.datacontract.org.ClassLibrary.ArrayOfMeasurement)(GetMeasurementsResultDCS.ReadObject(reader)));
                reader.ReadEndElement();
            }
            return GetMeasurementsResponseField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            GetMeasurementsResponse GetMeasurementsResponseField = ((GetMeasurementsResponse)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                schemas.datacontract.org.ClassLibrary.ArrayOfMeasurementDataContractSerializer GetMeasurementsResultDCS = new schemas.datacontract.org.ClassLibrary.ArrayOfMeasurementDataContractSerializer("GetMeasurementsResult", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                GetMeasurementsResultDCS.BodyParts = this.BodyParts;
                GetMeasurementsResultDCS.WriteObject(writer, GetMeasurementsResponseField.GetMeasurementsResult);
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [DataContract(Namespace="http://tempuri.org/")]
    public class CreateMeasurement
    {
        
        [DataMember(Order=0, IsNillable=true, IsRequired=false)]
        public schemas.datacontract.org.SGService.MeasurementContract m;
    }
    
    public class CreateMeasurementDataContractSerializer : DataContractSerializer
    {
        
        public CreateMeasurementDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public CreateMeasurementDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            CreateMeasurement CreateMeasurementField = null;
            if (IsParentStartElement(reader, false, true))
            {
                CreateMeasurementField = new CreateMeasurement();
                reader.Read();
                schemas.datacontract.org.SGService.MeasurementContractDataContractSerializer mDCS = new schemas.datacontract.org.SGService.MeasurementContractDataContractSerializer("m", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/SGService");
                mDCS.BodyParts = this.BodyParts;
                CreateMeasurementField.m = ((schemas.datacontract.org.SGService.MeasurementContract)(mDCS.ReadObject(reader)));
                reader.ReadEndElement();
            }
            return CreateMeasurementField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            CreateMeasurement CreateMeasurementField = ((CreateMeasurement)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                schemas.datacontract.org.SGService.MeasurementContractDataContractSerializer mDCS = new schemas.datacontract.org.SGService.MeasurementContractDataContractSerializer("m", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/SGService");
                mDCS.BodyParts = this.BodyParts;
                mDCS.WriteObject(writer, CreateMeasurementField.m);
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [DataContract(Namespace="http://tempuri.org/")]
    public class CreateMeasurementResponse
    {
        
        [DataMember(Order=0, IsNillable=true, IsRequired=false)]
        public schemas.datacontract.org.ClassLibrary.Measurement CreateMeasurementResult;
    }
    
    public class CreateMeasurementResponseDataContractSerializer : DataContractSerializer
    {
        
        public CreateMeasurementResponseDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public CreateMeasurementResponseDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            CreateMeasurementResponse CreateMeasurementResponseField = null;
            if (IsParentStartElement(reader, false, true))
            {
                CreateMeasurementResponseField = new CreateMeasurementResponse();
                reader.Read();
                schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer CreateMeasurementResultDCS = new schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer("CreateMeasurementResult", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                CreateMeasurementResultDCS.BodyParts = this.BodyParts;
                CreateMeasurementResponseField.CreateMeasurementResult = ((schemas.datacontract.org.ClassLibrary.Measurement)(CreateMeasurementResultDCS.ReadObject(reader)));
                reader.ReadEndElement();
            }
            return CreateMeasurementResponseField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            CreateMeasurementResponse CreateMeasurementResponseField = ((CreateMeasurementResponse)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer CreateMeasurementResultDCS = new schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer("CreateMeasurementResult", "http://tempuri.org/", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                CreateMeasurementResultDCS.BodyParts = this.BodyParts;
                CreateMeasurementResultDCS.WriteObject(writer, CreateMeasurementResponseField.CreateMeasurementResult);
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [ServiceContract(Namespace="http://tempuri.org/")]
    public interface IISmartService
    {
        
        [OperationContract(Action="http://tempuri.org/ISmartService/GetMeasurements")]
        GetMeasurementsResponse GetMeasurements(GetMeasurements req);
        
        [OperationContract(Action="http://tempuri.org/ISmartService/CreateMeasurement")]
        CreateMeasurementResponse CreateMeasurement(CreateMeasurement req);
    }
}
namespace schemas.datacontract.org.ClassLibrary
{
    
    
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ClassLibrary3")]
    public class Measurement
    {
        
        [DataMember(Order=0, IsRequired=false)]
        public double Light;
        
        [DataMember(Order=1, IsRequired=false)]
        public int Moisture;
        
        [DataMember(Order=2, IsRequired=false)]
        public double Temperature;
        
        [DataMember(Order=3, IsRequired=false)]
        public System.DateTime Time;
    }
    
    public class MeasurementDataContractSerializer : DataContractSerializer
    {
        
        public MeasurementDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public MeasurementDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            Measurement MeasurementField = null;
            if (IsParentStartElement(reader, false, true))
            {
                MeasurementField = new Measurement();
                reader.Read();
                if (IsChildStartElement(reader, "Light", false, false))
                {
                    reader.Read();
                    MeasurementField.Light = XmlConvert.ToDouble(reader.ReadString());
                    reader.ReadEndElement();
                }
                if (IsChildStartElement(reader, "Moisture", false, false))
                {
                    reader.Read();
                    MeasurementField.Moisture = XmlConvert.ToInt32(reader.ReadString());
                    reader.ReadEndElement();
                }
                if (IsChildStartElement(reader, "Temperature", false, false))
                {
                    reader.Read();
                    MeasurementField.Temperature = XmlConvert.ToDouble(reader.ReadString());
                    reader.ReadEndElement();
                }
                if (IsChildStartElement(reader, "Time", false, false))
                {
                    reader.Read();
                    MeasurementField.Time = XmlConvert.ToDateTime(reader.ReadString());
                    reader.ReadEndElement();
                }
                reader.ReadEndElement();
            }
            return MeasurementField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            Measurement MeasurementField = ((Measurement)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                if (WriteChildElement(writer, "Light", false, false, MeasurementField.Light))
                {
                    writer.WriteString(XmlConvert.ToString(MeasurementField.Light));
                    writer.WriteEndElement();
                }
                if (WriteChildElement(writer, "Moisture", false, false, MeasurementField.Moisture))
                {
                    writer.WriteString(XmlConvert.ToString(MeasurementField.Moisture));
                    writer.WriteEndElement();
                }
                if (WriteChildElement(writer, "Temperature", false, false, MeasurementField.Temperature))
                {
                    writer.WriteString(XmlConvert.ToString(MeasurementField.Temperature));
                    writer.WriteEndElement();
                }
                if (WriteChildElement(writer, "Time", false, false, MeasurementField.Time))
                {
                    writer.WriteString(XmlConvert.ToString(MeasurementField.Time));
                    writer.WriteEndElement();
                }
                writer.WriteEndElement();
            }
            return;
        }
    }
    
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/ClassLibrary3")]
    public class ArrayOfMeasurement
    {
        
        [DataMember(Order=0, IsNillable=true, IsRequired=false)]
        public Measurement[] Measurement;
    }
    
    public class ArrayOfMeasurementDataContractSerializer : DataContractSerializer
    {
        
        public ArrayOfMeasurementDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public ArrayOfMeasurementDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            ArrayOfMeasurement ArrayOfMeasurementField = null;
            if (IsParentStartElement(reader, false, true))
            {
                ArrayOfMeasurementField = new ArrayOfMeasurement();
                reader.Read();
                MeasurementDataContractSerializer MeasurementDCS = new MeasurementDataContractSerializer("Measurement", "http://schemas.datacontract.org/2004/07/ClassLibrary3", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                System.Collections.ArrayList Measurement_List = new System.Collections.ArrayList();
                for (int i = 0; (i > -1); i = (i + 1))
                {
                    if (!IsChildStartElement(reader, "Measurement", false, false))
                    {
                        ArrayOfMeasurementField.Measurement = new Measurement[Measurement_List.Count];
                        Measurement_List.CopyTo(ArrayOfMeasurementField.Measurement);
						break;
                    }
                    Measurement_List.Add(((Measurement)(MeasurementDCS.ReadObject(reader))));
                }
                reader.ReadEndElement();
            }
            return ArrayOfMeasurementField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            ArrayOfMeasurement ArrayOfMeasurementField = ((ArrayOfMeasurement)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                MeasurementDataContractSerializer MeasurementDCS = new MeasurementDataContractSerializer("Measurement", "http://schemas.datacontract.org/2004/07/ClassLibrary3", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                for (int i = 0; (i < ArrayOfMeasurementField.Measurement.Length); i = (i + 1))
                {
                    MeasurementDCS.WriteObject(writer, ArrayOfMeasurementField.Measurement[i]);
                }
                writer.WriteEndElement();
            }
            return;
        }
    }
}
namespace schemas.datacontract.org.SGService
{
    
    
    [DataContract(Namespace="http://schemas.datacontract.org/2004/07/SGService")]
    public class MeasurementContract
    {
        
        [DataMember(Order=0, IsNillable=true, IsRequired=false)]
        public schemas.datacontract.org.ClassLibrary.Measurement measurement;
    }
    
    public class MeasurementContractDataContractSerializer : DataContractSerializer
    {
        
        public MeasurementContractDataContractSerializer(string rootName, string rootNameSpace) : 
                base(rootName, rootNameSpace)
        {
        }
        
        public MeasurementContractDataContractSerializer(string rootName, string rootNameSpace, string localNameSpace) : 
                base(rootName, rootNameSpace, localNameSpace)
        {
        }
        
        public override object ReadObject(XmlReader reader)
        {
            MeasurementContract MeasurementContractField = null;
            if (IsParentStartElement(reader, false, true))
            {
                MeasurementContractField = new MeasurementContract();
                reader.Read();
                schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer measurementDCS = new schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer("measurement", "http://schemas.datacontract.org/2004/07/SGService", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                measurementDCS.BodyParts = this.BodyParts;
                MeasurementContractField.measurement = ((schemas.datacontract.org.ClassLibrary.Measurement)(measurementDCS.ReadObject(reader)));
                reader.ReadEndElement();
            }
            return MeasurementContractField;
        }
        
        public override void WriteObject(XmlWriter writer, object graph)
        {
            MeasurementContract MeasurementContractField = ((MeasurementContract)(graph));
            if (WriteParentElement(writer, true, true, graph))
            {
                schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer measurementDCS = new schemas.datacontract.org.ClassLibrary.MeasurementDataContractSerializer("measurement", "http://schemas.datacontract.org/2004/07/SGService", "http://schemas.datacontract.org/2004/07/ClassLibrary3");
                measurementDCS.BodyParts = this.BodyParts;
                measurementDCS.WriteObject(writer, MeasurementContractField.measurement);
                writer.WriteEndElement();
            }
            return;
        }
    }
}
