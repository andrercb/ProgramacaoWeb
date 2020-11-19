
using ProjectCRUD.Domain.Interfaces.Services;
using ProjectCRUD.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectCRUD.Web.Controllers
{
    public class UsuarioController : Controller
    {

        private readonly IUsuarioServices _usuarioServices;
        private readonly IEmpresaServices _empresaServices;
        private readonly IPerfilServices _perfilServices;

        public UsuarioController(IUsuarioServices usuarioServices, IEmpresaServices empresaServices, IPerfilServices perfilServices)
        {
            _usuarioServices = usuarioServices;
            _empresaServices = empresaServices;
            _perfilServices = perfilServices;
        }


        public ActionResult Index()
        {
            if (Login.Logado)
            {
                List<Usuario> listUsuario = _usuarioServices.ListUsuario();

                return View(listUsuario);
            }
            else
            {
                Response.Redirect("~/Home/Index");
                return View();
            }
        }

        // GET: Usuarios/Details/5
        [HttpGet]
        public ActionResult Details(int id)
        {
            if (Login.Logado)
            {

                Usuario usuario = _usuarioServices.GetUsuario(id);
                ViewBag.Empresa = _empresaServices.ListEmpresa().Where(w => w.Id == usuario.CodigoEmpresa).FirstOrDefault().Nomefantasia;
                ViewBag.Perfil = _perfilServices.ListPerfil().Where(w => w.Id == usuario.CodigoPerfil).FirstOrDefault().DescricaoPerfil;

                return View(usuario);
            }
            else
            {
                Response.Redirect("~/Home/Index");
                return View();
            }
        }

        // GET: Usuarios/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (Login.Logado)
            {

                ViewBag.ListaEmpresas = new SelectList(_empresaServices.ListEmpresa(), "Id", "Nomefantasia");
                ViewBag.ListaPerfil = new SelectList(_perfilServices.ListPerfil(), "Id", "NomePerfil");

                return View();
            }
            else
            {


                Response.Redirect("~/Home/Index");
                return View();
            }
        }

        // POST: Usuarios/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario, int ListaEmpresas, int ListaPerfil)
        {
            try
            {
                if (Login.Logado)
                {
                    if (ModelState.IsValid)
                    {
                        usuario.CodigoPerfil = ListaPerfil;
                        usuario.CodigoEmpresa = ListaEmpresas;
                        _usuarioServices.Save(usuario);

                        return RedirectToAction("Index", "Usuario");
                    }

                    ViewBag.ListaEmpresas = new SelectList(_empresaServices.ListEmpresa(), "Id", "Nomefantasia");
                    ViewBag.ListaPerfil = new SelectList(_perfilServices.ListPerfil(), "Id", "NomePerfil");
                    return View();
                }
                else
                {
                    Response.Redirect("~/Home/Index");
                    return View();
                }
            }
            catch
            {
                throw new Exception();
            }
        }

        // GET: Usuarios/Edit/5
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (Login.Logado)
            {
                Usuario usuario = _usuarioServices.GetUsuario(id);
                ViewBag.ListaEmpresas = new SelectList(_empresaServices.ListEmpresa(), "Id", "Nomefantasia", usuario.CodigoEmpresa);
                ViewBag.ListaPerfil = new SelectList(_perfilServices.ListPerfil(), "Id", "NomePerfil", usuario.CodigoPerfil);

                return View(usuario);
            }
            else
            {
                Response.Redirect("~/Home/Index");
                return View();
            }
        }

        // POST: Usuarios/Edit/5
        [HttpPost]
        public ActionResult Edit(Usuario usuario, int ListaEmpresas, int ListaPerfil)
        {
            try
            {
                if (Login.Logado)
                {
                    if (ModelState.IsValid)
                    {
                        usuario.CodigoPerfil = ListaPerfil;
                        usuario.CodigoEmpresa = ListaEmpresas;
                        _usuarioServices.Update(usuario);

                        return RedirectToAction("Index", "Usuario");
                    }

                    ViewBag.ListaEmpresas = new SelectList(_empresaServices.ListEmpresa(), "Id", "Nomefantasia", usuario.CodigoEmpresa);
                    ViewBag.ListaPerfil = new SelectList(_perfilServices.ListPerfil(), "Id", "NomePerfil", usuario.CodigoPerfil);
                    return View();
                }
                else
                {
                    Response.Redirect("~/Home/Index");
                    return View();
                }
            }
            catch (Exception exc)
            {
                throw new Exception();
            }
        }

        // GET: Usuarios/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Login.Logado)
            {
                Usuario usuario = _usuarioServices.GetUsuario(id);
                ViewBag.Empresa = _empresaServices.ListEmpresa().Where(w => w.Id == usuario.CodigoEmpresa).FirstOrDefault().Nomefantasia;
                ViewBag.Perfil = _perfilServices.ListPerfil().Where(w => w.Id == usuario.CodigoPerfil).FirstOrDefault().DescricaoPerfil;

                return View(usuario);
            }
            else
            {
                Response.Redirect("~/Home/Index");
                return View();
            }
        }

        // POST: Usuarios/Delete/5
        [HttpGet]
        public ActionResult Deletar(int id)
        {
            try
            {
                if (Login.Logado)
                {
                    _usuarioServices.Delete(id);
                    return RedirectToAction("Index", "Usuario");
                }
                else
                {
                    Response.Redirect("~/Home/Index");
                    return View();
                }
            }
            catch
            {
                throw new Exception();
            }
        }
    }
}
