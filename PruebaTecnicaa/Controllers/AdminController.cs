using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PruebaTecnicaa.Data;
using PruebaTecnicaa.Interfaces;
using PruebaTecnicaa.Models.PruebaTecnica;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PruebaTecnicaa.Controllers
{
    public class AdminController : Controller
    {
        private readonly PruebaTecnicaContext _context;
        private readonly ISeguridadServices _seguridad;
        public AdminController(PruebaTecnicaContext pruebaTecnica, ISeguridadServices seguridad)
        {
            _context = pruebaTecnica;
            _seguridad = seguridad;
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
        public IActionResult CrearUsuario()
        {
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                if (!_seguridad.ValidarSession(idUser, "Admin/CrearUsuario"))
                    return RedirectToAction("NoAutorizado", "Home");
            }
            catch (Exception)
            {

            }

            ViewBag.Perfiles = _context.Perfil.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult CrearUsuario(string nombre, string correo, string documento, string Rol, string contra)
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            if (!_seguridad.ValidarSession(idUser, "Admin/CrearUsuario"))
                return RedirectToAction("NoAutorizado", "Home");
            RegistroAuditoria(idUser, "Crear Usuario");
            var existe = _context.Usuario.Where(a => a.Documento == documento).Any();
            if (!existe)
            {
                var usuario = new Usuario()
                {
                    Documento = documento,
                    Email = correo,
                    PerfilId = int.Parse(Rol),
                    Pass = _seguridad.GenerateHashByCrypt(contra),
                    FechaCreacion = DateTime.Now,
                    Estado = true,
                    Nombre = nombre
                };
                _context.Add(usuario);
                _context.SaveChanges();
                return RedirectToAction("Usuarios", "Admin");
            }
            else
            {
                ViewBag.Error = "Ya existe un Usuario con el documento ingresado.";
            }
            return View();
        }
        public IActionResult Usuarios()
        {
            List<Usuario> model = new List<Usuario>();
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                RegistroAuditoria(idUser, "Consulta de Usuario");
                if (!_seguridad.ValidarSession(idUser, "Admin/Usuarios"))
                    return RedirectToAction("NoAutorizado", "Home");
                model = GetUsersApi();
                if (model == null)
                    model = new List<Usuario>();

                var perfiles = _context.Perfil.ToList();
                model.ForEach(item =>
                {
                    item.tipoRol = perfiles.Where(a => a.PerfilId == item.PerfilId).FirstOrDefault().Descripcion;
                });
                return View(model);
            }
            catch (Exception)
            {
                model = new List<Usuario>();
            }

            return View(model);
        }

        public List<Usuario> GetUsersApi()
        {
            List<Usuario> usuario = new List<Usuario>();
            try
            {
                var client = new RestClient("https://apipruebatecnica.azurewebsites.net/api/Usuarios/GetUsuarios");
                client.Authenticator = new HttpBasicAuthenticator("user", "123");
                var request = new RestRequest();
                request.Method = Method.GET;
                var response = client.Get(request);
                usuario = JsonConvert.DeserializeObject<List<Usuario>>(response.Content);
            }
            catch (Exception)
            {

            }
            return usuario;
        }
        public IActionResult EditarUsuario(int id)
        {
            Usuario model = new Usuario();
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                
                if (!_seguridad.ValidarSession(idUser, "Admin/EditarUsuario"))
                    return RedirectToAction("NoAutorizado", "Home");
                ViewBag.Perfiles = _context.Perfil.ToList();
                model = _context.Usuario.Where(a => a.UsuarioId == id).FirstOrDefault();
            }
            catch (Exception)
            {
                model = new Usuario();

            }

            return View(model);
        }
        [HttpPost]
        public IActionResult EditarUsuario(int id, string nombre, string email, string documento, string Rol, string Pass)
        {
            var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
            RegistroAuditoria(idUser, "Editar Usuario");
            var usuario = _context.Usuario.Where(a => a.UsuarioId == id).FirstOrDefault();
            usuario.Documento = documento;
            usuario.Email = email;
            usuario.PerfilId = int.Parse(Rol);
            usuario.Pass = _seguridad.GenerateHashByCrypt(Pass);
            usuario.Nombre = nombre;

            _context.Update(usuario);
            _context.SaveChanges();

            return RedirectToAction("Usuarios", "Admin");
        }

        public IActionResult Auditoria()
        {
            List<Auditoria> auditoria = new List<Auditoria>();
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                if (!_seguridad.ValidarSession(idUser, "Admin/Auditoria"))
                    return RedirectToAction("NoAutorizado", "Home");
                auditoria = _context.Auditoria.ToList();
                var usuarios = _context.Usuario.ToList();
                auditoria.ForEach(item => 
                {
                    try
                    {
                        item.UsuarioNombre = usuarios.Where(a => a.UsuarioId == item.UsuarioId).FirstOrDefault().Nombre;
                    }
                    catch (Exception)
                    {

                    }
                });
            }
            catch (Exception)
            {
                auditoria = new List<Auditoria>();
            }

            return View(auditoria);
        }

    }
}
