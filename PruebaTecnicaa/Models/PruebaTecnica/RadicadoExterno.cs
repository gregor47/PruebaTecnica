using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Models.PruebaTecnica
{
    public class RadicadoExterno
    {
        public int RadicadoExternoId { get; set; }
        public string Asunto { get; set; }
        public string Adjunto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacion { get; set; }
        public int Estado { get; set; }
        public string NumeroRadicado { get; set; }
        public string EmailRemitente { get; set; }
        public string DocumentoRemitente { get; set; }
        public string NombreRemitente { get; set; }
        [NotMapped]
        public string DescripcionEstado { get; set; }

    }
}
