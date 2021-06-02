using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ApiPruebaTecnica.Modelo
{
    public class SampleService : SampleModel
    {
        public string Test(string s)
        {
            Console.WriteLine("Test Method Executed!");
            return s;
        }
        public void XmlMethod(XElement xml)
        {
            Console.WriteLine(xml.ToString());
        }
        public CustomModel TestCustomModel(CustomModel customModel)
        {
            return customModel;
        }
    }
}
