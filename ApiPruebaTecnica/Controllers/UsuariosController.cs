using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaa.Interfaces;
using PruebaTecnicaa.Models;
using PruebaTecnicaa.Models.PruebaTecnica;
using System.Collections.Generic;

namespace ApiPruebaTecnica.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IApiServices _api;

        public UsuariosController(IApiServices apiServices)
        {
            _api = apiServices;
        }

        [HttpGet]
        [Route("GetUsuarios")]
        public IEnumerable<Usuario> Usuarios()
        {
            return _api.GetUsers();
        }
        [HttpGet]
        [Route("GetRadicadosInternos")]
        public IEnumerable<RadicadoInterno> RadicadosInternos()
        {
            return _api.GetRadicadosInternos();
        }
        [HttpGet]
        [Route("GetRadicadosExternos")]
        public IEnumerable<RadicadoExterno> RadicadosExternos()
        {
            return _api.GetRadicadosExternos();
        }
        [HttpPost]
        [Route("UpdateUsuarios")]
        public Usuario UpdUsuarios(Update.UpdateUser usuario)
        {
            return _api.UpdateUser(usuario);
        }
        //[HttpPost]
        //[Route("UpdateRadicadoInterno")]
        //public RadicadoInterno UpdRadicadosInternos(Update.UpdateRadicadoInterno radicadoInterno)
        //{
        //    return _api.UpdateRadicadosInternos(radicadoInterno);
        //}
        //[HttpPost]
        //[Route("UpdateRadicadoExterno")]
        //public RadicadoExterno UpdRadicadosExternos(Update.UpdateRadicadoExterno radicadoExterno)
        //{
        //    return _api.UpdateRadicadosExternos(radicadoExterno);
        //}
        [HttpPost]
        [Route("CreateUsuarios")]
        public Usuario CreatUsuarios(CreateUser usuario)
        {
            return _api.CreateUser(usuario);
        }
    }
}
