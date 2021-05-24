using PruebaTecnicaa.Data;
using PruebaTecnicaa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Implements
{
    public class SeguridadServices : ISeguridadServices
    {
        private readonly PruebaTecnicaContext _context;
        public SeguridadServices(PruebaTecnicaContext pruebaTecnicaContext)
        {
            _context = pruebaTecnicaContext;
        }
        public bool VerifyPassByCrypt(string passDigitado, string storedHash)
        {
            return BCrypt.Net.BCrypt.Verify(passDigitado, storedHash);
        }


        public string GenerateHashByCrypt(string data)
        {
            return BCrypt.Net.BCrypt.HashPassword(data); ;
        }
        public bool ValidarSession(int idUser ,string vista)
        {
            var usuario = _context.Usuario.Where(a => a.UsuarioId == idUser && a.Estado).FirstOrDefault();
            return _context.Pagina.Where(a => a.Ruta == vista && a.Roles.Contains(usuario.PerfilId.ToString())).Any();
        }
    }
}
