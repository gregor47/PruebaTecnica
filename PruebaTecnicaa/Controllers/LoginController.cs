using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaTecnicaa.Common;
using PruebaTecnicaa.Data;
using PruebaTecnicaa.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Controllers
{
    public class LoginController : Controller
    {
        private readonly PruebaTecnicaContext _context;
        private readonly ISeguridadServices _seguridad;
        public LoginController(PruebaTecnicaContext tecnicaContext, ISeguridadServices seguridad)
        {
            _context = tecnicaContext;
            _seguridad = seguridad;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var idUser = int.Parse(HttpContext.User.FindFirst(c => c.Type == "idUser")?.Value);
                if (idUser != null)
                {
                    var Usuario = _context.Usuario.Where(a => a.UsuarioId == idUser).FirstOrDefault();
                    var perfil = _context.Perfil.Where(a => a.PerfilId == Usuario.PerfilId).FirstOrDefault();
                    HttpContext.Session.SetString("nombre", Usuario.Nombre);
                    HttpContext.Session.SetString("rol", perfil.Descripcion);
                    return RedirectToAction("Index", "Home");
                }
            }
            catch (Exception)
            {

            }
                
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(string user, string pass)
        {
            var Usuario = _context.Usuario.Where(a => a.Email == user).FirstOrDefault();
            if(Usuario != null)
            {
                if (_seguridad.VerifyPassByCrypt(pass, Usuario.Pass))
                {
                    List<Claim> userClaims = new List<Claim>();
                    userClaims.Add(new Claim("idUser", Usuario.UsuarioId.ToString()));
                    ClaimsPrincipal principal = new ClaimsPrincipal(new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme));
                    AuthenticationProperties authProperties = new AuthenticationProperties
                    {
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                        RedirectUri = "/Login/NoAutorizado"
                    };
                    await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                principal,
                                authProperties
                    );
                    var perfil = _context.Perfil.Where(a => a.PerfilId == Usuario.PerfilId).FirstOrDefault();

                    HttpContext.Session.SetString("nombre", Usuario.Nombre);
                    HttpContext.Session.SetString("rol", perfil.Descripcion);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorLogin = "Credenciales Incorrectas";
                }
            }
            else
            {
                ViewBag.ErrorLogin = "Credenciales Incorrectas";
            }
            return View();
        }
        public async Task<IActionResult> NoAutorizado()
        {
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
        

    }
}
