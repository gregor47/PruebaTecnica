using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Models
{
    public class Update
    {
        public class UpdateRadicadoExterno
        {
            public int RadicadoExternoId { get; set; }
            public string Asunto { get; set; }
            public string Adjunto { get; set; }
            public string NumeroRadicado { get; set; }
            public string EmailRemitente { get; set; }
            public string DocumentoRemitente { get; set; }
            public string NombreRemitente { get; set; }
        }
        public class UpdateRadicadoInterno
        {
            public int RadicadoExternoId { get; set; }
            public string Asunto { get; set; }
            public string Adjunto { get; set; }
            public string NumeroRadicado { get; set; }
            public string EmailRemitente { get; set; }
            public string DocumentoRemitente { get; set; }
            public string NombreRemitente { get; set; }
        }
        public class UpdateUser
        {
            public int UsuarioId { get; set; }
            public int PerfilId { get; set; }
            public string Email { get; set; }
            public string Documento { get; set; }
            public string Nombre { get; set; }
            public string Pass { get; set; }
        }
    }
}
