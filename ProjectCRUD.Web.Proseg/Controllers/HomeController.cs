using ProjectCRUD.Domain.Interfaces.Services;
using ProjectCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectCRUD.Web.Proseg.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUsuarioServices _usuarioServices;

        public HomeController(IUsuarioServices usuarioServices)
        {
            _usuarioServices = usuarioServices;
        }



        public ActionResult Login()
        {
            Session["Logado"] = false;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login login)
        {
            if (ModelState.IsValid)
            {
                var usuario = _usuarioServices.GetUsuarioCPF(login.CpfUsuario);
                if (usuario != null)
                {
                    if (login.SenhaUsuario.Equals(usuario.Senha))
                    {
                        Session["Logado"] = true;
                        return RedirectToAction("Index", "Usuario");
                    }
                }
                ModelState.AddModelError(string.Empty, "Seu usuário ou senha estão incorretos.");
            }

            Session["Logado"] = false;
            return View();
        }

        public ActionResult Index()
        {
            if (Session["usuarioLogadoID"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }


    }
}