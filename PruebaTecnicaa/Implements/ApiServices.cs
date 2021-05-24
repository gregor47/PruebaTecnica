using Newtonsoft.Json.Linq;
using PruebaTecnicaa.Data;
using PruebaTecnicaa.Interfaces;
using PruebaTecnicaa.Models;
using PruebaTecnicaa.Models.PruebaTecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Implements
{
    public class ApiServices : IApiServices
    {
        private readonly PruebaTecnicaContext _context;
        private readonly ISeguridadServices _seguridad;
        public ApiServices(PruebaTecnicaContext pruebaTecnicaContext, ISeguridadServices seguridadServices)
        {
            _context = pruebaTecnicaContext;
            _seguridad = seguridadServices;
        }
        public List<Usuario> GetUsers()
        {
            return _context.Usuario.ToList();
        }
        public List<RadicadoExterno> GetRadicadosExternos()
        {
            return _context.RadicadoExterno.ToList();
        }
        public List<RadicadoInterno> GetRadicadosInternos()
        {
            return _context.RadicadoInterno.ToList();
        }
        public Usuario UpdateUser(Update.UpdateUser user)
        {
            var usuario = _context.Usuario.Where(a => a.UsuarioId == user.UsuarioId).FirstOrDefault();
            if(usuario != null)
            {
                usuario.Documento = user.Documento;
                usuario.Email = user.Email;
                usuario.PerfilId = user.PerfilId;
                usuario.Pass = _seguridad.GenerateHashByCrypt(user.Pass);
                usuario.Nombre = user.Nombre;
                _context.Update(usuario);
                _context.SaveChanges();
                return _context.Usuario.Where(a => a.UsuarioId == usuario.UsuarioId).FirstOrDefault();
            }
            else
            {
                return null;
            }

        }
        public RadicadoExterno UpdateRadicadosExternos(Update.UpdateRadicadoExterno radicadoExterno)
        {
            _context.Update(radicadoExterno);
            _context.SaveChanges();
            return _context.RadicadoExterno.Where(a => a.RadicadoExternoId == radicadoExterno.RadicadoExternoId).FirstOrDefault();
        }
        public RadicadoInterno UpdateRadicadosInternos(Update.UpdateRadicadoInterno radicadoInterno)
        {

            _context.Update(radicadoInterno);
            _context.SaveChanges();
            return _context.RadicadoInterno.Where(a => a.RadicadoInternoId == 1).FirstOrDefault();
        }
        public Usuario CreateUser(CreateUser user)
        {
            Usuario newUsu = new Usuario()
            {
                Documento = user.Documento,
                Email = user.Email,
                Estado = true,
                FechaCreacion = DateTime.Now,
                Nombre = user.Nombre,
                Pass = _seguridad.GenerateHashByCrypt(user.Pass),
                PerfilId = user.PerfilId,
            };
            _context.Add(newUsu);
            _context.SaveChanges();
            return _context.Usuario.Where(a => a.UsuarioId == newUsu.UsuarioId).FirstOrDefault();
        }
    }
}
