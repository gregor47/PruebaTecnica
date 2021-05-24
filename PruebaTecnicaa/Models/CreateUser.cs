using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Models
{
    public class CreateUser
    {
        public int PerfilId { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
    }
}
