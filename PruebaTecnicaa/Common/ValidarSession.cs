using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using PruebaTecnicaa.Data;
using System.Linq;

namespace PruebaTecnicaa.Common
{
    public class ValidarSession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var idUser = context.HttpContext.User.FindFirst(c => c.Type == "idUser");
            if (idUser == null)
            {
                context.Result = new RedirectResult("~/Login/NoAutorizado");
            }
        }
    }
}
