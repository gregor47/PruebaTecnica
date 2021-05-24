using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PruebaTecnicaa.Common;
using PruebaTecnicaa.Data;
using PruebaTecnicaa.Interfaces;
using PruebaTecnicaa.Models;
using PruebaTecnicaa.Models.PruebaTecnica;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PruebaTecnicaa.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PruebaTecnicaContext _context;
        private readonly ISeguridadServices _seguridad;
        private readonly IHostingEnvironment _env;
        private readonly IClienteServices _cliente;

        public HomeController(ILogger<HomeController> logger, PruebaTecnicaContext context, ISeguridadServices seguridad, IHostingEnvironment hosting, IClienteServices clienteServices)
        {
            _logger = logger;
            _context = context;
            _seguridad = seguridad;
            _env = hosting;
            _cliente = clienteServices;
        }
        [ValidarSession]
        public IActionResult Index()
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            if (!_seguridad.ValidarSession(idUser, "Home/Index"))
                return RedirectToAction("NoAutorizado", "Home");


            return RedirectToAction("Consultas","Home");
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult NoAutorizado()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Consultas()
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            if (!_seguridad.ValidarSession(idUser, "Home/Consultas"))
                return RedirectToAction("NoAutorizado", "Home");
            RegistroAuditoria(idUser, "Consultar Radicados");
            var estados = _context.Estado.ToList();
            var intdet = _context.RadicadoInternoDet.Where(a => a.UsuarioCreacion == idUser || a.UsuarioDestino == idUser).OrderByDescending(a => a.RadicadoInternoDetId).Distinct().Select(a => a.NumeroRadicado).ToList();
            var extdet = _context.RadicadoExternoDet.Where(a => a.UsuarioCreacion == idUser || a.UsuarioDestino == idUser).OrderByDescending(a => a.RadicadoExternoDetId).Distinct().Select(a => a.NumeroRadicado).ToList();
            var internas = _context.RadicadoInterno.Where(a => intdet.Contains(a.NumeroRadicado)).OrderByDescending(a => a.RadicadoInternoId).Distinct().ToList();
            internas.ForEach(item => 
            {
                item.DescripcionEstado = estados.Where(a => a.EstadoId == item.Estado).FirstOrDefault().Descripcion;
            });
            var externas = _context.RadicadoExterno.Where(a => extdet.Contains(a.NumeroRadicado)).OrderByDescending(a => a.RadicadoExternoId).Distinct().ToList();
            externas.ForEach(item =>
            {
                item.DescripcionEstado = estados.Where(a => a.EstadoId == item.Estado).FirstOrDefault().Descripcion;
            });

            ViewBag.Internas = internas;
            ViewBag.Externas = externas;
            return View();
        }

        private void RegistroAuditoria(int idUser, string v)
        {
            Auditoria au = new Auditoria()
            {
                Accion = v,
                UsuarioId = idUser,
                Fecha = DateTime.Now
            };
            _context.Add(au);
            _context.SaveChanges();
        }

        public IActionResult CrearRadicado()
        {
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                if (!_seguridad.ValidarSession(idUser, "Home/CrearRadicado"))
                    return RedirectToAction("NoAutorizado", "Home");
            }
            catch (Exception)
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult CrearRadicado(string asunto, string Nombre, string Documento, string correo, string Radicado, IFormFile file)
        {
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                if (!_seguridad.ValidarSession(idUser, "Home/CrearRadicado"))
                    return RedirectToAction("NoAutorizado", "Home");
                RegistroAuditoria(idUser, "Crear Radicado");
                string id = string.Empty;
                string extension = Path.GetExtension(file.FileName);
                if (Radicado.Equals("1"))
                {
                    var idRadi = _context.RadicadoInterno.Max(a => a.RadicadoInternoId);
                    if (idRadi != null || idRadi != 0)
                    {
                        var ultimoid = (idRadi + 1).ToString();
                        id = "CI" + ultimoid.PadLeft(8, '0');
                    }
                    else
                    {
                        id = "CI" + "1".PadLeft(8, '0');
                    }
                    using (var fileStream = new FileStream(
                        Path.Combine(_env.WebRootPath + "/CargueArchivos", id + extension),
                        FileMode.Create,
                        FileAccess.Write))
                    {
                        file.CopyTo(fileStream);

                        var Interno = new RadicadoInterno()
                        {
                            EmailRemitente = correo,
                            Asunto = asunto,
                            DocumentoRemitente = Documento,
                            FechaCreacion = DateTime.Now,
                            NombreRemitente = Nombre,
                            UsuarioCreacion = idUser,
                            Adjunto = id + extension,
                            NumeroRadicado = id,
                            Estado = 1
                        };

                        _context.Add(Interno);
                        InsertInternoDet(Interno);
                        _context.SaveChanges();
                    }
                }
                else
                {
                    var idRadi = _context.RadicadoExterno.Max(a => a.RadicadoExternoId);
                    if (idRadi != null || idRadi != 0)
                    {
                        var ultimoid = (idRadi + 1).ToString();
                        id = "CE" + ultimoid.PadLeft(8, '0');
                    }
                    else
                    {
                        id = "CE" + "1".PadLeft(8, '0');
                    }
                    using (var fileStream = new FileStream(
                        Path.Combine(_env.WebRootPath + "/CargueArchivos", id + extension),
                        FileMode.Create,
                        FileAccess.Write))
                    {
                        file.CopyTo(fileStream);

                        var Interno = new RadicadoExterno()
                        {
                            EmailRemitente = correo,
                            Asunto = asunto,
                            DocumentoRemitente = Documento,
                            FechaCreacion = DateTime.Now,
                            NombreRemitente = Nombre,
                            UsuarioCreacion = idUser,
                            Adjunto = id + extension,
                            NumeroRadicado = id,
                            Estado = 1
                        };
                        _context.Add(Interno);
                        InsertExternoDet(Interno);
                        _context.SaveChanges();
                    }
                }
                ViewBag.Result = "Exitoso, su numero de radicado es: " + id;
            }
            catch (Exception)
            {

            }
            return View();
        }

        private void InsertInternoDet(RadicadoInterno interno, int usuarioDest = -1)
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            RadicadoInternoDet det = new RadicadoInternoDet()
            {
                Adjunto = interno.Adjunto,
                UsuarioDestino = usuarioDest,
                Asunto = interno.Asunto,
                DocumentoRemitente = interno.DocumentoRemitente,
                EmailRemitente = interno.EmailRemitente,
                Estado = interno.Estado,
                FechaCreacion = DateTime.Now,
                NombreRemitente = interno.NombreRemitente,
                NumeroRadicado = interno.NumeroRadicado,
                UsuarioCreacion = idUser,
            };
            _context.Add(det);
        }

        private void InsertExternoDet(RadicadoExterno externo, int usuarioDest = -1)
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            RadicadoExternoDet det = new RadicadoExternoDet()
            {
                Adjunto = externo.Adjunto,
                UsuarioDestino = usuarioDest,
                Asunto = externo.Asunto,
                DocumentoRemitente = externo.DocumentoRemitente,
                EmailRemitente = externo.EmailRemitente,
                Estado = externo.Estado,
                FechaCreacion = DateTime.Now,
                NombreRemitente = externo.NombreRemitente,
                NumeroRadicado = externo.NumeroRadicado,
                UsuarioCreacion = idUser,
            };
            _context.Add(det);
        }

        public IActionResult Detalle(string radicado, int opc)
        {
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                RegistroAuditoria(idUser, "Consulta Detalle Radicado");
                var user = _context.Usuario.Where(a => a.UsuarioId == idUser).FirstOrDefault();
                if(user != null)
                {
                    ViewBag.Rol = user.PerfilId.ToString();
                }
                var estados = _context.Estado.ToList();
                var usuarios = _context.Usuario.ToList();
                if (opc == 1)
                {
                    var model = _context.RadicadoInterno.Where(a => a.NumeroRadicado == radicado).FirstOrDefault();
                    var hist = _context.RadicadoInternoDet.Where(a => a.NumeroRadicado == model.NumeroRadicado).ToList();
                    foreach (var item in hist)
                    {
                        item.DescripcionEstado = estados.Where(a => a.EstadoId == item.Estado).FirstOrDefault().Descripcion;
                        item.NombreUsuario = usuarios.Where(a => a.UsuarioId == item.UsuarioCreacion).FirstOrDefault().Nombre;
                    }
                    model.DescripcionEstado = estados.Where(a => a.EstadoId == model.Estado).FirstOrDefault().Descripcion;
                    ViewBag.Externo = null;
                    ViewBag.Interno = model;
                    ViewBag.Historial = hist;
                }
                else
                {
                    var model = _context.RadicadoExterno.Where(a => a.NumeroRadicado == radicado).FirstOrDefault();
                    var hist = _context.RadicadoExternoDet.Where(a => a.NumeroRadicado == model.NumeroRadicado).ToList();
                    foreach (var item in hist)
                    {
                        item.DescripcionEstado = estados.Where(a => a.EstadoId == item.Estado).FirstOrDefault().Descripcion;
                        item.NombreUsuario = usuarios.Where(a => a.UsuarioId == item.UsuarioCreacion).FirstOrDefault().Nombre;
                    }
                    model.DescripcionEstado = estados.Where(a => a.EstadoId == model.Estado).FirstOrDefault().Descripcion;
                    ViewBag.Interno = null;
                    ViewBag.Externo = model;
                    ViewBag.Historial = hist;
                }
                ViewBag.Usuarios = usuarios;
                ViewBag.Estados = estados;
            }
            catch (Exception)
            {

            }
            return View();
        }
        [HttpPost]
        public IActionResult Detalle(string Radicado, string Usuario, string Estado)
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            int opc = 0;
            var interno = _context.RadicadoInterno.Where(a => a.NumeroRadicado == Radicado).FirstOrDefault();
            if(interno != null)
            {
                opc = 1;
                interno.Estado = int.Parse(Estado);
                _context.Update(interno);
                InsertInternoDet(interno, int.Parse(Usuario));
                _context.SaveChanges();
            }
            else
            {
                var externo = _context.RadicadoExterno.Where(a => a.NumeroRadicado == Radicado).FirstOrDefault();
                if(externo != null)
                {
                    opc = 2;
                    externo.Estado = int.Parse(Estado);
                    _context.Update(externo);
                    InsertExternoDet(externo, int.Parse(Usuario));
                    _context.SaveChanges();
                }
            }
            return RedirectToAction("Detalle","Home", new { radicado = Radicado, opc = opc });
        }
    }
}
