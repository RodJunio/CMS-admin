using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using cms_admin.Models;
using Microsoft.AspNetCore.Http;
using cms_admin.Models.Infraestrutura.Autenticacao;
using cms_admin.Models.Infraestrutura.DataBase;

namespace cms_admin.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("/login/logar")]
        [HttpPost]
        public IActionResult Logar(string email, string senha)
        {
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                ViewBag.erro = "Digite o email e a senha";
            }
            else
            {
                var adms = new ContextCms().Administradores.Where(a => a.Email == email && a.Senha == senha).ToList();
                if (adms.Count > 0)
                {
                    this.HttpContext.Response.Cookies.Append("estoque_cms", adms.First().Id.ToString() , new CookieOptions()
                    {
                        Expires = DateTimeOffset.UtcNow.AddDays(1),
                        HttpOnly = true
                    });

                    Response.Redirect("/");
                }
                else
                {
                    ViewBag.erro = "Usuário ou senha inválido";
                }
            }
            return View("Index");
        }
    }
}
