using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace cms_admin.Models.Infraestrutura.Autenticacao
{
    public class LogadoAttribute : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(string.IsNullOrEmpty(filterContext.HttpContext.Request.Cookies["Administrador"])){

                filterContext.HttpContext.Response.Redirect("/");
                
                
                return;
            }

            base.OnActionExecuting(filterContext);

        }       

        

    }
}