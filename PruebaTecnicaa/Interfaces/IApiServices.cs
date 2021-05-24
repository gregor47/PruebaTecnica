using Newtonsoft.Json.Linq;
using PruebaTecnicaa.Models;
using PruebaTecnicaa.Models.PruebaTecnica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Interfaces
{
    public interface IApiServices
    {
        List<Usuario> GetUsers();
        List<RadicadoExterno> GetRadicadosExternos();
        List<RadicadoInterno> GetRadicadosInternos();
        Usuario UpdateUser(Update.UpdateUser user);
        RadicadoExterno UpdateRadicadosExternos(Update.UpdateRadicadoExterno radicadoExterno);
        RadicadoInterno UpdateRadicadosInternos(Update.UpdateRadicadoInterno radicadoInterno);
        Usuario CreateUser(CreateUser user);
    }
}
