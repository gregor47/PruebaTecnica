using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace ApiPruebaTecnica.Modelo
{
    [ServiceContract]
    public interface SampleModel
    {
        [OperationContract]
        string Test(string s);
        [OperationContract]
        void XmlMethod(System.Xml.Linq.XElement xml);
        [OperationContract]
        CustomModel TestCustomModel(CustomModel inputModel);
    }
}
