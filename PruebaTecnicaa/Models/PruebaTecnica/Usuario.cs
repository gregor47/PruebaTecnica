using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Models.PruebaTecnica
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public int PerfilId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Email { get; set; }
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Pass { get; set; }
        public bool Estado { get; set; }
        [NotMapped]
        public string tipoRol { get; set; }
    }
}
