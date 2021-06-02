using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace ApiPruebaTecnica.Modelo
{
    [DataContract]
    public class CustomModel
    {
        [DataMember]
        public int ced { get; set; }
        [DataMember]
        public string nombre { get; set; }
    }
}
