using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebaTecnicaa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PruebaTecnicaa.Common
{
    public class RolSession : ActionFilterAttribute
    {
        private readonly PruebaTecnicaContext _context;
        public RolSession(PruebaTecnicaContext tecnicaContext)
        {
            _context = tecnicaContext;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idUser = context.HttpContext.User.FindFirst(c => c.Type == "idUser");
            if (idUser == null)
            {
                context.Result = new RedirectResult("~/Login/NoAutorizado");
            }
            else
            {
            }
        }
    }
}
