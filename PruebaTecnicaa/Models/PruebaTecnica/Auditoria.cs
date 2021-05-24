using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Models.PruebaTecnica
{
    public class Auditoria
    {
        public int AuditoriaId { get; set; }
        public int UsuarioId { get; set; }
        public string Accion { get; set; }
        public DateTime Fecha { get; set; }
        [NotMapped]
        public string UsuarioNombre { get; set; }
    }
}
